using DataStorageService.Application.Helper;
using DataStorageService.Application.Requests.GreenHouses.DTOs;
using MediatR;

namespace DataStorageService.Application.Requests.GreenHouses.Commands.Update;

public class GreenHouseUpdateCommand : IRequest<Result<bool>>
{
    public GreenHouseUpdateDto GreenHouseUpdateDto { get; set; }
}