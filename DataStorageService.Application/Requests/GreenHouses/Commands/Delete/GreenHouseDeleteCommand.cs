using DataStorageService.Application.Helper;
using MediatR;

namespace DataStorageService.Application.Requests.GreenHouses.Commands.Delete;

public class GreenHouseDeleteCommand : IRequest<Result<bool>>
{
     public Guid Id { get; set; }
}