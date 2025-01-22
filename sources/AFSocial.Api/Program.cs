using Asp.Versioning;

namespace AFSocial.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddApiVersioning(ops =>
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
        builder.Services.AddControllers();
        builder.Services.AddOpenApi();

        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwaggerUi(ops =>
            {
                ops.Path = "/openapi";
                ops.DocumentPath = "/openapi/v1.json";
                ops.DocumentPath = "/openapi/v2.json";
            });
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
