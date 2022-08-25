using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;


namespace MovieWebAppAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;
        private readonly IConfiguration configuration;
        public AccountController(IAccountService _acc, IConfiguration con)
        {
            accountService = _acc;
            configuration = con;
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(UserLoginRequestModel loginRequest)
        {
            var user = await accountService.Validate(loginRequest.Email, loginRequest.Password);
            if (user == null)
            {
                return Unauthorized("Invalid Username or Password");
            }
            //add jwt token
            var token = GenerateJWT(user);
            var tokenValue = new { jwt = token };
            return Ok(tokenValue);
        }

        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterRequestModel model)
        {
            try
            {
                var result = await accountService.Register(model);
                var response = new { Message = "User Registered Successfully" };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        private string GenerateJWT(UserLoginResponseModel model)
        {
            var claims = new List<Claim> {
            new Claim(ClaimTypes.NameIdentifier, model.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, model.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, model.LastName),
            new Claim(JwtRegisteredClaimNames.Email, model.Email),
            new Claim(JwtRegisteredClaimNames.Birthdate,model.DateOfBirth.ToShortDateString()),
            new Claim("language","english")
            };

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);


            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["PrivateKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var expire = DateTime.UtcNow.AddHours(Convert.ToDouble(configuration["ExpirationHours"]));

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokendescription = new SecurityTokenDescriptor
            {
                Subject = identityClaims,
                Expires = expire,
                SigningCredentials = credentials,
                Issuer = configuration["Issuer"],
                Audience = configuration["Audience"]

            };

            var token = tokenHandler.CreateToken(tokendescription);
            return tokenHandler.WriteToken(token);

        }
    }
}
