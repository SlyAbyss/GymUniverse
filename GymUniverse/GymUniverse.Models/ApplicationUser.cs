﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymUniverse.Models
{
    public class ApplicationUser : IdentityUser
    {
        public  ICollection<UserCourse> UserCourses { get; set; }
    }
}
