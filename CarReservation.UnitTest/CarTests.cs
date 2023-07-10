using AutoMapper;
using CarReservation.Application.Features.CarFeatures.CreateCar;
using CarReservation.Application.Features.CarFeatures.DeleteCar;
using CarReservation.Application.Features.CarFeatures.GetAllCar;
using CarReservation.Application.Features.CarFeatures.UpdateCar;
using CarReservation.Persistence.Context;
using CarReservation.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CarReservation.UnitTest;

public class CarTests
{
    private DbContextOptions<DataContext> _dbContextOptions;
    private DataContext _dataContext;
    private Mock<UnitOfWork> _unitOfWork;

    private Mock<CarRepository> _carRepository;
    
    private CreateCarHandler _createCarHandler;
    private CreateCarValidator _createCarValidator;

    private UpdateCarHandler _updateCarHandler;
    private UpdateCarValidator _updateCarValidator;
        
    private GetAllCarHandler _getAllCarHandler;
    private DeleteCarHandler _deleteCarHandler;

    [SetUp]
    public void Setup()
    {
        _dbContextOptions = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "test")
            .Options;
        _dataContext = new DataContext(_dbContextOptions);
        _unitOfWork = new Mock<UnitOfWork>(_dataContext);

        _carRepository = new Mock<CarRepository>(_dataContext);

        _createCarHandler = new CreateCarHandler(_unitOfWork.Object, _carRepository.Object, 
            new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CreateCarMapper>();
            }).CreateMapper());
        _createCarValidator = new CreateCarValidator();

        _updateCarHandler = new UpdateCarHandler(_unitOfWork.Object, _carRepository.Object,
            new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UpdateCarMapper>();
            }).CreateMapper());
        _updateCarValidator = new UpdateCarValidator();
        
        _getAllCarHandler = new GetAllCarHandler(_carRepository.Object);
        
        _deleteCarHandler = new DeleteCarHandler(_unitOfWork.Object, _carRepository.Object,
            new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DeleteCarMapper>();
            }).CreateMapper());
    }
    
    [TestCase("test_brand", "test_model")]
    public async Task CreateCarHandler(string brand, string model)
    {
        // Arrange
        var request = new CreateCarRequest(brand, model);

        // Act
        var response = await _createCarHandler.Handle(request, default);
        
        // Assert
        Assert.That(request.Brand, Is.EqualTo(response.Brand));
    }

    [TestCase("test_brand", "test_model")]
    public async Task CreateCarValidator(string brand, string model)
    {
        // Arrange
        var request = new CreateCarRequest(brand, model);
        
        // Act
        var validationResult = await _createCarValidator.ValidateAsync(request);
        
        // Assert
        Assert.That(validationResult.IsValid, Is.True);
    }

    [TestCase("00000000-0000-0000-0000-000000000100", "test_brand", "test_model")]
    public async Task UpdateCarHandler(string guid, string brand, string model)
    {
        // Arrange
        var createCarRequest = new CreateCarRequest("oldBrand", "oldModel");
        var createCarResponse = await _createCarHandler.Handle(createCarRequest, default);
    
        // Act
        var request = new UpdateCarRequest(createCarResponse.Id, brand, model);
        var response = await _updateCarHandler.Handle(request, default);
    
        // Assert
        Assert.That(brand, Is.EqualTo(response.Brand));
    }

    [TestCase("test_brand", "test_model")]
    public async Task UpdateCarValidator(string brand, string model)
    {
        // Arrange
        var request = new UpdateCarRequest(Guid.NewGuid(), brand, model);
        
        // Act
        var validationResult = await _updateCarValidator.ValidateAsync(request);
        
        // Assert
        Assert.That(validationResult.IsValid, Is.True);
    }

    [Test]
    public async Task GetAllCarHandler()
    {
        // Arrange
        var request = new GetAllCarRequest();

        // Act
        var response = await _getAllCarHandler.Handle(request, default);
        
        // Assert
        Assert.That(response.Cars, Is.Not.Null);
    }
    
    [Test]
    public async Task DeleteCarHandler()
    {
        // Arrange
        var createCarRequest = new CreateCarRequest("oldBrand", "oldModel");
        var createCarResponse = await _createCarHandler.Handle(createCarRequest, default);
        
        // Act
        var request = new DeleteCarRequest(createCarResponse.Id);
        await _deleteCarHandler.Handle(request, default);

        var deletedCar = await _carRepository.Object.Get(request.Id, default);
        
        // Assert
        Assert.That(deletedCar, Is.Null);
    }
}
