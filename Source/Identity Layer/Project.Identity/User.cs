//-----------------------------------------------------------------------
// <copyright file="User.cs" company="Ansi ByteCode LLP">
//     Copyright (c) Ansi ByteCode LLP. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Project.Identity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using AspNet.Identity.EntityFramework.Multitenant;
    using Microsoft.AspNetCore.Identity;

    /// <summary>
    /// <para>User class</para>
    /// </summary>
    /// <seealso cref="AspNet.Identity.EntityFramework.Multitenant.MultitenantIdentityUser{System.String}" />
    public class User : MultitenantIdentityUser<string>
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User() : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        public User(string userName)
        {
            this.Id = Guid.NewGuid().ToString().GetHashCode().ToString("x");
            this.UserName = userName;
        }
        #endregion

        #region Async Methods
        /// <summary>
        /// Generates the user identity asynchronous.
        /// </summary>
        /// <param name="manager">The manager.</param>
        /// <returns>Returns user identity</returns>
        public async Task<IdentityResult> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // NOTE: AuthenticationType must match one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateAsync(this);

            return userIdentity;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        [Display(Name = "User Id")]
        public override string Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the tenant.
        /// </summary>
        [Required]
        [StringLength(128)]
        public override string TenantId { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [Display(Name = "Email")]
        public override string Email { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [email confirmed].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [email confirmed]; otherwise, <c>false</c>.
        /// </value>
        [Display(Name = "Email Confirmed?")]
        public override bool EmailConfirmed { get; set; }

        /// <summary>
        /// Gets or sets the password hash.
        /// </summary>
        /// <value>
        /// The password hash.
        /// </value>
        [Display(Name = "Encrypted Pwd")]
        public override string PasswordHash { get; set; }

        /// <summary>
        /// Gets or sets the security stamp.
        /// </summary>
        /// <value>
        /// The security stamp.
        /// </value>
        [Display(Name = "Security Stamp")]
        public override string SecurityStamp { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        [Display(Name = "Phone")]
        public override string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [phone number confirmed].
        /// </summary>
        /// <value>
        /// <c>true</c> if [phone number confirmed]; otherwise, <c>false</c>.
        /// </value>
        [Display(Name = "Phone Confirmed?")]
        public override bool PhoneNumberConfirmed { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [two factor enabled].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [two factor enabled]; otherwise, <c>false</c>.
        /// </value>
        [Display(Name = "Two Factor Auth?")]
        public override bool TwoFactorEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [lockout enabled].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [lockout enabled]; otherwise, <c>false</c>.
        /// </value>
        [Display(Name = "Lockout Enabled?")]
        public override bool LockoutEnabled { get; set; }

        /// <summary>
        /// Gets or sets the access failed count.
        /// </summary>
        /// <value>
        /// The access failed count.
        /// </value>
        [Display(Name = "Access Fail #")]
        public override int AccessFailedCount { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        [Required]
        [Display(Name = "User Name")]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "{0} must be less than {1} characters.")]
        public override string UserName { get; set; }
        #endregion

        #region Clone
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>Returns User object</returns>
        public object Clone()
        {
            return new User()
            {
                Id = this.Id,
                UserName = this.UserName,
                PasswordHash = this.PasswordHash,
                SecurityStamp = Guid.NewGuid().ToString(),
                Email = this.Email,
                EmailConfirmed = this.EmailConfirmed,
                PhoneNumber = this.PhoneNumber,
                PhoneNumberConfirmed = this.PhoneNumberConfirmed,
                TwoFactorEnabled = this.TwoFactorEnabled
            };
        }
        #endregion
    }
}
