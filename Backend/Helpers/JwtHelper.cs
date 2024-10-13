using Application.DTO.Response;
using Data.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Backend.Helpers
{
    public class JwtHelper
    {
        private readonly IConfiguration configuration;
        public JwtHelper(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GenerateJwtToken(UserResponse user)
        {
            // Crear los claims (información del usuario)
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Guid.ToString()),
                new Claim(ClaimTypes.Name, $@"{user.Name} {user.LastName}"),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("name", $@"{user.Name} {user.LastName}"),
                new Claim("email", user.Email),
                new Claim("nameIdentifier", user.Guid.ToString())
            };

            // Obtener la clave secreta del archivo appsettings.json
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Crear el token con los parámetros definidos
            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),  // Establecer la expiración del token
                signingCredentials: creds);

            // Devolver el token generado como una cadena
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
