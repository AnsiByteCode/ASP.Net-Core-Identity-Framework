//-----------------------------------------------------------------------
// <copyright file="SystemRoleName.cs" company="Ansi ByteCode LLP">
//     Copyright (c) Ansi ByteCode LLP. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Project.Identity
{
    using System.ComponentModel;

    /// <summary>
    /// <para>SystemRoleName enum</para>
    /// </summary>
    public enum SystemRoleName
    {
        /// <summary>
        /// The system admin
        /// </summary>
        [Description("System Admin")]
        SystemAdmin,

        /// <summary>
        /// The admin
        /// </summary>
        [Description("Admin")]
        Admin,

        /// <summary>
        /// The user
        /// </summary>
        [Description("User")]
        User
    }
}
