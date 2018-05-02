using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegressaoGCP.page;
using RegressaoGCP.Data;
using System.Configuration;
using RegressaoGCP.core;

namespace RegressaoGCP
{

    public class Preco : BaseTest
    {
        public PrecoPage PrecoPage = new PrecoPage();

        string telapreco = "//*[@id=\"sidebar\"]/ul/li[6]/a/span";
        string botaoincluir = "btnIncluir";
        string botaoaprovar = "btnAprovar";
        string botaocancelar = "btnCancelar";
        string campocodvenda = "txtCodVenda";
        string botaoexcluir = "btnExcluir";
        string consultar = "//*[@id=\"btnPesquisar\"]";
        string linhagrid = "//*[@id=\"tbPreco\"]/tbody/tr/td[8]/input";
        string confirmar = "/ html / body / div[6] / div[3] / div / button[1]";
        string telaerro = "/ html / body / div[8] ";
        string mensagemresultado = "/ html / body / div[6] / div[2]";
        string abrangencia = "//*[@id=\"arvoreEstrutura\"]/ul/li/span/span[2]";
        string Aprovado = "1";
        string lupaalterar = "//*[@id=\"tbPreco\"]/div[1]/div[2]/div[2]/table/tbody/tr[1]/td[7]";
        string gridcomercial = "//*[@id=\"tbAbrangencia\"]/tbody/tr[1]/td[9]";
        string cicloinicial = "cicloInicio";
        string ciclofinal = "cicloTermino";
        string preco = "preco";
        string redutor = "redutor";
        string pontos = "pontos";
        string campomotivo = "codigoMotivo";
        public void InserirPreco()
        {
            string acao = "inserir";

            string linha = "Aprovado";

            string teste = "Inserir Abrangência Comercial";

            var Validacao = ConfigurationManager.AppSettings["MsgInclui"];

            var linhaplanilha = ExcellAcess.PegaLinha(linha);


            PrecoPage.AguardaXPath(telapreco);

            PrecoPage.MenuPreco(telapreco);

            PrecoPage.InserirCodVenda(campocodvenda ,linhaplanilha.CodVendaProduto);


            PrecoPage.BuscarAbrangencia(consultar);

            System.Threading.Thread.Sleep(2000);

            PrecoPage.SelecionaAbrangenciaVigencia(gridcomercial);

            System.Threading.Thread.Sleep(800);

            PrecoPage.Incluir(botaoincluir);

            PrecoPage.AguardaXPath(abrangencia);

            PrecoPage.SelecionaAbrangenciaVigencia(abrangencia);

            System.Threading.Thread.Sleep(800);

            PrecoPage.InsereCiclo(cicloinicial , linhaplanilha.CicloInicio);

            PrecoPage.InserePreco(preco ,linhaplanilha.Preco);

            PrecoPage.InsereRedutor(redutor, linhaplanilha.Redutor);

            PrecoPage.acao(pontos);

            System.Threading.Thread.Sleep(1000);

            PrecoPage.SelecionaMotivo(campomotivo , linhaplanilha.Motivo);

            PrecoPage.Incluir("btnIncluirItem");

            System.Threading.Thread.Sleep(1000);
            
            PrecoPage.AlterarOuSalvar("btnSalvar");

            System.Threading.Thread.Sleep(3000);

            PrecoPage.ValidaTextoMensagem(telaerro, mensagemresultado, Validacao, teste);

        }

        public void AprovarPreco()
        {
            string acao = "aprovar";

            string linha = "Rascunho";

            string teste = "Aprovar Abrangência Comercial";

            var Validacao = ConfigurationManager.AppSettings["MsgAprovaPreco"];

            var linhaplanilha = ExcellAcess.PegaLinha(linha);

            AprovaCancelaouExclui(linhaplanilha.Status, linhaplanilha.CodVendaProduto, botaoaprovar, Validacao, teste, acao);


        }

    
        public void CancelarPreco()
        {
            string acao = "cancelar";

            string linha = "Aprovado";

            string teste = "Cancelar Abrangência Comercial";

            string Validacao = ConfigurationManager.AppSettings["MsgCancelaPreco"];

            var linhaplanilha = ExcellAcess.PegaLinha(linha);


            AprovaCancelaouExclui(linhaplanilha.Status, linhaplanilha.CodVendaProduto, botaocancelar, Validacao, teste, acao);
        }

