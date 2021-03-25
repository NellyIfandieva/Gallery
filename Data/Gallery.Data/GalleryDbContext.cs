namespace Gallery.Data
{
    using DataModels;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class GalleryDbContext : IdentityDbContext<GalleryUser, IdentityRole, string>
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }

        public GalleryDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
