using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorTrac2.core.Models
{
    public class ClassGrouping : BaseEntity
    {
        [DisplayName("Class Code")]
        public string Class_Code { get; set; }
        [DisplayName("Class Title")]
        public string Class_Title { get; set; }
        [DisplayName("Class Description")]
        public string Class_Description { get; set; }
        public string tut_id { get; set; }

        
    }
}
