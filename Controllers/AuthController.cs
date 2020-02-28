using System.Text;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using tokentutor.Models;  
// using Microsoft.AspNetCore.JsonPatch;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using System.Security;

namespace tokentutor.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public IActionResult Authenticate(Auth auth){
            var auths = new List<Auth>(){
                new Auth(){Username = "John", Password = "Doe"},
                new Auth(){Username = "Jane", Password = "Doe"},
                new Auth(){Username = "John", Password = "Tron"}
            };

            var _auth = auths.First(e => e.Username == auth.Username);

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescription = new SecurityTokenDescriptor(){

                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.Name, _auth.Username),
                    new Claim(ClaimTypes.Sid, _auth.Password)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("ini secret yang sangat panjang sekali")), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescription);

            var tokenResponse = new{
                token = tokenHandler.WriteToken(token),
                user = _auth.Username
            };

            return Ok(tokenResponse);
        }
    }
}