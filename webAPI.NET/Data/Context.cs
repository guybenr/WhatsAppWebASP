﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webAPI.Models;

namespace webAPI.NET.Data
{
    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<webAPI.Models.Contact> Contact { get; set; }

        public DbSet<webAPI.Models.User> User { get; set; }

        public DbSet<webAPI.Models.Chat> Chat { get; set; }

        public DbSet<webAPI.Models.Message> Message { get; set; }
    }
}
