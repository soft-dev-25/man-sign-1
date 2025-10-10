using System.Text.RegularExpressions;

namespace api.Models
{
    // link to information about danish address formats: https://danmarksadresser.dk/om-adresser/saadan-gengives-en-adresse

    public class Address
    {
        public string? Street { get; init; }
        public string? Number { get; init; }
        public int? Floor { private get; init; }
        public string? Door { get; init; }
        public string? PostalCode { get; set; }
        public string? TownName { get; set; }

        public string FloorDisplay =>
            Floor.HasValue? Floor.Value.ToString()
            : FloorType == FloorType.St ? nameof(FloorType.St)
            : string.Empty;

        public override string ToString()
        {
            var floorPart = Floor.HasValue ? $"{Floor}." : ""; // e.g. "3."
            var doorPart = !string.IsNullOrEmpty(Door) ? $" {Door}" : ""; // e.g. " th"

            return $"{Street} {Number}, {floorPart}{doorPart}\n{PostalCode} {TownName}";
        }



        private FloorType FloorType { get; set; } = FloorType.None;
        //private Doortype DoorType { get; } = Doortype.None;

        public void ValidateStreet()
        {
            if (string.IsNullOrWhiteSpace(Street) || string.IsNullOrEmpty(Street))
            {
                throw new ArgumentNullException($"Street {Street} must be provided");
            }

            if (!Street.All(char.IsLetter))
            {
                throw new ArgumentException($"Street {Street} must only contain letters");
            }

        }

        public void ValidateNumber()
        {
            if (string.IsNullOrWhiteSpace(Number) || string.IsNullOrEmpty(Number))
            {
                throw new ArgumentNullException($"Number {Number} must be provided");
            }

            if (!Regex.IsMatch(Number, @"^[1-9][0-9]{0,2}[A-Z]?$"))
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
                    throw new ArgumentException("Cannot set both FloorType as 'st' and FloorNumber.");
                return;
            }

            switch (Floor)
            {
                case null:
                    throw new ArgumentNullException(nameof(Floor),
                        "Either FloorType must be 'st' or FloorNumber must be set.");
                case < 1:
                case > 99:
                    throw new ArgumentOutOfRangeException(nameof(Floor), "FloorNumber must be between 1 and 99.");
            }

            if (FloorType != FloorType.None)
                throw new ArgumentException("FloorType must be None when FloorNumber is set.");
        }

        public void ValidateDoor()
        {
            if (string.IsNullOrWhiteSpace(Door) || string.IsNullOrEmpty(Door))
            {
                throw new ArgumentNullException($"Door {Door} must be provided");
            }

            // Valid values are "th", "mf", or "tv" (case insensitive), mean we can use Upper or lower case letters
            if (!Regex.IsMatch(Door, @"^(th|mf|tv)$", RegexOptions.IgnoreCase))
            {
                throw new ArgumentException($"Door {Door} must be either 'th', 'mf', or 'tv'");

            }

            if (!int.TryParse(Door, out int doorNumber) || doorNumber < 1 || doorNumber > 50)
            {
                throw new ArgumentException(" Door number must be an integer between 1 and 50.");

            }

            if (!Regex.IsMatch(Door, @"^[a-zA-ZæÆøØåÅ](-)?\d{1,3}$", RegexOptions.IgnoreCase))
            {

                throw new ArgumentException(
                    $"Door {Door} must be a valid door format like 'A-1', 'B12', 'C-123', etc.");

            }

        }
        public void Validate()
        {
            ValidateStreet();
            ValidateNumber();
            ValidateFloor();
            ValidateDoor();

        }

        #region Funtion - return a fack address
        public static Address GenerateFakeAddress()
        {
            var random = new Random();

            // Generate a random street name (5-12 characters, includes Danish letters)
            string street = GetRandomText(random.Next(5, 13), true);

            // Generate a random number (1-3 digits, optionally with uppercase or Danish letter)
            int numberPart = random.Next(1, 1000);
            string number = numberPart.ToString();
            if (random.NextDouble() < 0.3) // 30% chance to add a letter
            {
                string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅ";
                number += letters[random.Next(letters.Length)];
            }

            // Generate a random floor (null or 1-10) with 70% chance of being null and if null return FloorType = "st"
            int? floor = random.NextDouble() < 0.7 ? random.Next(1, 11) : null;


            // Generate a random door (valid formats)
            string[] doorOptions = ["th", "mf", "tv"];
            string door;
            int doorType = random.Next(3);
            switch (doorType)
            {
                case 0:
                    door = doorOptions[random.Next(doorOptions.Length)];
                    break;
                case 1:
                    door = random.Next(1, 51).ToString();
                    break;
                default:
                    {
                        // Letter (upper/lower/Danish), optional dash, 1-3 digits
                        const string letters = "abcdefghijklmnopqrstuvwxyzæøåABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅ";
                        char letter = letters[random.Next(letters.Length)];
                        string dash = random.NextDouble() < 0.5 ? "-" : "";
                        int digits = random.Next(1, 1000);
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
                FloorType = floor == null ? FloorType.St : FloorType.None

            };
        }
        private static string GetRandomText(int length = 1, bool includeDanishCharacters = true)
        {
            char[] validCharacters =
            [
                ' ', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q',
                'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F',
                'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X',
                'Y', 'Z'
            ];

            if (includeDanishCharacters)
            {
                validCharacters = validCharacters
                    .Concat(['æ', 'ø', 'å', 'Æ', 'Ø', 'Å'])
                    .ToArray();
            }

            var random = new Random();
            var text = new char[length];

            // The first character is chosen from position 1 to avoid the space
            text[0] = validCharacters[random.Next(1, validCharacters.Length)];
            for (int i = 1; i < length; i++)
            {
                text[i] = validCharacters[random.Next(0, validCharacters.Length)];
            }

            return new string(text);
        }
        #endregion

    }
}



public enum FloorType
{
    None,
    St
}
//public enum Doortype
//{
//    None, // by default
//    th,
//    tv,
//    mf

//}