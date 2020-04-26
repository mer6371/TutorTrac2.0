using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorTrac2.core.Models;

namespace TutorTrac2.core.ViewModels
{
    public class ClassListViewModel
    {
        public IEnumerable<ClassGrouping> ClassGrouping { get; set; }
        public IEnumerable<ClassTutors> ClassTutors { get; set; }
    }
}
