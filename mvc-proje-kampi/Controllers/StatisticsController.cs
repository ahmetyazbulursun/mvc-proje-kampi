using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_proje_kampi.Controllers
{
    public class StatisticsController : Controller
    {

        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        WriterManager wm = new WriterManager(new EfWriterDal());

        public ActionResult Index()
        {
            ViewBag.KategoriSayisi = cm.GetList().Count().ToString();
            ViewBag.YazilimBaslikSayi = hm.GetList().Where(x => x.Category.Name == "Yazılım").Count().ToString();
            ViewBag.YazarAHarf = wm.GetList().Where(x => x.Name.ToLower().Contains("a")).Count().ToString();
            ViewBag.EnFazlaBaslikKategori = hm.GetList().Distinct().OrderByDescending(x => x.ID).FirstOrDefault().Category.Name.ToString();

            int durumTrue, durumFalse, sonuc;

            durumTrue = cm.GetList().Where(x => x.Status == true).Count();
            durumFalse = cm.GetList().Where(x => x.Status == false).Count();
            sonuc = durumTrue - durumFalse;

            ViewBag.KategoriFark = sonuc.ToString();

            return View();
        }

    }
}