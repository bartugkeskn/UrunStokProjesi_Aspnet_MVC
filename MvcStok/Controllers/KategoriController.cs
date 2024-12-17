using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcDbStokEntities1 db = new MvcDbStokEntities1 ();
        public ActionResult KategoriListesi()
        {
            var degerler = db.TblKategoriler.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }


        [HttpPost]
        public ActionResult YeniKategori(TblKategoriler p1)
        {
            db.TblKategoriler.Add(p1);
            db.SaveChanges();
            Response.Redirect("/Kategori/KategoriListesi");
            return View();
        }
    }
}