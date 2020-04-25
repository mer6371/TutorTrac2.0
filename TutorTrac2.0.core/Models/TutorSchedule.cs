using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorTrac2.core.Models
{
    public class TutorSchedule : BaseEntity
    {
        [DisplayName("Day")]
        public DayOfWeek day { get; set; }
        [DisplayName("Time")]
        public string time { get; set; }
    }
}
