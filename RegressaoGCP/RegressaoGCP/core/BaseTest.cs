using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegressaoGCP.Data;
namespace RegressaoGCP.core
{
    [TestClass]
    public class BaseTest
    {
        
        [TestInitialize]
        public void Inicializa()
        {
            DriverFactory.GetDriver().Url = "http://hml3-naturahml.sysmap.com.br/gcpweb/";
            DriverFactory.GetDriver().Manage().Window.Maximize();
            
        }

        [TestCleanup]
        public void Finaliza()
        {
            DriverFactory.KillDriver();
        }
    }
}
