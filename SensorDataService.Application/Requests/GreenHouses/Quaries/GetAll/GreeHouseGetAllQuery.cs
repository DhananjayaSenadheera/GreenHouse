using MediatR;
using SensorDataService.Application.Helper;
using SensorDataService.Application.Requests.GreenHouses.Dtos;

namespace SensorDataService.Application.Requests.GreenHouses.Quaries.GetAll;

public class GreeHouseGetAllQuery : IRequest< Result<List<GreenHouseGetDto>>>
{
    // public List<GetDto> list { get; set; }
}