using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using Moq;
using NUnit.Framework;
using NotowaniaMVC.Autofac;

namespace NotowaniaMVC.Tests.NotowaniaMVC.Presentation.Tests.Autofac.Test
{
    [TestFixture]
    public class Autofac
    {

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

        [Test]
        public void Autofac_registration_test()
        {
            AutofacConfiguration.RegisterAndResolve();
        } 
    }
}
