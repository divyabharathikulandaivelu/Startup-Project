using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExerciseInfo.Models
{
    public class ExerciseModal
    {
        
        [Required]
        [StringLength(100)]
        public string ExerciseName { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public int Duration { get; set; }


    }
}

   