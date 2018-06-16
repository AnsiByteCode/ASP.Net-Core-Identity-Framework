//-----------------------------------------------------------------------
// <copyright company="James Skimming">
//     Copyright (c) 2013 James Skimming
// </copyright>
//-----------------------------------------------------------------------

namespace AspNet.Identity.EntityFramework.Multitenant
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    /// <summary>
    /// Class defining a multi-tenant user.
    /// </summary>
    /// <typeparam name="TKey">The type of <see cref="IUser{TKey}.Id"/> for a user.</typeparam>
    /// <typeparam name="TTenantKey">The type of <see cref="IMultitenantUser{TKey, TTenantKey}.TenantId"/> for a user.</typeparam>
    /// <typeparam name="TLogin">The type of user login.</typeparam>
    /// <typeparam name="TRole">The type of user role.</typeparam>
    /// <typeparam name="TClaim">The type of user claim.</typeparam>
    public class MultitenantIdentityUser<TKey, TTenantKey, TLogin, TRole, TClaim>
        : IdentityUser<TKey, TClaim, TRole, TLogin>, IMultitenantUser<TKey, TTenantKey>
        where TKey : IEquatable<TKey>
        where TLogin : MultitenantIdentityUserLogin<TKey, TTenantKey>
        where TRole : IdentityUserRole<TKey>
        where TClaim : IdentityUserClaim<TKey>
    {
        /// <summary>
        /// Gets or sets the unique identifier of the tenant.
        /// </summary>
        public virtual TTenantKey TenantId { get; set; }
    }
}
