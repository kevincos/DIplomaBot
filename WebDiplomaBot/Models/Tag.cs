using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebDiplomaBot.Models
{
    public class Tag
    {
        [Key]
        public int TagID { get; set; }

        public String Name { get; set; }
    }
}