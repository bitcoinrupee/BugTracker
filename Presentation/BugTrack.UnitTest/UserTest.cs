using BugTracker.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BugTrack.UnitTest
{
    public class userTest
    {
        [Fact]
        public void Test1()
        {

            var user = new UserDTO { UserID=1, Name="test user 1" };

            // Assert           
            Assert.NotNull(user);
            Assert.NotNull(user.Name);
        }

    }
}