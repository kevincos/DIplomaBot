using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Migrations;

namespace WebDiplomaBot.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<WebDiplomaBot.Models.DiplomaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }
    }

}