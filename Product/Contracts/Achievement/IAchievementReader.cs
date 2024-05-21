namespace Product.Contracts.Achievement;
using Product.Models.Achievements;

public interface IAchievementReader
{
    Task<IEnumerable<Achievement>> GetAchievements();
    Task<Achievement> GetAchievementById(int achievementId);
}