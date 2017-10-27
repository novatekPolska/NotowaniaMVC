﻿using System; 

namespace NotowaniaMVC.Domain.DomainEntities
{
    // Wzorzec fabryki dla przykładu. Enkapsulujemy objekt domenowy i wszelkie jego własnosci 
    // zmieniamy za pomocą jego metod. Obiekt tworzymy nie przez new, tylko przez fabryke. 
    // Dzieki temu nikt/nic nie zepsuje nam obiektu/stanu obiektu
    // umiescimy tutaj również walidacje za pomocą fluent validatora, 
    // żeby uniknąć "else-if patternu" lub "switch-case patternu"
    // a także poprawić czytelnosc i strukture projektu
    // Dodajemy tutaj klase factory która zwraca nam obiekt naszej encji domenowej - to własnie jest wzorzec fabryki
    // Przykłady użycia  Quotation quotation = new Quotation(...parametry...) = ŹLE! 
    // POWSZECHNIE STOSOWANY ANTYWZORZEC "bo w szkole/na studiach tak uczyli"
    // var Quotation = Quotation.Factory.Create(.... paremetry ...) = DOBRZE! Użyty wzorzec projektowy fabryki odporny na 
    // błędy użytkownika, zawierający czytelną walidacje obiektu, łatwomodyfikowalną i łatworozszerzalną
    public class Quotation
    {
        public int Id { get; private set; }
        public Guid Guid { get; private set; }
        public string Code { get; private set; }
        public decimal PriceMin { get; private set; }
        public decimal PriceMax { get; private set; }
        public int Currency { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime Modified { get; private set; }
        public int Modifier { get; private set; }
        public int Creator { get; private set; }
        public int Fuel { get; private set; }
        public int Region { get; private set; }
        public int Company { get; private set; }
        public int Unit { get; private set; }
        public int QuotationType { get; private set; }
        public DateTime DateTo { get; private set; }
        public DateTime DateOfQuotation { get; private set; }

        private Quotation(DateTime dateOfQuotation, int fuel, decimal priceNettoMin, decimal priceNettoMax, int unit,  int currency, int quotationType)
        {
            DateOfQuotation = dateOfQuotation;
            Fuel = fuel;
            PriceMax = priceNettoMax;
            PriceMin = priceNettoMin;
            Unit = unit;
            Currency = currency;
            QuotationType = quotationType;
        }

        private Quotation(string code, int fuel, int region, int company)
        {
            Code = code;
            Fuel = fuel;
            Region = region; 
            Company = company;
        }

        private Quotation(string code, int fuel)
        {
            Code = code;
            Fuel = fuel;  
        }

        private Quotation(string code)
        {
            Code = code; 
        }

        public void Validate()
        { 
        }

        public void Add()
        { 
        }

        public void Update()
        { 
        }
         
        public void Save()
        {
        }

        public static class Factory
        {
            public static Quotation Create(DateTime dateOfQuotation, int fuel, decimal priceNettoMin, decimal priceNettoMax, int unit, int currency, int quotationType)
            {
                return new Quotation(dateOfQuotation, fuel, priceNettoMin, priceNettoMax, unit, currency, quotationType);
            }

            public static Quotation Create(string code, int fuel, int region, int company)
            {
                return new Quotation(code, fuel, region, company);
            }

            public static Quotation Create(string code, int fuel)
            {
                return new Quotation(code, fuel);
            }

            public static Quotation Create(string code)
            {
                return new Quotation(code);
            }
        } 
    }
}
