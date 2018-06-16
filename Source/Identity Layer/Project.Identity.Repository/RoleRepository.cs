//-----------------------------------------------------------------------
// <copyright file="RoleRepository.cs" company="Ansi ByteCode LLP">
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
    /// <para>RoleRepository class</para>
    /// </summary>
    public static class RoleRepository
    {
        /// <summary>
        /// Gets the role by identifier asynchronous.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>The id</returns>
        /// <exception cref="ArgumentException">Null or empty argument: id</exception>
        public static Task<Role> GetRoleByIdAsync(this IGenericRepository<Role> repository, string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("Null or empty argument: id");
            }

            return repository.Query().FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// Gets the role by identifier.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>The id</returns>
        /// <exception cref="ArgumentException">Null or empty argument: id</exception>
        public static Role GetRoleById(this IGenericRepository<Role> repository, string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("Null or empty argument: id");
            }

            return repository.Query().FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Gets the role by name asynchronous.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="name">The name.</param>
        /// <returns>The name</returns>
        /// <exception cref="ArgumentException">Null or empty argument: name</exception>
        public static Task<Role> GetRoleByNameAsync(this IGenericRepository<Role> repository, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Null or empty argument: name");
            }

            return repository.Query().FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
        }

        /// <summary>
        /// Gets the name of the role by.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="name">The name.</param>
        /// <returns>The name</returns>
        /// <exception cref="ArgumentException">Null or empty argument: name</exception>
        public static Role GetRoleByName(this IGenericRepository<Role> repository, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Null or empty argument: name");
            }

            return repository.Query().FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
        }
    }
}
