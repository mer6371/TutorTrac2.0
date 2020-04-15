using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorTrac2.core.Models
{
    public class StudentAppointment
    {
        public string Id { get; set; }

        [DisplayName("Tutor")]
        public int tut_id { get; set; }

        public DateTime dateTime { get; set; }

        [DisplayName("Class")]
        public string ses_class { get; set; }

        public StudentAppointment()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
