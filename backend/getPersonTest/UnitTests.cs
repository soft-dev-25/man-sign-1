using api.Models.DTOs;
using api.Models;
using api.Shared.Constants;
using FluentAssertions;
using api.DBContext;
using api.ExceptionHandlers;
using api.Repositories;
using api.Services;
using NSubstitute;

namespace getPersonTests;

[Trait("TestCategory", "UnitTest")]
public class UnitTest
{
    [Fact]
    public async Task Person_Fields_Should_Not_Be()
    {
        var fname = "Nane";
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
