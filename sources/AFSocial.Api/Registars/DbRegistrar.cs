
using AFSocial.Data;

namespace AFSocial.Api.Registars;

public class DbRegistrar : IWebApplicationBuilderRegistar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        var cs = builder.Configuration.GetConnectionString("Default");
        builder.Services.AddDbContext<DataContext>();
    }
}
