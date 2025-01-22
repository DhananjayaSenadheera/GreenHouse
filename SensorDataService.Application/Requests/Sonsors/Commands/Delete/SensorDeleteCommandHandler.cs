using MediatR;
using SensorDataService.Application.Helper;
using SensorDataService.Domain.Interfaces;

namespace SensorDataService.Application.Requests.Sonsors.Commands.Delete;

public class SensorDeleteCommandHandler : IRequestHandler<SensorDeleteCommand , Result<bool>>
{
    private readonly ISensorsRepository _sensorsRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SensorDeleteCommandHandler(ISensorsRepository sensorsRepository, IUnitOfWork unitOfWork)
    {
        _sensorsRepository = sensorsRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result<bool>> Handle(SensorDeleteCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var existingSensor = await _sensorsRepository.GetOneById(request.Id);
            if (existingSensor == null)
                return Result<bool>.Failure("Sensor not found");
            _sensorsRepository.Delete(existingSensor);
            await _unitOfWork.CommitAsync();
            return Result<bool>.Success(true);
        }
        catch (Exception e)
        {
            return Result<bool>.Failure($" Error occured while deleting data: {e.Message}");
        }
    }
}