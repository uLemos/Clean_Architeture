using CleanArchMVC.API.DTOs;
using CleanArchMVC.Domain.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticate _authentication;
        private readonly IConfiguration _configuration;

        public TokenController(IAuthenticate authentication, IConfiguration configuration)
        {
            _authentication = authentication ?? 
                throw new ArgumentException(nameof(authentication));
            _configuration = configuration;
        }

        [HttpPost("CreateUser")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult> CreateUser([FromBody] LoginDto userInfo)
        {
            var result = await _authentication.RegisterUser(userInfo.Email, userInfo.Password);

            if (result)
                return Ok($"User {userInfo.Email} was create Successfully");
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid create attempt");
                return BadRequest(ModelState);
            }
        }


        [HttpPost("LoginUser")]
        public async Task<ActionResult<UserToken>> Login([FromBody] LoginDto userInfo)
        {
            var result = await _authentication.Authenticate(userInfo.Email, userInfo.Password);

            if (result)
                return GenerateToken(userInfo);
            else
            {
                ModelState.AddModelError(String.Empty, "Invalid Login attempt");
                return BadRequest(ModelState);
            }
        }

        private ActionResult<UserToken> GenerateToken(LoginDto userInfo)
        {
            //Declarações do Usuário
            var claims = new[]
            {
                new Claim("email", userInfo.Email),
                new Claim("meuValor", "É isso aí"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            //Gerar chave privada para assinar o Token
            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));

            //Gerar a assinatura Digital do Token
            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

            //Definir o tempo da expiração do token
            var expiration = DateTime.UtcNow.AddMinutes(10);

            //Gerar o Token
            JwtSecurityToken token = new JwtSecurityToken(
                //emissor
                issuer: _configuration["Jwt:Issuer"],
                //audience
                audience: _configuration["Jwt:Audience"],
                //claims
                claims: claims,
                //data de expiração
                expires: expiration,
                //assinatura digital
                signingCredentials: credentials
            );

            return new UserToken
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration,
            };
        }
    }
}
