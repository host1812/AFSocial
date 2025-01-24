using AFSocial.Api.Registars;

namespace AFSocial.Api.Extensions;

public static class RegistarExtensions
{
    public static void RegisterServices(this WebApplicationBuilder builder, Type scanningType)
    {
        var registars = scanningType.Assembly.GetTypes()
            .Where(t => t.IsAssignableTo<IWebApplicationBuilderRegistar>);
    }

    public static void RegisterPipelineComponents(this WebApplication app, Type scanningType)
    {

    }
}
