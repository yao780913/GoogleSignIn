using System;
using System.ComponentModel.DataAnnotations;

namespace GoogleSignIn
{
    public class Role
    {
        [Key]
        [StringLength(36)]
        public string Id { get; set; } = Guid.NewGuid().ToString("D");

        public string Name { get; set; }
        
    }
}