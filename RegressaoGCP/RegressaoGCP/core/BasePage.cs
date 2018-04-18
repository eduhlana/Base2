using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;

namespace RegressaoGCP.core
{
    public class BasePage
    {
        
        protected void acao(By Element)
        {
            DriverFactory.GetDriver().FindElement(Element).Click();
        }

        protected void Escrever(By Element, string Text )
        {
            
            DriverFactory.GetDriver().FindElement(Element).SendKeys(Text);
        }
        protected void SelectValue(By Element, string Text)
        {
            
            new SelectElement(DriverFactory.GetDriver().FindElement(Element)).SelectByText(Text);
        }

        protected string ObterTexto(By Element)
        {
            return DriverFactory.GetDriver().FindElement(Element).Text;
        }
        protected void ValidaMensagemPopup(By Element , string Texto1 , string teste)
        {
            string data = DateTime.Now.ToString();
            try
            {
                
                string mensagem = DriverFactory.GetDriver().FindElement(Element).Text;
                string result = data + " - " + teste + ": " + mensagem;
                Trace.TraceInformation(result);
                Trace.Flush();
                Assert.AreEqual(mensagem, Texto1);
            }
            catch(ElementNotVisibleException )
            {
                Trace.TraceInformation(data+" - " + "Erro ao " +teste);
                Trace.Flush();
            }
            
        }
        protected void EsperaCarregamento(By Element)
        {
            WebDriverWait wait = new WebDriverWait(DriverFactory.GetDriver(),
                TimeSpan.FromSeconds(10000));

            Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>
                ((IWebDriver Web) => {
                    Web.FindElement(Element);
                    return true;
            });

            wait.Until(waitForElement);
        }

        protected void EsperaCarregamentoTexto(By Element)
        {
            WebDriverWait wait = new WebDriverWait(DriverFactory.GetDriver(),
                TimeSpan.FromMinutes(3));

            Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>
                ((IWebDriver Web) => {

                    if (Web.FindElement(Element).Text != "")
                        return true;
                    else
                        return false;
                });

            wait.Until(waitForElement);
        }
    }
}
