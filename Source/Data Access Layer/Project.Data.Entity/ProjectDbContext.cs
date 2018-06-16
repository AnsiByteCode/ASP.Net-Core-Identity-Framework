//-----------------------------------------------------------------------
// <copyright file="ProjectDbContext.cs" company="Ansi ByteCode LLP">
//     Copyright (c) Ansi ByteCode LLP. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Project.Data.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// <para>ProjectDbContext class</para>
    /// </summary>
    /// <seealso cref="DbContext" />
    public class ProjectDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        {
            Database.EnsureCreated();            
        }

        /// <summary>
        /// Gets or sets the blogs.
        /// </summary>
        /// <value>
        /// The blogs.
        /// </value>
        public DbSet<Blog> Blogs { get; set; }

        /// <summary>
        /// Gets or sets the posts.
        /// </summary>
        /// <value>
        /// The posts.
        /// </value>
        public DbSet<Post> Posts { get; set; }

        /// <summary>
        /// Called when [model creating].
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }                
    }

    /// <summary>
    /// <para>Blog class</para>
    /// </summary>
    public class Blog
    {
        /// <summary>
        /// Gets or sets the blog identifier.
        /// </summary>
        /// <value>
        /// The blog identifier.
        /// </value>
        [Key]
        public int BlogId { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the posts.
        /// </summary>
        /// <value>
        /// The posts.
        /// </value>
        public List<Post> Posts { get; set; }
    }

    /// <summary>
    /// <para>Post class</para>
    /// </summary>
    public class Post
    {
        /// <summary>
        /// Gets or sets the post identifier.
        /// </summary>
        /// <value>
        /// The post identifier.
        /// </value>
        [Key]
        public int PostId { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the blog.
        /// </summary>
        /// <value>
        /// The blog.
        /// </value>
        public Blog Blog { get; set; }
    }
}
