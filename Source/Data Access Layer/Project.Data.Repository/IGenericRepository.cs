//-----------------------------------------------------------------------
// <copyright file="IGenericRepository.cs" company="Ansi ByteCode LLP">
//     Copyright (c) Ansi ByteCode LLP. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Project.Data.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// <para>IGenericRepository interface</para>
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IRepository{TEntity}" />
    public interface IGenericRepository<TEntity> : IRepository<TEntity>
         where TEntity : class
    {
    }
}
