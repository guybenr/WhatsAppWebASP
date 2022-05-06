using Microsoft.AspNetCore.Mvc;
using webAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService contactService;
        public ContactsController()
        {
            contactService = new ContactService();
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
        public void Post([FromBody] Contact newContact)
        {
            contactService.Add(newContact);
        }

        // PUT api/<ContactController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Contact newContact)
        {
            contactService.Edit(id, newContact);
        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            contactService.Delete(id);
        }
    }
}
