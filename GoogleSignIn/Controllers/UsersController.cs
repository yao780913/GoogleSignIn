﻿using GoogleSignIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace GoogleSignIn.Controllers
{
    public class UsersController : Controller
    {
        private DbEntities _dbcontext;
        public UsersController()
        {
            _dbcontext = new DbEntities();
        }

        public ActionResult Index()
        {
            var viewModel = new UsersViewModel()
            {
                Roles = _dbcontext.Roles.ToList(),
                Users = _dbcontext.Users.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddRole()
        {
            var role = new Role()
            {
                Name = "測試腳色"
            };

            _dbcontext.Roles.Add(role);
            _dbcontext.SaveChanges();

            return RedirectToAction("Index");
        }




    }
}