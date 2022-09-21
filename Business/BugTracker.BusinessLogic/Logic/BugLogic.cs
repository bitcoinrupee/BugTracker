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
    public class BugLogic : BaseLogic, IBugLogic
    {
        private readonly BugTrackerContext _Context;

        public BugLogic(BugTrackerContext Context) : base(Context)
        {
            _Context = Context;
        }
        public BugDTO get(int id)
        {
            BugDTO dto = null;
            var item =_Context.Bug.SingleOrDefault(d => d.BugID == id);
            if (item != null)
            {
                dto = CreateBugDTO(item);               

            }
            return dto;

        }

        public IEnumerable<BugDTO> getAllBugs()
        {
            List<BugDTO> list = new List<BugDTO>();
            _Context.Bug.ToList().ForEach(item =>
            {
                var dto = CreateBugDTO(item);                
                list.Add(dto);
            });
            return list;
        }
        public async Task save(BugDTO dto)
        {
            var item = _Context.Bug.SingleOrDefault(d => d.BugID == dto.BugID);
            if (item == null)
            {
                item = new Bug();
                item.DateCreated = DateTime.UtcNow;
            }
            else
            {
                item.DateModified = DateTime.UtcNow;
            }
            item.InjectFrom(new LoopInjection(new[] { "BugID", "DateCreated", "DateModified" }), dto);
            if (dto.BugID == 0)
                _Context.Bug.Add(item);
            else
                _Context.Bug.Update(item);
            await _Context.SaveChangesAsync();
        }
        public async Task delete(int id)
        {
            var item = _Context.Bug.SingleOrDefault(d => d.BugID == id);
            if (item != null)
            {
                _Context.Bug.Remove(item);
                await _Context.SaveChangesAsync();
            }
        }
    }
}
