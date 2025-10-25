using api.Models.DTOs;
using api.Models;
using api.Shared.Constants;
using FluentAssertions;
using api.DBContext;
using api.ExceptionHandlers;
using api.Repositories;
using api.Services;
using NSubstitute;
using api.Controllers;
using Microsoft.AspNetCore.Mvc;


namespace getPersonTests;

[Trait("TestCategory", "UnitTest")]
public class UnitTest
{
    [Fact]
    public async Task GetPerson_NoFieldsShouldNotBeNull()
    {
        var fname = "Nanu";
        var lname = "Larsen";
        var gender = "male";
        var tname = "Test town";
        var pcode = "1234";

        var mockRepository = Substitute.For<IPersonsRepository>();
        var mockDataContext = Substitute.For<DataContext>();
        var mockJsonService = Substitute.For<IJsonService>();
        mockJsonService
            .GetRandomPersonFromJson()
            .Returns(
                new Person
                {
                    FirstName = fname,
                    LastName = lname,
                    Gender = gender,
                }
            );
        mockRepository.GetPostal().Returns(new Postal
        {
            TownName = tname,
            PostalCode = pcode
        });

        var service = new PersonsService(mockRepository, mockDataContext, mockJsonService);

        var personDto = await service.GetPerson();

        Assert.Equal(personDto.FirstName, fname);
        Assert.Equal(personDto.LastName, lname);
        Assert.Equal(personDto.Gender, gender);
        Assert.Equal(personDto.Address?.TownName, tname);
        Assert.Equal(personDto.Address?.PostalCode, pcode);


        // Use reflection to check all properties of PersonDTO
        var properties = typeof(PersonDTO).GetProperties();
        foreach (var property in properties)
        {
            var value = property.GetValue(personDto);
            Assert.NotNull(value); // Ensure no property is null
        }
    }
}


[Trait("TestCategory", "UnitTest")]
public class PersonsControllerTests
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(500)]
    [InlineData(999)]
    [InlineData(1000)]
    public async Task GetPersons_ReturnsCorrectNumberOfPersons(int count)
    {

        // Arrange
        var mockPersonsService = Substitute.For<IPersonsService>();
        var fakePerson = new PersonDTO
        {
            Cpr = "123456-7890",
            FirstName = "John",
            LastName = "Doe",
            Gender = "Male",
            BirthDate = "1990-01-01",
            PhoneNumber = "12345678"
        };

        // Mock the GetPerson method to always return the fakePerson
        mockPersonsService.GetPerson().Returns(fakePerson);

        var controller = new PersonsController(mockPersonsService);

        // Act
        var result = await controller.GetPersons(count);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var persons = Assert.IsType<List<PersonDTO>>(okResult.Value);

        Assert.Equal(count, persons.Count); // Ensure the correct number of persons is returned
        foreach (var person in persons)
        {
            Assert.Equal(fakePerson, person); // Ensure each person matches the mocked data
        }
    }

    [Theory]
    [InlineData(null)] 
    [InlineData(-1)] 
    [InlineData(0)] 
    [InlineData(1001)]
    [InlineData(1002)]
    public async Task GetPersons_HandlesBadAmountsCorrectly(int? count)
    {
        // Arrange
        var mockPersonsService = Substitute.For<IPersonsService>();
        var controller = new PersonsController(mockPersonsService);

        // Act
        var result = await controller.GetPersons(count);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }
}