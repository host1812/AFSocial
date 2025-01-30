using AFSocial.Api.Extensions;

namespace AFSocial.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.RegisterServices(typeof(Program));
        
        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.RegisterDevPipelineComponents(typeof(Program));
        }
        app.RegisterPipelineComponents(typeof(Program));

    }
}
