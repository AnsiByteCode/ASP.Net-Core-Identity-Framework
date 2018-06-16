//-----------------------------------------------------------------------
// <copyright file="UserClaim.cs" company="Ansi ByteCode LLP">
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
    /// <para>UserClaim class</para>
    /// </summary>
    /// <seealso cref="IdentityUserClaim{System.String}" />
    public class UserClaim : IdentityUserClaim<string>
    {
    }
}
