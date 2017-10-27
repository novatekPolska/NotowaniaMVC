using FluentValidation; 

namespace NotowaniaMVC.Domain.Quotation.Validators
{
    public class QuotationValidator : AbstractValidator<DomainEntities.Quotation>
    {
        //Walidacja dla dodawania nowego notowania
        //wartosci z formularza nie mogą byc puste -> jednosta, waluta, typ paliwa, typ notowania, cena min i max, data notowania
        //data notowania musi byc wieksza lub równa dacie obecnej
        //ceny nie moga byc zerowe
        //cena min musi byc mniejsza od ceny max
        //ceny muszą być liczbami
        //klucze obce muszą istniec
        public QuotationValidator()
        {
            //wartosci niepuste
            RuleFor(quotation => quotation.Unit).NotNull();
            RuleFor(quotation => quotation.PriceMin).NotNull();
            RuleFor(quotation => quotation.PriceMax).NotNull();
            RuleFor(quotation => quotation.DateOfQuotation).NotNull();
            RuleFor(quotation => quotation.Currency).NotNull();
            RuleFor(quotation => quotation.Fuel).NotNull();
            RuleFor(quotation => quotation.QuotationType).NotNull(); 

            //cena max większ od ceny mic
            RuleFor(quotation => quotation.PriceMax).GreaterThanOrEqualTo(quotation => quotation.PriceMin);

            //ceny większe od zera
            RuleFor(quotation => quotation.PriceMax).GreaterThan(0);
            RuleFor(quotation => quotation.PriceMin).GreaterThan(0);
        
            //data notowania mniejsza lub równa dacie obecnej
            RuleFor(quotation => quotation.DateOfQuotation).LessThan(System.DateTime.Now);
        }
    }
}
