using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace GoogleSignIn
{
    public class User
    {
        [Key]
        [StringLength(36)]
        public string Id { get; set; } = Guid.NewGuid().ToString("D");
        public string Name { get; set; }
        public string Email { get; set; }

        public string RoleId { get; set; }
        public Role Role { get; set; }

    }
}