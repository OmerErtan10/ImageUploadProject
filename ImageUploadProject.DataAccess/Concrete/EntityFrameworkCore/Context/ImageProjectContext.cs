using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageUploadProject.DataAccess.Concrete.EntityFrameworkCore.Context
{
    public class ImageProjectContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public ImageProjectContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("db1"));
        }

        public DbSet<Entities.Concrete.Image> Images { get; set; }

    }
}
