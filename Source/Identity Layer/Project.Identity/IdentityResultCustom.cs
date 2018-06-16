//-----------------------------------------------------------------------
// <copyright file="IdentityResultCustom.cs" company="Ansi ByteCode LLP">
//     Copyright (c) Ansi ByteCode LLP. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Project.Identity
{
    using System.Collections.Generic;

    /// <summary>
    /// Identity Result Custom
    /// </summary>
    public class IdentityResultCustom
    {
        /// <summary>
        /// Gets or sets the errors.
        /// </summary>
        /// <value>
        /// The errors.
        /// </value>
        public IEnumerable<string> Errors { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IdentityResultCustom" /> is succeeded.
        /// </summary>
        /// <value>
        ///   <c>true</c> if succeeded; otherwise, <c>false</c>.
        /// </value>
        public bool Succeeded { get; set; }
    }
}
