using LogicSolution.Model;
using System.Threading.Tasks;

namespace LogicSolution.Services
{
    public interface IExtraSolutionService
    {
        Task<MetaData> ExtractMetaData(string link);
    }
}
