//-----------------------------------------------------------------------
// <copyright file="UserRoleRepository.cs" company="Ansi ByteCode LLP">
//     Copyright (c) Ansi ByteCode LLP. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Project.Identity.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Project.Data.Repository;

    /// <summary>
    /// <para>UserRoleRepository class</para>
    /// </summary>
    public static class UserRoleRepository
    {
        /// <summary>
        /// Gets the by user identifier asynchronous.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>The userId</returns>
        /// <exception cref="ArgumentException">Null or empty argument: userId</exception>
        public static Task<List<UserRole>> GetByUserIdAsync(this IGenericRepository<UserRole> repository, string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException("Null or empty argument: userId");
            }

            return repository.Query().Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
