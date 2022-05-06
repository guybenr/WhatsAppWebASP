﻿using Microsoft.AspNetCore.Mvc;
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
                return StatusCode(404, "Page Not Found");
            }
            return Ok(contactService.GetAll());
        }

        // GET api/<ContactController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ContactController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ContactController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
