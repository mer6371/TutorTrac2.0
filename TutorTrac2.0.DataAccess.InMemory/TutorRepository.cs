using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using TutorTrac2.core.Models;

namespace TutorTrac2.DataAccess.InMemory
{
    public class TutorRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Tutors> tutors;

        public TutorRepository()
        {
            tutors = cache["tutors"] as List<Tutors>;
            if (tutors == null)
            {
                tutors = new List<Tutors>();
            }
        }

        public void Commit()
        {
            cache["tutors"] = tutors;
        }

        public void Insert(Tutors t)
        {
            tutors.Add(t);
        }

        public void Update(Tutors tutor)
        {
            Tutors tutorsToUpdate = tutors.Find(t => t.Id == tutor.Id);

            if (tutorsToUpdate != null)
            {
                tutorsToUpdate = tutor;
            }
            else
            {
                throw new Exception("Tutor Not Found");
            }
        }

        public Tutors Find(string Id)
        {
            Tutors tutor = tutors.Find(t => t.Id == Id);

            if (tutors != null)
            {
                return tutor;
            }
            else
            {
                throw new Exception("Tutor Not Found");
            }
        }

        public IQueryable<Tutors> Collection()
        {
            return tutors.AsQueryable();
        }

        public void delete(string Id)
        {
            Tutors tutorsToDelete = tutors.Find(t => t.Id == Id);

            if (tutorsToDelete != null)
            {
                tutors.Remove(tutorsToDelete);
            }
            else
            {
                throw new Exception("Tutor Not Found");
            }
        }
    }
}
