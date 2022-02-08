using AliGulmen.Week5.HomeWork.RestfulApi.Attributes;
using AliGulmen.Week5.HomeWork.RestfulApi.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace AliGulmen.Week5.HomeWork.RestfulApi.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
       // private readonly IConfiguration _configuration;




        private readonly TokenGenerator _tokenGenerator; 
        public AccountController(TokenGenerator tokenGenerator, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _tokenGenerator = tokenGenerator;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        [HttpPost]
        public IActionResult Login([FromBody] User user)
        {
            Token token = new Token();

            if (user.PasswordHash == "1" && user.Email == "a@a.com")
            {
                token = _tokenGenerator.CreateToken(user);
                return Ok(token);
            }

            return Unauthorized();

        }


        //[HttpGet]
        //[CustomPermission("admin")]
        //public IActionResult IsLoggedIn(string username, string password)
        //{
        //    var pass = "1234";

        //    var permissions = typeof(AccountController)
        //        .GetMethod("IsLoggedIn")
        //        .GetCustomAttributes(typeof(CustomPermissionAttribute), true)
        //        .Cast<CustomPermissionAttribute>()
        //        .Select(attribute => attribute.Permission).ToArray();

        //    if(permissions.Any(parameter => parameter == username) && password == pass)
        //    return Ok();
        //    return Unauthorized();
        //}



    }
}
