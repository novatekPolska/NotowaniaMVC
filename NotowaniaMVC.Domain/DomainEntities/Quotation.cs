using System; 

namespace NotowaniaMVC.Domain.DomainEntities
{
        // Wzorzec fabryki dla przykładu. Enkapsulujemy objekt domenowy i wszelkie jego własnosci 
        // zmieniamy za pomocą jego metod. Obiekt tworzymy nie przez new tylko przez fabryke. 
        // Dzieki temu nikt/nic nie zepsuje nam obiektu/stanu obiektu
        // umiescimy tutaj również walidacje za pomocą fluent validatora, żeby uniknąć "else-if patternu" lub "switch-case patternu"
        // a także poprawić czytelnosc i strukture projektu
        // Dodajemy tutaj klase factory która zwraca nam obiekt naszej encji domenowej - to własnie jest wzorzec fabryki
        // Przykłady użycia  Quotation quotation = new Quotation(...parametry...) = ŹLE! POWSZECHNIE STOSOWANY ANTYWZORZEC
        // var Quotation = Quotation.Factory.Create(.... paremetry ...) = DOBRZE! Użyty wzorzec projektowy fabryki odporny na błędy użytkownika, zawierający czytelną walidacje obiektu, łatwomodyfikowalną i łatworozszerzalną
    public class Quotation 
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

        private Quotation(string code, int fuel, int region, int priceList, int company)
        {
            Code = code;
            Fuel = fuel;
            Region = region;
            PriceList = priceList;
            Company = company;
        }

        private Quotation(string code, int fuel, int priceList)
        {
            Code = code;
            Fuel = fuel; 
            PriceList = priceList; 
        }

        public static class Factory
        { 
            public static Quotation Create(string code, int fuel, int region, int priceList, int company)
            {
                return new Quotation(code, fuel, region, priceList, company);
            }

            public static Quotation Create(string code, int fuel, int priceList)
            {
                return new Quotation(code, fuel, priceList);
            }
        } 
    }
}
