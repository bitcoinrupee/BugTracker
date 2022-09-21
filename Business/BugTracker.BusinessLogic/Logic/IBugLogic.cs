using BugTracker.Entities.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BugTracker.BusinessLogic.Logic
{
    public interface IBugLogic
    {
        BugDTO get(int id);
        IEnumerable<BugDTO> getAllBugs();
        Task save(BugDTO dto);
        Task delete(int id);
    }
}