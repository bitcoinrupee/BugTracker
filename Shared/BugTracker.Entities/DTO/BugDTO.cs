using BugTracker.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Entities.DTO
{
    public class BugDTO:BaseDTO
    {
        public int BugID { get; set; }
        public string BugTitle { get; set; }
        public string BugDescription { get; set; }
        public UserDTO AssignedUser { get; set; }
        public BugStatus Status { get; set; }
    }
}
