using StudentStreamingSystem.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentStreamingSystem.Controllers
{
    public class StudentResultController : Controller
    {
        // GET: StudentResult
        StudentStreamingDBEntities db = new StudentStreamingDBEntities();
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult CreateEnrollCourse()
        {
            ViewBag.Students = new SelectList(db.Students.ToList(), "StudentId", "ApNo");
            ViewBag.Courses = new SelectList(db.Courses.ToList(), "CourseID", "CourseName");

            return View();
        }
        [HttpPost]

        public ActionResult CreateEnrollCourse(StudentResult enrollInACourse)
        {
            //enrollInACourse.Status = "Enroll";

            db.Entry(enrollInACourse).State = EntityState.Added;
            db.SaveChanges();

            return RedirectToAction("CreateEnrollCourse", "EnrollCourse");
        }
        [HttpPost]
        public JsonResult GetStudentNameEmailDeptByRegNo(int studentId)
        {
            string students = db.Students.Where(u => u.StudentID == studentId).Select(u => u.Email).SingleOrDefault();

            return Json(students);
        }
    }


}