using Microsoft.EntityFrameworkCore;
using Aspnet.com.Models;

namespace Aspnet.com
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adiciona servi�os ao cont�iner
            builder.Services.AddControllersWithViews();

            // Configura a string de conex�o e o DbContext
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<MyDbContext>(options =>
                options.UseSqlServer(connectionString)); // Altere UseSqlServer para o provedor de banco de dados que est� usando
            
            var app = builder.Build();

            // Configura o pipeline de solicita��o HTTP
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // O valor padr�o do HSTS � 30 dias. Voc� pode querer alterar isso para cen�rios de produ��o.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
