using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.StoreWayDbContext
{
    public class StoreWayContext : DbContext
    {
        public StoreWayContext(DbContextOptions<StoreWayContext> options): base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet <UserAdress> UserAdress { get; set; }
        public DbSet <Orders> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Products>()
              .HasKey(c => c.ProductId);
            modelBuilder.Entity<Products>()
                .HasOne(p => p.Category) 
                .WithMany(c => c.Products)  
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);  

             modelBuilder.Entity<Category>()
                 .HasOne(c => c.ParentCategory)
                 .WithMany()
                 .HasForeignKey(c => c.ParentCategoryId)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserAdress>()
                .Property(u => u.Type)
                .HasConversion<string>();
            modelBuilder.Entity<UserAdress>()
                .HasOne(ua => ua.Users)
                .WithMany(u => u.UserAdresses)
                .HasForeignKey(ua => ua.UserId)
                .OnDelete(DeleteBehavior.Cascade);
           
            modelBuilder.Entity<Orders>()
                .HasOne(c => c.Users)
                .WithMany(u => u.Orders)
                .HasForeignKey(c => c.UserId);
           

        }
    }
}
