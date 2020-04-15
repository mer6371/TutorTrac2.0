using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorTrac2.core.Models
{
    public class TutorAppointment
    {
        public string Id { get; set; }

        [DisplayName("Student First Name")]
        public string stu_fname { get; set; }

        [DisplayName("Student Last Name")]
        public string stu_lname { get; set; }

        [DisplayName("Date & Time")]
        public DateTime dateTime { get; set; }

        [DisplayName("Class")]
        public string ses_class { get; set; }

        public TutorAppointment()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
