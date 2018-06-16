//-----------------------------------------------------------------------
// <copyright file="RoleService.cs" company="Ansi ByteCode LLP">
//     Copyright (c) Ansi ByteCode LLP. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Project.Identity.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Project.Data.Repository;
    using Project.Identity.Repository;
    using Project.Identity.Service.Interface;

    /// <summary>
    /// <para>RoleService class</para>
    /// </summary>
    /// <typeparam name="TDbContext">The type of the database context.</typeparam>
    /// <seealso cref="Project.Identity.Service.BaseService{Project.Identity.Role, TDbContext}" />
    /// <seealso cref="Project.Identity.Service.Interface.IRoleService" />
    public class RoleService<TDbContext> : BaseService<Role, TDbContext>, IRoleService
        where TDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleService{TDbContext}"/> class.
        /// </summary>
        /// <param name="tDbContext">The t database context.</param>
        public RoleService(TDbContext tDbContext) : base(tDbContext)
        {
        }

        #region Declarations

        /// <summary>
        /// The _unit of work
        /// </summary>
        private IUnitOfWork _unitOfWork;

        /// <summary>
        /// The _role repository
        /// </summary>
        private readonly IGenericRepository<Role> _roleRepository;

        /// <summary>
        /// The _user role repository
        /// </summary>
        private readonly IGenericRepository<UserRole> _userRoleRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleService{TDbContext}"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="roleRepository">The role repository.</param>
        /// <param name="userRoleRepository">The user role repository.</param>
        /// <param name="tDbContext">The t database context.</param>
        public RoleService(IUnitOfWork unitOfWork, IGenericRepository<Role> roleRepository, IGenericRepository<UserRole> userRoleRepository, TDbContext tDbContext)
            : base(tDbContext)
        {
            _unitOfWork = unitOfWork;
            //_cacheManager = cacheManager;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                //free managed resources
                if (_unitOfWork != null)
                {
                    _unitOfWork.Dispose();
                    _unitOfWork = null;
                }
            }

            // free native resources (if any)
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the role by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The id
        /// </returns>
        public Task<Role> GetRoleByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                return Task.FromResult<Role>(null);

            var role = _roleRepository.GetRoleById(id);

            return Task.FromResult<Role>(role);
        }

        /// <summary>
        /// Gets the role by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The id</returns>
        public Role GetRoleById(string id)
        {
            if (string.IsNullOrEmpty(id))
                return (null);

            var role = _roleRepository.GetRoleById(id);

            return role;
        }

        /// <summary>
        /// Gets the name of the role identifier by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>The name</returns>
        private string GetRoleIdByName(string name)
        {
            var role = _roleRepository.GetRoleByName(name);
            return role != null ? role.Id : "";
        }

        /// <summary>
        /// Gets the role by name asynchronous.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>
        /// The name
        /// </returns>
        public Task<Role> GetRoleByNameAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
                return Task.FromResult<Role>(null);

            var roleId = GetRoleIdByName(name);
            return GetRoleByIdAsync(roleId);
        }

        /// <summary>
        /// Gets the name of the role by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>
        /// The name
        /// </returns>
        public Role GetRoleByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return null;

            var roleId = GetRoleIdByName(name);
            return GetRoleById(roleId);
        }

        /// <summary>
        /// Adds the role to user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleId">The role identifier.</param>
        /// <returns>
        /// Add role to user
        /// </returns>
        public Task AddRoleToUser(string userId, string roleId)
        {
            var userRole = new UserRole
            {
                RoleId = roleId,
                UserId = userId
            };
            _userRoleRepository.Insert(userRole);

            return _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Removes the role from user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleId">The role identifier.</param>
        /// <returns>
        /// Remove role from user
        /// </returns>
        public Task RemoveRoleFromUser(string userId, string roleId)
        {
            var existRole = _userRoleRepository.Query()
                .FirstOrDefault(t => t.RoleId == roleId && t.UserId == userId);
            if (existRole != null)
                _userRoleRepository.Delete(existRole);

            return _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Removes all roles from user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// Remove all roles from user
        /// </returns>
        public Task RemoveAllRolesFromUser(string userId)
        {
            var existRole = _userRoleRepository.Query()
                .Where(t => t.UserId == userId);
            foreach (var userRole in existRole)
            {
                _userRoleRepository.Delete(userRole);
            }

            return _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Creates the asynchronous.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>
        /// Create role
        /// </returns>
        public Task CreateAsync(Role role)
        {
            _roleRepository.Insert(role);

            return _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>
        /// Update role
        /// </returns>
        public Task UpdateAsync(Role role)
        {
            _roleRepository.Update(role);

            return _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>
        /// Delete role
        /// </returns>
        public Task DeleteAsync(Role role)
        {
            ////remove user roles
            foreach (var source in _userRoleRepository.Query().Where(t => t.RoleId == role.Id))
            {
                _userRoleRepository.Delete(source);
            }

            _roleRepository.Delete(role);

            return _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Gets all system roles.
        /// </summary>
        /// <returns>
        /// All system roles
        /// </returns>
        public List<Role> GetAllSystemRoles()
        {
            return _roleRepository.Query().ToList();
        }


        /// <summary>
        /// Gets the user roles.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// List of roles
        /// </returns>
        public Task<List<UserRole>> GetUserRoles(string id)
        {
            return _userRoleRepository.GetByUserIdAsync(id);
        }

        #endregion
    }
}
