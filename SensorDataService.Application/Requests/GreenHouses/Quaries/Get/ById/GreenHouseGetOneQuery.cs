using MediatR;
using SensorDataService.Application.Helper;
using SensorDataService.Application.Requests.GreenHouses.DTOs;

namespace SensorDataService.Application.Requests.GreenHouses.Quaries.Get.ById;

public class GreenHouseGetOneQuery(Guid id) : IRequest<Result<GreenHouseGetDto>>
{ 
    public Guid Id { get; set; } = id;
}