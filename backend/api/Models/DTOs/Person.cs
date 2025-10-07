using System.Text.Json.Serialization;

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
}

