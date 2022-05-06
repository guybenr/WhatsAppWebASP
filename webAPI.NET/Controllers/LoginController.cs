using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webAPI.Models;

namespace webAPI.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
       IContactService contactService = new ContactService();

        // POST: LoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult userLogin([FromBody] LoginInfo loginInfo)
        {
            Contact user = contactService.GetAll().Where(x => x.Id.Equals(loginInfo.Username) && x.Password.Equals(loginInfo.Password)).FirstOrDefault();
            if (user == null)
            {
                return Ok(new Response ("Invalid","Invalid User." ));
            }
            contactService.setContact(user);
            return Ok(new Response ("Success","Login Successfully" ));
        }
    }
}
