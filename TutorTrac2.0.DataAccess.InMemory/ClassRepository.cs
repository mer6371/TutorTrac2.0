using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using TutorTrac2.core.Models;

namespace TutorTrac2.DataAccess.InMemory
{
    public class ClassRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ClassGrouping> classGroupings;

        public ClassRepository()
        {
            classGroupings = cache["classGroupings"] as List<ClassGrouping>;
            if (classGroupings == null)
            {
                classGroupings = new List<ClassGrouping>();
            }
        }

        public void Commit()
        {
            cache["classGroupings"] = classGroupings;
        }

        public void Insert(ClassGrouping c)
        {
            classGroupings.Add(c);
        }

        public void Update(ClassGrouping classGrouping)
        {
            ClassGrouping classGroupingToUpdate = classGroupings.Find(c => c.Id == classGrouping.Id);

            if (classGroupingToUpdate != null)
            {
                classGroupingToUpdate = classGrouping;
            }
            else
            {
                throw new Exception("Class Not Found");
            }
        }

        public ClassGrouping Find(string Id)
        {
            ClassGrouping classGrouping = classGroupings.Find(c => c.Id == Id);

            if (classGrouping != null)
            {
                return classGrouping;
            }
            else
            {
                throw new Exception("Class Not Found");
            }
        }

        public IQueryable<ClassGrouping> Collection()
        {
            return classGroupings.AsQueryable();
        }

        public void delete(string Id)
        {
            ClassGrouping classGroupingToDelete = classGroupings.Find(c => c.Id == Id);

            if (classGroupingToDelete != null)
            {
                classGroupings.Remove(classGroupingToDelete);
            }
            else
            {
                throw new Exception("Appointment Not Found");
            }
        }
    }
}
