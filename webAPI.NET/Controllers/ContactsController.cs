using Microsoft.AspNetCore.Mvc;
using webAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private static readonly IContactService contactService = new ContactService();
        public ContactsController()
        {
        }

        // GET: api/<ContactController>
        [HttpGet]
        public IActionResult Get()
        {
            if (contactService.GetAll() == null)
            {
                return StatusCode(404, "No Contacts Exist");
            }
            return Ok(contactService.GetAll());
        }

        // GET api/<ContactController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            Contact contact = contactService.Get(id);
            if (contact == null)
            {
                return StatusCode(404, "Contact Not Found");
            }
            return Ok(contact);
        }

        // POST api/<ContactController>
        [HttpPost]
        public IActionResult Post([FromBody] string newContact)
        {
            if (!contactService.Add(newContact))
            {
                return StatusCode(404, "Can't Add this Contect");
            }
            return Ok();
        }

        // PUT api/<ContactController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, string name)
        {
            if (!contactService.Edit(id, name))
            {
                return StatusCode(404, "Contact Not Found");
            }
            return Ok();
        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (!contactService.Delete(id))
            {
                return StatusCode(404, "Contact Not Found");
            }
            return Ok();
        }
    }
}
