
using AFSocial.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AFSocial.Api.Registars;

public class DbRegistrar : IWebApplicationBuilderRegistar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        var cs = builder.Configuration.GetConnectionString("Default");
        builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(cs));
        builder.Services.AddIdentityCore<IdentityUser>().AddEntityFrameworkStores<DataContext>();
    }
}
