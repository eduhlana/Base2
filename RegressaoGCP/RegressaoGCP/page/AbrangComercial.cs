using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegressaoGCP.core;
using RegressaoGCP.page;
using RegressaoGCP.Data;
using System.Configuration;

namespace RegressaoGCP
{
    
    public class AbrangComercial : BaseTest
    {
        public AbrangComercialPage AbrangComercialPage = new AbrangComercialPage();
        public BasePage basepage = new BasePage();
        public string telaabrangcomercial = "//*[@id=\"sidebar\"]/ul/li[4]/a/span";
        public string botaoincluir = "btnIncluir";
        public string botaoaprovar = "btnAprovar";
        public string botaocancelar = "btnCancelar";
        public string campocodvenda = "txtCodVenda";
        public string botaoexcluir = "btnExcluir";
        public string consultar = "btnPesquisar";
        public string linhagrid = "//*[@id=\"tbAbrangencia\"]/tbody/tr[1]/td[13]/input";
        public string confirmar = "/ html / body / div[6] / div[3] / div / button[1]";
        public string telaerro = "/ html / body / div[8] "; 
        public string mensagemresultado = "/ html / body / div[6] / div[2]";
        public string abrangencia = "//*[@id=\"arvoreEstrutura\"]/ul/li/span/span[2]";
        public string Aprovado = "1";

        [TestMethod]
        public void InserirAbrang()
        {
            string acao = "inserir";

            string linha = "Aprovado";

            string teste = "Inserir Abrangência Comercial";

            var Validacao = ConfigurationManager.AppSettings["MsgInclui"];

            var linhaplanilha = ExcellAcess.PegaLinha(linha);


            AbrangComercialPage.AguardaXPath(telaabrangcomercial);

            AbrangComercialPage.MenuAbrangComercial(telaabrangcomercial);

            AbrangComercialPage.AguardaId(botaoincluir);

            AbrangComercialPage.Incluir(botaoincluir);

            AbrangComercialPage.AguardaId("codigoVendaProduto");

            AbrangComercialPage.InserirCodVenda("codigoVendaProduto", linhaplanilha.CodVendaProduto);

            System.Threading.Thread.Sleep(2000);

            AbrangComercialPage.SelecionarAbrang(abrangencia);
            
            AbrangComercialPage.InsereCiclo("cicloInicioIncluir", linhaplanilha.CicloInicio);

            AbrangComercialPage.AlterarOuSalvar("btnSalvar");

            System.Threading.Thread.Sleep(3000);

            AbrangComercialPage.ValidaTextoMensagem(telaerro, mensagemresultado, Validacao, teste);

           

        }
        [TestMethod]
        public void AprovarRascunhoAbrang()
        {
            string acao = "aprovar";

            string linha = "Rascunho";

            string teste = "Aprovar Abrangência Comercial";

            var Validacao = ConfigurationManager.AppSettings["MsgAprova"];
          
            var linhaplanilha = ExcellAcess.PegaLinha(linha);

            AprovaCancelaouExclui(linhaplanilha.Status, linhaplanilha.CodVendaProduto, botaoaprovar, Validacao, teste , acao);


        }

        [TestMethod]
        public void CancelarAbrang()
        {
            string acao = "cancelar";

            string linha = "Aprovado";

            string teste = "Cancelar Abrangência Comercial";

            string Validacao = ConfigurationManager.AppSettings["MsgCancel"];
            
            var linhaplanilha = ExcellAcess.PegaLinha(linha);


            AprovaCancelaouExclui(linhaplanilha.Status, linhaplanilha.CodVendaProduto, botaocancelar, Validacao, teste , acao);
        }
        [TestMethod]
        public void SalvarAbrang()
        {
            string acao = "salvar";

            string linha = "Rascunho";

            string teste = "Alterar ciclo final e salvar Abrangência Comercial";

            var Validacao = ConfigurationManager.AppSettings["MsgAltera"];

            var linhaplanilha = ExcellAcess.PegaLinha(linha);
            
            AbrangComercialPage.MenuAbrangComercial(telaabrangcomercial);

            AbrangComercialPage.AguardaXPath(telaabrangcomercial);

            AbrangComercialPage.InserirCodVenda("txtCodVenda", linhaplanilha.CodVendaProduto);
            
            AbrangComercialPage.SelecionaStatus(Aprovado);
           
            AbrangComercialPage.SelecionaStatus(linhaplanilha.Status);
            
            AbrangComercialPage.ConsultarAbrangencia(consultar);

            System.Threading.Thread.Sleep(2000);

            AbrangComercialPage.SelecionaAbrangencia("//*[@id=\"tbAbrangencia\"]/tbody/tr[1]/td[12]/a/i" , acao , teste);

            AbrangComercialPage.AguardaId("cicloTermino");

            AbrangComercialPage.AlterarOuSalvar("btnAlterar");

            AbrangComercialPage.AguardaId("cicloTermino");

            AbrangComercialPage.InsereCiclo("cicloTermino", linhaplanilha.CicloFim);

            System.Threading.Thread.Sleep(2000);

            AbrangComercialPage.AlterarOuSalvar("btnSalvar");

            AbrangComercialPage.AguardaXPath(mensagemresultado);

            AbrangComercialPage.ValidaTextoMensagem(telaerro, mensagemresultado, Validacao, teste);
        }
        [TestMethod]
        public void ExcluiRascunhoAbrang()
        {
            string acao = "excluir";

            string linha = "Rascunho";

            string teste = "Excluir Rascunho Abrangência Comercial ";

            var Validacao = ConfigurationManager.AppSettings["MsgExclui"];

            var linhaplanilha = ExcellAcess.PegaLinha(linha);

            AprovaCancelaouExclui(linhaplanilha.Status, linhaplanilha.CodVendaProduto, botaoexcluir, Validacao, teste , acao);
        }


        public void AprovaCancelaouExclui(string status, string codvenda, string botao, string texto, string teste , string acao)
        {
            
            AbrangComercialPage.MenuAbrangComercial(telaabrangcomercial);

            AbrangComercialPage.AguardaXPath(telaabrangcomercial);

            AbrangComercialPage.InserirCodVenda(campocodvenda, codvenda);
            
            if (Aprovado != status)
            {
                AbrangComercialPage.SelecionaStatus(Aprovado);
                AbrangComercialPage.SelecionaStatus(status);
            }

            AbrangComercialPage.ConsultarAbrangencia(consultar);

            System.Threading.Thread.Sleep(3000);

            AbrangComercialPage.SelecionaAbrangencia(linhagrid , acao , teste);
            
            AbrangComercialPage.acao(botao);
            
            AbrangComercialPage.Confirma(confirmar);

            AbrangComercialPage.AguardaXPath(mensagemresultado);

            AbrangComercialPage.ValidaTextoMensagem(telaerro,mensagemresultado, texto, teste);

        }


    }
}

