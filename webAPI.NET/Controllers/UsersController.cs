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

/*        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.User.Add(user);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserExists(user.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }*/

        [HttpPost]
        public async Task<ActionResult> userLogin([FromBody] LoginInfo loginInfo)
        {
            var user = await _usersService.IsExist(loginInfo.Username, loginInfo.Password);
            if(user == null)
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
            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }

  /*  private bool UserExists(string id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }*/
}
