using DataStorageService.Application.Helper;
using DataStorageService.Application.Requests.GreenHouses.DTOs;
using MediatR;

namespace DataStorageService.Application.Requests.GreenHouses.Commands.Create;

public class GreenHouseCreateCommand : IRequest<Result<bool>>
{
    public GreenHouseCreateDto GreenHouseCreateDto { get; set; }
}