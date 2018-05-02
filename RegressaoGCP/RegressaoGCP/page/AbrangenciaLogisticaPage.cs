using RegressaoGCP.core;
using OpenQA.Selenium;

namespace RegressaoGCP.page
{
    public class AbrangenciaLogisticaPage : BasePage
    {
        public void MenuAbrangLog(string texto)
        {

            acao(By.XPath(texto));
        }
        public void Incluir(string texto)
        {
            acao(By.Id(texto));
        }
        public void InserirCodVenda(string texto, string codvenda)
        {
            AguardaId(texto);
            Escrever(By.Id(texto), codvenda);
        }

       
        public void SelecionarAbrangLog(string texto)
        {
            acao(By.XPath(texto));
        }
        public void InsereCiclo(string texto, string ciclo)
        {
            acao(By.Id(texto));
            SelectValue(By.Id(texto), ciclo);
        }
        public void AguardaId(string texto)
        {
            EsperaCarregamento(By.Id(texto));
        }
        public void AguardaXPath(string texto)
        {
            EsperaCarregamento(By.XPath(texto));
        }
        public void ValidaTextoMensagem(string telaerro,string Texto, string Texto1, string teste)
        {
            ValidaMensagemPopup(By.XPath(telaerro), By.XPath(Texto), Texto1, teste);

        }
        public void SelecionaStatus(string status)
        {
            Status(By.XPath("//input[@name='statusAprovacao'and @value='" + status + "']"));


        }
        public void ConsultarAbrangenciaLog(string Texto)
        {
            acao(By.Id(Texto));

        }
        public void SelecionaAbrangencia(string Texto )
        {
            SelecionaGridComercial(By.XPath(Texto));

        }

        public void SelecionaAbrangenciaLog(string Texto, string acao , string teste)
        {
            SelecionaGrid(By.XPath(Texto), acao , teste);

        }
        public void Aprovar(string Texto)
        {
            acao(By.Id(Texto));

        }
        public void ConfirmaCancela(string Texto)
        {
            acao(By.XPath(Texto));

        }

        public void SelecionaMaterial(string Texto)
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
        public void SelecionaMaterial(string texto , string material)
        {
            acao(By.Id(texto));
            System.Threading.Thread.Sleep(2000);
            SelectValue(By.Id(texto), material);
        }
        public void InserePrioridade(string texto , string prioridade)
        {
            Escrever(By.Id(texto), prioridade);
        }
    }
}
