//-----------------------------------------------------------------------
// <copyright file="IUser.cs" company="Ansi ByteCode LLP">
//     Copyright (c) Ansi ByteCode LLP. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace AspNet.Identity.EntityFramework.Multitenant
{
    /// <summary>
    /// <para>IUser interface</para>
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    public interface IUser<out TKey>
    {
    }
}