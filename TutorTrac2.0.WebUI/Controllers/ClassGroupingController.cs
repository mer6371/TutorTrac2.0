using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TutorTrac2.core.Contracts;
using TutorTrac2.core.Models;
using TutorTrac2.DataAccess.InMemory;

namespace TutorTrac2.WebUI.Controllers
{
    public class ClassGroupingController : Controller
    {
        IRepository<ClassGrouping> context;

        public ClassGroupingController(IRepository<ClassGrouping> classGroupingContext)
        {
            context = classGroupingContext;
        }

        //Get: ClassManager
        public ActionResult Index()
        {
            List<ClassGrouping> tutors = context.Collection().ToList();
            return View(tutors);
        }
    }
}