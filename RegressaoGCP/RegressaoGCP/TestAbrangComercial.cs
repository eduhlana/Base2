using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using RegressaoGCP.core;
using RegressaoGCP.page;
using RegressaoGCP.Data;
using System.Configuration;

namespace RegressaoGCP
{
    [TestClass]
    public class TestAbrangComercial : BaseTest
    {
        private AbrangComercial abrangenciacomercial = new AbrangComercial();

        [TestMethod]
        public void TesteAbrangenciaComercial()
        {
            //abrangenciacomercial.InserirAbrang();
            //abrangenciacomercial.AprovarRascunhoAbrang();
            //abrangenciacomercial.CancelarAbrang();
            //abrangenciacomercial.SalvarAbrang();
            abrangenciacomercial.ExcluiRascunhoAbrang();
        }
    }
}

