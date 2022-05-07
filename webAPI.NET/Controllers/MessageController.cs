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
        public IActionResult Post(string id, Message message)
        {
            if (!messageService.Add(id,message))
            {
                return StatusCode(404, "Contact Not Found");
            }
            return Ok();
        }

        // PUT api/<ContactController>/5
        [HttpPut("{id}/[controller]/{id2}")]
        public IActionResult Put(string id, int id2, string newContent)
        {
            if (!messageService.Edit(id2, id, newContent))
            {
                return StatusCode(404, "Message Not Found");
            }
            return Ok();
        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{id2}")]
        public IActionResult Delete(string id, int id2)
        {
            if (!messageService.Delete(id2, id))
            {
                return StatusCode(404, "Message Not Found");
            }
            return Ok();
        }
    }
}
