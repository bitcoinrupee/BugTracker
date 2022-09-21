using BugTracker.Entities.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BugTracker.BusinessLogic.Logic
{
    public interface IUserLogic
    {
        UserDTO get(int id);
        IEnumerable<UserDTO> getAllUsers();
        Task save(UserDTO dto);
        Task delete(int id);

    }
}