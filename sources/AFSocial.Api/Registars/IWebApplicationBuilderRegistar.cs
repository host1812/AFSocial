namespace AFSocial.Api.Registars;

public interface IWebApplicationBuilderRegistar : IRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder);
}
