using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using TutorTrac2.core.Models;

namespace TutorTrac2.DataAccess.InMemory
{
    public class TutorScheduleRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<TutorSchedule> tutorSchedules;

        public TutorScheduleRepository()
        {
            tutorSchedules = cache["tutorSchedules"] as List<TutorSchedule>;
            if (tutorSchedules == null)
            {
                tutorSchedules = new List<TutorSchedule>();
            }
        }

        public void Commit()
        {
            cache["tutorSchedules"] = tutorSchedules;
        }

        public void Insert(TutorSchedule s)
        {
            tutorSchedules.Add(s);
        }

        public void Update(TutorSchedule tutorSchedule)
        {
            TutorSchedule tutorScheduleToUpdate = tutorSchedules.Find(s => s.Id == tutorSchedule.Id);

            if (tutorScheduleToUpdate != null)
            {
                tutorScheduleToUpdate = tutorSchedule;
            }
            else
            {
                throw new Exception("Session Not Found");
            }
        }

        public TutorSchedule Find(string Id)
        {
            TutorSchedule tutorSchedule = tutorSchedules.Find(s => s.Id == Id);

            if (tutorSchedule != null)
            {
                return tutorSchedule;
            }
            else
            {
                throw new Exception("Session Not Found");
            }
        }

        public IQueryable<TutorSchedule> Collection()
        {
            return tutorSchedules.AsQueryable();
        }

        public void delete(string Id)
        {
            TutorSchedule tutorScheduleToDelete = tutorSchedules.Find(s => s.Id == Id);

            if (tutorScheduleToDelete != null)
            {
                tutorSchedules.Remove(tutorScheduleToDelete);
            }
            else
            {
                throw new Exception("Session Not Found");
            }
        }
    }
}
