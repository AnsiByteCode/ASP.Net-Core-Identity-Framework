//-----------------------------------------------------------------------
// <copyright file="UserService.cs" company="Ansi ByteCode LLP">
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
    /// <para>UserService class</para>
    /// </summary>
    /// <typeparam name="TDbContext">The type of the database context.</typeparam>
    /// <seealso cref="Project.Identity.Service.BaseService{Project.Identity.User, TDbContext}" />
    /// <seealso cref="Project.Identity.Service.Interface.IUserService" />
    public class UserService<TDbContext> : BaseService<User, TDbContext>, IUserService
        where TDbContext : DbContext
    {
        #region Members

        /// <summary>
        /// The _unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// The _user repository
        /// </summary>
        private readonly IGenericRepository<User> _userRepository;

        /// <summary>
        /// The _role repository
        /// </summary>
        private readonly IGenericRepository<Role> _roleRepository;

        /// <summary>
        /// The _user role repository
        /// </summary>
        private readonly IGenericRepository<UserRole> _userRoleRepository;

        /// <summary>
        /// The _user claim repository
        /// </summary>
        private readonly IGenericRepository<UserClaim> _userClaimRepository;

        /// <summary>
        /// The _user login repository
        /// </summary>
        private readonly IGenericRepository<UserLogin> _userLoginRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService{TDbContext}"/> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="roleRepository">The role repository.</param>
        /// <param name="userRoleRepository">The user role repository.</param>
        /// <param name="userClaimRepository">The user claim repository.</param>
        /// <param name="userLoginRepository">The user login repository.</param>
        /// <param name="tDbContext">The t database context.</param>
        public UserService(IGenericRepository<User> userRepository,
            IUnitOfWork unitOfWork,
            IGenericRepository<Role> roleRepository,
            IGenericRepository<UserRole> userRoleRepository,
            IGenericRepository<UserClaim> userClaimRepository,
            IGenericRepository<UserLogin> userLoginRepository,
            TDbContext tDbContext)
            : base(tDbContext)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
            _userClaimRepository = userClaimRepository;
            _userLoginRepository = userLoginRepository;
        }

        /// <summary>
        /// Creates the asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        /// Create user
        /// </returns>
        public Task CreateAsync(User user)
        {
            _userRepository.Insert(user);

            return _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Gets the roles asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        /// List of roles
        /// </returns>
        public Task<IList<string>> GetRolesAsync(User user)
        {
            IList<string> result = new List<string>();
            var listUserUserRole = _userRoleRepository.Query().Where(p => p.UserId == user.Id).Select(p => p.RoleId).ToList();

            foreach (var userRole in listUserUserRole)
            {
                var role = _roleRepository.Find(userRole);
                if (role != null) result.Add(role.Name);
            }

            return Task.FromResult<IList<string>>(result);
        }

        /// <summary>
        /// Gets the user by email asynchronous.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>
        /// The email
        /// </returns>
        public Task<User> GetUserByEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
                return Task.FromResult<User>(null);

            var userId = GetUserIdFromEmail(email);
            return GetUserByIdAsync(userId);
        }

        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The id
        /// </returns>
        public User GetUserById(string id)
        {
            if (string.IsNullOrEmpty(id))
                return null;

            return _userRepository.GetUserById(id);
        }

        /// <summary>
        /// Gets the user by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The username
        /// </returns>
        public Task<User> GetUserByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                return Task.FromResult<User>(null);
            
            var result = _userRepository.GetUserById(id);
            return Task.FromResult<User>(result);
        }

        /// <summary>
        /// Gets the user by phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <returns>
        /// The phone number
        /// </returns>
        public User GetUserByPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
                return null;

            return _userRepository.Query().FirstOrDefault(m => m.PhoneNumber == phoneNumber);
        }

        /// <summary>
        /// Gets the user by username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>
        /// The username
        /// </returns>
        public User GetUserByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
                return null;

            var userId = this.GetUserIdFromUserName(username);
            return GetUserById(userId);
        }

        /// <summary>
        /// Gets the user by username asynchronous.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>
        /// The username
        /// </returns>
        public Task<User> GetUserByUsernameAsync(string username)
        {
            if (string.IsNullOrEmpty(username))
                Task.FromResult<User>(null);
            var userId = GetUserIdFromUserName(username);

            return GetUserByIdAsync(userId);
        }

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        /// Update user
        /// </returns>
        public Task UpdateAsync(User user)
        {
            try
            {
                _userRepository.Update(user);
                return _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Gets the user identifier from email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>The email</returns>
        private string GetUserIdFromEmail(string email)
        {
            var user = _userRepository.GetUserByEmail(email);
            return user != null ? user.Id : "";            
        }

        /// <summary>
        /// Gets the name of the user identifier from user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>The username</returns>
        private string GetUserIdFromUserName(string username)
        {
            var user = _userRepository.GetUserByUsername(username);
            return user != null ? user.Id : "";
        }
        #endregion
    }
}
