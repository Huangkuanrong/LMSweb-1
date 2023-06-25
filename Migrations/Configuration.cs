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

            context.CommentTypes.AddOrUpdate(
                p => p.CommentTypeID,
                new Models.CommentType { CommentTypeID = "01", CTContent = "�ڭ̷Q���g�o�ժ��y�{�ϩε{���X", CTAttribute = "���y" },
                new Models.CommentType { CommentTypeID = "02", CTContent = "�ڭ̷Q����o�ժ��y�{�ϩε{���X", CTAttribute = "���y" },
                new Models.CommentType { CommentTypeID = "03", CTContent = "�ڭ̷Q���X�o�զ����~���a��", CTAttribute = "���y" },
                new Models.CommentType { CommentTypeID = "04", CTContent = "�ڭ̷Q�гo�շQ�Q�ݦp���i�L�̪��y�{�ϩε{���X", CTAttribute = "���y" },
                new Models.CommentType { CommentTypeID = "05", CTContent = "�ڭ̷Q����o�ժ��@�~�L��������", CTAttribute = "���y" },
                new Models.CommentType { CommentTypeID = "06", CTContent = "�ڭ̷Q���g�o�յ������y", CTAttribute = "�^�X" },
                new Models.CommentType { CommentTypeID = "07", CTContent = "�ڭ̷Q����o�յ������y", CTAttribute = "�^�X" },
                new Models.CommentType { CommentTypeID = "08", CTContent = "�ڭ̷Q���X�o�յ������y�����~���a��", CTAttribute = "�^�X" },
                new Models.CommentType { CommentTypeID = "09", CTContent = "�ڭ̷Q�гo�շQ�Q�ݦp���i�L�̪����y", CTAttribute = "�^�X" },
                new Models.CommentType { CommentTypeID = "10", CTContent = "�ڭ̷Q����o�ժ����y�L�����^�X", CTAttribute = "�^�X" }
            );
        }
    }
}
