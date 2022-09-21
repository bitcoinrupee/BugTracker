using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Entities.DTO
{
    public class UserDTO:BaseDTO
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        
    }
}
