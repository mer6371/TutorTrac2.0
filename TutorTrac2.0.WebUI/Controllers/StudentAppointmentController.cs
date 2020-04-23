using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TutorTrac2.core.Models;
using TutorTrac2.core.ViewModels;
using TutorTrac2.DataAccess.InMemory;

namespace TutorTrac2.WebUI.Controllers
{
    public class StudentAppointmentController : Controller  
    {
        StudentAppointmentRepository context;
        TutorRepository tutors;
        ClassRepository classes;

        public StudentAppointmentController()
        {
            context = new StudentAppointmentRepository();
            tutors = new TutorRepository();
            classes = new ClassRepository();
        }

        //Get: StudentAppointmentManager
        public ActionResult Index()
        {
            List<StudentAppointment> studentAppointments = context.Collection().ToList();
            return View(studentAppointments);
        }

        public ActionResult Create()
        {
            TutorViewModel viewModel = new TutorViewModel();

            viewModel.StudentAppointment = new StudentAppointment();
            viewModel.Tutors = tutors.Collection();
            viewModel.ClassGroupings = classes.Collection();
            return View(viewModel);
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
                TutorViewModel viewModel = new TutorViewModel();
                viewModel.StudentAppointment = studentAppointment;
                viewModel.Tutors = tutors.Collection();
                viewModel.ClassGroupings = classes.Collection();
                return View(viewModel);
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

                studentAppointmentToEdit.tut_f_name = studentAppointment.tut_f_name;
                studentAppointmentToEdit.tut_l_name = studentAppointment.tut_l_name;
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