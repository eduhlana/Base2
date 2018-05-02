using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace RegressaoGCP.core
{
    public class BasePage
    {

        protected void acao(By Element)
        {
            DriverFactory.GetDriver().FindElement(Element).Click();
        }
        protected void SelecionaGridComercial(By Element )
        { 
            try
            {
                DriverFactory.GetDriver().FindElement(Element).Click();
            }
            catch (NoSuchElementException a)
            {
                string mensagem = "Nao existe abrangência comercial cadastrada para esse código de venda ";
                Trace.TraceInformation(mensagem);
                Trace.Flush();
                throw a;
            }
        }
        protected void SelecionaGrid(By Element ,string acao , string teste)
        {
            string data = DateTime.Now.ToString();
            try
            {
                DriverFactory.GetDriver().FindElement(Element).Click();
            }
            catch (NoSuchElementException a)
            {

                string mensagem = "Nao existe registro para  " + acao;
                Trace.TraceInformation(data + " - " + teste +":" +mensagem);
                Trace.Flush();
                throw a;
            }
        }
        protected void Escrever(By Element, string Text )
        {
            
            DriverFactory.GetDriver().FindElement(Element).SendKeys(Text);
        }
        protected void SelectValue(By Element, string Text)
        {

            new SelectElement(DriverFactory.GetDriver().FindElement(Element)).SelectByValue(Text);
        }

        protected void Status(By Element)
        {

            DriverFactory.GetDriver().FindElement(Element).Click();
            
           
        }
        protected string ObterTexto(By Element)
        {
            return DriverFactory.GetDriver().FindElement(Element).Text;
        }
        protected void ValidaMensagemPopup(By Element , By Element1, string Texto1 , string teste)
        {
            string data = DateTime.Now.ToString();
            string result;
            try
            {
                
                string mensagem = DriverFactory.GetDriver().FindElement(Element).Text;

                if (mensagem == "")
                {
                    System.Threading.Thread.Sleep(1000);
                     mensagem = DriverFactory.GetDriver().FindElement(Element1).Text;
                    result = data + " - " + teste + ": " + mensagem;
                    Trace.TraceInformation(result);
                    Trace.Flush();
                    Assert.AreEqual(mensagem, Texto1);
                }
                 result = data + " - " + teste + ": " + mensagem;
                Trace.TraceInformation(result);
                Trace.Flush();
               
                Assert.AreEqual(mensagem, Texto1);
            }catch(NoSuchElementException)
            {
                System.Threading.Thread.Sleep(1000);
                string mensagem = DriverFactory.GetDriver().FindElement(Element1).Text;
                 result = data + " - " + teste + ": " + mensagem;
                Trace.TraceInformation(result);
                Trace.Flush();
                Assert.AreEqual(mensagem, Texto1);
            }
           
        }
        protected void EsperaCarregamento(By Element)
        {
            WebDriverWait wait = new WebDriverWait(DriverFactory.GetDriver(),
                TimeSpan.FromMinutes(6));

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
