using AccessControlService.Application.Requests.User.Commands.Create;
using AccessControlService.Application.Requests.User.Commands.Update;
using AccessControlService.Application.Requests.User.DTOs;
using AutoMapper;

namespace AccessControlService.Application.Requests.User.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateUserCommand, Domain.Entities.User>();
        CreateMap<Domain.Entities.User, GetUserDto>();
        CreateMap<GetUserDto, Domain.Entities.User>();
        CreateMap<UpdateUserComand, Domain.Entities.User>();

    }
}
