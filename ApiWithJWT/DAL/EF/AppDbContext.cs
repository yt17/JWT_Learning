using CORE.Classes;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF
{
    public class AppDbContext:DbContext
    {
        //public AppDbContext(ModelBuilder modelBuilder):base()
        //{

        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-HLDC6L5\SQLEXPRESS;Database=Yusuf;Integrated Security=SSPI");
        }
        public DbSet<Product> Product { get; set; }
        public DbSet<OperationClaims> operationClaims { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<UserOperationClaims> userOperationClaims { get; set; }
    }
}
