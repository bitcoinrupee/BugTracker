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
    public class UserController : ControllerBase
    {
        private readonly IUserLogic _userlogic;
        public UserController(IUserLogic userlogic)
        {
            _userlogic = userlogic;
        }
        // GET: api/<UserController>
        [HttpGet("Get/{id}")]
        public UserDTO Get(int id)
        {
            return _userlogic.get(id);
        }
        [HttpGet("Search")]
        public IEnumerable<UserDTO> GetAll()
        {
            return _userlogic.getAllUsers();
        }


        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] UserDTO dto)
        {
            _userlogic.save(dto);
        }

       

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _userlogic.delete(id);
        }
    }
}
