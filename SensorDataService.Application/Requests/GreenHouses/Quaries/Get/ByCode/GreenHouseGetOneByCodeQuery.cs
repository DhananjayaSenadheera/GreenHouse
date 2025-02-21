using MediatR;
using SensorDataService.Application.Helper;
using SensorDataService.Application.Requests.GreenHouses.DTOs;

namespace SensorDataService.Application.Requests.GreenHouses.Quaries.Get.ByCode;

public class GreenHouseGetOneByCodeQuery(string code) : IRequest<Result<GreenHouseGetDto>>
{
    public string Code { get; set; } = code;
}