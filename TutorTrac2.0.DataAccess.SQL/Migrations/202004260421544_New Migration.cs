namespace TutorTrac2._0.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClassGroupings", "Class_Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClassGroupings", "Class_Description");
        }
    }
}
