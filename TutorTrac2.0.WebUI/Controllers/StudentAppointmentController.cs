using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TutorTrac2.core.Models;
using TutorTrac2.DataAccess.InMemory;

namespace TutorTrac2.WebUI.Controllers
{
    public class StudentAppointmentController : Controller
    {
        StudentAppointmentRepository context;

        public StudentAppointmentController()
        {
            context = new StudentAppointmentRepository();
        }

        //Get: StudentAppointmentManager
        public ActionResult Index()
        {
            List<StudentAppointment> studentAppointments = context.Collection().ToList();
            return View(studentAppointments);
        }

        public ActionResult Create()
        {
            StudentAppointment studentAppointment = new StudentAppointment();
            return View(studentAppointment);
        }

        [HttpPost]
        public ActionResult Create(StudentAppointment studentAppointment)
        {
            if(!ModelState.IsValid)
            {
                return View(studentAppointment);
            }
            else
            {
                context.Insert(studentAppointment);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            StudentAppointment studentAppointment = context.Find(Id);
            if (studentAppointment == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(studentAppointment);
            }
        }

        [HttpPost]
        public ActionResult Edit(StudentAppointment studentAppointment, string Id)
        {
            StudentAppointment studentAppointmentToEdit = context.Find(Id);
            if (studentAppointment == null)
            {
                return HttpNotFound();
            }
            else
            {
                if(!ModelState.IsValid)
                {
                    return View(studentAppointment);
                }

                studentAppointmentToEdit.tut_fname = studentAppointment.tut_fname;
                studentAppointmentToEdit.tut_lname = studentAppointment.tut_lname;
                studentAppointmentToEdit.dateTime = studentAppointment.dateTime;
                studentAppointmentToEdit.ses_class = studentAppointment.ses_class;

                context.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            StudentAppointment studentAppointmentToDelete = context.Find(Id);
            if (studentAppointmentToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(studentAppointmentToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            StudentAppointment studentAppointmentToDelete = context.Find(Id);
            if (studentAppointmentToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}