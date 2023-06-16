namespace LMSweb.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LMSweb.Models.LMSmodel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LMSweb.Models.LMSmodel context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.ExperimentalProcedures.AddOrUpdate(
                p => p.EProcedureID,
                new Models.ExperimentalProcedure { EProcedureID = "1", Name = "�ؼг]�m" },
                new Models.ExperimentalProcedure { EProcedureID = "2", Name = "�ۧڤϫ�" },
                new Models.ExperimentalProcedure { EProcedureID = "3", Name = "�ζ��ϫ�" },
                new Models.ExperimentalProcedure { EProcedureID = "4", Name = "�ǲߺʷ�" },
                new Models.ExperimentalProcedure { EProcedureID = "5", Name = "�P������" },
                new Models.ExperimentalProcedure { EProcedureID = "6", Name = "�����^�X" }
                );
        }
    }
}
