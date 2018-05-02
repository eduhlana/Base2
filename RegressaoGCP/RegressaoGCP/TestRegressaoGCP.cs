using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegressaoGCP.core;
using RegressaoGCP.page;

namespace RegressaoGCP
{
    [TestClass]
    public class TestRegressaoGCP : BaseTest
    {
        private AbrangComercial abrangenciacomercial = new AbrangComercial();
        private AbrangenciaLogistica abrangencialogistica = new AbrangenciaLogistica();
        private Preco preco = new Preco();
        public BasePage basepage = new BasePage();

        [TestMethod]
        public void TesteRegressao()
        {
            //abrangenciacomercial.InserirAbrang();
            //abrangenciacomercial.AprovarRascunhoAbrang();
            abrangencialogistica.CancelarAbrangLog();
            abrangencialogistica.InserirAbrangLog();
            abrangencialogistica.AprovarRascunhoAbrangLog();
            abrangencialogistica.CancelarAbrangLog();
            abrangencialogistica.SalvarAbrangLog();
            abrangencialogistica.ExcluiRascunhoLog();
            abrangencialogistica.SalvarAbrangLog();
            preco.InserirPreco();
            preco.AprovarPreco();
            preco.SalvarPreco();
            preco.CancelarPreco();
            preco.ExcluiPreco();
            preco.SalvarPreco();
            abrangenciacomercial.CancelarAbrang();
            abrangenciacomercial.SalvarAbrang();
            abrangenciacomercial.ExcluiRascunhoAbrang();

        }


    }
}

