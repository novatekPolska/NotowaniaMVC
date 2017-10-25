using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NotowaniaMVC.Application.Quotations.ViewModels;
using System.Collections;

namespace NotowaniaMVC.Controllers.Quotations
{
    public class QuotationsController : Controller
    {
        // GET: Quotations
        public ActionResult Quotations()
        {
            Dictionary<int, string> currencyType = new Dictionary<int, string>();
            currencyType.Add(1, "test");

            Dictionary<int, string> fuelTypes = new Dictionary<int, string>();
            fuelTypes.Add(1, "test");

            Dictionary<int, string> quotationTypes = new Dictionary<int, string>();
            quotationTypes.Add(1, "test");

            NewQuotationViewModel quotationViewModel = new NewQuotationViewModel { CurrencyTypes = currencyType, FuelTypes = fuelTypes, QuotationTypes = quotationTypes };
            return View(quotationViewModel);
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Cancel()
        {
            return View();
        }
    }
}