//-----------------------------------------------------------------------
// <copyright file="Startup.cs" company="Ansi ByteCode LLP">
//     Copyright (c) Ansi ByteCode LLP. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace IdentityCoreServer.Web
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Project.Data.Entity;
    using Project.Data.Repository;
    using Project.Identity;
    using Project.Identity.Store;

    /// <summary>
    /// <para>Startup class</para>
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="env">The env.</param>
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            #region Identity
            services.AddDbContext<ApplicationDbContext>(opt => { opt.UseSqlServer(Configuration.GetConnectionString("DefaultIdentityConnection")); }).AddUnitOfWork<ApplicationDbContext>();
            services.AddDbContext<ProjectDbContext>(opt => { opt.UseSqlServer(Configuration.GetConnectionString("DefaultApplicationConnection")); }).AddUnitOfWork<ProjectDbContext>();
            #endregion

            services.AddScoped(typeof(IUnitOfWork<ProjectDbContext>), typeof(UnitOfWork<ProjectDbContext>));
            services.AddScoped(typeof(IUnitOfWork<ApplicationDbContext>), typeof(UnitOfWork<ApplicationDbContext>));

            services.AddScoped(typeof(IRepository<Post>), typeof(GenericRepository<Post, ProjectDbContext>));

            services.AddScoped(typeof(IRepository<Role>), typeof(GenericRepository<Role, ApplicationDbContext>));
            services.AddScoped(typeof(IRepository<User>), typeof(GenericRepository<User, ApplicationDbContext>));
            services.AddScoped(typeof(IRepository<UserRole>), typeof(GenericRepository<UserRole, ApplicationDbContext>));
            services.AddScoped(typeof(IRepository<RoleClaim>), typeof(GenericRepository<RoleClaim, ApplicationDbContext>));

            // Add framework services.
            services.AddMvc();            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        /// <param name="loggerFactory">The logger factory.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
