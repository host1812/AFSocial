namespace AFSocial.Api.Registars;

public class MediatrRegistrar : IWebApplicationBuilderRegistar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(
            cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
    }
}
