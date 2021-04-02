using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zigit_Backend.Models
{
    public class UserModel
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Team { get; set; }

        [Required]
        public string Avatar { get; set; }

        [Required]
        public DateTime JoinedAt { get; set; }

        public List<ProjectsModel> Projects { get; set; }
    }
}
