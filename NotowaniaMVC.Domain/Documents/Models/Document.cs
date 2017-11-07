using System;

namespace NotowaniaMVC.Domain.DomainEntities
{
    public class Document
    {
        public int Id { get; private set; }
        public Guid Guid { get; private set; }
        public string Code { get; private set; }
        public string Link { get; private set; }
        public int Quotation { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime Modified { get; private set; }
        public int Modifier { get; private set; }
        public int Creator { get; private set; }
        public object Blob { get; private set; }

        private Document (string code, string link, int quotation, int creator, int modifier, object blob)
        {
            Code = code;
            Link = link;
            Quotation = quotation;
            Created = DateTime.Now;
            Modified = DateTime.Now;
            Creator = creator;
            Modifier = modifier;
            Blob = blob;
            Guid = Guid.NewGuid();
        }

        public static class Factory
        {
            public static Document Create(string code, string link, int quotation, int creator, int modifier, object blob)
            {
                return new Document(code, link, quotation, creator, modifier, blob);
            }
        }
    }
}
