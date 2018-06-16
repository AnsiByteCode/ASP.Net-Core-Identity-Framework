//-----------------------------------------------------------------------
// <copyright file="GenericRepository.cs" company="Ansi ByteCode LLP">
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
    /// <para>GenericRepository class</para>
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TDbContext">The type of the database context.</typeparam>
    /// <seealso cref="Microsoft.EntityFrameworkCore.Repository{TEntity}" />
    /// <seealso cref="Project.Data.Repository.IGenericRepository{TEntity}" />
    public class GenericRepository<TEntity, TDbContext> : Repository<TEntity>, IGenericRepository<TEntity>
        where TEntity : class
        where TDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{TEntity, TDbContext}"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public GenericRepository(TDbContext dbContext) : base(dbContext)
        {
        }
    }
}
