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

        public ActionResult Create()
        {
            ClassGrouping classGrouping = new ClassGrouping();
            return View(classGrouping);
        }

        [HttpPost]
        public ActionResult Create(ClassGrouping classGrouping)
        {
            if (!ModelState.IsValid)
            {
                return View(classGrouping);
            }
            else
            {
                context.Insert(classGrouping);
                context.Commit();

                return RedirectToAction("Index");
            }
        }
    }
}