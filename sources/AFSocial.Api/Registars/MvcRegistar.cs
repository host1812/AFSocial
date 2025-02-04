
using AFSocial.Api.Filters;
using Asp.Versioning;

namespace AFSocial.Api.Registars;

public class MvcRegistar : IWebApplicationBuilderRegistar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services
            .AddApiVersioning(ops =>
            {
                ops.DefaultApiVersion = new ApiVersion(1);
                ops.AssumeDefaultVersionWhenUnspecified = true;
                ops.ReportApiVersions = true;
                ops.ApiVersionReader = new UrlSegmentApiVersionReader();
            })
            .AddMvc()
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
        builder.Services.AddControllers(cfg => 
        {
            cfg.Filters.Add<HandleExceptionAttribute>();
        });
    }
}
