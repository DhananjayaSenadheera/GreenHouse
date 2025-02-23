using DataAnalysingService.Application.Helper;
using DataAnalysingService.Application.Requests.GreenHouses.DTOs;
using MediatR;

namespace DataAnalysingService.Application.Requests.GreenHouses.Quaries.Get.ById;

public class GreenHouseGetOneQuery(Guid id) : IRequest<Result<GreenHouseGetDto>>
{ 
    public Guid Id { get; set; } = id;
}