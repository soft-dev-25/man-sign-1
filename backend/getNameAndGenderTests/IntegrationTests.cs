using api.DBContext;
using api.Repositories;
using api.Services;
using FluentAssertions;
using NSubstitute;

namespace getNameAndGenderTests;

[Trait("TestCategory", "IntegrationTest")]
public class IntegrationTests
{
    // Integration Test, since we are reading from a file system
    [Fact]
    public async Task Get_NameAndGender_Should_Be_Successful()
    {
        // Arrange
        var mockRepository = Substitute.For<IPersonsRepository>();
        var mockDataContext = Substitute.For<DataContext>();
        var jsonService = new JsonService();

        var service = new PersonsService(mockRepository, mockDataContext, jsonService);

        // Act
        var person = await service.GetNameAndGender();

        // Assert
        person.FirstName.Should().NotBeNullOrEmpty();
        person.LastName.Should().NotBeNullOrEmpty();
        person.Gender.Should().NotBeNullOrEmpty();
    }
}
