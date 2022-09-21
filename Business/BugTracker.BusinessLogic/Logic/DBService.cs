using BugTracker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.BusinessLogic.Logic
{
    public class DbService : IDbService
    {
        private readonly BugTrackerContext _context;
        public DbService(BugTrackerContext context)
        {
            _context = context;
        }
        public bool InitDB()
        {
            var cleared = _context.Database.EnsureDeleted();
            var created = _context.Database.EnsureCreated();
            _context.UserContact.Add(new UserContact {Name="User test 1", DateCreated=DateTime.UtcNow });
            _context.UserContact.Add(new UserContact { Name = "User test 2", DateCreated = DateTime.UtcNow });
            _context.BugStatus.Add(new BugStatus { BugStatusID=1,BugStatusName="Open" });
            _context.BugStatus.Add(new BugStatus { BugStatusID = 2, BugStatusName = "Resolved" });
            _context.BugStatus.Add(new BugStatus { BugStatusID = 3, BugStatusName = "Closed" });
            _context.BugStatus.Add(new BugStatus { BugStatusID = 4, BugStatusName = "Unknow" });

            _context.Bug.Add(new Bug { AssignedUserID=1, BugTitle="test 1", BugDescription="this is test 1", DateCreated=DateTime.UtcNow, BugStatusID=1 });
            _context.Bug.Add(new Bug { AssignedUserID = 2, BugTitle = "test 2", BugDescription = "this is test 2", DateCreated = DateTime.UtcNow, BugStatusID = 1 });

            var entitiesadded = _context.SaveChanges();

            return (cleared && created && entitiesadded == 0);
        }



        public async Task<int> SaveAnyChanges()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
