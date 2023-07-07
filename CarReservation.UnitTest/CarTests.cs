using AutoMapper;
using CarReservation.Application.Features.CarFeatures.CreateCar;
using CarReservation.Application.Features.CarFeatures.UpdateCar;
using CarReservation.Application.Repositories;
using CarReservation.Persistence.Context;
using CarReservation.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CarReservation.UnitTest;

public class CarTests
{
    private DbContextOptions<DataContext> _dbContextOptions;
    private DataContext _dataContext;
    private UnitOfWork _unitOfWork;
    
    private CarRepository _carRepository;
    
    private CreateCarHandler _createCarHandler;
    private CreateCarValidator _createCarValidator;

    private UpdateCarHandler _updateCarHandler;
    private UpdateCarValidator _updateCarValidator;
    
    [SetUp]
    public void Setup()
    {
        _dbContextOptions = new DbContextOptions<DataContext>();
        _dataContext = new DataContext(_dbContextOptions);
        _carRepository = new CarRepository(_dataContext);
        _unitOfWork = new UnitOfWork(_dataContext);

        _createCarHandler = new CreateCarHandler(_unitOfWork, _carRepository, 
            new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CreateCarMapper>();
            }).CreateMapper());
        _createCarValidator = new CreateCarValidator();

        _updateCarHandler = new UpdateCarHandler(_unitOfWork, _carRepository,
            new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UpdateCarMapper>();
            }).CreateMapper());
        _updateCarValidator = new UpdateCarValidator();
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
}