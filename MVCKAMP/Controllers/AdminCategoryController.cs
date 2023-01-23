using BusinessLayer.concrete;
using BusinessLayer.ValidationRules_FluentValidations;
using DataAccessLayer.EntityFramework;
using EntityLayer.concrete;
using FluentValidation.Results;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCKAMP.Controllers
{
    public class AdminCategoryController : Controller
    {
        CategoryManager Cm = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            var CategoryValues = Cm.GetList();
            return View(CategoryValues);
        }
        [HttpGet]
        public ActionResult CategoryAdd() 
        {
            return View();        
        }
        [HttpPost]
        public ActionResult CategoryAdd(Category p)
        {
            CategoryValidator categoryvalidator = new CategoryValidator();
            ValidationResult results =categoryvalidator.Validate(p);
            if (results.IsValid)
            {
                Cm.CategoryAddBL(p);
                return RedirectToAction("Index");

            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult DeleteCategory(int Id)
        {
            var CategorValue = Cm.GetById(Id);
            Cm.CategoryDelete(CategorValue);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditCategory(int Id)    
        {
            var CategoryValue = Cm.GetById(Id);
            return View(CategoryValue);
        }
        [HttpGet]
        public ActionResult CategoryUpdate(Category p)
        {
            Cm.CategoryUpdate(p);
            return RedirectToAction("Index");
        }
    }
}