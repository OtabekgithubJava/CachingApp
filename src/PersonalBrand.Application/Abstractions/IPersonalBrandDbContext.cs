using Microsoft.EntityFrameworkCore;
using PersonalBrand.Domain.Entities.DTOs;
using PersonalBrand.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBrand.Application.Abstractions
{
    public interface IPersonalBrandDbContext
    {
        public DbSet<Login> TestLoginTable { get; set; }
        //public DbSet<UserModel> Users { get; set; } // qo`shih keremi yo`qmi bilmadim.
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Blog> Posts { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
