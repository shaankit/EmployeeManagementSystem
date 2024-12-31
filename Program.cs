using Microsoft.EntityFrameworkCore;



namespace EmployeeManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
                            
            builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=employees.db"));

            // builder.Services.AddScoped<TokenService>();

            builder.Services.AddEndpointsApiExplorer();
            
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.MapControllers();

            // Database Migration
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                dbContext.Database.EnsureCreated();
            }

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Employee}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
