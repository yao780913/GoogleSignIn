using GoogleSignIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoogleSignIn.Controllers
{
    public class LoginsController : Controller
    {
        private ProjectContext _dbcontext;
        public LoginsController()
        {
            _dbcontext = new ProjectContext();
        }
        // GET: Logins
        public ActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddRoles(Role role)
        {
            _dbcontext.Roles.Add(role);
            _dbcontext.SaveChanges();

            return View("Index");
        }


    }
}