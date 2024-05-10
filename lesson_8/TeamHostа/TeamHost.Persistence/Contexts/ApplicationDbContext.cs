using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeamHost.Domain.Entities;
using TeamHost.Persistence.Configurations;

namespace TeamHost.Persistence.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DbSet<Chats> Chats { get; set; }
        
        public DbSet<Message> Messages { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<StaticFile> StaticFiles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Game> Games { get; set; }
        
        public DbSet<UserInfo> UserInfos { get; set; }
        
       

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new GameConfiguration());
            modelBuilder.ApplyConfiguration(new StaticFileConfiguration());
            modelBuilder.ApplyConfiguration(new UserInfoConfiguration());
            modelBuilder.ApplyConfiguration(new ChatConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());

            modelBuilder.Entity<Company>().HasData(DatabaseSeeder.Companies());
            modelBuilder.Entity<Category>().HasData(DatabaseSeeder.Categories());
            modelBuilder.Entity<Platform>().HasData(DatabaseSeeder.Platforms());
            modelBuilder.Entity<Country>().HasData(DatabaseSeeder.Countries());
         
            base.OnModelCreating(modelBuilder);
        }
    }
}
