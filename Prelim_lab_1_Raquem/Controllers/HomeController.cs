using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Prelim_lab_1_Raquem.Models;
using System;
using System.Collections.Generic;

namespace Prelim_lab_1_Raquem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Task 1
            string studentName = "Enzo Raquem";
            int score = 87;
            bool isPassed = (score >= 75);
            DateTime examDate = DateTime.Now;
            decimal tuitionFee = 15500.75m;

            ViewBag.StudentName = studentName;
            ViewBag.Score = score;
            ViewBag.IsPassed = isPassed;
            ViewBag.ExamDate = examDate;
            ViewBag.TuitionFee = tuitionFee;

            // Task 2
            string grade;
            string message;

            if (score >= 90)
                grade = "A";
            else if (score >= 80)
                grade = "B";
            else if (score >= 75)
                grade = "C";
            else
                grade = "F";

            message = isPassed ? "Congratulations, you passed!" : "Better luck next time.";

            ViewBag.Grade = grade;
            ViewBag.Message = message;

            // Task 3
            string[] courses = { "Web Systems", "OOP", "DBMS", "UI/UX", "Networking" };
            string courseList = "";
            int courseCount = 0;

            foreach (var course in courses)
            {
                courseList += course + ", ";
                courseCount++;
            }

            ViewBag.CourseList = courseList.TrimEnd(',', ' ');
            ViewBag.CourseCount = courseCount;

            // Task 4
            ViewBag.NetFee = ComputeNetFee(tuitionFee, 10);

            // BONUS
            ViewBag.Today = DateTime.Now.ToString("MMMM dd, yyyy");

            // Task 5–6
            var student = new Student
            {
                Name = "Enzo Raquem",
                Age = 21,
                Course = "BSIT - Web Systems"
            };
            ViewBag.Student = student;

            var students = new List<Student>
            {
                new Student { Name = "Maria Santos", Age = 20, Course = "Web Systems" },
                new Student { Name = "Pedro Ramirez", Age = 21, Course = "OOP" },
                new Student { Name = "Angelica Reyes", Age = 22, Course = "DBMS" }
            };
            ViewBag.Students = students;

            return View();
        }

        public IActionResult AboutMe()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private decimal ComputeNetFee(decimal tuition, decimal discountPercent)
        {
            return tuition - (tuition * discountPercent / 100);
        }
    }
}
