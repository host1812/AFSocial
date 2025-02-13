
namespace AFSocial.Api.Registars;

public class OpenApiRegistar : IWebApplicationBuilderRegistar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddOpenApi("v1", options => { options.AddDocumentTransformer<BearerSecuritySchemeTransformer>(); });
        builder.Services.AddOpenApi("v2");
    }
}
