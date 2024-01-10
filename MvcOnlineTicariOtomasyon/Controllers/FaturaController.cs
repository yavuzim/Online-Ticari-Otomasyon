using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context c = new Context();
        public ActionResult Index()
        {
            var liste = c.Faturalars.ToList();
            return View(liste);
        }
        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Faturalar d)
        {
            c.Faturalars.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int id)
        {
            var fat = c.Faturalars.Find(id);
            return View("FaturaGetir", fat);
        }
        public ActionResult FaturaGuncelle(Faturalar k)
        {
            var fat = c.Faturalars.Find(k.FaturaId);
            fat.FaturaSeriNo = k.FaturaSeriNo;
            fat.FaturaSiraNo = k.FaturaSiraNo;
            fat.Saat = k.Saat;
            fat.Tarih = k.Tarih;
            fat.TeslimAlan = k.TeslimAlan;
            fat.TeslimEden = k.TeslimEden;
            fat.VergiDairesi = k.VergiDairesi;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaDetay(int id)
        {
            var degerler = c.FaturaKalems.Where(x => x.FaturaKalemId == id).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }
        public ActionResult YeniKalem(FaturaKalem p)
        {
            c.FaturaKalems.Add(p);
            c.SaveChanges();
            return View("Index");
        }
    }
}