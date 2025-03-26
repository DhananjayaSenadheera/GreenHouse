using AutoMapper;
using DataAnalysingService.Application.Requests.GreenHouses.DTOs;
using DataAnalysingService.Application.Requests.SensorReadings.DTos;
using DataAnalysingService.Application.Requests.Sensors.DTOs;
using DataAnalysingService.Domain.Entities;

namespace DataAnalysingService.Application.Mappings;

public class ProfileMapper : Profile
{
    public ProfileMapper()
    {
        
        //***GreenHouse***
        CreateMap<Greenhouse, GreenHouseGetDto>();
        
        //***Sensor***
        CreateMap<Sensor, SensorGetDto>()
            .ForMember(dest => dest.GreenHouse_Code, opt => opt.MapFrom(src => src.Greenhouse.GreenHouse_Code))
            .ForMember(dest => dest.GreenHouse_Name, opt => opt.MapFrom(src => src.Greenhouse.Name));
       
       //***Sensor***
       //CreateMap<SensorReading, SensorReadingGetDto>();
       CreateMap<SensorReading, SensorReadingGetDto>()
           .ForMember(dest => dest.Sensor_Code, opt => opt.MapFrom(src => src.Sensor.Sensor_Code))
           .ForMember(dest => dest.Sensor_Name, opt => opt.MapFrom(src => src.Sensor.Name))
           .ForMember(dest => dest.GrnHouse_code, opt => opt.MapFrom(src => src.Sensor.Greenhouse.GreenHouse_Code))
           .ForMember(dest => dest.GrnHouse_name, opt => opt.MapFrom(src => src.Sensor.Greenhouse.Name))
           .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
           .ForMember(dest => dest.Unit, opt => opt.MapFrom(src => src.Unit))
           .ForMember(dest => dest.Plot_No, opt => opt.MapFrom(src => src.Plot_No))
           .ForMember(dest => dest.Created_Date, opt => opt.MapFrom(src => src.CreatedAt));
    }
}