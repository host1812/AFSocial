
namespace AFSocial.Api.Registars;

public class OpenApiRegistar : IWebApplicationBuilderRegistar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddOpenApi("v1");
        builder.Services.AddOpenApi("v2");
    }
}
