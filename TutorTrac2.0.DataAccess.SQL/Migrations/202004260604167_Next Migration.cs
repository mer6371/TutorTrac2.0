namespace TutorTrac2._0.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NextMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClassTutors", "CreatedAt", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClassTutors", "CreatedAt");
        }
    }
}
