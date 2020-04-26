namespace TutorTrac2._0.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationTwo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tutors", "Schedule", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tutors", "Schedule");
        }
    }
}
