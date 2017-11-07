using FluentValidation;
using System.IO;

namespace NotowaniaMVC.Domain.Documents.Validators
{
    public class DocumentValidator : AbstractValidator<DomainEntities.Document>
    {  
        public DocumentValidator()
        { 
            RuleFor(document => document.Link).NotNull();
            RuleFor(document => document.Blob).NotNull();
            RuleFor(document => document.Link).Must(LinkExist).WithMessage("Podana sciezka lub podany plik nie istnieje"); 
        }

        private bool LinkExist(string link)
        {
            return File.Exists(link); 
        }
    }
}