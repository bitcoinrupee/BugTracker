using BugTracker.Entities.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BugTracker.WebUI.Helper
{
    public interface IHttpClientHelper
    {
        Task CreateBug(BugDTO bug);
        Task<BugDTO> GetBugByID(int bugId);
        Task<IEnumerable<BugDTO>> GetBugList();
        Task SendAsync<T>(string segment, T obj);
    }
}