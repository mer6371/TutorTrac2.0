using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TutorTrac2.core.Models;
using TutorTrac2.DataAccess.InMemory;

namespace TutorTrac2.WebUI.Controllers
{
    public class TutorScheduleController : Controller
    {
        InMemoryRepository<TutorSchedule> context;

        public TutorScheduleController()
        {
            context = new InMemoryRepository<TutorSchedule>();
        }

        //Get: TutorScheduleManager
        public ActionResult Index()
        {
            List<TutorSchedule> tutorSchedules = context.Collection().ToList();
            return View(tutorSchedules);
        }

        public ActionResult Create()
        {
            TutorSchedule tutorSchedule = new TutorSchedule();
            return View(tutorSchedule);
        }

        [HttpPost]
        public ActionResult Create(TutorSchedule tutorSchedule)
        {
            if (!ModelState.IsValid)
            {
                return View(tutorSchedule);
            }
            else
            {
                context.Insert(tutorSchedule);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            TutorSchedule tutorSchedule = context.Find(Id);
            if (tutorSchedule == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(tutorSchedule);
            }
        }

        [HttpPost]
        public ActionResult Edit(TutorSchedule tutorSchedule, string Id)
        {
            TutorSchedule tutorScheduleToEdit = context.Find(Id);
            if (tutorSchedule == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(tutorSchedule);
                }

                tutorScheduleToEdit.day = tutorSchedule.day;
                tutorScheduleToEdit.time = tutorSchedule.time;

                context.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            TutorSchedule tutorScheduleToDelete = context.Find(Id);
            if (tutorScheduleToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(tutorScheduleToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            TutorSchedule tutorScheduleToDelete = context.Find(Id);
            if (tutorScheduleToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}