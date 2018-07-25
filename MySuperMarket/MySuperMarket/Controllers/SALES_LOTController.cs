﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MySuperMarket.Models;

namespace MySuperMarket.Controllers
{
    public class SALES_LOTController : Controller
    {
        private MyMarket db = new MyMarket();

        // GET: SALES_LOT
        public ActionResult Index()
        {
            var sALES_LOT = db.SALES_LOT.Include(s => s.INCOME).Include(s => s.PRODUCT);
            return View(sALES_LOT.ToList());
        }

        // GET: SALES_LOT/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALES_LOT sALES_LOT = db.SALES_LOT.Find(id);
            if (sALES_LOT == null)
            {
                return HttpNotFound();
            }
            return View(sALES_LOT);
        }

        // GET: SALES_LOT/Create
        public ActionResult Create()
        {
            ViewBag.INCOME_ID = new SelectList(db.INCOME, "INCOME_ID", "TYPE");
            ViewBag.BATCH_ID = new SelectList(db.PRODUCT, "BATCH_ID", "PRODUCT_ID");
            return View();
        }

        // POST: SALES_LOT/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BATCH_ID,LOT_DATE,INCOME_ID,MONEY,LOT_NUMBER")] SALES_LOT sALES_LOT)
        {
            if (ModelState.IsValid)
            {
                db.SALES_LOT.Add(sALES_LOT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.INCOME_ID = new SelectList(db.INCOME, "INCOME_ID", "TYPE", sALES_LOT.INCOME_ID);
            ViewBag.BATCH_ID = new SelectList(db.PRODUCT, "BATCH_ID", "PRODUCT_ID", sALES_LOT.BATCH_ID);
            return View(sALES_LOT);
        }

        // GET: SALES_LOT/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALES_LOT sALES_LOT = db.SALES_LOT.Find(id);
            if (sALES_LOT == null)
            {
                return HttpNotFound();
            }
            ViewBag.INCOME_ID = new SelectList(db.INCOME, "INCOME_ID", "TYPE", sALES_LOT.INCOME_ID);
            ViewBag.BATCH_ID = new SelectList(db.PRODUCT, "BATCH_ID", "PRODUCT_ID", sALES_LOT.BATCH_ID);
            return View(sALES_LOT);
        }

        // POST: SALES_LOT/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BATCH_ID,LOT_DATE,INCOME_ID,MONEY,LOT_NUMBER")] SALES_LOT sALES_LOT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sALES_LOT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.INCOME_ID = new SelectList(db.INCOME, "INCOME_ID", "TYPE", sALES_LOT.INCOME_ID);
            ViewBag.BATCH_ID = new SelectList(db.PRODUCT, "BATCH_ID", "PRODUCT_ID", sALES_LOT.BATCH_ID);
            return View(sALES_LOT);
        }

        // GET: SALES_LOT/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALES_LOT sALES_LOT = db.SALES_LOT.Find(id);
            if (sALES_LOT == null)
            {
                return HttpNotFound();
            }
            return View(sALES_LOT);
        }

        // POST: SALES_LOT/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SALES_LOT sALES_LOT = db.SALES_LOT.Find(id);
            db.SALES_LOT.Remove(sALES_LOT);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}