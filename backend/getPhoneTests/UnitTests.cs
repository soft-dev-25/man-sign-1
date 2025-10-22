using api.Models.DTOs;
using api.Shared.Constants;
using FluentAssertions;

namespace getPhoneTests;

[Trait("TestCategory", "UnitTest")]
public class UnitTests
{
    private readonly string _phoneNumber;

    public UnitTests()
    {
        var person = new Person();
        person.CreatePhoneNumber();
        _phoneNumber = person.PhoneNumber!;
    }

    [Fact]
    public void PhoneNumber_Should_StartWithAllowedPrefix()
    {
        // Arrange
        var allowedPrefixes = PhoneNumberData.AllowedPrefixes;

        // Act & Assert
        allowedPrefixes.Any(prefix => _phoneNumber.StartsWith(prefix)).Should().BeTrue();
    }

    [Fact]
    public void PhoneNumber_Should_BeLengthOf8()
    {
        // Act & Assert
        _phoneNumber.Length.Should().Be(8);
    }

    [Fact]
    public void PhoneNumber_Should_NotBeNullOrEmpty()
    {
        // Act & Assert
        _phoneNumber.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void PhoneNumber_Should_OnlyConsistOfDigits()
    {
        // Act & Assert
        _phoneNumber.All(char.IsDigit).Should().BeTrue();
    }

    [Fact]
    public void PhoneNumber_Generation_Should_ConsistentlyProduceValidNumbers()
    {
        // Arrange
        var allowedPrefixes = PhoneNumberData.AllowedPrefixes;
        const int testIterations = 100;

        // Act & Assert
        for (var i = 0; i < testIterations; i++)
        {
            var person = new Person();
            person.CreatePhoneNumber();
            var phoneNumber = person.PhoneNumber;

            // All invariant properties must be true for every generation
            phoneNumber.Should().NotBeNullOrEmpty();
            phoneNumber.Length.Should().Be(8);
            phoneNumber.All(char.IsDigit).Should().BeTrue();
            allowedPrefixes.Any(prefix => phoneNumber.StartsWith(prefix)).Should().BeTrue();
        }
    }
}
