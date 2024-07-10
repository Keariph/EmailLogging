using EmailLogging.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmailLogging
{
    /// <summary>
    /// Startes and configure the project
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddDbContext<EmailContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL")));
            builder.Services.AddControllers();
            var app = builder.Build();
            app.MapControllers();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=api}/{action=Mails}/{id?}");
            app.Run();
        }
    }
}
