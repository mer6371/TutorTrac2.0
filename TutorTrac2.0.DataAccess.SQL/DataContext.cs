using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorTrac2.core.Models;

namespace TutorTrac2.DataAccess.SQL
{
    public class DataContext : DbContext
    {
        public DataContext()
            :base("DefaultConnection")
        {
        }

        public DbSet<ClassGrouping> Classes { get; set; }
        public DbSet<ClassTutors> ClassTutors { get; set; }
        public DbSet<StudentAppointment> StudentAppointments { get; set; }
        public DbSet<StudentSchedule> StudentSchedules { get; set; }
        public DbSet<TutorAppointment> TutorAppointments { get; set; }
        public DbSet<Tutors> Tutors { get; set; }
        public DbSet<TutorSchedule> TutorSchedules { get; set; }
    }
}
