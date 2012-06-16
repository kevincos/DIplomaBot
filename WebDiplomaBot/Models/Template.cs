using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebDiplomaBot.Models
{
    public class Template
    {
        [Key]
        public int TemplateID { get; set; }

        public String Target { get; set; }
        public String Replacement { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}