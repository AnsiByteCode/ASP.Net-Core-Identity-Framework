//-----------------------------------------------------------------------
// <copyright file="IRoleService.cs" company="Ansi ByteCode LLP">
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
    /// <para>IRoleService interface</para>
    /// </summary>
    public interface IRoleService
    {
        /// <summary>
        /// Gets the role by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The id</returns>
        Task<Role> GetRoleByIdAsync(string id);

        /// <summary>
        /// Gets the role by name asynchronous.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>The name</returns>
        Task<Role> GetRoleByNameAsync(string name);

        /// <summary>
        /// Gets the name of the role by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>The name</returns>
        Role GetRoleByName(string name);

        /// <summary>
        /// Adds the role to user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleId">The role identifier.</param>
        /// <returns>Add role to user</returns>
        Task AddRoleToUser(string userId, string roleId);

        /// <summary>
        /// Removes the role from user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleId">The role identifier.</param>
        /// <returns>Remove role from user</returns>
        Task RemoveRoleFromUser(string userId, string roleId);

        /// <summary>
        /// Removes all roles from user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Remove all roles from user</returns>
        Task RemoveAllRolesFromUser(string userId);

        /// <summary>
        /// Creates the asynchronous.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>Create role</returns>
        Task CreateAsync(Role role);

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>Delete role</returns>
        Task DeleteAsync(Role role);

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>Update role</returns>
        Task UpdateAsync(Role role);

        /// <summary>
        /// Gets all system roles.
        /// </summary>
        /// <returns>All system roles</returns>
        List<Role> GetAllSystemRoles();

        /// <summary>
        /// Gets the user roles.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>List of roles</returns>
        Task<List<UserRole>> GetUserRoles(string id);
    }
}
