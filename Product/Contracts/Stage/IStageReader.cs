namespace Product.Contracts.Stage;
using Product.Models.Stages;

public interface IStageReader
{
    Task<IEnumerable<Stage>> GetStages();
    Task<Stage> GetStageById(int stageId);
}