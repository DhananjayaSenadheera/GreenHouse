using AutoMapper;
using SensorDataService.Domain.Entities;
using SensorDataService.Application.Requests.GreenHouses.Dtos;

namespace SensorDataService.Application.Requests.GreenHouses.Mappings;

public class ProfileMapper : Profile
{
    public ProfileMapper()
    {
        CreateMap<CreateDto, Greenhouse>()
             .ForMember(desc => desc.GreenHouse_Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
             .ForMember(desc =>desc.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
             .ForMember(desc => desc.UpdatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow));
        CreateMap<UpdateDto, Greenhouse>()
            .ForMember(desc => desc.UpdatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null && !(srcMember is string str &&  string.IsNullOrWhiteSpace(str)) ));
        CreateMap<Greenhouse, GetDto>();
    }
}