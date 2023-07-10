using AutoMapper;
using CarReservation.Application.Features.ReservationFeatures.CreateReservation;
using CarReservation.Application.Features.ReservationFeatures.GetAllAvailableReservation;
using CarReservation.Application.Features.ReservationFeatures.GetAllReservation;
using CarReservation.Persistence.Context;
using CarReservation.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework.Constraints;

namespace CarReservation.UnitTest;

public class ReservationTests
{
    private DbContextOptions<DataContext> _dbContextOptions;
    private DataContext _dataContext;
    private Mock<UnitOfWork> _unitOfWork;
    
    private Mock<ReservationRepository> _reservationRepository;
    private Mock<CarRepository> _carRepository;
    
    private CreateReservationHandler _createReservationHandler;
    private CreateReservationValidator _createReservationValidator;
    
    private GetAllReservationHandler _getAllReservationHandler;
    
    private GetAllAvailableReservationHandler _getAllAvailableReservationHandler;
    private GetAllAvailableReservationValidator _getAllAvailableReservationValidator;

    [SetUp]
    public void Setup()
    {
        _dbContextOptions = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "test")
            .Options;
        _dataContext = new DataContext(_dbContextOptions);
        _unitOfWork = new Mock<UnitOfWork>(_dataContext);

        _reservationRepository = new Mock<ReservationRepository>(_dataContext);
        _carRepository = new Mock<CarRepository>(_dataContext);

        _createReservationHandler = new CreateReservationHandler(_unitOfWork.Object, _reservationRepository.Object, 
            new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CreateReservationMapper>();
            }).CreateMapper());
        _createReservationValidator = new CreateReservationValidator();
        
        _getAllReservationHandler = new GetAllReservationHandler(_reservationRepository.Object);

        _getAllAvailableReservationHandler = new GetAllAvailableReservationHandler(
            _carRepository.Object,
            _reservationRepository.Object,
            new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<GetAllAvailableReservationMapper>();
            }).CreateMapper());
        _getAllAvailableReservationValidator = new GetAllAvailableReservationValidator();
    }

    [Test]
    public async Task CreateReservationHandler()
    {
        // Arrange
        var startTime = DateTime.Now;
        var endTime = DateTime.Now + TimeSpan.FromHours(1);
        var request = new CreateReservationRequest(Guid.NewGuid(), startTime, endTime);

        // Act
        var response = await _createReservationHandler.Handle(request, default);
        
        // Assert
        Assert.That(response.StartTime, Is.EqualTo(startTime));
    }

    [TestCase(1, true)]
    [TestCase(3, false)]
    public async Task CreateReservationValidator(int timeDifferenceInHours, bool shouldBeValid)
    {
        // Arrange
        var startTime = DateTime.Now;
        var endTime = startTime + TimeSpan.FromHours(timeDifferenceInHours);
        var request = new CreateReservationRequest(Guid.NewGuid(), startTime, endTime);
        
        // Act
        var validationResult = await _createReservationValidator.ValidateAsync(request);
        
        // Assert
        Assert.That(shouldBeValid, Is.EqualTo(validationResult.IsValid));
    }
    
    [Test]
    public async Task GetAllReservationHandler()
    {
        // Arrange
        var request = new GetAllReservationRequest();

        // Act
        var response = await _getAllReservationHandler.Handle(request, default);
        
        // Assert
        Assert.That(response.Reservations, Is.Not.Null);
    }    
    
    [Test]
    public async Task GetAllAvailableReservationHandler()
    {
        // Arrange
        var startTime = DateTime.Now;
        var endTime = DateTime.Now + TimeSpan.FromHours(5);
        var request = new GetAllAvailableReservationRequest(startTime, endTime);

        // Act
        var response = await _getAllAvailableReservationHandler.Handle(request, default);
        
        // Assert
        Assert.That(response.AvailableReservations, Is.Not.Null);
    }

    [Test]
    public async Task GetAllAvailableReservationValidator()
    {
        // Arrange
        var startTime = DateTime.Now;
        var endTime = startTime + TimeSpan.FromHours(5);
        var request = new GetAllAvailableReservationRequest(startTime, endTime);    
        
        // Act
        var validationResult = await _getAllAvailableReservationValidator.ValidateAsync(request);
        
        // Assert
        Assert.That(validationResult.IsValid, Is.True);
    }
}
