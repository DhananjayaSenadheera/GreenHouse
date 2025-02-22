using DataStorageService.Application.Helper;
using DataStorageService.Application.Requests.GreenHouses.DTOs;
using MediatR;

namespace DataStorageService.Application.Requests.GreenHouses.Quaries.GetAll;

public class GreeHouseGetAllQuery : IRequest< Result<List<GreenHouseGetDto>>>
{
    // public List<GetDto> list { get; set; }
}