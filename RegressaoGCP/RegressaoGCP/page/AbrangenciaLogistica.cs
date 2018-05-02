using RegressaoGCP.core;
using RegressaoGCP.page;
using RegressaoGCP.Data;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace RegressaoGCP.page
{
    [TestClass]
    public class AbrangenciaLogistica : BaseTest
    {
        private AbrangenciaLogisticaPage AbrangLogisticaPage = new AbrangenciaLogisticaPage();
        private BasePage basepage = new BasePage();
        string telaabranglogistica = "//*[@id=\"sidebar\"]/ul/li[5]/a/span";
        string botaoincluir = "btnIncluir";
        string botaoaprovar = "btnAprovar";
        string botaocancelar = "btnCancelar";
        string campocodvenda = "txtCodVenda";
        string botaoexcluir = "btnExcluir";
        string consultar = "btnPesquisar";
        string confirmar = "/ html / body / div[6] / div[3] / div / button[1]";
        string telaerro = "/ html / body / div[8]";
        string mensagemresultado = "/ html / body / div[6] / div[2]";
        string abrangencia = "//*[@id=\"arvoreEstrutura\"]/ul/li/span/span[2]";
        string gridcomercial = "//*[@id=\"tbAbrangencia\" and @style=\"201819\")]";
        string gridlogistica = "//*[@id=\"tbProdutoAbrangencia\"]/tbody/tr/td[4]/input";
        string material = "//*[@id=\"codigoProduto\"]";
        string Aprovado = "1";
        string campomaterial = "codigoProduto";
        string campoprioridade = "nmPrioridade";
        string campocicloinicial = "nmCicloInicio";
        string campociclofinal = "nmCicloTermino";
        string lupaalterar = "//*[@id=\"tbProdutoAbrangencia\"]/tbody/tr[1]/td[3]/a";
        string linhamaterial = "//*[@id=\"tbProdutoAbrangenciaItem\"]/tbody/tr[1]/td[8]/input";

     
        public void InserirAbrangLog()
        {

            string linha = "Aprovado";

            string teste = "Inserir Abrangência Logística";

            var Validacao = ConfigurationManager.AppSettings["MsgInclui"];

            var linhaplanilha = ExcellAcess.PegaLinha(linha);

            AbrangLogisticaPage.AguardaXPath(telaabranglogistica);

            AbrangLogisticaPage.MenuAbrangLog(telaabranglogistica);

            AbrangLogisticaPage.AguardaId(campocodvenda);

            AbrangLogisticaPage.InserirCodVenda(campocodvenda, linhaplanilha.CodVendaProduto);

            AbrangLogisticaPage.ConsultarAbrangenciaLog(consultar);

            System.Threading.Thread.Sleep(2000);

            AbrangLogisticaPage.SelecionaAbrangencia(gridcomercial);

            System.Threading.Thread.Sleep(2000);

            AbrangLogisticaPage.Incluir(botaoincluir);

            AbrangLogisticaPage.AguardaId("incluirForm");

            AbrangLogisticaPage.SelecionaMaterial(campomaterial , linhaplanilha.Material);

            AbrangLogisticaPage.InserePrioridade(campoprioridade, linhaplanilha.Prioridade);

            AbrangLogisticaPage.InsereCiclo(campocicloinicial , linhaplanilha.CicloInicio);

            AbrangLogisticaPage.Incluir("btnAddSessionItem");

            System.Threading.Thread.Sleep(2000);

            AbrangLogisticaPage.AlterarOuSalvar("btnSalvar");

            System.Threading.Thread.Sleep(3000);

            AbrangLogisticaPage.ValidaTextoMensagem(telaerro, mensagemresultado,  Validacao, teste);
         
        }
     
        public void AprovarRascunhoAbrangLog()
        {

            string linha = "Rascunho";

            string acao = "aprovar";

            string teste = "Aprovar Abrangência Logística";

            var Validacao = ConfigurationManager.AppSettings["MsgAprovaLog"];

            var linhaplanilha = ExcellAcess.PegaLinha(linha);

      
            Acao(linhaplanilha.Status, linhaplanilha.CodVendaProduto, botaoaprovar, Validacao, teste , acao );


        }
   

        public void CancelarAbrangLog()
        {
            string linha = "Aprovado";

            string teste = "Cancelar Abrangência Logística";

            string acao = "cancelar";

            string Validacao = ConfigurationManager.AppSettings["MsgCancelLog"];

            var linhaplanilha = ExcellAcess.PegaLinha(linha);


            Acao(linhaplanilha.Status, linhaplanilha.CodVendaProduto, botaocancelar, Validacao, teste , acao );
        }

        public void SalvarAbrangLog()
        {
            string linha = "Encerrado";

            string teste = "Alterar e salvar Abrangência Logística";

   
            var Validacao = ConfigurationManager.AppSettings["MsgAltera"];

            var linhaplanilha = ExcellAcess.PegaLinha(linha);

            
            AbrangLogisticaPage.MenuAbrangLog(telaabranglogistica);

            AbrangLogisticaPage.AguardaXPath(telaabranglogistica);

            AbrangLogisticaPage.InserirCodVenda(campocodvenda, linhaplanilha.CodVendaProduto);

            AbrangLogisticaPage.ConsultarAbrangenciaLog(consultar);

            System.Threading.Thread.Sleep(2000);

            AbrangLogisticaPage.SelecionaAbrangencia(gridcomercial);

            System.Threading.Thread.Sleep(2000);

            AbrangLogisticaPage.SelecionaStatus(Aprovado);

            AbrangLogisticaPage.AguardaXPath(lupaalterar);

            AbrangLogisticaPage.SelecionaAbrangencia(lupaalterar);

            AbrangLogisticaPage.AguardaId("btnAlterar");

            AbrangLogisticaPage.acao("btnAlterar");

            AbrangLogisticaPage.AguardaId(campociclofinal);

            AbrangLogisticaPage.SelecionaMaterial(linhamaterial);

            AbrangLogisticaPage.acao("btnRemoveSessionItems");

            AbrangLogisticaPage.SelecionaMaterial(campomaterial, linhaplanilha.Material);

            AbrangLogisticaPage.InserePrioridade(campoprioridade,linhaplanilha.Prioridade);

            AbrangLogisticaPage.InsereCiclo(campocicloinicial ,linhaplanilha.CicloInicio);

            AbrangLogisticaPage.acao("btnAddSessionItem");

            System.Threading.Thread.Sleep(2000);

            AbrangLogisticaPage.acao("btnSalvar");

            System.Threading.Thread.Sleep(2000);

            AbrangLogisticaPage.ValidaTextoMensagem(telaerro, mensagemresultado, Validacao, teste);
        }

        public void ExcluiRascunhoLog()
        {
            string linha = "Rascunho";

            string teste = "Excluir Rascunho Abrangência Logistica ";

            string acao = "excluir";

            var Validacao = ConfigurationManager.AppSettings["MsgExclui"];

            var linhaplanilha = ExcellAcess.PegaLinha(linha);

            Acao(linhaplanilha.Status, linhaplanilha.CodVendaProduto, botaoexcluir, Validacao, teste , acao );
        }

  
        public void Acao(string status, string codvenda, string botao, string Validacao, string teste , string acao )
        {

            AbrangLogisticaPage.MenuAbrangLog(telaabranglogistica);

            AbrangLogisticaPage.AguardaXPath(telaabranglogistica);

            AbrangLogisticaPage.InserirCodVenda(campocodvenda, codvenda);

            AbrangLogisticaPage.ConsultarAbrangenciaLog(consultar);

            System.Threading.Thread.Sleep(2000);

            AbrangLogisticaPage.SelecionaAbrangencia(gridcomercial);

            System.Threading.Thread.Sleep(2000);

            if (status != Aprovado)
            {
                AbrangLogisticaPage.SelecionaStatus(Aprovado);
                System.Threading.Thread.Sleep(2000);
                AbrangLogisticaPage.SelecionaStatus(status);
                System.Threading.Thread.Sleep(2000);
            }
            
            AbrangLogisticaPage.SelecionaAbrangenciaLog(gridlogistica , acao , teste);

            System.Threading.Thread.Sleep(3000);

            AbrangLogisticaPage.acao(botao);

            AbrangLogisticaPage.AguardaXPath(confirmar);

            AbrangLogisticaPage.ConfirmaCancela(confirmar);


            System.Threading.Thread.Sleep(4000);

            AbrangLogisticaPage.ValidaTextoMensagem(telaerro, mensagemresultado, Validacao, teste);

        }

    }
}
