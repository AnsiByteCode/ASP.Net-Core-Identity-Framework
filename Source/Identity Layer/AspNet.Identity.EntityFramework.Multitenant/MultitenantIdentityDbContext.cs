//-----------------------------------------------------------------------
// <copyright file="MultitenantIdentityDbContext.cs" company="Ansi ByteCode LLP">
//     Copyright (c) Ansi ByteCode LLP. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace AspNet.Identity.EntityFramework.Multitenant
{
    using System;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// <para>MultitenantIdentityDbContext class</para>
    /// </summary>
    /// <typeparam name="TUser">The type of the user.</typeparam>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <seealso cref="AspNet.Identity.EntityFramework.Multitenant.MultitenantIdentityDbContext{TUser, IdentityRole{TKey}, TKey, TKey, AspNet.Identity.EntityFramework.Multitenant.MultitenantIdentityUserLogin{TKey, TKey}, IdentityUserRole{TKey}, IdentityUserClaim{TKey}}" />
    public class MultitenantIdentityDbContext<TUser, TKey>
        : MultitenantIdentityDbContext<TUser, IdentityRole<TKey>, TKey, TKey, MultitenantIdentityUserLogin<TKey, TKey>, IdentityUserRole<TKey>, IdentityUserClaim<TKey>>
        where TUser : MultitenantIdentityUser<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultitenantIdentityDbContext{TUser, TKey}"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public MultitenantIdentityDbContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultitenantIdentityDbContext{TUser}" /> class.
        /// </summary>
        public MultitenantIdentityDbContext()
        {
        }

        /// <summary>
        /// Applies custom model definitions for multi-tenancy.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}