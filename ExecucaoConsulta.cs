using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using static WebProject.Global;

namespace WebProject
{
    public class ExecucaoConsulta
    {
        public Global global;
        public MetodosDeBusca busca;

        [Theory]
        [InlineData(Browser.Chrome, "fiat", "Brava")]
        public void Consultar(Browser browser, string marca, string modelo) 
        {
            global = new Global();
            busca = new MetodosDeBusca();

            global.SelecionarNavegador(Browser.Chrome);
            global.AbrirNavegador();

            busca.ConsultarCarrosUsados(marca, modelo);
            busca.ValidarPrecoEMarcaDosItensConsutados();
            busca.GravarDadosEmUmaLista();
            busca.LerEComprarDados(marca, modelo);

            


        }


    }
}
