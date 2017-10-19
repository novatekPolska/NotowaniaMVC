using System; 

namespace NotowaniaMVC.Domain.DomainEntities
{
    public class Quotation // Wzorzec fabryki dla przykładu. Enkapsulujemy objekt domenowy i wszelkie jego wławosci zmieniamy za pomocą jego metod. Obiekt tworzym7y nie przez new tylko przez fabryke. Dzieki temu nikt/nic nie zepsuje nam obiektu/stanu obiektu
    {
        private int Id { get; set; }
        private Guid Guid { get; set; }
        private string Code { get; set; }
        private DateTime Created { get; set; }
        private DateTime Modified { get; set; }
        private int Modifier { get; set; }
        private int Creator { get; set; }
        private int Fuel { get; set; }
        private int Region { get; set; }
        private int PriceList { get; set; }
        private int Company { get; set; }

        private Quotation(string _code, int _fuel, int _region, int _priceList, int _company)
        {
            Code = _code;
            Fuel = _fuel;
            Region = _region;
            PriceList = _priceList;
            Company = _company;
        }

        public class Factory
        {

            public Quotation Create(string _code, int _fuel, int _region, int _priceList, int _company)
            {
                return new Quotation(_code, _fuel, _region, _priceList, _company);
            }
        } 
    }
}
