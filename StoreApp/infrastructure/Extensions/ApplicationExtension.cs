using Microsoft.AspNetCore.Identity; // Düzeltilmiş kütüphane
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace StoreApp.infrastructure.Extensions
{
    public static class ApplicationExtension
    {
        // Auto migrate
        public static void ConfigureAndCheck(this IApplicationBuilder app)
        {
            RepositoryContext context = app
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<RepositoryContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }

        // Localization
        public static void ConfigureLocalization(this WebApplication app)
        {
            app.UseRequestLocalization(options =>
                options.AddSupportedCultures("tr-TR")
                    .AddSupportedUICultures("tr-TR")
                    .SetDefaultCulture("tr-TR")
            );
        }

        // ASP.NET Core Identity'nin kullanıcı ve rol yönetiminde kullanılan kod bloğu
        public static async Task ConfigureDefaultAdminUser(this IApplicationBuilder app) // async Task
        {
            const string adminUser = "Admin"; // Admin için kullanıcı adı ve şifre belirledik
            const string adminPassword = "Admin+1234";

            using var scope = app.ApplicationServices.CreateScope(); // Tek bir scope kullanımı

            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>(); // UserManager DI
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();  // RoleManager DI

            IdentityUser user = await userManager.FindByNameAsync(adminUser); // Kullanıcının varlığını kontrol ettik
            if (user == null) // Eğer kullanıcı yoksa
            {
                user = new IdentityUser(adminUser)
                {
                    Email = "mehmety.113113@gmail.com",
                    PhoneNumber = "5061112233",
                    UserName = adminUser
                };

                var roles = roleManager.Roles.Select(r => r.Name).ToArray(); // Rol isimlerini dizi olarak al

                var result = await userManager.CreateAsync(user, adminPassword); // Admin kullanıcıyı oluştur
                if (!result.Succeeded)
                {
                    throw new Exception("Admin user could not be created.");
                }

                var roleResult = await userManager.AddToRolesAsync(user, roles); // Rolleri kullanıcıya ekledik
                if (!roleResult.Succeeded)
                {
                    throw new Exception("System encountered problems while defining roles for admin.");
                }
            }
        }
    }
}
