using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TutorTrac2.core.Contracts;
using TutorTrac2.core.Models;
using TutorTrac2.core.ViewModels;
using TutorTrac2.DataAccess.InMemory;

namespace TutorTrac2.WebUI.Controllers
{
    public class TutorController : Controller
    {
        IRepository<Tutors> context;
        IRepository<ClassGrouping> classes;

        public TutorController(IRepository<Tutors> tutorContext, IRepository<ClassGrouping> classGroupingContext)
        {
            context = tutorContext;
            classes = classGroupingContext;
        }

        //Get: TutorManager
        public ActionResult Index(string Class_Code = null)
        {
            List<Tutors> tutors;
            List<ClassGrouping> classGroupings = classes.Collection().ToList();

            if (Class_Code == null)
            {
                tutors = context.Collection().ToList();
            }
            else
            {
                tutors = context.Collection().Where(t => t.Class_Code == Class_Code).ToList();
            }

            TutorListViewModel model = new TutorListViewModel();
            model.Tutors = tutors;
            model.ClassGroupings = classGroupings;

            return View(model);
        }

        public ActionResult Create()
        {
            Tutors tutor = new Tutors();
            return View(tutor);
        }

        [HttpPost]
        public ActionResult Create(Tutors tutor)
        {
            if (!ModelState.IsValid)
            {
                return View(tutor);
            }
            else
            {
                context.Insert(tutor);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

    }
}