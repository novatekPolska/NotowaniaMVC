using FluentValidation;
using System.IO;
using System.Text;

namespace NotowaniaMVC.Domain.Documents.Validators
{
    public class DocumentValidator : AbstractValidator<DomainEntities.Document>
    {  
        public DocumentValidator()
        {
            StringBuilder sb = new StringBuilder();
            RuleFor(document => document.Link).NotNull();
           // RuleFor(document => document.Blob).NotNull(); todo to ma byc na podstawie paremetru
            RuleFor(document => sb.AppendFormat("{0}{1}", document.Link, document.Name).ToString()).Must(LinkExist).WithMessage("Podana sciezka lub podany plik nie istnieje"); 
        }

        private bool LinkExist(string link)
        {
            return File.Exists(link); 
        }
    }
}