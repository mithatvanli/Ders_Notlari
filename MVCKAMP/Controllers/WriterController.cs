using BusinessLayer.concrete;
using BusinessLayer.ValidationRules_FluentValidations;
using DataAccessLayer.EntityFramework;
using EntityLayer.concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCKAMP.Controllers
{
    public class WriterController : Controller
    {
        WriterValidator writervalidator = new WriterValidator();
        WriterManager Ww = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var WriterValues = Ww.GetList();
            return View(WriterValues);
        }
        [HttpGet]
        public ActionResult AddWriter() 
        {        
         return View();
        }
        [HttpPost]
        public ActionResult AddWriter(Writer p)
        {            
            ValidationResult result= writervalidator.Validate(p);
            if (result.IsValid)
            {
                Ww.WriterAddBL(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }




        [HttpGet]
        public ActionResult EditWriter(int Id) 
        {
            var writervalues = Ww.GetById(Id);
            return View(writervalues);        
        }
        [HttpPost]
        public ActionResult EditWriter(Writer p)
        {
            WriterValidator writervalidator = new WriterValidator();
            ValidationResult result = writervalidator.Validate(p);
            if (result.IsValid)
            {
                Ww.WriterUpdate(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }

    }
}