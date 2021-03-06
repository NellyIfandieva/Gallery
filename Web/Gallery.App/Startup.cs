namespace Gallery.App
{
    using CloudinaryDotNet;
    using Data;
    using DataModels;
    using Gallery.Services;
    using Gallery.Services.Contracts;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using System.Linq;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDbContext<GalleryDbContext>(options =>
                options
                .UseSqlServer(Configuration
                                .GetConnectionString("DefaultConnection")));

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 0;

                options.User.RequireUniqueEmail = true;
            });

            services
                .AddDatabaseDeveloperPageExceptionFilter();

            services
                .AddIdentity<GalleryUser, IdentityRole>(options => 
                options
                .SignIn
                .RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<GalleryDbContext>();

            var cloudinaryCredentials = new Account(
                Configuration["Cloudinary:CloudName"],
                Configuration["Cloudinary:ApiKey"],
                Configuration["Cloudinary:ApiSecret"]);

            var cloudinaryUtility = new Cloudinary(cloudinaryCredentials);

            var sendGridCredentials = new Account(
                Configuration["SendGrid:ApiKey"],
                Configuration["SendGrid:ApiSecret"],
                Configuration["SendGrid:Username"]
                );

            services
                .AddSingleton(cloudinaryUtility);

            services
                .AddTransient<ICloudinaryService, CloudinaryService>();
            services.AddTransient<IEmailSender, EmailSender>();

            services
                .AddTransient<IItemService, ItemService>();

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (IServiceScope serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope
                    .ServiceProvider
                    .GetRequiredService<GalleryDbContext>();

                dbContext.Database.Migrate();

                if (!dbContext.Roles.Any())
                {
                    var adminRole = new IdentityRole
                    {
                        Name = "Admin",
                        NormalizedName = "ADMIN"
                    };

                    dbContext.Roles.Add(adminRole);
                    dbContext.SaveChanges();
                }
            }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                     name: "areas",
                     pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                   );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
