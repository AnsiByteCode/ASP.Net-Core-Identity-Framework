//-----------------------------------------------------------------------
// <copyright file="Role.cs" company="Ansi ByteCode LLP">
//     Copyright (c) Ansi ByteCode LLP. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Project.Identity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="IdentityRole{System.String}" />
    public class Role : IdentityRole<string>
    {
        #region Constructors
        /// <summary>
        /// Creates an empty role
        /// </summary>
        public Role()
        {
            this.Id = Guid.NewGuid().ToString().GetHashCode().ToString("x");
        }

        public Role(string roleName) : base(roleName)
        {
        }
        #endregion

        #region Properties

        //[Key]
        //[Display(Name = "Role Id")]
        //[StringLength(40, ErrorMessage = "{0} must be less than {1} characters.")]
        //public override string Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required]
        //[Index("IX_UniqueRoleName", 1, IsUnique = true)]
        [Display(Name = "Role Name")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "{0} must be less than {1} characters.")]
        public override string Name { get; set; }

        #endregion

        //public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
