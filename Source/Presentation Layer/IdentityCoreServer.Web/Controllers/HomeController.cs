//-----------------------------------------------------------------------
// <copyright file="HomeController.cs" company="Ansi ByteCode LLP">
//     Copyright (c) Ansi ByteCode LLP. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace IdentityCoreServer.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Project.Data.Entity;
    using Project.Identity;

    /// <summary>
    /// <para>HomeController class</para>
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class HomeController : Controller
    {
        /// <summary>
        /// The _role
        /// </summary>
        private readonly IRepository<Role> _role;

        /// <summary>
        /// The _post
        /// </summary>
        private readonly IRepository<Post> _post;

        /// <summary>
        /// The _user
        /// </summary>
        private readonly IRepository<User> _user;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <param name="post">The post.</param>
        /// <param name="user">The user.</param>
        public HomeController(IRepository<Role> role, IRepository<Post> post, IRepository<User> user)
        {
            this._role = role;
            this._post = post;
            this._user = user;
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>The index view</returns>
        public IActionResult Index()
        {
            Post post = this._post.Find(1);

            Role role = this._role.Find("0");

            User user = this._user.Find("0");

            return View();
        }

        /// <summary>
        /// Abouts this instance.
        /// </summary>
        /// <returns>The about view</returns>
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        /// <summary>
        /// Contacts this instance.
        /// </summary>
        /// <returns>The contact view</returns>
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        /// <summary>
        /// Errors this instance.
        /// </summary>
        /// <returns>The error view</returns>
        public IActionResult Error()
        {
            return View();
        }
    }
}
