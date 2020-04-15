using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using TutorTrac2.core.Models;

namespace TutorTrac2.DataAccess.InMemory
{
    public class TutorAppointmentRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<TutorAppointment> tutorAppointments;

        public TutorAppointmentRepository()
        {
            tutorAppointments = cache["tutorAppointments"] as List<TutorAppointment>;
            if (tutorAppointments == null)
            {
                tutorAppointments = new List<TutorAppointment>();
            }
        }

        public void Commit()
        {
            cache["tutorAppointments"] = tutorAppointments;
        }

        public void Insert(TutorAppointment a)
        {
            tutorAppointments.Add(a);
        }

        public void Update(TutorAppointment tutorAppointment)
        {
            TutorAppointment tutorAppointmentToUpdate = tutorAppointments.Find(a => a.Id == tutorAppointment.Id);

            if (tutorAppointmentToUpdate != null)
            {
                tutorAppointmentToUpdate = tutorAppointment;
            }
            else
            {
                throw new Exception("Appointment Not Found");
            }
        }

        public TutorAppointment Find(string Id)
        {
            TutorAppointment tutorAppointment = tutorAppointments.Find(a => a.Id == Id);

            if (tutorAppointment != null)
            {
                return tutorAppointment;
            }
            else
            {
                throw new Exception("Appointment Not Found");
            }
        }

        public IQueryable<TutorAppointment> Collection()
        {
            return tutorAppointments.AsQueryable();
        }

        public void delete(string Id)
        {
            TutorAppointment tutorAppointmentToDelete = tutorAppointments.Find(a => a.Id == Id);

            if (tutorAppointmentToDelete != null)
            {
                tutorAppointments.Remove(tutorAppointmentToDelete);
            }
            else
            {
                throw new Exception("Appointment Not Found");
            }
        }
    }
}
