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
        public AbrangComercialPage AbrangComercial = new AbrangComercialPage();
        public BasePage basepage = new BasePage();
        public AbrangComercial TelaAbrang = new AbrangComercial();


        [TestMethod]
      
        public void InserirAbrang()
        {
            string teste = "Inserir Abrangência Comercial";
            var Validacao = ConfigurationManager.AppSettings["MsgInclui"];

            string linha = "natura";
            var linhaplanilha = ExcellAcess.PegaLinha(linha);
            AbrangComercial.Aguarda(3000);
            AbrangComercial.MenuAbrangComercial("#sidebar > ul > li:nth-child(4) > a > i");
            AbrangComercial.Aguarda(3000);
            AbrangComercial.Incluir("btnIncluir");
            AbrangComercial.Aguarda(3000);
            AbrangComercial.InserirCodVenda("codigoVendaProduto", linhaplanilha.CodVendaProduto);
            AbrangComercial.Aguarda(3000);
            AbrangComercial.SelecionarAbrang("#arvoreEstrutura > ul > li > span > span.dynatree-checkbox");
            AbrangComercial.Aguarda(3000);
            AbrangComercial.InsereCiclo("cicloInicioIncluir", linhaplanilha.CicloInicio);
            AbrangComercial.Aguarda(3000);
            AbrangComercial.AlterarOuSalvar("btnSalvar");
            AbrangComercial.Aguarda(5000);
            AbrangComercial.ValidaTextoMensagem("/ html / body / div[6] / div[2]", Validacao, teste);

        }

        [TestMethod]
        public void AprovarRascunhoAbrang()
        {
            string teste = "Aprovar Abrangência Comercial";
            var Validacao = ConfigurationManager.AppSettings["MsgAprova"];
            string linha = "natura";
            var linhaplanilha = ExcellAcess.PegaLinha(linha);
            string status = TelaAbrang.Rascunho;
            int segundos = 20000;
            AprovaCancelaouExclui(TelaAbrang, TelaAbrang.Rascunho, linhaplanilha.CodVendaProduto, TelaAbrang.botaoaprovar, Validacao, teste, segundos);


        }

        [TestMethod]
        public void CancelarAbrang()
        {
            string teste = "Cancelar Abrangência Comercial";
            string Validacao = ConfigurationManager.AppSettings["MsgCancel"];
            string linha = "natura";
            var linhaplanilha = ExcellAcess.PegaLinha(linha);
            string status = TelaAbrang.Aprovado;
            int segundos = 15000;
            AprovaCancelaouExclui(TelaAbrang, status, linhaplanilha.CodVendaProduto, TelaAbrang.botaocancelar, Validacao, teste, segundos);
        }
        [TestMethod]
        public void SalvarAbrang()
        {
            string teste = "Alterar ciclo final e salvar Abrangência Comercial";
            var Validacao = ConfigurationManager.AppSettings["MsgAltera"];
            string linha = "natura";
            var linhaplanilha = ExcellAcess.PegaLinha(linha);
            AbrangComercial.Aguarda(3000);
            AbrangComercial.MenuAbrangComercial("#sidebar > ul > li:nth-child(4) > a > i");
            AbrangComercial.Aguarda(3000);
            AbrangComercial.InserirCodVenda("txtCodVenda", linhaplanilha.CodVendaProduto);
            AbrangComercial.Aguarda(3000);
            //desmarcar o status aprovado
            AbrangComercial.SelecionaStatus("//*[@id=\"pesquisarVendaProdutoAbrangencia\"]/div[2]/div/div[3]/div[2]/div[1]/label/input");
            //marcar o status Cancelado
            AbrangComercial.Aguarda(3000);
            AbrangComercial.SelecionaStatus("//*[@id=\"pesquisarVendaProdutoAbrangencia\"]/div[2]/div/div[3]/div[2]/div[2]/label/input");
            AbrangComercial.Aguarda(3000);
            AbrangComercial.ConsultarAbrangencia("btnPesquisar");
            AbrangComercial.Aguarda(5000);
            AbrangComercial.SelecionaAbrangencia("//*[@id=\"tbAbrangencia\"]/tbody/tr[1]/td[12]/a/i");
            AbrangComercial.Aguarda(3000);
            AbrangComercial.AlterarOuSalvar("btnAlterar");
            AbrangComercial.Aguarda(3000);
            AbrangComercial.InsereCiclo("cicloTermino", linhaplanilha.CicloFim);
            AbrangComercial.Aguarda(3000);
            AbrangComercial.AlterarOuSalvar("btnSalvar");
            AbrangComercial.Aguarda(5000);
            AbrangComercial.ValidaTextoMensagem("/html/body/div[6]/div[2]", Validacao, teste);
        }
        [TestMethod]
        public void ExcluiRascunhoAbrang()
        {
            string teste = "Excluir Rascunho Abrangência Comercial ";
            var Validacao = ConfigurationManager.AppSettings["MsgExclui"];
            string linha = "natura";
            var linhaplanilha = ExcellAcess.PegaLinha(linha);
            string status = TelaAbrang.Rascunho;
            int segundos = 6000;
            AprovaCancelaouExclui(TelaAbrang, status, linhaplanilha.CodVendaProduto, TelaAbrang.botaoexcluir, Validacao, teste, segundos);
        }
       

        public void AprovaCancelaouExclui(AbrangComercial TelaAbrang, string status, string codvenda, string acao, string texto, string teste, int segundos)
        {
            AbrangComercial.Aguarda(3000);
            AbrangComercial.MenuAbrangComercial(TelaAbrang.telaabrangcomercial);
            AbrangComercial.Aguarda(3000);
            AbrangComercial.InserirCodVenda(TelaAbrang.campocodvenda, codvenda);
            AbrangComercial.Aguarda(3000);
            if (TelaAbrang.Aprovado != status)
            {
                AbrangComercial.SelecionaStatus(TelaAbrang.Aprovado);
                AbrangComercial.SelecionaStatus(status);
            }

            AbrangComercial.Aguarda(3000);
            AbrangComercial.ConsultarAbrangencia(TelaAbrang.consultar);
            AbrangComercial.Aguarda(3000);
            AbrangComercial.SelecionaAbrangencia(TelaAbrang.linhagrid);
            AbrangComercial.Aguarda(3000);
            AbrangComercial.acao(acao);
            AbrangComercial.Aguarda(3000);
            AbrangComercial.Confirma(TelaAbrang.confirmar);
            AbrangComercial.Aguarda(segundos);
            AbrangComercial.ValidaTextoMensagem(TelaAbrang.mensagemresultado, texto, teste);

        }


    }
}

