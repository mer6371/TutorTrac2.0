﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorTrac2.core.Models;

namespace TutorTrac2.core.ViewModels
{
    public class TutorListViewModel
    {
        public IEnumerable<Tutors> Tutors { get; set; }
        public IEnumerable<ClassGrouping> ClassGroupings { get; set; }
    }
}
