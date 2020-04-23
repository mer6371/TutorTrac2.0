using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorTrac2.core.Models
{
    public class Tutors
    {
        public string Id { get; set; }
        [DisplayName("First Name")]
        public string tut_f_name { get; set; }
        [DisplayName("Last Name")]
        public string tut_l_name { get; set; }
        [DisplayName("Email")]
        public string tut_email { get; set; }

        public Tutors()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
