using GoogleSignIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoogleSignIn.ViewModels
{
    public class LoginViewModels
    {
        public IEnumerable<Role> Roles { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}