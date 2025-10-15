using api.DBContext;
using api.Models.DTOs;
using api.Repositories;
using api.Services;
using FluentAssertions;
using NSubstitute;

namespace getNameAndGenderAndDoBTests;

public class UnitTests
{
    [Fact]
    public async Task GetNameAndGenderAndDoB_Should_Return_Correct_Props()
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
        var person = await service.GetNameAndGenderAndDoB();

        // Assert
        person.Should().NotBeNull();
        person.FirstName.Should().Be("Ali");
        person.LastName.Should().Be("Mohammed");
        person.Gender.Should().Be("male");
        person.BirthDate.Should().NotBeNullOrEmpty();
        person.BirthDate.Should().HaveLength(10);
    }
}
