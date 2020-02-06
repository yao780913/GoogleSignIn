using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GoogleSignIn
{
    public class DbEntities: DbContext
    {
        public DbEntities()
            :base("DbEntities")
        {

        }
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

    }
}