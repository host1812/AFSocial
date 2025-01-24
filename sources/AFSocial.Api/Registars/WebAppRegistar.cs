
namespace AFSocial.Api.Registars;

public class WebAppRegistar : IWebApplicationRegistar
{
    public void RegisterPipelineComponents(WebApplication app)
    {
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
