using api.Controllers;
using api.DBContext;
using api.ExceptionHandlers;
using api.Models;
using api.Models.DTOs;
using api.Repositories;
using api.Services;
using api.Shared.Constants;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace getPersonTests;

[Trait("TestCategory", "UnitTest")]
public class GetPersonsTests
{
    private PersonsService _service;
    private Person _person = new Person()
    {
        FirstName = "Nanu",
        LastName = "Larsen",
        Gender = "male",
    };

    public GetPersonsTests()
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
        mockRepository.GetPostal().Returns(new Postal { TownName = tname, PostalCode = pcode });

        _service = new PersonsService(mockRepository, mockDataContext, mockJsonService);
    }

    private bool _EnsureNoNullPersonFields(PersonDTO personDto)
    {
        // Use reflection to check all properties of PersonDTO
        var properties = typeof(PersonDTO).GetProperties();
        foreach (var property in properties)
        {
            if (property.GetValue(personDto) == null)
            {
                return false;
            }
        }
        return true;
    }

    [Fact]
    public async Task GetPerson_NoFieldsShouldNotBeNull()
    {
        var personDto = await _service.GetPerson();

        Assert.Equal(personDto.FirstName, _person.FirstName);
        Assert.Equal(personDto.LastName, _person.LastName);
        Assert.Equal(personDto.Gender, _person.Gender);

        Assert.True(_EnsureNoNullPersonFields(personDto));
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(50)]
    [InlineData(99)]
    [InlineData(100)]
    public async Task GetPersons_ReturnsCorrectNumberOfPersons(int count)
    {
        var persons = await _service.GetPersons(count);

        Assert.Equal(count, persons.Count); // Ensure the correct number of persons is returned
        foreach (var person in persons)
        {
            Assert.True(_EnsureNoNullPersonFields(person));
        }
    }

    [Theory]
    [InlineData(null)]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(101)]
    [InlineData(102)]
    public async Task GetPersons_HandlesBadAmountsCorrectly(int? count)
    {
        await Assert.ThrowsAnyAsync<ArgumentException>(() => _service.GetPersons(count));
    }
}
