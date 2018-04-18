using RegressaoGCP.core;
using OpenQA.Selenium;

namespace RegressaoGCP.page
{
    public class AbrangComercialPage : BasePage
    {
       
        public void MenuAbrangComercial(string texto)
        {
           
            acao(By.CssSelector(texto));
        }
        public void Incluir(string texto)
        {
            acao(By.Id(texto));
        }
        public void InserirCodVenda(string texto , string codvenda)
        {
            Escrever(By.Id(texto), codvenda);
             
    }
        public void SelecionarAbrang(string texto)
        {
            acao(By.CssSelector(texto)); 
        }
        public void InsereCiclo(string texto , string ciclo)
        {
            SelectValue(By.Id(texto),ciclo);
        }
        public void Aguarda(int segundos)
        {
            System.Threading.Thread.Sleep(segundos);
        }
        public void ValidaTextoMensagem(string Texto , string Texto1 , string teste)
        {
            ValidaMensagemPopup(By.XPath(Texto),Texto1 , teste);

        }
        public void SelecionaStatus(string Texto)
        {
            acao(By.XPath(Texto));

        }
        public void ConsultarAbrangencia(string Texto)
        {
            acao(By.Id(Texto));

        }
        public void SelecionaAbrangencia(string Texto)
        {
            acao(By.XPath(Texto));

        }
        public void Aprovar(string Texto)
        {
            acao(By.Id(Texto));

        }
        public void Confirma(string Texto)
        {
            acao(By.XPath(Texto));

        }
        public void Cancelar(string Texto)
        {
            acao(By.XPath(Texto));

        }
        public void AlterarOuSalvar(string texto)
        {
            acao(By.Id(texto));
        }
        public void acao(string texto)
        {
            acao(By.Id(texto));
        }

    }
}
