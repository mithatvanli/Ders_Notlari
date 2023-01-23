using BusinessLayer.concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace MVCKAMP.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManager HM = new HeadingManager(new EfHeadingDal());
        CategoryManager CM =new CategoryManager(new EfCategoryDal());   
        public ActionResult Index()
        {
            var HeadingValues = HM.GetList();
            return View(HeadingValues);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> ValueCategory = (from x in CM.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text=x.CategoryName,//DropDownListin Text Değeri
                                                      Value=x.Id.ToString()//DropDownList in value değeri
                                                  }).ToList();
            ViewBag.vlc = ValueCategory;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            HM.HeadingAddBL(p); 
            return RedirectToAction("Index");
        }
    }
}