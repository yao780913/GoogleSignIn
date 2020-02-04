using System;
using System.ComponentModel.DataAnnotations;

namespace GoogleSignIn.Models
{
    public class Role
    {
        [Key]
        [StringLength(32)]
        public string Id { get; set; } = new Guid().ToString();

        public string Name { get; set; }
        
    }
}