        public void SalvarPreco()
        {
            string acao = "salvar";

            string linha = "Rascunho";

            string teste = "Alterar ciclo final e salvar Abrangência Comercial";

            var Validacao = ConfigurationManager.AppSettings["MsgAltera"];

            var linhaplanilha = ExcellAcess.PegaLinha(linha);

            PrecoPage.MenuPreco(telapreco);

            PrecoPage.AguardaXPath(telapreco);

            PrecoPage.InserirCodVenda("txtCodVenda", linhaplanilha.CodVendaProduto);

            PrecoPage.AguardaXPath(consultar);

            PrecoPage.BuscarAbrangencia(consultar);

            PrecoPage.AguardaXPath(gridcomercial);

            PrecoPage.SelecionaAbrangenciaVigencia(gridcomercial);

            System.Threading.Thread.Sleep(3000);

            PrecoPage.SelecionaStatus(Aprovado);

            System.Threading.Thread.Sleep(800);

            PrecoPage.SelecionaStatus("6");

            System.Threading.Thread.Sleep(800);

            PrecoPage.SelecionaStatus("7");

            System.Threading.Thread.Sleep(2000);

            PrecoPage.SelecionaAbrangencia(lupaalterar, acao, teste);

            PrecoPage.AguardaId("btnAlterar");

            PrecoPage.AlterarOuSalvar("btnAlterar");

            PrecoPage.AguardaId("cicloTermino");

            PrecoPage.InsereCiclo("cicloTermino", linhaplanilha.CicloFim);

            PrecoPage.AguardaId("btnSalvar");

            PrecoPage.AlterarOuSalvar("btnSalvar");

            System.Threading.Thread.Sleep(1000);

            PrecoPage.ValidaTextoMensagem(telaerro, mensagemresultado, Validacao, teste);
        }

        public void ExcluiPreco()
        {
            string acao = "excluir";

            string linha = "Rascunho";

            string teste = "Excluir Rascunho Abrangência Comercial ";

            var Validacao = ConfigurationManager.AppSettings["MsgExclui"];

            var linhaplanilha = ExcellAcess.PegaLinha(linha);

            AprovaCancelaouExclui(linhaplanilha.Status, linhaplanilha.CodVendaProduto, botaoexcluir, Validacao, teste, acao);
        }


        public void AprovaCancelaouExclui(string status, string codvenda, string botao, string texto, string teste, string acao)
        {

            PrecoPage.AguardaXPath(telapreco);

            PrecoPage.MenuPreco(telapreco);

            PrecoPage.InserirCodVenda(campocodvenda, codvenda);

            PrecoPage.AguardaXPath(consultar);

            PrecoPage.BuscarAbrangencia(consultar);

            System.Threading.Thread.Sleep(2000);

            PrecoPage.AguardaXPath(gridcomercial);

            PrecoPage.SelecionaAbrangenciaVigencia(gridcomercial);

            System.Threading.Thread.Sleep(800);


            if (Aprovado != status)
            {
                PrecoPage.SelecionaStatus(Aprovado);
                System.Threading.Thread.Sleep(3000);
                PrecoPage.SelecionaStatus(status);
            }

            System.Threading.Thread.Sleep(3000);

            PrecoPage.SelecionaAbrangencia(linhagrid, acao, teste);

            PrecoPage.acao(botao);

            PrecoPage.ConfirmaCancela(confirmar);

            System.Threading.Thread.Sleep(2000);

            PrecoPage.ValidaTextoMensagem(telaerro, mensagemresultado, texto, teste);

        }


    }
}

