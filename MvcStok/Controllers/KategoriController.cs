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

        public ActionResult Sil(int id)
        {
            var kategori = db.TblKategoriler.Find(id);
            db.TblKategoriler.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("KategoriListesi");
        }

        [HttpGet]
        public ActionResult KategoriGuncelle(int id)
        {
            var kategori = db.TblKategoriler.Find(id);
            return View("KategoriGuncelle", kategori);
        }

        [HttpPost]
        public ActionResult KategoriGuncelle(TblKategoriler p1)
        {
            var kategori = db.TblKategoriler.Find(p1.KATEGORIID);
            kategori.KATEGORIAD = p1.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("KategoriListesi");
        }
    }
}