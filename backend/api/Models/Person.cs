using System.Text.Json.Serialization;
using api.ExceptionHandlers;

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

    public DateOnly? BirthDate { get; set; }

    public Address? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public Person() { }

    public void CreateCpr()
    {
        if (Gender != "male" && Gender != "female")
        {
            throw new BadRequestException($"Gender {Gender} is unknown");
        }
        var random = new Random();

        CreateBirthdate();

        
        var year = BirthDate.Value.Year;
        var month = BirthDate.Value.Month;
        var day = BirthDate.Value.Day;

        // Get last 2 digits of year
        var yearTwoDigits = year.ToString().Substring(2);

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

        Cpr = $"{day:D2}{month:D2}{yearTwoDigits}{digitOne}{digitTwo}{digitThree}{finalDigit}";
    }

    public void CreateBirthdate()
    {
        var random = new Random();

        // Between 1900 and last year (including)
        var year = random.Next(1900, DateTime.Now.Year);
        // 1-12
        var month = random.Next(1, 13);
        int day;

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

        BirthDate = new DateOnly(year, month, day);
    }
}
