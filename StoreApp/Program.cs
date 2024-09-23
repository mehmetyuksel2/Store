using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;
using StoreApp.infrastructure.Extensions;
using StoreApp.infrastructure.Mapper;
using StoreApp.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()//api dersi
    .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);
    //api controllerini kullanabilmek için gerekli configure ^
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();//razorpage leri controller olmadan kullanmak için eklememiz gereken kod satırı
builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureIdentity();
builder.Services.ConfigureSession();
builder.Services.ConfigureRepositoryRegistration();

builder.Services.ConfigureRouting();

builder.Services.ConfigureServiceRegistration();
builder.Services.ConfigureApplicationCookie();

builder.Services.AddAutoMapper(typeof(Program));


var app = builder.Build();

// app.MapGet("/", () => "Hello World!");

// app.MapGet("/btk", () => "Btk Akademi");//endpoint özelinde text döndürür

app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthentication();//login // routing() ve endpoints arasında yazılır
app.UseAuthorization();//login // routing() ve endpoints arasında yazılır

app.UseEndpoints(endpoints => 
{
    endpoints.MapAreaControllerRoute(
        name:"Admin",
        areaName:"Admin",
        pattern:"Admin/{controller=Dashboard}/{action=Index}/{id?}"
    );
    endpoints.MapControllerRoute("default","{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();//razorpage leri controller olmadan kullanmak için eklememiz gereken kod satırı
    endpoints.MapControllers();//api dersi
});


app.ConfigureAndCheck();//extensions dosyasındaki implemente ettiğimiz
app.ConfigureLocalization();//metodları burada çalıştırıyoruz
app.MapControllerRoute("default","{controller=Home}/{action=Index}/{id?}");

app.ConfigureDefaultAdminUser();
app.Run();
