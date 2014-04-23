using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrackYourBudget.Models;
using Microsoft.AspNet.Identity;

namespace TrackYourBudget.Controllers
{
    public class ReceiptProfileController : Controller
    {
        private ReceiptDbContext db = new ReceiptDbContext();

        // GET: /ReceiptProfile/
        public ActionResult Index()
        {
            string sortResult = User.Identity.GetUserId().ToString();
            var items = from it in db.Receipts.ToList()
                        where it.usercode == sortResult
                        select it;

           
            return View(items);
        }

        // GET: /ReceiptProfile/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceiptPage receiptpage = db.Receipts.Find(id);
            if (receiptpage == null)
            {
                return HttpNotFound();
            }
            return View(receiptpage);
        }

        public ActionResult PieChart()
        {
            return View(ChartData.GetPieChartData());
        }

        // GET: /ReceiptProfile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ReceiptProfile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="rdiCode,venueName,rciCode,amountSpent,descriptioninfo,dateTimePurchase,dateTime,Category,PaymentType")] ReceiptPage receiptpage)
        {
            if (ModelState.IsValid)
                {
                    receiptpage.usercode = User.Identity.GetUserId();
                   
                    List<SelectListItem> items = new List<SelectListItem>();

                    db.Receipts.Add(receiptpage);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            

           
            return View(receiptpage);
        }

        // GET: /ReceiptProfile/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceiptPage receiptpage = db.Receipts.Find(id);
            if (receiptpage == null)
            {
                return HttpNotFound();
            }
            return View(receiptpage);
        }

        // POST: /ReceiptProfile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="rdiCode,venueName,rciCode,amountSpent,descriptioninfo,dateTimePurchase,dateTime,Category,PaymentType")] ReceiptPage receiptpage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(receiptpage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(receiptpage);
        }

        // GET: /ReceiptProfile/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceiptPage receiptpage = db.Receipts.Find(id);
            if (receiptpage == null)
            {
                return HttpNotFound();
            }
            return View(receiptpage);
        }

        // POST: /ReceiptProfile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReceiptPage receiptpage = db.Receipts.Find(id);
            db.Receipts.Remove(receiptpage);
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
