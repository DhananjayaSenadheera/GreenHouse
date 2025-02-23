using DataAnalysingService.Application.Helper;
using DataAnalysingService.Application.Requests.GreenHouses.DTOs;
using MediatR;

namespace DataAnalysingService.Application.Requests.GreenHouses.Quaries.Get.ByCode;

public class GreenHouseGetOneByCodeQuery(string code) : IRequest<Result<GreenHouseGetDto>>
{
    public string Code { get; set; } = code;
}