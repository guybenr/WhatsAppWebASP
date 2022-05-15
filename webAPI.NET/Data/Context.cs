using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webAPI.Models;
using webAPI.NET.Models;

namespace webAPI.NET.Data
{
    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasKey("Id", "UserId");
        }

        public DbSet<webAPI.Models.Contact> Contact { get; set; }

        public DbSet<webAPI.Models.User> User { get; set; }

        public DbSet<webAPI.Models.Chat> Chat { get; set; }

        public DbSet<webAPI.Models.Message> Message { get; set; }

        public DbSet<webAPI.NET.Models.Invitation> Invitation { get; set; }

        public DbSet<webAPI.NET.Models.Transfer> Transfer { get; set; }
    }
}
