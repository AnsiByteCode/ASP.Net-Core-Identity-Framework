//-----------------------------------------------------------------------
// <copyright file="ApplicationDbContext.cs" company="Ansi ByteCode LLP">
//     Copyright (c) Ansi ByteCode LLP. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Project.Identity.Store
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using AspNet.Identity.EntityFramework.Multitenant;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Project.Identity;
    using Project.Identity.Store;

    /// <summary>
    /// <para>ApplicationDbContext class</para>
    /// </summary>
    /// <seealso cref="AspNet.Identity.EntityFramework.Multitenant.MultitenantIdentityDbContext{Project.Identity.User, System.String}" />
    public class ApplicationDbContext : MultitenantIdentityDbContext<User, string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// Initializes the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        static ApplicationDbContext()
        {
        }

        /// <summary>
        /// Applies custom model definitions for multi-tenancy.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            EntityMappings(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Entities the mappings.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        private static void EntityMappings(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(x =>
            {
                x.ToTable("IdentityUser");
            });

            modelBuilder.Entity<Role>(x =>
            {
                x.ToTable("IdentityRole");
            });

            modelBuilder.Entity<UserRole>(x =>
            {
                x.ToTable("IdentityUserRole");
            });

            modelBuilder.Entity<UserLogin>(x =>
            {
                x.HasKey(u => new { u.LoginProvider, u.UserId });
                x.ToTable("IdentityUserLogin");
            });

            modelBuilder.Entity<UserClaim>(x =>
            {
                x.ToTable("IdentityUserClaim");
            });
        }
    }
}
