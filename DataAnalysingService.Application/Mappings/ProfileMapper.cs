using AutoMapper;
using DataAnalysingService.Application.Requests.GreenHouses.DTOs;
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
       CreateMap<Sensor, SensorGetDto>();                                                                                                                                                                 
    }
}