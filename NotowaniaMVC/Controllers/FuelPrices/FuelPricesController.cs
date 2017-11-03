 
using NotowaniaMVC.Application.FuelPrices.ViewModels; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MediatR;
using NotowaniaMVC.Application.Quotations.Handlers.CommandHandlers.Messages;

namespace NotowaniaMVC.Controllers.FuelPrices
{
    public class FuelPricesController : Controller
    {
        private readonly IMediator _mediator;
        public FuelPricesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public FuelPricesController()
        { }
         
        public ActionResult FuelPrices()
        {
            List<FuelPricesViewModel> fuels = new List<FuelPricesViewModel>();
            FuelPricesViewModel fuel = new FuelPricesViewModel
            {
                CurrencyName = "test",
                Id = 1,
                DeliveryMaxValue = 100,
                DeliveryMinValue = 120,
                FuelPriceMaxBrutto = 40,
                FuelPriceMinNetto = 30,
                FormOfCooperationName = "b2b",
                FuelPriceMaxNetto = 80,
                FuelPriceMinBrutto = 70,
                DeliveryCombinedValue = "100 - 200",
                Rebate = 30,
                UGM = 3
            };

            fuels.Add(new FuelPricesViewModel
            {
                CurrencyName = "test",
                Id = 1,
                DeliveryMaxValue = 100,
                DeliveryMinValue = 120,
                FuelPriceMaxBrutto = 40,
                FuelPriceMinNetto = 30,
                FormOfCooperationName = "b2b",
                FuelPriceMaxNetto = 80,
                FuelPriceMinBrutto = 70,
                DeliveryCombinedValue = "100 - 200",
                Rebate = 30,
                UGM = 3
            });

            fuels.Add(new FuelPricesViewModel
            {
                CurrencyName = "test",
                Id = 1,
                DeliveryMaxValue = 100,
                DeliveryMinValue = 120,
                FuelPriceMaxBrutto = 40,
                FuelPriceMinNetto = 30,
                FormOfCooperationName = "b2b",
                FuelPriceMaxNetto = 80,
                FuelPriceMinBrutto = 70,
                DeliveryCombinedValue = "100 - 200",
                Rebate = 30,
                UGM = 3
            });

            fuels.Add(new FuelPricesViewModel
            {
                CurrencyName = "test",
                Id = 1,
                DeliveryMaxValue = 100,
                DeliveryMinValue = 120,
                FuelPriceMaxBrutto = 40,
                FuelPriceMinNetto = 30,
                FormOfCooperationName = "b2b",
                FuelPriceMaxNetto = 80,
                FuelPriceMinBrutto = 70,
                DeliveryCombinedValue = "100 - 200",
                Rebate = 30,
                UGM = 3
            });

            fuels.Add(new FuelPricesViewModel
            {
                CurrencyName = "tenmjk,kst",
                Id = 1,
                DeliveryMaxValue = 100,
                DeliveryMinValue = 120,
                FuelPriceMaxBrutto = 40,
                FuelPriceMinNetto = 30,
                FormOfCooperationName = "b2b",
                FuelPriceMaxNetto = 80,
                FuelPriceMinBrutto = 70,
                DeliveryCombinedValue = "100 - 200",
                Rebate = 30,
                UGM = 3
            });

            fuels.Add(new FuelPricesViewModel
            {
                CurrencyName = "tnmghfgest",
                Id = 4,
                DeliveryMaxValue = 100,
                DeliveryMinValue = 120,
                FuelPriceMaxBrutto = 40,
                FuelPriceMinNetto = 30,
                FormOfCooperationName = "b2b",
                FuelPriceMaxNetto = 80,
                FuelPriceMinBrutto = 70,
                DeliveryCombinedValue = "100 - 200",
                Rebate = 30,
                UGM = 3
            });

            fuels.Add(new FuelPricesViewModel
            {
                CurrencyName = "jghmghm",
                Id = 3,
                DeliveryMaxValue = 100,
                DeliveryMinValue = 120,
                FuelPriceMaxBrutto = 40,
                FuelPriceMinNetto = 30,
                FormOfCooperationName = "b2c",
                FuelPriceMaxNetto = 80,
                FuelPriceMinBrutto = 70,
                DeliveryCombinedValue = "101- 200",
                Rebate = 30,
                UGM = 3
            });

            fuels.Add(new FuelPricesViewModel
            {
                CurrencyName = "dfsdfsd",
                Id = 2,
                DeliveryMaxValue = 34,
                DeliveryMinValue = 50,
                FuelPriceMaxBrutto = 55,
                FuelPriceMinNetto = 30,
                FormOfCooperationName = "b2c",
                FuelPriceMaxNetto = 80,
                FuelPriceMinBrutto = 70,
                DeliveryCombinedValue = "100 - 203",
                Rebate = 30,
                UGM = 3
            });

            var result = fuels.AsEnumerable();
            return View(result);
        }

        public ActionResult Add(IEnumerable<FuelPricesViewModel> fuelPricesModels)
        {
            //_mediator.Send(new NewQuotationCommand { FuelPricesViewModels = fuelPricesModels });
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }


        public ActionResult Delete()
        {
            return View();
        }
    }
}