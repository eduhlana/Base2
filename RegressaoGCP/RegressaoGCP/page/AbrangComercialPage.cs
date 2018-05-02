using RegressaoGCP.core;
using OpenQA.Selenium;

namespace RegressaoGCP.page
{

    public class AbrangComercialPage : BasePage
    {
       
        public void MenuAbrangComercial(string texto)
        {
           
            acao(By.XPath(texto));
        }
        public void Incluir(string texto)
        {
            acao(By.Id(texto));
        }
        public void InserirCodVenda(string texto , string codvenda)
        {
            AguardaId(texto);
            Escrever(By.Id(texto), codvenda);
        }
        public void SelecionarAbrang(string texto)
        {
            acao(By.XPath(texto)); 
        }
        public void InsereCiclo(string texto , string ciclo)
        {
            acao(By.Id(texto));
            SelectValue(By.Id(texto),ciclo);
        }
        public void AguardaId(string texto)
        {
            EsperaCarregamento(By.Id(texto));
        }
        public void AguardaXPath(string texto)
        {
            EsperaCarregamento(By.XPath(texto));
        }
        public void ValidaTextoMensagem(string telaerro ,string Texto , string Texto1 , string teste)
        {
            ValidaMensagemPopup(By.XPath(telaerro), By.XPath(Texto) ,Texto1 , teste);
           
        }
        public void SelecionaStatus(string status )
        {
            Status(By.XPath("//input[@name='statusAprovacao'and @value='"+status+"']"));


        }
        public void ConsultarAbrangencia(string Texto)
        {
            acao(By.Id(Texto));

        }
        public void SelecionaAbrangencia(string Texto , string acao ,string teste)
        {
            SelecionaGrid(By.XPath(Texto) , acao ,teste);

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
