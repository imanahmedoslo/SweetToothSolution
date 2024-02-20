using SweetTooth.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using SweetTooth.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace SweetTooth.Controllers
{
    
        [Route("api/[controller]")]
        [ApiController]
        public class LoginController : ControllerBase
        {
            private IConfiguration _config;
            private readonly SweetToothDbContext _context;
            public LoginController(IConfiguration config, SweetToothDbContext context)
            {
                _config = config;
                _context = context;
            }

            [HttpPost()]
            public async Task<IActionResult> Post([FromBody] LoginRequest loginRequest)
            {
               Employee? Employee = await _context.Employees.Include(x => x.StaffMembersInfo).FirstOrDefaultAsync(user => user.UserName == loginRequest.Email && user.Password == loginRequest.Password); //Email is here a stand in for UserName, loginRequest does not accept userName.
                if (Employee == null)
                {
                    return NotFound();
                }


                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"],
                  _config["Jwt:Issuer"],
                  new List<Claim>() { new Claim("fullname", Employee.StaffMembersInfo?.FullName ?? ""), new Claim("id", Employee.Id.ToString()) },
                  expires: DateTime.Now.AddMinutes(120),
                  signingCredentials: credentials); ;

                var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

                return Ok(new
                {
                    AccessToken = token,
                    ExpiresAt = Sectoken.ValidTo,
                });
            }
        }
    

}
