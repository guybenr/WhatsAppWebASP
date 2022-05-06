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
        public void Post([FromBody] string newContact)
        {
            contactService.Add(newContact);
        }

        // PUT api/<ContactController>/5
        [HttpPut("{id}")]
        public void Put(string id, string name)
        {
            contactService.Edit(id, name);
        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            contactService.Delete(id);
        }
    }
}
