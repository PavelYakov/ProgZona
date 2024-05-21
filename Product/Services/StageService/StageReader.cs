using Microsoft.EntityFrameworkCore;
using Product.Contracts.Stage;
using Product.Data.Context;
using Product.Models.Courses;
using Product.Models.Stages;

namespace Product.Services.StageService;

internal sealed class StageReader : IStageReader
{
    private readonly ProductContext _ctx;
    
    public StageReader(ProductContext ctx)
    {
        _ctx = ctx;
    }
    
    public async Task<IEnumerable<Stage>> GetStages()
    {
        var stagesEntities = await _ctx.Stages.ToListAsync();
        var stages = stagesEntities.Select(mc => new Stage
        {
            Id = mc.Id,
            Name = mc.Name,
            StagePoint = mc.StagePoint,
            Text = mc.Text
        }).ToList();
        
        return stages;
    }

    public async Task<Stage> GetStageById(int stageId)
    {
        var stageEntity = await _ctx.Stages.FirstOrDefaultAsync(mc => mc.Id == stageId);
        if (stageEntity == null)
        {
            // Вернуть null или бросить исключение, если курс с указанным идентификатором не найден
            return null;
        }

        
        var stage = new Stage
        {
            Id = stageEntity.Id,
            Name = stageEntity.Name,
            StagePoint = stageEntity.StagePoint,
            Text = stageEntity.Text
        };

        return stage;
    }
}