namespace TutorTrac2._0.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationOne : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClassGroupings", "tut_id", c => c.String());
            AddColumn("dbo.Tutors", "Class_Code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tutors", "Class_Code");
            DropColumn("dbo.ClassGroupings", "tut_id");
        }
    }
}
