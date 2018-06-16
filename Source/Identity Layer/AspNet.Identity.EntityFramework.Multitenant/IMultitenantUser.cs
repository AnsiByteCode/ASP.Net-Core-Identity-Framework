//-----------------------------------------------------------------------
// <copyright file="IMultitenantUser.cs" company="Ansi ByteCode LLP">
//     Copyright (c) Ansi ByteCode LLP. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace AspNet.Identity.EntityFramework.Multitenant
{
    using Microsoft.AspNetCore.Identity;


    /// <summary>
    /// <para>IMultitenantUser interface</para>
    /// </summary>
    /// <seealso cref="AspNet.Identity.EntityFramework.Multitenant.IMultitenantUser{System.String, System.String}" />
    public interface IMultitenantUser : IMultitenantUser<string, string>
    {
    }
}
