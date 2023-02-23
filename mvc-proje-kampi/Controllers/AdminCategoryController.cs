using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_proje_kampi.Controllers
{
    public class AdminCategoryController : Controller
    {

        CategoryManager cm = new CategoryManager(new EfCategoryDal());

        public ActionResult Index()
        {
            var values = cm.GetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            CategoryValidator validator = new CategoryValidator();
            ValidationResult results = validator.Validate(category);

            if (results.IsValid)
            {
                cm.CategoryAddBL(category);
                return RedirectToAction("Index");
            }

            else
            {
                foreach (var x in results.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
            }

            return View();
        }

        public ActionResult DeleteCategory(int id)
        {
            var value = cm.GetByID(id);
            cm.CategoryDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var value = cm.GetByID(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            cm.CategoryUpdate(category);
            return RedirectToAction("Index");
        }

    }
}