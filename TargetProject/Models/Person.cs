using System;
using System.ComponentModel.DataAnnotations;

namespace TargetProject.Models
{
    public class Person : Entity
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string FullName { get; set; }
        
        [Required]
        
        public int Born{ get; set; }

        [Required]
        public string Email { get; set; }
   
        [Required]
        public int Phone { get; set; }

    }
}
