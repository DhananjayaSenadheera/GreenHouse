using MediatR;

namespace AccessControlService.Application.Requests.User.Commands.Delete;

public class DeleteUserComand :IRequest<bool>
{
    public Guid Id { get; set; }

    public DeleteUserComand(Guid id)
    {
        Id = id;
    }
}