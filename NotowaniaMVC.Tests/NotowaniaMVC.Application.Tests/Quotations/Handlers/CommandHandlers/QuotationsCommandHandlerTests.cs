using NotowaniaMVC.Application.Quotations.Handlers.CommandHandlers;
using NotowaniaMVC.Application.Quotations.Handlers.CommandHandlers.Messages;
using NotowaniaMVC.Application.Quotations.ViewModels;
using NotowaniaMVC.Domain.Documents.Helpers;
using NotowaniaMVC.Domain.Documents.Mappers;
using NotowaniaMVC.Domain.Documents.Services; 
using NotowaniaMVC.Domain.Quotation.Services;
using NotowaniaMVC.Domain.Quotations.Mappers; 
using NotowaniaMVC.Infrastructure.Common.Repositories;
using NotowaniaMVC.Infrastructure.Database.DBConfiguration;
using NotowaniaMVC.Infrastructure.Database.Entities;
using NUnit.Framework;
using System;
using System.IO;

namespace NotowaniaMVC.Tests.NotowaniaMVC.Application.Tests.Quotations.Handlers.CommandHandlers
{
    [TestFixture]
    public class QuotationsCommandHandlerTests
    {
        private readonly DatabaseConfiguration dbConfiguration;
        private readonly NHibernate.ISession _session;
        private readonly DocumentsDomainService _documentsDomainService;
        private readonly QuotationDomainService _quotationsDomainService;
        private readonly NHibernateUniversalRepository<XXX_R55_Documents> _nhibernateUniversalRepository;
        private readonly NHibernateUniversalRepository<XXX_R55_Quotations> _nhibernateQuotationsUniversalRepository;
        private readonly DbDocumentsHelper _dbDocumentsHelper;
        private readonly DiskDocumentsHelper _diskDocumentsHelper;
        private readonly DocumentToDocumentDbMapper _documentMapper;
        private readonly QuotationsCommandHandler _quotationsCommandHandler;

        public QuotationsCommandHandlerTests()
        {
            dbConfiguration = new DatabaseConfiguration();
            _session = dbConfiguration.GetSession();
            _nhibernateUniversalRepository = new NHibernateUniversalRepository<XXX_R55_Documents>(_session);
            _nhibernateQuotationsUniversalRepository = new NHibernateUniversalRepository<XXX_R55_Quotations>(_session);
            _diskDocumentsHelper = new DiskDocumentsHelper();
            _dbDocumentsHelper = new DbDocumentsHelper(_nhibernateUniversalRepository, new DocumentToDocumentDbMapper());
            _documentsDomainService = new DocumentsDomainService(_dbDocumentsHelper, _diskDocumentsHelper);
            _quotationsDomainService = new QuotationDomainService(_nhibernateQuotationsUniversalRepository, _nhibernateUniversalRepository, new QuotationToQuotationDbMapper());
            _quotationsCommandHandler = new QuotationsCommandHandler(_quotationsDomainService, _documentsDomainService);
        }

        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [Test]
        public void can_add_new_quotation_new_document_and_document_to_quotation()
        {
            Stream file = File.OpenRead("C:/Users/szklarek/Documents/Funkcje-logiczne w Excelu.pdf"); 
            _quotationsCommandHandler.Handle(new NewQuotationCommand { FileName = "test.pdf", FileStream = file, QuotationViewModels = new NewQuotationViewModel { QuotationDate = DateTime.Now, PdfPath = "C:/", FuelType = 1, Currency = 1, PriceNettoMax = 10, PriceNettoMin = 5, PdfName = "test.pdf", QuotationType = 1, Unit = 10001 } });
        } 
    }
}
