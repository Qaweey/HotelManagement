using DTOS.RequestDtos;
using HotelManagementAPI.DataModel;
using HotelManagementAPI.DTOS.ResponseDtos;
using HotelManagementAPI.ModelDtos;
using HotelManagementAPI.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        
        private readonly JWTSettings _jwtsettings;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;

        public AccountController(UserManager<ApplicationUser> userManager, IOptions<JWTSettings> jwtsettings, IEmailSender emailSender)
        {
            
            _jwtsettings = jwtsettings.Value;
            this._userManager = userManager;
            this._emailSender = emailSender;
        }
        // GET: api/<AccountController>
        [HttpPost("Registeruser")]

        public  async Task<IActionResult> Register([FromBody]SignUpDtocs model)
        {
            if (ModelState.IsValid)
            {
                var findsimilaremail =  await _userManager.FindByEmailAsync(model.Email);
                if (findsimilaremail is not null)
                {
                    return BadRequest(new Response {Success="False", Message="The email already exist" });
                      
                }
                var identityUser = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
   
                    
                };
               var registeredUser= await _userManager.CreateAsync(identityUser);
                if (registeredUser.Succeeded)
                {
                    var token = GenerateJwtToken(identityUser);
                    await _emailSender.sendEmail(model.Email);
                    return Ok(new Response() { Message = "The operation is successful",  Success = "true",Token=token });
                }


                return BadRequest(new Response { Success = "False", Message = "The operation was not successful" });


            }
            return BadRequest(new Response { Success = "False", Message = "Invalid data" });
        }


        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody]SignInDto model )
        {
            if (ModelState.IsValid)
            {
                var findEmail =  await _userManager.FindByEmailAsync(model.Email);
                if (findEmail is not null)
                {
                    
                    var comparePassword = await _userManager.CheckPasswordAsync(findEmail, model.Password);
                    if (comparePassword)
                    {
                        return Ok(new Response { Success = "true", Message = "You are successfully verified" });
                    }
                    return Unauthorized(new Response { Success = "false", Message = "You are not authorized" });

                }
                return BadRequest(new Response { Success = "false ", Message = "The email is not in the database" });

            }
            return BadRequest(new Response { Success = "False", Message = "Invalid Data" });

        }
        private string GenerateJwtToken(ApplicationUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_jwtsettings.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }

       
    }

}
