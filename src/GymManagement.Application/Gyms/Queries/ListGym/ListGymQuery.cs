using GymManagement.Domain.Gyms;
using MediatR;
using ErrorOr;

namespace GymManagement.Application.Gyms.Queries.ListGym;

public record ListGymsQuery(Guid SubscriptionId) : IRequest<ErrorOr<List<Gym>>>;