using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebDiplomaBot.Models
{
    public class Instructor
    {
        [Key]
        public int InstructorID { get; set; }

        public String LogonID { get; set; }
        public String FullName { get; set; }
        public String Nickname { get; set; }

        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}