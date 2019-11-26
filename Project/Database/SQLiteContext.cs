using Domain;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class SQLiteContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ReceivedMessages> ReceivedMessages { get; set; }
        public DbSet<Conversation> Conversations { get; set; }

        public DbSet<ConversationUser> ConversationUsers { get; set; }

        public SQLiteContext() : base()
        { }

        public SQLiteContext(DbContextOptions<SQLiteContext> options)
            : base(options)
        { }

        /// <summary>
        /// Config sqlite context
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.EnableSensitiveDataLogging();
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseSqlite(
                    @"Data Source=C:\Users\16pxd\Desktop\Desktop Appliaction\Desktop Appliaction\Project\Database\Data\SQLiteDB.db");
            }
        }
        
        /// <summary>
        /// Create relationships
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conversation>()
                .HasMany(m=>m.Messages)
                .WithOne(m=>m.Conversation)
                .HasForeignKey(m=>m.ConversationId);
          
           modelBuilder.Entity<Conversation>()
                .HasMany(m => m.ConversationUsers)
                .WithOne(m => m.Conversation)
                .HasForeignKey(m => m.ConversationId);

            modelBuilder.Entity<User>()
                .HasMany(m => m.ConversationUsers)
                .WithOne(m => m.User)
                .HasForeignKey(m => m.UserId);

        }
    }

}
