
using Scalar.AspNetCore;

namespace AFSocial.Api.Registars;

public class SwagRegistar : IWebApplicationRegistar
{
    public void RegisterPipelineComponents(WebApplication app)
    {
        app.MapScalarApiReference(cfg => cfg.Theme = ScalarTheme.BluePlanet);
        app.MapOpenApi();
        app.UseSwaggerUi(ops =>
        {
            ops.Path = "/openapi";
            ops.DocumentPath = "/openapi/v1.json";
        });
    }
}
