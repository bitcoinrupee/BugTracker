using BugTracker.Data;
using BugTracker.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Omu.ValueInjecter;
using Omu.ValueInjecter.Injections;

namespace BugTracker.BusinessLogic.Logic
{
   public class UserLogic :BaseLogic, IUserLogic
    {
        private readonly BugTrackerContext _Context;

        public UserLogic(BugTrackerContext Context) : base(Context)
        {
            _Context = Context;
        }
        public UserDTO get(int id)
        {
            return getUser(id);
        }

        public IEnumerable<UserDTO> getAllUsers()
        {
            List<UserDTO> list = new List<UserDTO>();
            _Context.UserContact.ToList().ForEach(e =>
            {
                var dto = new UserDTO();
                dto.InjectFrom(e);
                list.Add(dto);
            });
            return list;
        }
        public async Task save(UserDTO dto)
        {
            var item = _Context.UserContact.SingleOrDefault(d => d.UserID == dto.UserID);
            if (item == null)
            {
                item = new UserContact();
                item.DateCreated = DateTime.UtcNow;
            }
            else
            {
                item.DateModified = DateTime.UtcNow;
            }
            item.InjectFrom(new LoopInjection(new[] { "UserID", "DateCreated" }),dto);
            if (dto.UserID == 0)
                _Context.UserContact.Add(item);
            else
                _Context.UserContact.Update(item);
            await _Context.SaveChangesAsync();
        }
        public async Task delete(int id)
        {
            var item = _Context.UserContact.SingleOrDefault(d => d.UserID == id);
            if (item != null)
            {
                _Context.UserContact.Remove(item);
                await _Context.SaveChangesAsync();
            }
        }

       
    }
}
