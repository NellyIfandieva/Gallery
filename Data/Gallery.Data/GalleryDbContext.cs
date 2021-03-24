using Gallery.DataModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery.Data
{
    public class GalleryDbContext : IdentityDbContext<GalleryUser, IdentityRole, string>
    {
        public DbSet<Item> Items { get; set; }

        public GalleryDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
