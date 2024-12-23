﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDbStokEntities1 db = new MvcDbStokEntities1();
        public ActionResult MusteriListesi(string p)
        {
            var degerler = from d in db.TblMusteriler select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m=>m.MUSTERIAD.Contains(p));
            }

            return View(degerler.ToList());
            //var degerler = db.TblMusteriler.ToList();
            //return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(TblMusteriler p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.TblMusteriler.Add(p1);
            db.SaveChanges();
            Response.Redirect("/Musteri/MusteriListesi");
            return View();
        }

        public ActionResult Sil(int id)
        {
            var musteri = db.TblMusteriler.Find(id);
            db.TblMusteriler.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("MusteriListesi");
        }

        [HttpGet]
        public ActionResult MusteriGuncelle(int id)
        {
            var musteri = db.TblMusteriler.Find(id);
            return View("MusteriGuncelle", musteri);
        }

        [HttpPost]
        public ActionResult MusteriGuncelle(TblMusteriler p1)
        {
            var musteri = db.TblMusteriler.Find(p1.MUSTERIID);
            musteri.MUSTERIAD = p1.MUSTERIAD;
            musteri.MUSTERISOYAD = p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("MusteriListesi");
        }
    }
}