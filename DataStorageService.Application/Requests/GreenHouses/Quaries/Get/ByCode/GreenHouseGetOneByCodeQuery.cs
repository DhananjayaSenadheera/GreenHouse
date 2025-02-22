using DataStorageService.Application.Helper;
using DataStorageService.Application.Requests.GreenHouses.DTOs;
using MediatR;

namespace DataStorageService.Application.Requests.GreenHouses.Quaries.Get.ByCode;

public class GreenHouseGetOneByCodeQuery(string code) : IRequest<Result<GreenHouseGetDto>>
{
    public string Code { get; set; } = code;
}