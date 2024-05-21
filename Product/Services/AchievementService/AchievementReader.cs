using Microsoft.EntityFrameworkCore;
using Product.Contracts.Achievement;
using Product.Data.Context;
using Product.Models.Achievements;

namespace Product.Services.AchievementService;

internal sealed class AchievementReader:IAchievementReader
{
    private readonly ProductContext _ctx;

    public AchievementReader(ProductContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<IEnumerable<Achievement>> GetAchievements()
    {
        var achivs = await _ctx.Achievements.ToListAsync();
        var achiv = achivs.Select(ach => new Achievement
        {
            Id = ach.Id,
            Name = ach.Name,
            Description = ach.Description
        }).ToList();
        
        return achiv;
    }

    public  async Task<Achievement> GetAchievementById(int achievementId)
    {
        var achiv = await _ctx.Achievements.FirstOrDefaultAsync(ac=>ac.Id==achievementId);
        
        if (achiv == null)
        {
            return null;
        }

        
        var achievement = new Achievement
        {
            Id = achiv.Id,
            Name =achiv.Name,
            Description = achiv.Description,
        };
        
        return achievement;
        
    }
}