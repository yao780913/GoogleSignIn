using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace GoogleSignIn.Models
{
    public class User
    {
        [Key]
        [StringLength(32)]
        public string Id { get; set; } = new Guid().ToString();
        public string Name { get; set; }
        public string Email { get; set; }

        public string RoleId { get; set; }
        public Role Role { get; set; }

    }
}