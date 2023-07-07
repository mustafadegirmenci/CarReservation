using CarReservation.Application.Features.CarFeatures.CreateCar;
using CarReservation.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CarReservation.UnitTest;

public class CarControllerTests
{
    private Mock<IMediator> _mediator;
    private CarController _carController;

    [SetUp]
    public void Setup()
    {
        _mediator = new Mock<IMediator>();
        
        _carController = new CarController(_mediator.Object);
    }

    [Test]
    public async Task GetAllReturnsAllCars()
    {
        var result = await _carController.GetAll(default);
        
        Assert.That(result.Result as OkObjectResult, Is.Not.Null);
    }
    
    [TestCase("test_brand", "test_model")]
    public async Task CreateAddsNewCar(string brand, string model)
    {
        var request = new CreateCarRequest(brand, model);
        var result = await _carController.Create(request, default);

        Assert.That(result.Result as OkObjectResult, Is.Not.Null);
    }
}
