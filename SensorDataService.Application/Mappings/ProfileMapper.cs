using AutoMapper;
using SensorDataService.Application.Requests.GreenHouses.Dtos;
using SensorDataService.Application.Requests.SensorReadings.Quaries;
using SensorDataService.Application.Requests.Sensors.DTOs;
using SensorDataService.Domain.Entities;

namespace SensorDataService.Application.Mappings;

public class ProfileMapper : Profile
{
    public ProfileMapper()
    {
        
        //***Green House***
        CreateMap<GreenHouseCreateDto, Greenhouse>()
             .ForMember(desc => desc.GreenHouse_Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
             .ForMember(desc =>desc.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
             .ForMember(desc => desc.UpdatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow));
        CreateMap<GreenHouseUpdateDto, Greenhouse>()
            .ForMember(desc => desc.UpdatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null && !(srcMember is string str &&  string.IsNullOrWhiteSpace(str)) ));
        CreateMap<Greenhouse, GreenHouseGetDto>();
        
        //***Sensor***
        CreateMap<SensorCreateDto ,Sensor>()
            .ForMember(desc => desc.UpdatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(desc => desc.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(desc => desc.Sensor_Id, opt => opt.MapFrom(_ => Guid.NewGuid()));
       CreateMap<SensorUpdateDto , Sensor>()
           .ForMember(desc => desc.UpdatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
           .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null && !(srcMember is string str &&  string.IsNullOrWhiteSpace(str)) ));
       CreateMap<Sensor, SensorGetDto>();                                                                                                                                                                 
       // .ForMember(dest => dest.Greenhouse, opt => opt.Ignore());  // Avoid mapping the entire Greenhouse object
       CreateMap<SensorReadingCreateDTo, SensorReading>()
           .ForMember(desc => desc.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
           .ForMember(opt => opt.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
           .ForMember(opt => opt.UpdatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow));



    }
}