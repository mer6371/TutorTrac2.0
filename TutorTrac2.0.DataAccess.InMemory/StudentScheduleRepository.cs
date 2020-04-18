using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using TutorTrac2.core.Models;

namespace TutorTrac2.DataAccess.InMemory
{
    public class StudentScheduleRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<StudentSchedule> studentSchedules;

        public StudentScheduleRepository()
        {
            studentSchedules = cache["studentSchedules"] as List<StudentSchedule>;
            if (studentSchedules == null)
            {
                studentSchedules = new List<StudentSchedule>();
            }
        }

        public void Commit()
        {
            cache["studentSchedules"] = studentSchedules;
        }

        public void Insert(StudentSchedule s)
        {
            studentSchedules.Add(s);
        }

        public void Update(StudentSchedule studentSchedule)
        {
            StudentSchedule studentScheduleToUpdate = studentSchedules.Find(s => s.Id == studentSchedule.Id);

            if (studentScheduleToUpdate != null)
            {
                studentScheduleToUpdate = studentSchedule;
            }
            else
            {
                throw new Exception("Class Not Found");
            }
        }

        public StudentSchedule Find(string Id)
        {
            StudentSchedule studentSchedule = studentSchedules.Find(s => s.Id == Id);

            if (studentSchedule != null)
            {
                return studentSchedule;
            }
            else
            {
                throw new Exception("Class Not Found");
            }
        }

        public IQueryable<StudentSchedule> Collection()
        {
            return studentSchedules.AsQueryable();
        }

        public void delete(string Id)
        {
            StudentSchedule studentScheduleToDelete = studentSchedules.Find(s => s.Id == Id);

            if (studentScheduleToDelete != null)
            {
                studentSchedules.Remove(studentScheduleToDelete);
            }
            else
            {
                throw new Exception("Class Not Found");
            }
        }
    }
}
