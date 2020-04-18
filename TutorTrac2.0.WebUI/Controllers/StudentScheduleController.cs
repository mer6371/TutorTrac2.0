using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TutorTrac2.core.Models;
using TutorTrac2.DataAccess.InMemory;

namespace TutorTrac2.WebUI.Controllers
{
    public class StudentScheduleController : Controller
    {
        StudentScheduleRepository context;

        public StudentScheduleController()
        {
            context = new StudentScheduleRepository();
        }

        //Get: StudentScheduleManager
        public ActionResult Index()
        {
            List<StudentSchedule> studentSchedules = context.Collection().ToList();
            return View(studentSchedules);
        }

        public ActionResult Create()
        {
            StudentSchedule studentSchedule = new StudentSchedule();
            return View(studentSchedule);
        }

        [HttpPost]
        public ActionResult Create(StudentSchedule studentSchedule)
        {
            if (!ModelState.IsValid)
            {
                return View(studentSchedule);
            }
            else
            {
                context.Insert(studentSchedule);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            StudentSchedule studentSchedule = context.Find(Id);
            if (studentSchedule == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(studentSchedule);
            }
        }

        [HttpPost]
        public ActionResult Edit(StudentSchedule studentSchedule, string Id)
        {
            StudentSchedule studentScheduleToEdit = context.Find(Id);
            if (studentSchedule == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(studentSchedule);
                }

                studentScheduleToEdit.c_code = studentSchedule.c_code;
                studentScheduleToEdit.professor = studentSchedule.professor;
                studentScheduleToEdit.day = studentSchedule.day;
                studentScheduleToEdit.time = studentSchedule.time;
                studentScheduleToEdit.room = studentSchedule.room;

                context.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            StudentSchedule studentScheduleToDelete = context.Find(Id);
            if (studentScheduleToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(studentScheduleToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            StudentSchedule studentScheduleToDelete = context.Find(Id);
            if (studentScheduleToDelete == null)
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