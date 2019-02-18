using MessageService.Data.DTO;
using MessageService.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace MessageService.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        public IMessageRepository _MessageRepository;

        MessageController(IMessageRepository MessageRepository)
        {
            _MessageRepository = MessageRepository;
        }

        [Authorize(Policy = "User")]
        // GET api/message/Customer
        [HttpGet("User")]
        public ActionResult<IEnumerable<MessageDTO>> GetCustomerMessages()
        {
            int.TryParse(User.Claims.First(u => u.Type == "UserId").Value, out int userID);
            return Ok(_MessageRepository.CustomerMessages(userID));
        }

        // POST api/message
        [HttpPost]
        public void Post([FromBody] MessageDTO Message)
        {
            _MessageRepository.InsertMessage(Message);
        }
    }
}