
using Microsoft.EntityFrameworkCore.Design;
using PersonalBrand.API.PersonalIdentity;
using PersonalBrand.Application;
using PersonalBrand.Infrastructure;
using Serilog;                                      // AddSerilog, Log.Logger |ishlashi uchun 

namespace PersonalBrand.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // ILogggerni sozlash
            builder.Services.AddLogging(logging =>
            {
                logging.AddSerilog(dispose: true);      // AddSerilog togri ishlashi uchun [Serilog.Extensions.Logging] o'rnatilishi kerak
            });

            Log.Logger = new LoggerConfiguration()
           .WriteTo.Console(
               theme: Serilog.Sinks.SystemConsole.Themes.AnsiConsoleTheme.Sixteen) // theme togri ishlashi uchun [Serilog.Sinks.Console] o'rnatilishi kerak
                                                                                   // theme: Consolga rangli qilib yozish uchun kerak            ^^^^^^^ --> boshqa stylar ham mavjud
           .WriteTo.File("logs/app.log", rollingInterval: RollingInterval.Day) // .WriteTo.File tog'ri ishlashi uchun [Serilog.Sinks.File] o'rnatilishi kerak
           .CreateLogger();


            builder.Services.AddControllers();
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddApplication();
            builder.Services.AddIdentity();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }

    }
}















