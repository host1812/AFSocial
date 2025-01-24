using Asp.Versioning;
using Scalar.AspNetCore;

namespace AFSocial.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            
        }


    }
}
