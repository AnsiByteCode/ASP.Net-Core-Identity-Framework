//-----------------------------------------------------------------------
// <copyright file="IBaseService.cs" company="Ansi ByteCode LLP">
//     Copyright (c) Ansi ByteCode LLP. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Project.Identity.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// <para>IBaseService interface</para>
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IBaseService<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Deeps the find.
        /// </summary>
        /// <param name="parentKeyValues">The parent key values.</param>
        /// <returns>The parentkeyvalues</returns>
        TEntity DeepFind(params object[] parentKeyValues);

        /// <summary>
        /// Deeps the find asynchronous.
        /// </summary>
        /// <param name="parentKeyValues">The parent key values.</param>
        /// <returns>The parentkeyvalues</returns>
        Task<TEntity> DeepFindAsync(params object[] parentKeyValues);
    }
}
