using System;

namespace NotowaniaMVC.Domain.DomainEntities
{
    public class Document
    {
        public int Id { get; private set; }
        public Guid Guid { get; private set; }
        public string Code { get; private set; }
        public string Link { get; private set; } 
        public DateTime Created { get; private set; }
        public DateTime Modified { get; private set; }
        public int Modifier { get; private set; }
        public int Creator { get; private set; }
        public object Blob { get; private set; }
        public string Name { get; private set; }

        private Document (string name, string code, string link, int creator, int modifier, object blob)
        {
            Name = name;
            Code = code;
            Link = link;
            Created = DateTime.Now;
            Modified = DateTime.Now;
            Creator = creator;
            Modifier = modifier;
            Blob = blob;
            Guid = Guid.NewGuid();
        }

        public static class Factory
        {
            public static Document Create(string name, string code, string link, int creator, int modifier, object blob)
            {
                return new Document(name, code, link, creator, modifier, blob);
            }
        }
    }
}
