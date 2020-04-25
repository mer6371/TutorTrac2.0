using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorTrac2.core.Models
{
    public class StudentAppointment : BaseEntity
    {
        [DisplayName("Tutor First Name")]
        public string tut_f_name { get; set; }

        [DisplayName("Tutor Last Name")]
        public string tut_l_name { get; set; }

        [DisplayName("Date & Time")]
        public DateTime dateTime { get; set; }

        [DisplayName("Class")]
        public string ses_class { get; set; }

        
    }
}
