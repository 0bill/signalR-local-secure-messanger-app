﻿using Domain;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class SQLiteContext : DbContext
    {

        public DbSet<User> Users { get; set; }
       // public DbSet<Conversation> Conversations { get; set; }
       // public DbSet<Message> Messages { get; set; }

        public SQLiteContext() : base()
        { }

        public SQLiteContext(DbContextOptions<SQLiteContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.EnableSensitiveDataLogging();
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseSqlite(
                    @"Data Source=C:\Users\16pxd\Desktop\CORE\Project\Database\Data\SQLiteDB.db");
            }
        }

    
    }
}
