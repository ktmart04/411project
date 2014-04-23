using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrackYourBudget.Models;
using System.Web.Mvc;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace TrackYourBudget.Controllers
{
    public class ReportsController : Controller
    {
        private ReceiptDbContext Receipts = new ReceiptDbContext();
        // GET: /Reports/
        public ActionResult Index()
        {



           var categorySelected = from cat in Receipts.Receipts.ToList()
                                  select cat.Category;

           int count = categorySelected.Count();

           List<string> categories = new List<string>();

           //foreach (ReceiptPage rp in Receipts)
           //{
               
        

          string numberOfDifferntCats = categories.Count.ToString();
            
           // categories.Add(Receipts.Receipts);
    return View();

        }
    }
}