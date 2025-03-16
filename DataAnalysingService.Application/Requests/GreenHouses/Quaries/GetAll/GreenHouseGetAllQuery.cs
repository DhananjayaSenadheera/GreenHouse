using DataAnalysingService.Application.Helper;
using DataAnalysingService.Application.Requests.GreenHouses.DTOs;
using MediatR;

namespace DataAnalysingService.Application.Requests.GreenHouses.Quaries.GetAll;

public class GreenHouseGetAllQuery : IRequest<Result<List<GreenHouseGetDto>>>
{
    // public List<GetDto> list { get; set; }
}