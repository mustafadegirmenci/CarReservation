using AutoMapper;
using CarReservation.Application.Features.CarFeatures.CreateCar;
using CarReservation.Application.Features.CarFeatures.UpdateCar;
using CarReservation.Application.Features.ReservationFeatures.CreateReservation;
using CarReservation.Persistence.Context;
using CarReservation.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CarReservation.UnitTest;

public class ReservationTests
{
    private DbContextOptions<DataContext> _dbContextOptions;
    private DataContext _dataContext;
    private UnitOfWork _unitOfWork;
    
    private ReservationRepository _reservationRepository;
    
    private CreateReservationHandler _createReservationHandler;
    private CreateReservationValidator _createReservationValidator;

    [SetUp]
    public void Setup()
    {
        _dbContextOptions = new DbContextOptions<DataContext>();
        _dataContext = new DataContext(_dbContextOptions);
        _reservationRepository = new ReservationRepository(_dataContext);
        _unitOfWork = new UnitOfWork(_dataContext);

        _createReservationHandler = new CreateReservationHandler(_unitOfWork, _reservationRepository, 
            new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CreateReservationMapper>();
            }).CreateMapper());
        _createReservationValidator = new CreateReservationValidator();
    }

    [Test]
    public async Task CreateReservationValidator()
    {
        // Arrange
        var request = new CreateReservationRequest(Guid.NewGuid(), DateTime.Now + TimeSpan.FromHours(3),
            DateTime.Now + TimeSpan.FromHours(4));
        
        // Act
        var validationResult = await _createReservationValidator.ValidateAsync(request);
        
        // Assert
        Assert.That(validationResult.IsValid, Is.True);
    }
}
