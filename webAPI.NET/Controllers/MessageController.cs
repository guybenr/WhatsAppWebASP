using Microsoft.AspNetCore.Mvc;
using webAPI.Models;

namespace webAPI.NET.Controllers
{
    [Route("api/contact")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private static readonly IMessageService messageService = new MessageService();

        public MessageController()
        {
        }







        // GET: api/<ContactController>
        [HttpGet("{id}/[controller]")]
        public IActionResult Get(string id)
        {
            if (messageService.GetAll(id) == null)
            {
                return StatusCode(404, "No Messages Exist");
            }
            return Ok(messageService.GetAll(id));
        }

        // GET api/<ContactController>/5
        [HttpGet("{id}/[controller]/{id2}")]
        public IActionResult Get(string id, int id2)
        {
            Message message = messageService.Get(id2,id);
            if (message == null)
            {
                return StatusCode(404, "Message Not Found");
            }
            return Ok(message);
        }

        // POST api/<ContactController>
        [HttpPost("{id}/[controller]")]
        public void Post(string id, Message message)
        {
            messageService.Add(id,message);
        }

        // PUT api/<ContactController>/5
        [HttpPut("{id}/[controller]/{id2}")]
        public void Put(string id, int id2, Message message)
        {
            messageService.Edit(id2, id, message);
        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{id2}")]
        public void Delete(string id, int id2)
        {
            messageService.Delete(id2, id);
        }
    }
}
