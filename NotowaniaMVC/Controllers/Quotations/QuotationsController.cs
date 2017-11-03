using System.Collections.Generic; 
using System.Web.Mvc;
using NotowaniaMVC.Application.Quotations.ViewModels;
using MediatR;
using NotowaniaMVC.Application.Quotations.Handlers.CommandHandlers.Messages;

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

        public ActionResult Cancel()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Add(FormCollection form)
        //{
        //    return View("Quotations");
        //}
    }
}