using api.DBContext;
using api.Models.DTOs;
using api.Repositories;
using api.Services;
using FluentAssertions;
using NSubstitute;

namespace getCprAndNameAndGender;

public class UnitTests
{
    [Fact]
    public async Task GetCprAndNameAndGender_Should_Return_Correct_Props()
    {
        // Arrange
        var mockRepository = Substitute.For<IPersonsRepository>();
        var mockDataContext = Substitute.For<DataContext>();
        var mockJsonService = Substitute.For<IJsonService>();
        mockJsonService
            .GetRandomPersonFromJson()
            .Returns(
                new Person
                {
                    FirstName = "Ali",
                    LastName = "Mohammed",
                    Gender = "male",
                }
            );

        var service = new PersonsService(mockRepository, mockDataContext, mockJsonService);

        // Act
        var person = await service.GetCprAndNameAndGender();

        // Assert
        person.Should().NotBeNull();
        person.FirstName.Should().Be("Ali");
        person.LastName.Should().Be("Mohammed");
        person.Gender.Should().Be("male");
        person.Cpr.Should().HaveLength(10);
        person.Cpr.Should().MatchRegex(@"^\d+$");
    }
}
