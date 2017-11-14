using NotowaniaMVC.Domain.Documents.Interfaces;
using System.IO; 
using System.Text; 

namespace NotowaniaMVC.Domain.Documents.Helpers
{
    public class DiskDocumentsHelper : IDiskDocumentHelper
    {
        public void SaveDocumentOnDisk(Stream file, string Name, string Path)
        { 
            if (file != null) {
                StringBuilder sb = new StringBuilder();

                if (!Directory.Exists(Path)) 
                    Directory.CreateDirectory(Path); 

                using (FileStream fs = File.Create(sb.AppendFormat("{0}{1}", Path, Name).ToString()))
                {
                    byte[] bytesInStream = new byte[file.Length];
                    file.Read(bytesInStream, 0, bytesInStream.Length);
                    fs.Write(bytesInStream, 0, bytesInStream.Length);
                }
            }
        }

        public bool DocumentExist(string path, string name)
        {
            StringBuilder sb = new StringBuilder();
            return File.Exists(sb.AppendFormat("{0}, {1}", path, name).ToString());
        }
    }
}
