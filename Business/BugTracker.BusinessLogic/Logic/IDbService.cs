using System.Threading.Tasks;

namespace BugTracker.BusinessLogic.Logic
{
    public interface IDbService
    {
        bool InitDB();
        Task<int> SaveAnyChanges();
    }
}