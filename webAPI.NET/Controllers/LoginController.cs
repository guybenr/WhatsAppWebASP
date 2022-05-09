using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webAPI.Models;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace webAPI.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
       private IContactService contactService = new ContactService();
       public IConfiguration _configuration;
       
        public LoginController(IConfiguration conf)
        {
            _configuration = conf;
        }

        // POST: LoginController/Create
        [HttpPost]
        public ActionResult userLogin([FromBody] LoginInfo loginInfo)
        {
            Contact user = contactService.Get(loginInfo.Username);
            if (user == null || user.Password != loginInfo.Password) //Invalid login details
            {
                return Ok(new string("Invalid username or password"));
            }
            // username and password correct, creating an authentication token
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["JWTParams:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
                new Claim("UserId", loginInfo.Username)
            };
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTParams:SecretKey"]));
            var mac = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["JWTParams:Issuer"], 
                _configuration["JWTParams:Audience"], 
                claims,
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: mac);
            contactService.setContact(user);
            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
