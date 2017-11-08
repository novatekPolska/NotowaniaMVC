using System.IO;

namespace NotowaniaMVC.Domain.Documents.Interfaces
{
    public interface IDiskDocumentHelper
    {
        void SaveDocumentOnDisk(Stream file, string Name, string Path);
        bool DocumentExist(string path, string name);
    }
}
