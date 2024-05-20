using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersonalBrand.Application.Abstractions;
using PersonalBrand.Domain.Entities.DTOs;
using PersonalBrand.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBrand.Infrastructure.Persistance
{
    public class PersonalBrandDbContext : IdentityDbContext<UserModel>, IPersonalBrandDbContext
    {
        public PersonalBrandDbContext(DbContextOptions<PersonalBrandDbContext> options) : base(options)
        {
            
        }
        public DbSet<Login> TestLoginTable { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Blog> Posts { get; set; }
    }
}
