using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;


namespace MvcStok.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MvcDbStokEntities1 db = new MvcDbStokEntities1();
        public ActionResult UrunListesi()
        {
            var degerler = db.TblUrunler.ToList();
            return View(degerler);
        }
    }
}