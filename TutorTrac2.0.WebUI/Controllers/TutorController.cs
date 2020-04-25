using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TutorTrac2.core.Models;
using TutorTrac2.DataAccess.InMemory;

namespace TutorTrac2.WebUI.Controllers
{
    public class TutorController : Controller
    {
        InMemoryRepository<Tutors> context;

        public TutorController()
        {
            context = new InMemoryRepository<Tutors>();
        }

        //Get: TutorManager
        public ActionResult Index()
        {
            List<Tutors> tutors = context.Collection().ToList();
            return View(tutors);
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