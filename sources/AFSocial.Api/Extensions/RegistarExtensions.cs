using AFSocial.Api.Registars;

namespace AFSocial.Api.Extensions;

public static class RegistarExtensions
{
    public static void RegisterServices(this WebApplicationBuilder builder, Type scanningType)
    {
        var registrars = GetRegistrars<IWebApplicationBuilderRegistar>(scanningType);

        foreach (var registrar in registrars)
        {
            registrar.RegisterServices(builder);
        }
    }

    public static void RegisterPipelineComponents(this WebApplication app, Type scanningType)
    {
        var registrars = GetRegistrars<IWebApplicationRegistar>(scanningType);
        foreach (var registrar in registrars)
        {
            registrar.RegisterPipelineComponents(app);
        }
    }

    public static void RegisterDevPipelineComponents(this WebApplication app, Type scanningType)
    {
        var registrars = GetDevRegistrars<IWebApplicationDevRegistar>(scanningType);
        foreach (var registrar in registrars)
        {
            registrar.RegisterPipelineComponents(app);
        }
    }

    private static IEnumerable<T> GetRegistrars<T>(Type scanningType) where T : IRegistrar
    {
        return scanningType.Assembly.GetTypes()
            .Where(t => t.IsAssignableTo(typeof(T)) && !t.IsAbstract && !t.IsInterface)
            .Select(Activator.CreateInstance)
            .Cast<T>();
    }

    private static IEnumerable<T> GetDevRegistrars<T>(Type scanningType) where T : IRegistrarDev
    {
        return scanningType.Assembly.GetTypes()
            .Where(t => t.IsAssignableTo(typeof(T)) && !t.IsAbstract && !t.IsInterface)
            .Select(Activator.CreateInstance)
            .Cast<T>();
    }
}
