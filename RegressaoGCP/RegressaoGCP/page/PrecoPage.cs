using RegressaoGCP.core;
using OpenQA.Selenium;

namespace RegressaoGCP.page
{
    public class PrecoPage : BasePage
    {
        public void MenuPreco(string texto)
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
        public void SelecionaMotivo(string texto, string motivo)
        {
            acao(By.Id(texto));
            System.Threading.Thread.Sleep(2000);
            SelectValue(By.Id(texto), motivo);
        }

        public void SelecionarAbrang(string texto)
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
        public void ValidaTextoMensagem(string telaerro, string Texto, string Texto1, string teste)
        {
            ValidaMensagemPopup(By.XPath(telaerro), By.XPath(Texto), Texto1, teste);

        }
        public void SelecionaStatus(string status)
        {
            Status(By.XPath("//input[@name='statusAprovacao'and @value='" + status + "']"));
        }
        public void ConsultarAbrangencia(string Texto)
        {
            acao(By.Id(Texto));

        }

        public void BuscarAbrangencia(string Texto)
        {
            SelecionaGridComercial(By.XPath(Texto));

        }
        public void SelecionaAbrangenciaVigencia(string Texto)
        {
            SelecionaGridComercial(By.XPath(Texto));

        }

        public void SelecionaAbrangencia(string Texto, string acao, string teste)
        {
            SelecionaGrid(By.XPath(Texto), acao, teste);

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
     
        public void InserePreco(string texto, string prioridade)
        {
            Escrever(By.Id(texto), prioridade);
        }
        public void InsereRedutor(string texto, string prioridade)
        {
            Escrever(By.Id(texto), prioridade);
        }
    }
}
