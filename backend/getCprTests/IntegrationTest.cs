using api.DBContext;
using api.Repositories;
using api.Services;
using NSubstitute;

namespace getCprTests;

public class IntegrationTest
{
    // Integration Test, since we are reading from a file system
    [Fact]
    public async Task Get_Cpr_Should_Be_Successful()
    {
        // Arrange
        var mockRepository = Substitute.For<IPersonsRepository>();
        var mockDataContext = Substitute.For<DataContext>();
        var jsonService = new JsonService();

        var service = new PersonsService(mockRepository, mockDataContext, jsonService);

        // Act
        var person = await service.GetCpr();
        var cpr = person.Cpr!;
        var lastDigit = cpr[cpr.Length - 1] - '0';

        // Assert
        Assert.Equal(10, cpr.Length);
        Assert.Matches(@"^\d+$", cpr); // digits
    }
}