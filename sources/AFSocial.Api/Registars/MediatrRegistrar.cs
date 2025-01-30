using System.Reflection;

namespace AFSocial.Api.Registars;

public class MediatrRegistrar : IWebApplicationBuilderRegistar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        var assemblies = Assembly.Load("AFSocial.Application");

        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));
    }
}
