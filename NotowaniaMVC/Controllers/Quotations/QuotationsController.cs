using System.Web.Mvc;
using NotowaniaMVC.Application.Quotations.ViewModels;
using MediatR;
using NotowaniaMVC.Application.Quotations.Handlers.CommandHandlers.Messages;
using System.Web;  
using NotowaniaMVC.Application.Quotations.Handlers.QueryHandlers.Messages;
using NotowaniaMVC.Application.Documents.Handlers.CommandHandlers.Messages; 

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
        public string GeneratePDF(NewQuotationViewModel newQuotationModel, HttpPostedFileBase PdfFile) 
        { 
            _mediator.Send(new NewTemporaryDocumentCommand { PdfFile = PdfFile.InputStream, PdfName = PdfFile.FileName, PdfPath = "C:/Users/szklarek/source/repos/NotowaniaMVC/NotowaniaMVC/Content/" }); //todo konfigurowalnia sciezka
            return "/Content/" + PdfFile.FileName; //todo usunąć sklejaka
        }

        [HttpPost]
        public void Add(NewQuotationViewModel newQuotationModel, HttpPostedFileBase PdfFile)
        {
            if (PdfFile != null) //todo do handlera bo to logika aplikacyjna
            {
                newQuotationModel.PdfFile = PdfFile.InputStream;
                newQuotationModel.PdfName = PdfFile.FileName;
                newQuotationModel.PdfPath = "C:/Users/szklarek/"; 
            } 
            _mediator.Send(new NewQuotationCommand { QuotationViewModels = newQuotationModel }); 
        }
 
        [HttpPost]
        public ActionResult GetDataForGrid()
        {
            return InitialGrid();
        }

        [ChildActionOnly] 
        public PartialViewResult InitialDataForPartialQuotationGrid()
        {
            return InitialGrid();
        } 

        private PartialViewResult InitialGrid()
        {
            var results = _mediator.Send(new GetDataSourceForQuotationsGridQuery());
            return PartialView("QuotationGrid", results.Result);
        }
    }
}