using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorTrac2.core.Models
{
    public class StudentSchedule : BaseEntity
    {
        [DisplayName("Class Code")]
        public string c_code { get; set; }
        [DisplayName("Professor")]
        public string professor { get; set; }
        [DisplayName("Days")]
        public string day { get; set; }
        [DisplayName("Time")]
        public string time { get; set; }
        [DisplayName("Room")]
        public string room { get; set; }

    }
}
