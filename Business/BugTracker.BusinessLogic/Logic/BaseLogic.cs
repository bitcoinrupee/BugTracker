using BugTracker.Data;
using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BugTracker.Entities.DTO;
using Omu.ValueInjecter;
namespace BugTracker.BusinessLogic.Logic
{
    public abstract class BaseLogic
    {
        private readonly BugTrackerContext _Context;
        public BaseLogic(BugTrackerContext Context)
        {
            _Context = Context;
        }
        public UserDTO getUser(int id)
        {
            UserDTO dto = null;
            var item = _Context.UserContact.SingleOrDefault(d => d.UserID == id);
            if (item != null)
            {
                dto = new UserDTO();
                dto.InjectFrom(item);
            }
            return dto;

        }
        public BugDTO CreateBugDTO(Bug item)
        {
           var dto = new BugDTO();
            dto.InjectFrom(item);
            dto.Status =(Entities.Enums.BugStatus)item.BugStatusID;
            dto.AssignedUser = getUser(item.AssignedUserID);
            return dto;
        }



    }
}
