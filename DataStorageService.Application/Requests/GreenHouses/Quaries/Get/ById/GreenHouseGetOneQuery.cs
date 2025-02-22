using DataStorageService.Application.Helper;
using DataStorageService.Application.Requests.GreenHouses.DTOs;
using MediatR;

namespace DataStorageService.Application.Requests.GreenHouses.Quaries.Get.ById;

public class GreenHouseGetOneQuery(Guid id) : IRequest<Result<GreenHouseGetDto>>
{ 
    public Guid Id { get; set; } = id;
}