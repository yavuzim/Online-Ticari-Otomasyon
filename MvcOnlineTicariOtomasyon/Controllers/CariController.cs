﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Carilers.Where(x => x.Durum == true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniCari()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniCari(Cariler p)
        {
            p.Durum = true;
            c.Carilers.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var cr = c.Carilers.Find(id);
            cr.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGetir(int id)
        {
            var cari = c.Carilers.Find(id);
            return View("CariGetir", cari);
        }
        public ActionResult CariGuncelle(Cariler cr)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var car = c.Carilers.Find(cr.CariId);
            car.CariAd = cr.CariAd;
            car.CariSoyadi = cr.CariSoyadi;
            car.CariSehir = cr.CariSehir;
            car.CariMail = cr.CariMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.Cariid == id).ToList();
            var cr = c.Carilers.Where(x => x.CariId == id).Select(y => y.CariAd + " " + y.CariSoyadi).FirstOrDefault();
            ViewBag.cari = cr;
            return View(degerler);
        }
    }
}