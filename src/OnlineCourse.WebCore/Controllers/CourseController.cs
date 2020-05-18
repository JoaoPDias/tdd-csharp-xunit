using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineCourse.Domain.Courses;
using OnlineCourse.Web.Util;

namespace OnlineCourse.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseService _courseService;

        public CourseController(CourseService courseService)
        {
            _courseService = courseService;
        }
        public ActionResult Index()
        {
            var courses = _courseService.GetAll();
            return View("Index", PaginatedList<CourseDTO>.Create(courses, Request));

        }

        public IActionResult Update(int id)
        {
            var courseDTO = _courseService.GetById(id);
            return View("CreateOrUpdate", courseDTO);
        }

        public IActionResult Create()
        {
            return View("CreateOrUpdate", new CourseDTO());
        }

        public IActionResult Save(CourseDTO model) {
            _courseService.Save(model);
            return RedirectToAction("Index");
        }

    }
}