using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AgendaApp.API.Configurations
{
    /// <summary>
    /// Classe de configuração para definir a politica de
    /// autenticação do projeto (JWT - JSON WEB TOKENS)
    /// </summary>
    public class JwtTokenConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey
                        (Encoding.UTF8.GetBytes("F5C1DF88-F772-4427-A799-224193C2B01A")) //mesma chave secreta utilizada no UsuariosApp para gerar o token
                };
            });
        }
    }
}



