using AutoMapper;
using MediatR;
using SensorDataService.Application.Helper;
using SensorDataService.Domain.Entities;
using SensorDataService.Domain.Interfaces;

namespace SensorDataService.Application.Requests.GreenHouses.Commands.Create;

public class GreenHouseCreateCommandHandler : IRequestHandler<GreenHouseCreateCommand ,Result<bool>>
{
    private readonly IGreenHouseRepository _repository;
    private readonly IMapper _mapper;

    public GreenHouseCreateCommandHandler(IGreenHouseRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<Result<bool>> Handle(GreenHouseCreateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result =  _mapper.Map<Greenhouse>(request.CreateDto);
            await _repository.Add(result);
            return Result<bool>.Success(true);
        }
        catch (Exception ex)
        {
            return Result<bool>.Failure($"Failed to create Greenhouse.{ex.Message}");
        }
    }
}