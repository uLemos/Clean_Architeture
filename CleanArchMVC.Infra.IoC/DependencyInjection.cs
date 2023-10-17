using CleanArchMVC.Application.Interfaces;
using CleanArchMVC.Application.Mappings;
using CleanArchMVC.Application.Services;
using CleanArchMVC.Domain.Account;
using CleanArchMVC.Domain.Interfaces;
using CleanArchMVC.Infra.Data.Context;
using CleanArchMVC.Infra.Data.Identity;
using CleanArchMVC.Infra.Data.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace CleanArchMVC.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
            );

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


            var myHandlers = AppDomain.CurrentDomain.Load("CleanArchMVC.Application");
            //services.AddMediatR(myHandlers);                                           //.net 5
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(myHandlers)); //.net 6

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();


            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

            services.ConfigureApplicationCookie(options =>
                options.AccessDeniedPath = "/Account/Login");

            return services;
        }
    }
}
