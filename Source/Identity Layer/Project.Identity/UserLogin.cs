//-----------------------------------------------------------------------
// <copyright file="UserLogin.cs" company="Ansi ByteCode LLP">
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
    /// <para>UserLogin class</para>
    /// </summary>
    /// <seealso cref="IdentityUserLogin{System.String}" />
    public class UserLogin : IdentityUserLogin<string>
    {
    }
}
