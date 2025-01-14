using AccessControlService.Application.Requests.User.DTos;
using MediatR;

namespace AccessControlService.Application.Requests.User.Quaries.Get;

public class GetUserQuary : IRequest<GetUserDto>
{
    public Guid Id { get; set; }
    public GetUserQuary(Guid id)
    {
        Id = id;
    }
}