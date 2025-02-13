
using AFSocial.Application.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AFSocial.Api.Registars;

public class IdentityRegistrar : IWebApplicationBuilderRegistar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        var jwtSettings = new JwtSettings();
        builder.Configuration.Bind(nameof(JwtSettings), jwtSettings);
        
        var jwtSection = builder.Configuration.GetSection(nameof(JwtSettings));
        builder.Services.Configure<JwtSettings>(jwtSection);

        builder.Services.AddAuthentication(a =>
        {
            a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            a.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(jwt =>
        {
            jwt.SaveToken = true;
            jwt.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.SigningKey)),
                ValidateIssuer = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidateAudience = true,
                ValidAudiences = jwtSettings.Audiences,
                RequireExpirationTime = false,
                ValidateLifetime = true,
            };
            jwt.Audience = jwtSettings.Audiences.FirstOrDefault();
            jwt.ClaimsIssuer = jwtSettings.Issuer;
        }).AddBearerToken(IdentityConstants.BearerScheme);
        builder.Services.AddAuthorizationBuilder();
    }
}
