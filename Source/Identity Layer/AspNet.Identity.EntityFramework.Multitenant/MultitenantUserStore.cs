//-----------------------------------------------------------------------
// <copyright file="MultitenantUserStore.cs" company="Ansi ByteCode LLP">
//     Copyright (c) Ansi ByteCode LLP. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace AspNet.Identity.EntityFramework.Multitenant
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Multitenant;

    /// <summary>
    /// The store for a multi tenant user.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TUser">The type of user.</typeparam>
    /// <typeparam name="TContext">The type of the context.</typeparam>
    /// <seealso cref="AspNet.Identity.EntityFramework.Multitenant.MultitenantUserStore{TUser, IdentityRole{TKey}, TKey, TKey, AspNet.Identity.EntityFramework.Multitenant.MultitenantIdentityUserLogin{TKey, TKey}, IdentityUserRole{TKey}, IdentityUserClaim{TKey}, TContext}" />
    public class MultitenantUserStore<TKey, TUser, TContext>
        : MultitenantUserStore<TUser, IdentityRole<TKey>, TKey, TKey, MultitenantIdentityUserLogin<TKey, TKey>, IdentityUserRole<TKey>, IdentityUserClaim<TKey>, TContext>
        where TUser : MultitenantIdentityUser<TKey>
         where TKey : IEquatable<TKey>
        where TContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultitenantUserStore{TUser}"/> class.
        /// </summary>
        /// <param name="context">The <see cref="DbContext"/>.</param>
        public MultitenantUserStore(TContext context)
            : base(context)
        {
        }
    }
}
