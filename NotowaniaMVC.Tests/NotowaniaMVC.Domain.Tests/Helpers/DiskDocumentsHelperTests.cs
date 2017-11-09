using NotowaniaMVC.Domain.Documents.Helpers;
using NotowaniaMVC.Domain.DomainEntities;
using NUnit.Framework;
using System;
using System.IO;
using System.Text;

namespace NotowaniaMVC.Tests.NotowaniaMVC.Domain.Tests.Helpers
{
    [TestFixture]
    public class DiskDocumentsHelperTests
    {
        private readonly DiskDocumentsHelper diskDocumentsHelper;
        

        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        public DiskDocumentsHelperTests()
        {
            diskDocumentsHelper = new DiskDocumentsHelper(); 
        }

        [Test]
        public void when_document_is_null_then_method_should_not_create_new_empty_file()
        { 
            diskDocumentsHelper.SaveDocumentOnDisk(null, "test.pdf", "C:/"); 
            Assert.AreEqual(File.Exists("C:/test.pdf"), false); 
        }

        [Test]
        public void when_document_is_not_null_then_method_should_create_new_file()
        {   
            Stream file = File.OpenRead("C:/Users/szklarek/Documents/Funkcje-logiczne w Excelu.pdf");  
            diskDocumentsHelper.SaveDocumentOnDisk(file, "Funkcje-logiczne w Excelu1.pdf", "C:/Users/szklarek/Documents/");
            Assert.AreEqual(File.Exists("C:/Users/szklarek/Documents/Funkcje-logiczne w Excelu1.pdf"), true);
            file.Close();
        }

        [Test]
        public void when_path_exist_then_method_should_create_new_file()
        {
            Stream file = File.OpenRead("C:/Users/szklarek/Documents/Funkcje-logiczne w Excelu.pdf");
            diskDocumentsHelper.SaveDocumentOnDisk(file, "Funkcje-logiczne w Excelu.pdf", "C:/");
            if (File.Exists("C:/Funkcje-logiczne w Excelu.pdf"))
            {
                diskDocumentsHelper.SaveDocumentOnDisk(file, "Funkcje-logiczne w Excelu.pdf", "C:/");
                Assert.AreEqual(File.Exists("C:/Funkcje-logiczne w Excelu.pdf"), true); 
                file.Close();
            }
            else
            {
                throw (new Exception("Wyjebało się"));
            } 
        }

        [Test]
        public void when_path_does_not_exist_then_method_should_create_path_and_new_file()
        {
            Stream file = File.OpenRead("C:/Users/szklarek/Documents/Funkcje-logiczne w Excelu.pdf");
            diskDocumentsHelper.SaveDocumentOnDisk(file, "Funkcje-logiczne w Excelu.pdf", "C:/testowyFolder/");
            Assert.AreEqual(File.Exists("C:/testowyFolder/Funkcje-logiczne w Excelu.pdf"), true);
            file.Close();
        }

        [Test]
        public void when_create_new_file_then_files_can_have_the_same_length()
        {
            throw (new Exception("niezaimplementowane"));
        } 
    } 
}
