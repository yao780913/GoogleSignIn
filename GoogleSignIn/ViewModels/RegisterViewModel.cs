using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoogleSignIn
{
    public class RegisterViewModel
    {
        public User User { get; set; }
        public IEnumerable<Role> Roles { get; set; }
        public string Gmail { get; set; }
    }
}