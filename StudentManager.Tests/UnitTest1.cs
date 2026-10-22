using Microsoft.AspNetCore.Mvc;
using Moq;
using StudentManager.Controllers;
using StudentManager.Models;

namespace StudentManager.Tests;

public class HomeControllerTests {
    [Fact]
    public void Edit_UkendtId_ReturnererNotFound() 
        {
        // Arrange
        var mockRepo = new Mock<IStudentRepository>();
        mockRepo.Setup(r => r.GetStudentById(99)).Returns((Student?)null);
        var controller = new HomeController(mockRepo.Object);

        // Act
        var result = controller.Edit(99);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void CreateStudent_GyldigModel_KalderAddStudentOgRedirecter() 
        {
        // Arrange
        var mockRepo = new Mock<IStudentRepository>();
        var controller = new HomeController(mockRepo.Object);
        var student = new Student { Name = "Bastian", Email = "StoreBastian@mand.dk", Education = "DMU", Semester = 3 };

        // Act
        var result = controller.CreateStudent(student);

        // Assert
        mockRepo.Verify(r => r.AddStudent(student), Times.Once);
        var redirect = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Index", redirect.ActionName);
    }

    [Fact]
    public void CreateStudent_ManglendeInformation_ReturnererViewMedModel() 
    {
        // Arrange
        var mockRepo = new Mock<IStudentRepository>();
        var controller = new HomeController(mockRepo.Object);
        var student = new Student { Email = "StoreBastian@mand.dk", Education = "DMU", Semester = 3 };
        //controller.ModelState.AddModelError("Name", "Navn Mangler");
        
        // Act
        var result = controller.CreateStudent(student);

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
    }
}