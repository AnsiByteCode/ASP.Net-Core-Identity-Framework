//-----------------------------------------------------------------------
// <copyright file="MultitenantIdentityUserLogin.cs" company="Ansi ByteCode LLP">
//     Copyright (c) Ansi ByteCode LLP. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace AspNet.Identity.EntityFramework.Multitenant
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    /// <summary>
    /// <para>MultitenantIdentityUserLogin class</para>
    /// </summary>
    /// <seealso cref="AspNet.Identity.EntityFramework.Multitenant.MultitenantIdentityUserLogin{System.String, System.String}" />
    public class MultitenantIdentityUserLogin : MultitenantIdentityUserLogin<string, string>
    {
    }
}
