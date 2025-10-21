using api.Models.DTOs;
using api.Shared.Constants;
using FluentAssertions;

namespace getPhoneTests;

[Trait("TestCategory", "UnitTest")]
public class UnitTests
{
    [Fact]
    public void PhoneNumber_Should_StartWithAllowedPrefix()
    {
        // Arrange
        var person = new Person();
        var allowedPrefixes = PhoneNumberData.AllowedPrefixes;

        // Act
        person.CreatePhoneNumber();

        // Assert
        allowedPrefixes.Any(prefix => person.PhoneNumber!.StartsWith(prefix)).Should().BeTrue();
    }

    [Fact]
    public void PhoneNumber_Should_BeLengthOf8()
    {
        // Arrange
        var person = new Person();

        // Act
        person.CreatePhoneNumber();

        // Assert
        person.PhoneNumber!.Length.Should().Be(8);
    }

    [Fact]
    public void PhoneNumber_Should_NotBeNullOrEmpty()
    {
        // Arrange
        var person = new Person();

        // Act
        person.CreatePhoneNumber();

        // Assert
        person.PhoneNumber!.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void PhoneNumber_Should_OnlyConsistOfDigits()
    {
        // Arrange
        var person = new Person();

        // Act
        person.CreatePhoneNumber();

        // Assert
        person.PhoneNumber!.All(char.IsDigit).Should().BeTrue();
    }
}
