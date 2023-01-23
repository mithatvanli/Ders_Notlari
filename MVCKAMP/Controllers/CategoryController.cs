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
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager Cm = new CategoryManager(new EfCategoryDal());//businesslayer katmanından çağırdık ve den Dal katmanından EfCategoryDal classını al dedik
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategoryList() 
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
        public ActionResult CategoryAdd(Category p) //httpPost sayfada herhagi bir düğmeye tıklandığında o düğmeye ne atıldıysa o çalışır  HttpGet ise sayfa yüklendiğinde çalışır
        {
            CategoryValidator categoryValidator=new CategoryValidator();
            ValidationResult validationResult = categoryValidator.Validate(p);//validationresult komutu kontrol sonuçlarını tutan komut
            if (validationResult.IsValid)
            {
                Cm.CategoryAddBL(p);
                return RedirectToAction("GetCategoryList"); //kaydetme yaptıysan beni bu aksiyona yönlendir
            }
            else
            {
                foreach (var item in validationResult.Errors)//validasyon sonuçlarındaki erroları dön
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage); //oluşan errorları önce property ismi sonra erroru getir
                }
            }
           // Cm.CategoryAddBL(p);    
            return View();
        }
    }
}