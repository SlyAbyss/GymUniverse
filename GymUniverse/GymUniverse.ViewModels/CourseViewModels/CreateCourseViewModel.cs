using GymUniverse.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GymUniverse.Constants.DataModelConstants;

namespace GymUniverse.ViewModels.CourseViewModels
{
    public class CreateCourseViewModel
    {     
        [Required]
        [StringLength(CourseNameMaxLength, MinimumLength = CourseNameMinLength)]
        public string Name { get; set; }

        [Required]
        [Range(CoursePriceMinAmount, CoursePriceMaxAmount)]
        public int Price { get; set; }

        [Required]
        public DateTime Schedule { get; set; } = DateTime.Now;

        [Required]
        [StringLength(CourseDescriptionMaxLength, MinimumLength = CourseDescriptionMinLength)]
        public string Description { get; set; }

        public int TrainerId { get; set; }
    }
}