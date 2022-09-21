using BugTracker.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BugTrack.UnitTest
{
    public class BugTest
    {
        [Fact]
        public void Test1()
        {
           
            var bug = new BugDTO { BugID = 1, BugTitle = "test 1", AssignedUser = new UserDTO { Name = "test User 1", UserID = 1 }, BugDescription = "this is test 1" };
           
            // Assert
            Assert.NotNull(bug.BugTitle);
            Assert.NotNull(bug.AssignedUser);
        }
        
   


    }
}
