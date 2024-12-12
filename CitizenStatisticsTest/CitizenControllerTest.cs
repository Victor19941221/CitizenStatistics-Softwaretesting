using CitizenStatistics;
using CitizenStatistics.Controllers;
using CitizenStatistics.Models;
using CitizenStatistics.Services;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;

namespace CitizenStatisticsTest;

public class CitizenControllerTest
{
    private readonly ICitizenService _citizenService;
    private readonly CitizenController _controller;

    public CitizenControllerTest()
    {
        _citizenService = Substitute.For<ICitizenService>();
        _controller = new CitizenController(_citizenService);
    }

    // Test for HttpPost Create
    [Fact]
    public void Create_Post_ValidCitizen_RedirectsToIndex()
    {
        // Arrange
        var citizen = new Citizen { Id = 1, Age = 30, Profession = "Teacher", Income = 50000 };

        // Act
        var result = _controller.Create(citizen);

        // Assert
        var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Index", redirectToActionResult.ActionName);
        _citizenService.Received().AddCitizen(citizen);
    }

    // Test for HttpPost Create when invalid model
    [Fact]
    public void Create_Post_InvalidModel_ReturnsViewWithCitizen()
    {
        // Arrange
        var citizen = new Citizen { Id = 1, Age = 30, Profession = "", Income = 50000 }; // Profession missing
        _controller.ModelState.AddModelError("Profession", "Required");

        // Act
        var result = _controller.Create(citizen);

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.Equal(citizen, viewResult.Model);
        _citizenService.DidNotReceive().AddCitizen(Arg.Any<Citizen>());
    }

    // Test for HttpPost Delete
    [Fact]
    public void Delete_Post_ValidCitizen_RedirectsToIndex()
    {
        // Arrange
        var citizen = new Citizen { Id = 1 };
        _citizenService.GetCitizen(citizen.Id).Returns(citizen);

        // Act
        var result = _controller.DeleteConfirmed(citizen.Id); // Uppdatera så att du skickar Id

        // Assert
        var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Index", redirectToActionResult.ActionName);
        _citizenService.Received().RemoveCitizen(citizen.Id); // Uppdatera så att du verifierar med Id
    }

    // Test for HttpPost Delete when citizen doesn't exist
    [Fact]
    public void Delete_Post_NonExistingCitizen_ReturnsNotFound()
    {
        // Arrange
        var citizen = new Citizen { Id = 1 };
        _citizenService.GetCitizen(citizen.Id).Returns((Citizen)null);

        // Act
        var result = _controller.DeleteConfirmed(citizen.Id); // Uppdatera så att du skickar Id

        // Assert
        Assert.IsType<NotFoundResult>(result);
        _citizenService.DidNotReceive().RemoveCitizen(Arg.Any<int>()); // Uppdatera för att verifiera med Id
    }

    // Test for HttpPost Edit
    [Fact]
    public void Edit_Post_ValidCitizen_RedirectsToIndex()
    {
        // Arrange
        var citizen = new Citizen { Id = 1, Age = 30, Profession = "Doctor", Income = 70000 };

        // Act
        var result = _controller.Edit(citizen);

        // Assert
        var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Index", redirectToActionResult.ActionName);
        _citizenService.Received().UpdateCitizen(citizen);
    }

    // Test for HttpPost Edit with invalid model
    [Fact]
    public void Edit_Post_InvalidModel_ReturnsViewWithCitizen()
    {
        // Arrange
        var citizen = new Citizen { Id = 1, Age = 30, Profession = "", Income = 70000 }; // Profession missing
        _controller.ModelState.AddModelError("Profession", "Required");

        // Act
        var result = _controller.Edit(citizen);

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.Equal(citizen, viewResult.Model);
        _citizenService.DidNotReceive().UpdateCitizen(Arg.Any<Citizen>());
    }

    [Fact]
    public void Create_Post_ReturnsViewResult_WhenProfessionIsMissing()
    {
        // Arrange
        var citizen = new Citizen { Id = 1, Age = 25, Profession = "" }; // Profession is missing

        // Act
        var result = _controller.Create(citizen);

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.False(viewResult.ViewData.ModelState.IsValid);
        Assert.True(viewResult.ViewData.ModelState.ContainsKey("Profession"));
    }

}
