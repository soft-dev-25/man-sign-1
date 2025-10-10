using api.ExceptionHandlers;
using api.Shared.Constants;

namespace api.Models.DTOs;

public class Address
{
    public string? Street { get; set; }
    public string? Number { get; set; }
    public int? Floor { get; set; }
    public string? Door { get; set; }
    public string? PostalCode { get; set; }
    public string? TownName { get; set; }
}

public class Person
{
    public string? Cpr { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Gender { get; set; }

    public string? BirthDate { get; set; }

    public Address? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public void CreateCpr()
    {
        if (Gender != "male" && Gender != "female")
        {
            throw new BadRequestException($"Gender {Gender} is unknown");
        }

        var random = new Random();

        CreateBirthdate();

        var dateParts = BirthDate!.Split('-');
        var year = dateParts[0];
        var month = dateParts[1];
        var day = dateParts[2];

        // Get last 2 digits of year
        var yearTwoDigits = year.Substring(2);

        // 0-9
        var digitOne = random.Next(0, 10);
        var digitTwo = random.Next(0, 10);
        var digitThree = random.Next(0, 10);

        int finalDigit;
        if (Gender == "female")
        {
            var evenDigits = new[] { 0, 2, 4, 6, 8 };
            finalDigit = evenDigits[random.Next(evenDigits.Length)];
        }
        else
        {
            var oddDigits = new[] { 1, 3, 5, 7, 9 };
            finalDigit = oddDigits[random.Next(oddDigits.Length)];
        }

        Cpr = $"{day}{month}{yearTwoDigits}{digitOne}{digitTwo}{digitThree}{finalDigit}";
    }

    private void CreateBirthdate()
    {
        var random = new Random();

        // Between 1900 and last year (including)
        var year = random.Next(1900, DateTime.Now.Year);
        // 1-12
        var month = random.Next(1, 13);
        var day = 1;

        if (new List<int>(new[] { 1, 3, 5, 7, 8, 10, 12 }).Contains(month))
        {
            // 1-31
            day = random.Next(1, 32);
        }
        else if (new List<int>(new[] { 4, 6, 9, 11 }).Contains(month))
        {
            // 1-30
            day = random.Next(1, 31);
        }
        else
        {
            // Check for leap year
            var isLeapYear = DateTime.IsLeapYear(year);
            day = random.Next(1, isLeapYear ? 30 : 29);
        }

        BirthDate = $"{year}-{month:D2}-{day:D2}";
    }

    public void CreatePhoneNumber()
    {
        var phonePrefixes = PhoneNumberData.AllowedPrefixes;

        var random = new Random();

        var phoneNumber = phonePrefixes[random.Next(phonePrefixes.Count)];

        var numbersToAdd = 8 - phoneNumber.Length;

        for (var i = 0; i < numbersToAdd; i++)
        {
            phoneNumber += random.Next(0, 10);
        }

        PhoneNumber = phoneNumber;
    }
}