using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
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
        public string Aprovado = "//*[@id=\"pesquisarVendaProdutoAbrangencia\"]/div[2]/div/div[3]/div[2]/div[1]/label/input";
        public string Cancelado = "//*[@id=\"pesquisarVendaProdutoAbrangencia\"]/div[2]/div/div[3]/div[2]/div[2]/label/input";
        public string Encerrado = "//*[@id=\"pesquisarVendaProdutoAbrangencia\"]/div[2]/div/div[3]/div[2]/div[3]/label/input";
        public string Rascunho = "//*[@id=\"pesquisarVendaProdutoAbrangencia\"]/div[2]/div/div[3]/div[2]/div[4]/label/input";
        public string mensagemresultado = "/ html / body / div[6] / div[2]";
        public string abrangencia = "//*[@id=\"arvoreEstrutura\"]/ul/li/span/span[2]";
        string linha = "natura";
        public void InserirAbrang()
        {
            string teste = "Inserir Abrangência Comercial";
            var Validacao = ConfigurationManager.AppSettings["MsgInclui"];

            var linhaplanilha = ExcellAcess.PegaLinha(linha);

            AbrangComercialPage.MenuAbrangComercial(telaabrangcomercial);

            AbrangComercialPage.AguardaXPath(telaabrangcomercial);

            AbrangComercialPage.Incluir(botaoincluir);

            AbrangComercialPage.InserirCodVenda("codigoVendaProduto", linhaplanilha.CodVendaProduto);

            AbrangComercialPage.AguardaXPath(abrangencia);

            AbrangComercialPage.SelecionarAbrang(abrangencia);
            
            AbrangComercialPage.InsereCiclo("cicloInicioIncluir", linhaplanilha.CicloInicio);

            AbrangComercialPage.AlterarOuSalvar("btnSalvar");

            System.Threading.Thread.Sleep(5000);

            AbrangComercialPage.ValidaTextoMensagem(mensagemresultado, Validacao, teste);

        }

        public void AprovarRascunhoAbrang()
        {
            string teste = "Aprovar Abrangência Comercial";

            var Validacao = ConfigurationManager.AppSettings["MsgAprova"];
          
            var linhaplanilha = ExcellAcess.PegaLinha(linha);

            string status = Rascunho;

            AprovaCancelaouExclui(Rascunho, linhaplanilha.CodVendaProduto, botaoaprovar, Validacao, teste);


        }

       
        public void CancelarAbrang()
        {
            string teste = "Cancelar Abrangência Comercial";

            string Validacao = ConfigurationManager.AppSettings["MsgCancel"];
            
            var linhaplanilha = ExcellAcess.PegaLinha(linha);

            string status = Aprovado;

            AprovaCancelaouExclui(status, linhaplanilha.CodVendaProduto, botaocancelar, Validacao, teste);
        }
        
        public void SalvarAbrang()
        {
            string teste = "Alterar ciclo final e salvar Abrangência Comercial";

            var Validacao = ConfigurationManager.AppSettings["MsgAltera"];

            var linhaplanilha = ExcellAcess.PegaLinha(linha);
            
            AbrangComercialPage.MenuAbrangComercial(telaabrangcomercial);

            AbrangComercialPage.AguardaXPath(telaabrangcomercial);

            AbrangComercialPage.InserirCodVenda("txtCodVenda", linhaplanilha.CodVendaProduto);
            
            AbrangComercialPage.SelecionaStatus(Aprovado);
           
            AbrangComercialPage.SelecionaStatus(Cancelado);
            
            AbrangComercialPage.ConsultarAbrangencia(consultar);

            System.Threading.Thread.Sleep(2000);

            AbrangComercialPage.SelecionaAbrangencia("//*[@id=\"tbAbrangencia\"]/tbody/tr[1]/td[12]/a/i");

            AbrangComercialPage.AguardaId("cicloTermino");

            AbrangComercialPage.AlterarOuSalvar("btnAlterar");

            AbrangComercialPage.AguardaId("btnSalvar");

            AbrangComercialPage.InsereCiclo("cicloTermino", linhaplanilha.CicloFim);
            
            AbrangComercialPage.AlterarOuSalvar("btnSalvar");

            AbrangComercialPage.AguardaXPath(mensagemresultado);

            AbrangComercialPage.ValidaTextoMensagem(mensagemresultado, Validacao, teste);
        }
     
        public void ExcluiRascunhoAbrang()
        {
            string teste = "Excluir Rascunho Abrangência Comercial ";

            var Validacao = ConfigurationManager.AppSettings["MsgExclui"];

            var linhaplanilha = ExcellAcess.PegaLinha(linha);

            string status = Rascunho;
            
            AprovaCancelaouExclui(status, linhaplanilha.CodVendaProduto, botaoexcluir, Validacao, teste);
        }


        public void AprovaCancelaouExclui(string status, string codvenda, string botao, string texto, string teste)
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

            System.Threading.Thread.Sleep(2000);

            AbrangComercialPage.SelecionaAbrangencia(linhagrid);
            
            AbrangComercialPage.acao(botao);
            
            AbrangComercialPage.Confirma(confirmar);
            AbrangComercialPage.AguardaXPath(mensagemresultado);
            AbrangComercialPage.ValidaTextoMensagem(mensagemresultado, texto, teste);

        }


    }
}

