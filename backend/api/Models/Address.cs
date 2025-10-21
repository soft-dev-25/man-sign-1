using System.Text.RegularExpressions;

namespace api.Models
{
    // link to information about danish address formats: https://danmarksadresser.dk/om-adresser/saadan-gengives-en-adresse

    public class Address
    {
        //  private static readonly Random random = new Random();
        public string? Street { get; set; }
        public string? Number { get; set; }
        public int? Floor { get; set; }
        public string? Door { get; set; }
        public string? PostalCode { get; set; }
        public string? TownName { get; set; }
        public FloorType FloorType { private get; set; } = FloorType.None;

        public void ValidateStreet()
        {
            if (string.IsNullOrWhiteSpace(Street) || string.IsNullOrEmpty(Street))
            {
                throw new ArgumentNullException(
                    nameof(Street),
                    $"Street {Street} must be provided"
                );
            }

            if (!Street.All(char.IsLetter))
            {
                throw new ArgumentException(
                    $"Street {Street} must only contain letters",
                    nameof(Street)
                );
            }
        }

        public void ValidateNumber()
        {
            if (string.IsNullOrWhiteSpace(Number) || string.IsNullOrEmpty(Number))
            {
                throw new ArgumentNullException(
                    nameof(Number),
                    $"Number {Number} must be provided"
                );
            }

            if (
                !Regex.IsMatch(
                    Number,
                    @"^[1-9][0-9]{0,2}[A-Z]?$",
                    RegexOptions.None,
                    TimeSpan.FromMilliseconds(200)
                )
            )
            {
                throw new ArgumentException(
                    $"Invalid number format: '{Number}'. It must be 1 to 3 digits (not starting with 0), optionally followed by a single uppercase letter. Examples: '7', '42B', '123'."
                );
            }
        }

        public void ValidateFloor()
        {
            if (FloorType.Equals(FloorType.St))
            {
                if (Floor is not null)
                    throw new ArgumentException(
                        "Cannot set both FloorType as 'st' and FloorNumber."
                    );
                return;
            }

            switch (Floor)
            {
                case null:
                    throw new ArgumentNullException(
                        nameof(Floor),
                        "Either FloorType must be 'st' or FloorNumber must be set."
                    );
                case < 1:
                case > 99:
                    throw new ArgumentOutOfRangeException(
                        nameof(Floor),
                        "FloorNumber must be between 1 and 99."
                    );
            }

            //NOTE: During White box testing we found that this check is not needed.

            //if (FloorType != FloorType.None)
            //    throw new ArgumentException("FloorType must be None when FloorNumber is set.");
        }

        public void ValidateDoor()
        {
            if (string.IsNullOrWhiteSpace(Door) || string.IsNullOrEmpty(Door))
                throw new ArgumentNullException(nameof(Door), "Door must be provided.");

            // Setups to validate the door:

            // 1. Check for "th", "mf", "tv" (case-insensitive)
            if (
                Regex.IsMatch(
                    Door,
                    @"^(th|mf|tv)$",
                    RegexOptions.IgnoreCase,
                    TimeSpan.FromMilliseconds(200)
                )
            )
                return;

            // 2. Check for digits only (door number)
            if (Regex.IsMatch(Door, @"^\d+$", RegexOptions.None, TimeSpan.FromMilliseconds(200)))
            {
                if (!int.TryParse(Door, out int doorNumber) || doorNumber < 1 || doorNumber > 50)
                    throw new ArgumentException(
                        "Door number must be an integer between 1 and 50.",
                        nameof(Door)
                    );
                return;
            }

            // 3. Check for letter(-)digits format (e.g., A-1, B12, C-123)
            if (
                Regex.IsMatch(
                    Door,
                    @"^[a-zA-ZæÆøØåÅ](-)?\d{1,3}$",
                    RegexOptions.IgnoreCase,
                    TimeSpan.FromMilliseconds(200)
                )
            )
                return;

            // 4. If none of the above, throw a format exception
            throw new ArgumentException(
                $"Door {Door} must be either 'th', 'mf', 'tv', a number between 1 and 50, or a valid door format like 'A-1', 'B12', 'C-123', etc.",
                nameof(Door)
            );
        }

        #region Function - return a fake address
        private static int GenerateRandomNumber(int x, int y)
        {
            // Generates a random integer between x and y
            return Random.Shared.Next(x, y);
        }

        private static Random GetRandomShared()
        {
            return Random.Shared;
        }

        public static Address GenerateFakeAddress()
        {
            // Generate a random street name (5-12 characters, includes Danish letters)
            string street = GetRandomText(GenerateRandomNumber(5, 13), true);

            // Generate a random number (1-3 digits, optionally with uppercase or Danish letter)
            int numberPart = GenerateRandomNumber(1, 1000);
            string number = numberPart.ToString();
            if (GetRandomShared().NextDouble() < 0.3) // 30% chance to add a letter
            {
                string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅ";
                number += letters[GetRandomShared().Next(letters.Length)];
            }

            // Generate a random floor (null or 1-10) with 70% chance of being null and if null return FloorType = "st"
            int? floor =
                GetRandomShared().NextDouble() < 0.3 ? GetRandomShared().Next(1, 11) : null;

            // Generate a random door (valid formats)
            string[] doorOptions = ["th", "mf", "tv"];
            string door;
            int doorType = GetRandomShared().Next(3);
            switch (doorType)
            {
                case 0:
                    door = doorOptions[GetRandomShared().Next(doorOptions.Length)];
                    break;
                case 1:
                    door = GetRandomShared().Next(1, 51).ToString();
                    break;
                default:
                {
                    // Letter (upper/lower/Danish), optional dash, 1-3 digits
                    const string letters =
                        "abcdefghijklmnopqrstuvwxyzæøåABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅ";
                    char letter = letters[GetRandomShared().Next(letters.Length)];
                    string dash = GetRandomShared().NextDouble() < 0.5 ? "-" : "";
                    int digits = GetRandomShared().Next(1, 1000);
                    door = $"{letter}{dash}{digits}";
                    break;
                }
            }
            return new Address
            {
                Street = street,
                Number = number,
                Floor = floor,
                Door = door,
                FloorType = floor == null ? FloorType.St : FloorType.None,
            };
        }

        private static string GetRandomText(int length = 1, bool includeDanishCharacters = true)
        {
            char[] validCharacters =
            [
                ' ',
                'a',
                'b',
                'c',
                'd',
                'e',
                'f',
                'g',
                'h',
                'i',
                'j',
                'k',
                'l',
                'm',
                'n',
                'o',
                'p',
                'q',
                'r',
                's',
                't',
                'u',
                'v',
                'w',
                'x',
                'y',
                'z',
                'A',
                'B',
                'C',
                'D',
                'E',
                'F',
                'G',
                'H',
                'I',
                'J',
                'K',
                'L',
                'M',
                'N',
                'O',
                'P',
                'Q',
                'R',
                'S',
                'T',
                'U',
                'V',
                'W',
                'X',
                'Y',
                'Z',
            ];

            if (includeDanishCharacters)
            {
                validCharacters = validCharacters.Concat(['æ', 'ø', 'å', 'Æ', 'Ø', 'Å']).ToArray();
            }

            // var random = new Random();
            var text = new char[length];

            // The first character is chosen from position 1 to avoid the space
            text[0] = validCharacters[GetRandomShared().Next(1, validCharacters.Length)];
            for (int i = 1; i < length; i++)
            {
                text[i] = validCharacters[GetRandomShared().Next(0, validCharacters.Length)];
            }

            return new string(text);
        }
        #endregion
    }

    public enum FloorType
    {
        None,
        St,
    }
}
