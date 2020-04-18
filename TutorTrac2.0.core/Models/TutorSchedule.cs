using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorTrac2.core.Models
{
    public class TutorSchedule
    {
        public string Id { get; set; }
        [DisplayName("Day")]
        public DayOfWeek day { get; set; }
        [DisplayName("Time")]
        public string time { get; set; }

        public TutorSchedule()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
