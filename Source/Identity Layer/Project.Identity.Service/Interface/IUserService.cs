//-----------------------------------------------------------------------
// <copyright file="IUserService.cs" company="Ansi ByteCode LLP">
//     Copyright (c) Ansi ByteCode LLP. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Project.Identity.Service.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// <para>IUserService interface</para>
    /// </summary>
    public interface IUserService
    {
        #region User

        /// <summary>
        /// Gets the user by username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>The username</returns>
        User GetUserByUsername(string username);

        /// <summary>
        /// Gets the user by username asynchronous.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>The username</returns>
        Task<User> GetUserByUsernameAsync(string username);

        /// <summary>
        /// Gets the user by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The username</returns>
        Task<User> GetUserByIdAsync(string id);

        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The id</returns>
        User GetUserById(string id);

        /// <summary>
        /// Gets the user by email asynchronous.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>The email</returns>
        Task<User> GetUserByEmailAsync(string email);

        /// <summary>
        /// Creates the asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>Create user</returns>
        Task CreateAsync(User user);

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>Update user</returns>
        Task UpdateAsync(User user);

        /// <summary>
        /// Updates the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        void Update(User user);

        /// <summary>
        /// Gets the roles asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>List of roles</returns>
        Task<IList<string>> GetRolesAsync(User user);

        /// <summary>
        /// Gets the user by phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <returns>The phone number</returns>
        User GetUserByPhoneNumber(string phoneNumber);

        #endregion        
    }
}
