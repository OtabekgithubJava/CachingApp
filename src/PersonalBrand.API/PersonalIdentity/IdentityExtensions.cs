using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using PersonalBrand.Application.Abstractions;
using PersonalBrand.Domain.Entities.Models;
using PersonalBrand.Infrastructure.Persistance;

namespace PersonalBrand.API.PersonalIdentity
{
    public static class IdentityExtensions
    {
        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<UserModel, IdentityRole>()
                    .AddEntityFrameworkStores<PersonalBrandDbContext>()
                    .AddDefaultTokenProviders();

            return services;
        }
    }
}
