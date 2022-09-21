using BugTracker.BusinessLogic.Logic;
using BugTracker.Entities.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BugTracker.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BugController : ControllerBase
    {
        private readonly IBugLogic _bugLogic;
        public BugController(IBugLogic bugLogic)
        {
            _bugLogic = bugLogic;
        }
        // GET: api/<UserController>
        [HttpGet("Get/{id}")]
        public BugDTO Get(int id)
        {
            return _bugLogic.get(id);
        }
        [HttpGet("Search")]
        public IEnumerable<BugDTO> GetAll()
        {
            return _bugLogic.getAllBugs();
        }


        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] BugDTO dto)
        {
            _bugLogic.save(dto);
        }



        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _bugLogic.delete(id);
        }
    }
}
