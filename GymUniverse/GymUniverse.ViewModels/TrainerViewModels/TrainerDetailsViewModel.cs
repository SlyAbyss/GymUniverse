using GymUniverse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymUniverse.ViewModels.TrainerViewModels
{
    public class TrainerDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Bio { get; set; }
        public string ImageUrl { get; set; }
        public Location Location { get; set; }
        public List<Course> Courses { get; set; }
    }
}
