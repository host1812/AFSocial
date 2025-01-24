namespace AFSocial.Api.Registars;

public interface IWebApplicationDevRegistar : IRegistrarDev
{
    public void RegisterPipelineComponents(WebApplication app);
}
