using AutoMapper;
using SensorDataService.Domain.Entities;
using SensorDataService.Application.Requests.GreenHouses.Dtos;

namespace SensorDataService.Application.Requests.GreenHouses.Mappings;

public class ProfileMapper : Profile
{
    public ProfileMapper()
    {
        CreateMap<CreateDto, Greenhouse>();
    }
}