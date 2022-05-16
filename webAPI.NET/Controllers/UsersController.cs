using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webAPI.Models;
using webAPI.NET.Data;
using webAPI.NET.Services;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace webAPI.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _usersService;
        public IConfiguration _configuration;

        public UsersController(IUserService service, IConfiguration conf)
        {
            _usersService = service;
            _configuration = conf;
        }

        // GET: api/Users
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst("UserId").Value;
            var user = await _usersService.GetUser(userId);
            return Ok(user);
        }

        // POST: api/users/register - function adding a new user to the database and generate a token
        [Route("register")]
        [HttpPost]
        public async Task<ActionResult<User>> PostUser([FromBody] User user)
        {
            //User u = new User(user.Id, user.Name, user.Password, user.Image);
            var hasAdded = await _usersService.AddUser(user);
            if(hasAdded)
            {
                return Ok(GenerateToken(user.Id));
            }
            return BadRequest(new string("Username already taken"));
        }

        private string GenerateToken(string username)
        {
            var claims = new[]
           {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["JWTParams:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
                new Claim("UserId", username)
            };
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTParams:SecretKey"]));
            var mac = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["JWTParams:Issuer"],
                _configuration["JWTParams:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: mac);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [Route("login")]
        [HttpPost]
        public async Task<ActionResult> userLogin([FromBody] LoginInfo loginInfo)
        {
            var user = await _usersService.IsExist(loginInfo.Username, loginInfo.Password);
            if(user == null)
            {
                return Ok(new string("Invalid username or password"));
            }
            // username and password correct, creating an authentication token
            return Ok(GenerateToken(loginInfo.Username));
        }
    }
}
