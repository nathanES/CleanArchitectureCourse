using GymManagement.Domain.Rooms;
using MediatR;
using ErrorOr;

namespace GymManagement.Application.Rooms.Commands.CreateRoom;

public record CreateRoomCommand(
    Guid GymId,
    string RoomName) : IRequest<ErrorOr<Room>>;