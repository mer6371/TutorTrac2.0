namespace TutorTrac2._0.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassGroupings",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Class_Code = c.String(nullable: false, maxLength: 128),
                        Class_Title = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Class_Code);
            
            CreateTable(
                "dbo.ClassTutors",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Class_Code = c.String(),
                        tut_id = c.String(),
                    })
                .PrimaryKey(t => t.Id);
                
            
            CreateTable(
                "dbo.StudentAppointments",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        tut_f_name = c.String(),
                        tut_l_name = c.String(),
                        dateTime = c.DateTime(nullable: false),
                        ses_class = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentSchedules",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        c_code = c.String(),
                        professor = c.String(),
                        day = c.String(),
                        time = c.String(),
                        room = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TutorAppointments",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        stu_fname = c.String(),
                        stu_lname = c.String(),
                        dateTime = c.DateTime(nullable: false),
                        ses_class = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tutors",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        tut_f_name = c.String(),
                        tut_l_name = c.String(),
                        tut_email = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TutorSchedules",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        day = c.Int(nullable: false),
                        time = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TutorSchedules");
            DropTable("dbo.Tutors");
            DropTable("dbo.TutorAppointments");
            DropTable("dbo.StudentSchedules");
            DropTable("dbo.StudentAppointments");
            DropTable("dbo.ClassTutors");
            DropTable("dbo.ClassGroupings");
        }
    }
}
