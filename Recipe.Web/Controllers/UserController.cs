using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipe.Model;
using Recipe.Web.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Recipe.Web.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IUserService _userService;
        private AppSettings _appSettings;

        public UserController(IUserService userService, AppSettings appSettings)
        {
            _userService = userService;
            _appSettings = appSettings;
        }

        [HttpPost("[action]")]
        public IActionResult Authenticate([FromBody]User userDto)
        {
            var user = _userService.Authenticate(userDto.Username, userDto.Password);

            if (user == null)
                return Unauthorized();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.HashKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info (without password) and token to store client side
            return Ok(new
            {
                Id = user.Id,
                Username = user.Result.Username,
                FirstName = user.Result.FirstName,
                LastName = user.Result.LastName,
                Token = tokenString
            });
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public IActionResult Register([FromBody]User user)
        {
            try
            {
                // save 
                _userService.Create(user, user.Password);
                return Ok();
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);

            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]User user)
        {
            user.Id = id;

            try
            {
                // save 
                _userService.Update(user, user.Password);
                return Ok();
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok();
        }

    }
}