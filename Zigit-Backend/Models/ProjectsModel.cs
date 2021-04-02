using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zigit_Backend.Models
{
    public class ProjectsModel
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Score { get; set; }

        [Required]
        public int BugsCount { get; set; }

        [Required]
        public int DurationInDays { get; set; }

        [Required]
        public bool MadeDeadLine { get; set; }

        [Required]
        public Guid UserID { get; set; }

        [Required]
        public UserModel User { get; set; }
    }
}
