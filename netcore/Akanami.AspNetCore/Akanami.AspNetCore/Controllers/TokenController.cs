using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Akanami.AspNetCore.Configurations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Akanami.AspNetCore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly JwtOptions jwtOptions;

        public TokenController(JwtOptions jwtOptions)
        {
            this.jwtOptions = jwtOptions;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<string> Login([FromBody]LoginRequestDto request)
        {
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("id", "1", ClaimValueTypes.String),
                new Claim("name", request.Name)
            };

            var token = new JwtSecurityToken
                (
                    issuer: this.jwtOptions.Issuer,
                    audience: this.jwtOptions.Audience,
                    signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecurityKey)),
                        SecurityAlgorithms.HmacSha256Signature),
                    claims: claims,
                    expires: DateTime.Now.AddDays(10)
                );

            string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return await Task.FromResult(jwtToken);
        }

        [HttpGet]
        [Authorize]
        public async Task<object> GetUser()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (var item in this.User.Claims)
            {
                dict.Add(item.Type, item.Value);
            }

            return await Task.FromResult(dict);
        }
    }

    public class LoginRequestDto
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}