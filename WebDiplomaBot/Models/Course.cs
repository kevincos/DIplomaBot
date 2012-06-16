using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebDiplomaBot.Models
{
    public enum ProjectType
    {
        Project,
        Game,
        Level
    }

    public class Course
    {
        [Key]
        public int CourseID { get; set; }

        public String CourseName { get; set; }
        public ProjectType DefaultProjectType { get; set; }
        
    }
}