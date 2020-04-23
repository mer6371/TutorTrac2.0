﻿using System;
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
        TutorRepository context;

        public TutorController()
        {
            context = new TutorRepository();
        }

        //Get: TutorManager
        public ActionResult Index()
        {
            List<Tutors> tutors = context.Collection().ToList();
            return View(tutors);
        }

    }
}