﻿using MediatR;
using NotowaniaMVC.Application.Quotations.ViewModels;
using System.IO;

namespace NotowaniaMVC.Application.Quotations.Handlers.CommandHandlers.Messages
{
    public class NewQuotationCommand : IRequest 
    {
        public NewQuotationViewModel QuotationViewModels { get; set; } 
    }
}
