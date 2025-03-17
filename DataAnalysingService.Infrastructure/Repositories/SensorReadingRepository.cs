using DataAnalysingService.Domain.Entities;
using DataAnalysingService.Domain.Interfaces;

namespace DataAnalysingService.Infrastructure.Repositories;

public class SensorReadingRepository(IGenericRepository<SensorReading> repository) : ISensorReadingsRepository
{
    public async Task<IEnumerable<SensorReading>> GetAll()
    {
        return await repository.GetAllAsync();
    }

    public async Task<SensorReading> GetOneById(Guid guid)
    {
        return await repository.GetByIdAsync(guid);
    }

    public async Task<List<SensorReading>> GetAllInclude()
    {
        var result = await repository.GetAllAsyncInclude(x => x.Sensor,x => x.Sensor.Greenhouse); 
        //return (List<SensorReading>)result;
        return result.Select(sr => new SensorReading
        {
            Id = sr.Id,
            CreatedAt = sr.CreatedAt,
            Unit =sr.Unit,
            Value = sr.Value,
            Plot_No = sr.Plot_No,
            Sensor = new Sensor
            {
                Sensor_Id = sr.Sensor.Sensor_Id,
                Name = sr.Sensor.Name,
                Sensor_Code = sr.Sensor.Sensor_Code,
                Status = sr.Sensor.Status,
                Greenhouse = sr.Sensor.Greenhouse,
            }
        }).ToList();
    }
}