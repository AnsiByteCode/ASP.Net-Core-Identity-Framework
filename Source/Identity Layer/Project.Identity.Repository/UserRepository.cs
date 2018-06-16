//-----------------------------------------------------------------------
// <copyright file="UserRepository.cs" company="Ansi ByteCode LLP">
//     Copyright (c) Ansi ByteCode LLP. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Project.Identity.Repository
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Project.Data.Repository;

    /// <summary>
    /// <para>UserRepository class</para>
    /// </summary>
    public static class UserRepository
    {
        #region Methods

        /// <summary>
        /// Gets the user by username.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="username">The username.</param>
        /// <returns>The username</returns>
        /// <exception cref="ArgumentException">Null or empty argument: userName</exception>
        public static User GetUserByUsername(this IGenericRepository<User> repository, string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException("Null or empty argument: userName");
            }

            return repository.Query().FirstOrDefault(p => p.UserName == username);
        }

        /// <summary>
        /// Gets the user by username asynchronous.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="username">The username.</param>
        /// <returns>The username</returns>
        /// <exception cref="ArgumentException">Null or empty argument: userName</exception>
        public static Task<User> GetUserByUsernameAsync(this IGenericRepository<User> repository, string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException("Null or empty argument: userName");
            }

            return repository.Query().FirstOrDefaultAsync(p => p.UserName == username);
        }

        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>The id</returns>
        /// <exception cref="ArgumentException">Null or empty argument: id</exception>
        public static User GetUserById(this IGenericRepository<User> repository, string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("Null or empty argument: id");
            }

            return repository.Find(id);
        }

        /// <summary>
        /// Gets the user by identifier asynchronous.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>The id</returns>
        /// <exception cref="ArgumentException">Null or empty argument: id</exception>
        public static Task<User> GetUserByIdAsync(this IGenericRepository<User> repository, string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("Null or empty argument: id");
            }

            return repository.FindAsync(id);
        }

        /// <summary>
        /// Gets the user by email.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="email">The email.</param>
        /// <returns>The email</returns>
        /// <exception cref="ArgumentException">Null or empty argument: email</exception>
        public static User GetUserByEmail(this IGenericRepository<User> repository, string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("Null or empty argument: email");
            }

            return repository.Query().FirstOrDefault(x => x.Email == email);
        }

        /// <summary>
        /// Gets the user by email asynchronous.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="email">The email.</param>
        /// <returns>The email</returns>
        /// <exception cref="ArgumentException">Null or empty argument: email</exception>
        public static Task<User> GetUserByEmailAsync(this IGenericRepository<User> repository, string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("Null or empty argument: email");
            }

            return repository.Query().FirstOrDefaultAsync(x => x.Email == email);
        }

        #endregion
    }
}
