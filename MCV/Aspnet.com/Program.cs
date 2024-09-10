using Microsoft.EntityFrameworkCore;
using Aspnet.com.Models;

namespace Aspnet.com
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adiciona serviços ao contêiner
            builder.Services.AddControllersWithViews();

            // Configura a string de conexão e o DbContext
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<MyDbContext>(options =>
                options.UseSqlServer(connectionString)); // Altere UseSqlServer para o provedor de banco de dados que está usando
            
            var app = builder.Build();

            // Configura o pipeline de solicitação HTTP
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // O valor padrão do HSTS é 30 dias. Você pode querer alterar isso para cenários de produção.
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
