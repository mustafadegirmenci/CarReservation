using MediatR;

namespace CarReservation.Application.Features.UserFeatures.CreateUser;

public sealed record CreateUserRequest(string Email, string Name) : IRequest<CreateUserResponse>;