using System.Collections.Generic; 
using System.Web.Mvc;
using NotowaniaMVC.Application.Quotations.ViewModels;
using MediatR;
using NotowaniaMVC.Application.Quotations.Handlers.CommandHandlers.Messages;
using System.Web;
using System.IO; 
using System; 
using NotowaniaMVC.Application.Quotations.Handlers.QueryHandlers.Messages;

namespace NotowaniaMVC.Controllers.Quotations
{
    public class QuotationsController : Controller
    {
        private readonly IMediator _mediator;
        public QuotationsController(IMediator mediator)
        {
            _mediator = mediator;
        } 

        // GET: Quotations
        public ActionResult Quotations()
        {
            var quotationViewModel = _mediator.Send(new GetDataForNewQuotationQuery()).Result;
            return View(quotationViewModel);
        }

        [HttpPost]
        public ActionResult GeneratePDF(NewQuotationViewModel newQuotationModel) //działa, przekazuje pdfa do modelu
        { 
            //return File(PdfFile.InputStream, "application/pdf");
            return View();
        }

        [HttpPost]
        public ActionResult Add(NewQuotationViewModel newQuotationModel, HttpPostedFileBase PdfFile)
        {
            if (PdfFile != null) //todo do handlera
            {
                newQuotationModel.PdfFile = PdfFile.InputStream;
                newQuotationModel.PdfName = PdfFile.FileName;
                newQuotationModel.PdfPath = "C:/"; 
            }

            _mediator.Send(new NewQuotationCommand { QuotationViewModels = newQuotationModel });
            var quotationViewModel = _mediator.Send(new GetDataForNewQuotationQuery()).Result;
            return View("Quotations", quotationViewModel);
        }

        [HttpGet]
        public ActionResult GetDataForGrid()
        {
            var list = new List<QuotationsViewModel>();
            list.Add(new QuotationsViewModel { Id = 1, CurrencyName = "test", FuelTypeName = "test", PdfPath = "C:/", PriceNettoMax = 5, PriceNettoMin = 4, UnitName = "test", QuotationTypeName = "test", QuotationDate = DateTime.Today });
            return Json(list);
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