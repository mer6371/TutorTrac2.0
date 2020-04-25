using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TutorTrac2.core.Models;
using TutorTrac2.DataAccess.InMemory;

namespace TutorTrac2.WebUI.Controllers
{
    public class TutorAppointmentController : Controller
    {
        InMemoryRepository<TutorAppointment> context;

        public TutorAppointmentController()
        {
            context = new InMemoryRepository<TutorAppointment>();
        }

        //Get: TutorAppointmentManager
        public ActionResult Index()
        {
            List<TutorAppointment> tutorAppointments = context.Collection().ToList();
            return View(tutorAppointments);
        }

        public ActionResult Create()
        {
            TutorAppointment tutorAppointment = new TutorAppointment();
            return View(tutorAppointment);
        }

        [HttpPost]
        public ActionResult Create(TutorAppointment tutorAppointment)
        {
            if (!ModelState.IsValid)
            {
                return View(tutorAppointment);
            }
            else
            {
                context.Insert(tutorAppointment);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            TutorAppointment tutorAppointment = context.Find(Id);
            if (tutorAppointment == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(tutorAppointment);
            }
        }

        [HttpPost]
        public ActionResult Edit(TutorAppointment tutorAppointment, string Id)
        {
            TutorAppointment tutorAppointmentToEdit = context.Find(Id);
            if (tutorAppointment == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(tutorAppointment);
                }

                tutorAppointmentToEdit.stu_fname = tutorAppointment.stu_fname;
                tutorAppointmentToEdit.stu_lname = tutorAppointment.stu_lname;
                tutorAppointmentToEdit.dateTime = tutorAppointment.dateTime;
                tutorAppointmentToEdit.ses_class = tutorAppointment.ses_class;

                context.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            TutorAppointment tutorAppointmentToDelete = context.Find(Id);
            if (tutorAppointmentToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(tutorAppointmentToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            TutorAppointment tutorAppointmentToDelete = context.Find(Id);
            if (tutorAppointmentToDelete == null)
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