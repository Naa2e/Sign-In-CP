using Check_In.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Check_In.Controllers
{
    public class CheckInCntrl : Controller
    {
        private TeacherRepo repository;
        //private Mock<>

        public CheckInCntrl()
        {
            repository = new TeacherRepo();
        }

        public CheckInCntrl(TeacherRepo _repo)
        {
            repository = _repo;
        }

        // GET: Board
        [Authorize]
        public ActionResult Index()
        {
            //UserManager<ApplicationUser> manager = new UserManager<ApplicationUser>();
            //UserManager<ApplicationUser> manager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            return View();
        }

        // GET: Board/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Board/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateList(FormCollection form)
        {
     
            return RedirectToAction("Index");

        }

        // POST: Board/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Board/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Board/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Board/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Board/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}