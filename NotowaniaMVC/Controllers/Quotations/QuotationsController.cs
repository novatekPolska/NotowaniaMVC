using System.Collections.Generic; 
using System.Web.Mvc;
using NotowaniaMVC.Application.Quotations.ViewModels;
using MediatR;
using NotowaniaMVC.Application.Quotations.Handlers.CommandHandlers.Messages;
using System.Web;
using System.IO;
using System.Text;
using System;

namespace NotowaniaMVC.Controllers.Quotations
{
    public class QuotationsController : Controller
    {
        private readonly IMediator _mediator;
        public QuotationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //public QuotationsController() //: this(IMediator mediator)
        //{
        //}

        // GET: Quotations
        public ActionResult Quotations()
        {
            Dictionary<int, string> currencyType = new Dictionary<int, string>();
            currencyType.Add(1, "test");

            Dictionary<int, string> fuelTypes = new Dictionary<int, string>();
            fuelTypes.Add(1, "test");

            Dictionary<int, string> quotationTypes = new Dictionary<int, string>();
            quotationTypes.Add(1, "test");

            Dictionary<int, string> units = new Dictionary<int, string>();
            units.Add(1, "test");

            NewQuotationViewModel quotationViewModel = new NewQuotationViewModel { CurrencyTypes = currencyType, FuelTypes = fuelTypes, QuotationTypes = quotationTypes, Units = units };
            return View(quotationViewModel);
        }

        [HttpPost]
        public ActionResult Add(NewQuotationViewModel newQuotationModel)
        {
            _mediator.Send(new NewQuotationCommand { QuotationViewModels = newQuotationModel });
            return View("Quotations", newQuotationModel);
        }

        [HttpPost]
        public ActionResult SavePdf(HttpPostedFileBase PdfFile)
        {
            var pdf = PdfFile.InputStream;
            var pdfName = PdfFile.FileName;
            //   var streamWritter = new StreamWriter(pdf);

            string path = @"C:\Users\szklarek\Documents\" + pdfName;

            
   

            using (FileStream fs = System.IO.File.Create(path, (int)pdf.Length))
            {
                byte[] bytesInStream = new byte[pdf.Length];
                pdf.Read(bytesInStream, 0, bytesInStream.Length);
                fs.Write(bytesInStream, 0, bytesInStream.Length);
            }

            return View("Quotations", new NewQuotationViewModel());
        }

        public ActionResult Cancel()
        {
            return View();
        }
         
    }
}