using api.DBContext;
using api.ExceptionHandlers;
using api.Models.DTOs;
using api.Repositories;
using api.Services;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace getCprTests;

[Trait("TestCategory", "UnitTest")]
public class UnitTest
{
    // TODO: Nedenstående test skal flyttes til en Person.cs.test klasse
    [Fact]
    public async Task BirthDate_And_Cpr_Should_Be_Equal()
    {
        // Arrange
        var person = new Person() { Gender = "male" };

        // Act
        person.CreateCpr();

        // Assert
        Assert.NotNull(person.Cpr);
        Assert.NotNull(person.BirthDate);

        // CPR ("DDMMYYXXXX")
        var cprDate = person.Cpr.Substring(0, 6);
        var cprDay = cprDate.Substring(0, 2);
        var cprMonth = cprDate.Substring(2, 2);
        var cprYear = cprDate.Substring(4, 2);

        // BirthDate
        var bDate = person.BirthDate.Value;
        var bDay = $"{bDate.Day:D2}";
        var bMonth = $"{bDate.Month:D2}";
        var bYear = bDate.Year.ToString().Substring(2);

        // Compare
        Assert.Equal(cprDay, bDay);
        Assert.Equal(cprMonth, bMonth);
        Assert.Equal(cprYear, bYear);
    }

    [InlineData("female", new[] { 2, 4, 6, 8, 0 })]
    [InlineData("male", new[] { 1, 3, 5, 7, 9 })]
    [Theory]
    public async Task Get_Cpr_Should_Be_Successful_When_Correct_Gender(
        string gender,
        int[] expectedSingleDigit
    )
    {
        // Arrange
        var mockRepository = Substitute.For<IPersonsRepository>();
        var mockDataContext = Substitute.For<DataContext>();
        var mockJsonService = Substitute.For<IJsonService>();
        mockJsonService.GetRandomPersonFromJson().Returns(new Person() { Gender = gender });

        var service = new PersonsService(mockRepository, mockDataContext, mockJsonService);

        // Act
        var person = await service.GetCpr();
        var cpr = person.Cpr!;
        var lastDigit = cpr[cpr.Length - 1] - '0';

        // Assert
        Assert.Equal(10, cpr.Length);
        Assert.Matches(@"^\d+$", cpr);
        Assert.Contains(lastDigit, expectedSingleDigit);
    }

    // Negative test
    [InlineData("")]
    [InlineData("other")]
    [InlineData("non-binary")]
    [InlineData("fluid")]
    [Theory]
    public async Task Get_Cpr_Should_Throw_When_Unknown_Gender(string gender)
    {
        // Arrange
        var mockRepository = Substitute.For<IPersonsRepository>();
        var mockDataContext = Substitute.For<DataContext>();
        var mockJsonService = Substitute.For<IJsonService>();
        mockJsonService.GetRandomPersonFromJson().Returns(new Person() { Gender = gender });

        var service = new PersonsService(mockRepository, mockDataContext, mockJsonService);

        // Act & Assert
        var act = async () => await service.GetCpr();
        await act.Should().ThrowAsync<BadRequestException>();
    }
}
