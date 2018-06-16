//-----------------------------------------------------------------------
// <copyright file="MultitenantIdentityUser.cs" company="Ansi ByteCode LLP">
//     Copyright (c) Ansi ByteCode LLP. All rights reserved.
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
    /// <para>MultitenantIdentityUser class</para>
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <seealso cref="AspNet.Identity.EntityFramework.Multitenant.MultitenantIdentityUser{TKey, TKey, AspNet.Identity.EntityFramework.Multitenant.MultitenantIdentityUserLogin{TKey, TKey}, IdentityUserRole{TKey}, IdentityUserClaim{TKey}}" />
    public class MultitenantIdentityUser<TKey> :
        MultitenantIdentityUser<TKey, TKey, MultitenantIdentityUserLogin<TKey, TKey>, IdentityUserRole<TKey>, IdentityUserClaim<TKey>>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultitenantIdentityUser" /> class.
        /// </summary>
        public MultitenantIdentityUser()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultitenantIdentityUser{TKey}"/> class.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <exception cref="ArgumentNullException">userName</exception>
        public MultitenantIdentityUser(string userName)
            : this()
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentNullException("userName");
            UserName = userName;
        }
    }
}
