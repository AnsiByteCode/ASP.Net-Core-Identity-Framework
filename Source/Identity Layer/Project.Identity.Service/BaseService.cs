//-----------------------------------------------------------------------
// <copyright file="BaseService.cs" company="Ansi ByteCode LLP">
//     Copyright (c) Ansi ByteCode LLP. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Project.Identity.Service
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Project.Data.Repository;

    /// <summary>
    /// <para>BaseService</para>
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TDbContext">The type of the database context.</typeparam>
    /// <seealso cref="Project.Data.Repository.GenericRepository{TEntity, TDbContext}" />
    /// <seealso cref="Project.Identity.Service.IBaseService{TEntity}" />
    public class BaseService<TEntity, TDbContext> : GenericRepository<TEntity, TDbContext>, IBaseService<TEntity>
        where TEntity : class
        where TDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseService{TEntity, TDbContext}" /> class.
        /// </summary>
        /// <param name="tDbContext">The t database context.</param>
        protected BaseService(TDbContext tDbContext) : base(tDbContext)
        {
        }

        #region Implements IBaseService
        /// <summary>
        /// Deeps the find.
        /// </summary>
        /// <param name="keyValues">The key values.</param>
        /// <returns>The keyvalue</returns>
        public virtual TEntity DeepFind(params object[] keyValues)
        {
            return this.Find(keyValues);
        }

        /// <summary>
        /// Deeps the find asynchronous.
        /// </summary>
        /// <param name="keyValues">The key values.</param>
        /// <returns>The keyvalue</returns>
        public virtual Task<TEntity> DeepFindAsync(params object[] keyValues)
        {
            return this.FindAsync(keyValues);
        }

        #endregion
    }
}
