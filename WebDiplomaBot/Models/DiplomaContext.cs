using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Migrations;

using WebDiplomaBot.Migrations;

namespace WebDiplomaBot.Models
{
    public class DiplomaContext : DbContext
    {
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Template> Templates { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
          //  Database.SetInitializer(new MigrateDatabaseToLatestVersion<DiplomaContext, Configuration>());
        //}
    }
}