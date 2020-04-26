using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorTrac2.core.Models
{
    public class Students : BaseEntity
    {
        public string UserId { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
