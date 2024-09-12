﻿using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;
using Services;
using Entities.Models;
using StoreApp.Models;

namespace StoreApp.infrastructe.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services,
            IConfiguration configuration)
        {// context bağlantısı
            services.AddDbContext<RepositoryContext>(options =>
            {
                options.UseSqlite("Data Source = Products.db", b => b.MigrationsAssembly("StoreApp"));
                //b.MigrationsAssembly("StoreApp") contex ve modeller repositories deyken storeapp de
                // migration oluşturmak için 
                // burada storeapp e yönlendirme yapıyoruz
            });
        }

        public static void ConfigureSession(this IServiceCollection services)
        {// session

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.Name = "StoreApp.Session";//cookie oluştur
                options.IdleTimeout = TimeSpan.FromMinutes(10);//10 dk tut
            });// session
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<Cart>(c => SessionCart.GetCart(c));//bir cart nesnesi oluşturuldu heryer aynı nesneyi kullanacaktır

        }
        public static void ConfigureRepositoryRegistration(this IServiceCollection services)
        {

            services.AddScoped<IRepositoryManager, RepositoryManager>();
            //addscoped özelliği bi kapsam tanımlar IRepositoryManager in 
            //görüldüğü heryer RepositoryManager i örnek alır
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
        }
        public static void ConfigureServiceRegistration(this IServiceCollection services)
        {

            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IOrderService, OrderManager>();
        }
        public static void ConfigureRouting(this IServiceCollection services)
        {
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;//endpointte büyük harfle başlamasın
                options.AppendTrailingSlash = false;//link sonuna slash eklensinmi ?
                

            });
        }
    }
}
