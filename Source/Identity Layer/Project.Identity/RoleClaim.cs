//-----------------------------------------------------------------------
// <copyright file="RoleClaim.cs" company="Ansi ByteCode LLP">
//     Copyright (c) Ansi ByteCode LLP. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Project.Identity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    /// <summary>
    /// <para>Role class</para>
    /// </summary>
    /// <seealso cref="IdentityRoleClaim{System.String}" />
    public class RoleClaim : IdentityRoleClaim<string>
    {
    }
}
