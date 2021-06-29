using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TeisterMask.Data.Models
{
    public class Project
    {
        public Project()
        {
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime OpenDate { get; set; }

        public DateTime? DueDate { get; set; }

        public ICollection<Task> Tasks { get; set; }
    }
}

