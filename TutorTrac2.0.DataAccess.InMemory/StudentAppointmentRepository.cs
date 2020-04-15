using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using TutorTrac2.core.Models;

namespace TutorTrac2.DataAccess.InMemory
{
    public class StudentAppointmentRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<StudentAppointment> studentAppointments;

        public StudentAppointmentRepository()
        {
            studentAppointments = cache["studentAppointments"] as List<StudentAppointment>;
            if(studentAppointments == null)
            {
                studentAppointments = new List<StudentAppointment>();
            }
        }

        public void Commit()
        {
            cache["studentAppointments"] = studentAppointments;
        }

        public void Insert(StudentAppointment a)
        {
            studentAppointments.Add(a);
        }

        public void Update(StudentAppointment studentAppointment)
        {
            StudentAppointment studentAppointmentToUpdate = studentAppointments.Find(a => a.Id == studentAppointment.Id);

            if (studentAppointmentToUpdate != null)
            {
                studentAppointmentToUpdate = studentAppointment;
            }
            else
            {
                throw new Exception("Appointment Not Found");
            }
        }

        public StudentAppointment Find(string Id)
        {
            StudentAppointment studentAppointment = studentAppointments.Find(a => a.Id == Id);

            if (studentAppointment != null)
            {
                return studentAppointment;
            }
            else
            {
                throw new Exception("Appointment Not Found");
            }
        }

        public IQueryable<StudentAppointment> Collection()
        {
            return studentAppointments.AsQueryable();
        }

        public void delete(string Id)
        {
            StudentAppointment studentAppointmentToDelete = studentAppointments.Find(a => a.Id == Id);

            if (studentAppointmentToDelete != null)
            {
                studentAppointments.Remove(studentAppointmentToDelete);
            }
            else
            {
                throw new Exception("Appointment Not Found");
            }
        }
    }
}
