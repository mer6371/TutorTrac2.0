using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorTrac2.core.Models
{
    public class ClassGrouping
    {
        public string Id { get; set; }
        [DisplayName("Class Code")]
        public string Class_Code { get; set; }
        [DisplayName("Class Title")]
        public string Class_Title { get; set; }

        public ClassGrouping()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
