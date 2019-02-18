using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessageService.Data.DTO;
using MessageService.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MessageService.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserRepository _UserRepository;

        UserController(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }

        [Authorize(Policy = "Customer")]
        // GET api/message/Customer
        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> GetUser(int UserID)
        {
            return Ok(_UserRepository.GetUser(UserID));
        }

        // POST api/message
        [HttpPost]
        public IActionResult Post([FromBody] UserDTO User)
        {
            _UserRepository.InsertUser(User);
            return Ok();
        }

        [Authorize(Policy = "Admin")]
        // DELETE api/message?id=5
        [HttpDelete]
        public IActionResult Delete(int CustomerID)
        {
            try{
                _UserRepository.DeleteUser(CustomerID);
            }
            catch {
                return BadRequest();
            }
            return Ok();
        }


    }
}