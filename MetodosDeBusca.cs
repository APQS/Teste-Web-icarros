using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace WebProject
{
    public class MetodosDeBusca
    {
        #region Elementos da Tela de busca
        public WebDriverWait wait;
        public IWebElement BotaoOk => Global.Webdriver.FindElement(By.XPath("//*[@id='isView']/div/div/button"));
        public IWebElement CheckBoxKM => Global.Webdriver.FindElement(By.Id("anunciosNovos"));
        public IWebElement CampoMarca => Global.Webdriver.FindElement(By.XPath("//*[@id='buscaForm']/div[2]/div[1]/div/div/div/div"));
        public IWebElement CampoPesquisaDeMarca => Global.Webdriver.FindElement(By.XPath("//*[@id='buscaForm']/div[2]/div[1]/div/div/div/div/div/div/input"));
        public IWebElement CampoModelo => Global.Webdriver.FindElement(By.XPath("//*[@id='buscaForm']/div[2]/div[2]/div/div/div/div"));
        public IWebElement CampoPesquisaDeModelo => Global.Webdriver.FindElement(By.XPath("//*[@id='buscaForm']/div[2]/div[2]/div/div/div/div/div/div/input"));
        public IWebElement CampoAnoMin => Global.Webdriver.FindElement(By.XPath("//*[@id='buscaForm']/div[3]/div[1]/div/div/div"));
        public IWebElement PesquisaDeAnoMin => Global.Webdriver.FindElement(By.XPath("//*[@id='buscaForm']/div[3]/div[1]/div/div/div/div/div/div/input"));
        public IWebElement CampoAnoMax => Global.Webdriver.FindElement(By.XPath("//*[@id='buscaForm']/div[3]/div[2]/div/div/div"));
        public IWebElement PesquisaAnoMax => Global.Webdriver.FindElement(By.XPath("//*[@id='buscaForm']/div[3]/div[2]/div/div/div/div/div/div/input"));
        public IWebElement CampoPrecoMin => Global.Webdriver.FindElement(By.XPath("//*[@id='buscaForm']/div[3]/div[3]//button"));
        public IWebElement CampoPrecoMax => Global.Webdriver.FindElement(By.XPath("//*[@id='buscaForm']/div[3]/div[4]//button"));
        public IWebElement BotaoBuscar => Global.Webdriver.FindElement(By.XPath("//*[@id='buscaForm']/div[4]/div[2]"));
        public IWebElement CheckboxMinhaCidade => Global.Webdriver.FindElement(By.Id("localizacaoEstado"));
        public IWebElement CampoLocalizacao => Global.Webdriver.FindElement(By.Id("cidadeAbertoTexto"));
        public IWebElement BotaoVoltarParaTelaDeConsulta => Global.Webdriver.FindElement(By.XPath("//*[@id='conteudoLista']/div[1]/ul/li[1]/span[2]/a"));
        #endregion

        #region Elementos do Primeiro resultado de busca
        // tabela 1
        public IWebElement Tabela1ValorAVista => Global.Webdriver.FindElement(By.XPath("//*[@id='ac31000680']/div/a/h3"));
        public IWebElement Tabela1Modelo => Global.Webdriver.FindElement(By.XPath("//*[@id='ac31000680']/div/a/h2"));
        public IWebElement Tabela1Ano => Global.Webdriver.FindElement(By.XPath("//*[@id='ac31000680']/div/div[2]/div[1]/a/ul/li[1]/p"));
        public IWebElement Tabela1KM => Global.Webdriver.FindElement(By.XPath("//*[@id='ac31000680']/div/div[2]/div[1]/a/ul/li[2]"));
        public IWebElement Tabela1Cor => Global.Webdriver.FindElement(By.XPath("//*[@id='ac31000680']/div/div[2]/div[1]/a/ul/li[3]/p"));
        public IWebElement Tabela1Cambio => Global.Webdriver.FindElement(By.XPath("//*[@id='ac31000680']/div/div[2]/div[1]/a/ul/li[4]/p"));

        #endregion

        #region Elementos do Segundo resultado de busca
        // tabela 2 
        public IWebElement Tabela2Modelo => Global.Webdriver.FindElement(By.XPath("//*[@id='ac31147904']/div/a/h2"));
        public IWebElement Tabela2Preco => Global.Webdriver.FindElement(By.XPath("//*[@id='ac31147904']/div/a/h3"));
        public IWebElement Tabela2Ano => Global.Webdriver.FindElement(By.XPath("//*[@id='ac31147904']/div/div[3]/div[1]/a/ul/li[1]/p"));
        public IWebElement Tabela2KM => Global.Webdriver.FindElement(By.XPath("//*[@id='ac31147904']/div/div[3]/div[1]/a/ul/li[2]/p"));
        public IWebElement Tabela2Cor => Global.Webdriver.FindElement(By.XPath("//*[@id='ac31147904']/div/div[3]/div[1]/a/ul/li[3]/p"));
        public IWebElement Tabela2Cambio => Global.Webdriver.FindElement(By.XPath("//*[@id='ac31147904']/div/div[3]/div[1]/a/ul/li[4]/p"));
        #endregion

        #region Elementos do Terceiro resultado de busca
        public IWebElement Tabela3Modelo => Global.Webdriver.FindElement(By.XPath("//*[@id='ac31150204']/div/a/h2"));
        public IWebElement Tabela3Preco => Global.Webdriver.FindElement(By.XPath("//*[@id='ac31150204']/div/a/h3"));
        public IWebElement Tabela3Ano => Global.Webdriver.FindElement(By.XPath("//*[@id='ac31150204']/div/div[2]/div[1]/a/ul/li[1]/p"));
        public IWebElement Tabela3KM => Global.Webdriver.FindElement(By.XPath("//*[@id='ac31150204']/div/div[2]/div[1]/a/ul/li[2]/p"));
        public IWebElement Tabela3Cor => Global.Webdriver.FindElement(By.XPath("//*[@id='ac31150204']/div/div[2]/div[1]/a/ul/li[3]/p"));
        public IWebElement Tabela3Cambio => Global.Webdriver.FindElement(By.XPath("//*[@id='ac31150204']/div/div[2]/div[1]/a/ul/li[4]/p"));

        #endregion

        public void ConsultarCarrosUsados(string marca, string modelo)
        {
            wait = new WebDriverWait(Global.Webdriver, new TimeSpan(0, 0, 100));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='buscaForm']/div[2]/div[1]/div/div/div/div")));
            CampoMarca.Click();
            CampoPesquisaDeMarca.SendKeys(marca + Keys.Enter);
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='buscaForm']/div[2]/div[2]/div/div/div/div/div/div/input")));
            CampoPesquisaDeModelo.SendKeys(modelo + Keys.Enter);
            CampoAnoMin.Click();
            PesquisaDeAnoMin.SendKeys("2001" + Keys.Enter);
            CampoAnoMax.Click();
            PesquisaAnoMax.SendKeys("2001" + Keys.Enter);
            CampoLocalizacao.Click();
            CheckboxMinhaCidade.Click();
            if (BotaoOk.Displayed)
            {
                BotaoOk.Click();
            }
            BotaoBuscar.Click();
        }
        public void ValidarPrecoEMarcaDosItensConsutados()
        {
            string valorAVista = Tabela1ValorAVista.Text;
            string modelotabela = Tabela1Modelo.Text;
            string modelo1Esperado = "Fiat Brava SX 1.6 16V";
            string preco1Esperado = "R$ 8.000,00\r\npreço à vista";
            Assert.Equal(modelo1Esperado, modelotabela);
            Assert.Equal(preco1Esperado, valorAVista);


            string valorAVista2 = Tabela2Preco.Text;
            string modelotabela2 = Tabela2Modelo.Text;
            string modelo2Esperado = "Fiat Brava SX 1.6 16V";
            string preco2Esperado = "R$ 11.900,00\r\npreço à vista";
            Assert.Equal(modelo2Esperado, modelotabela2);
            Assert.Equal(preco2Esperado, valorAVista2);

            string valorAVista3 = Tabela3Preco.Text;
            string modelotabela3 = Tabela3Modelo.Text;
            string modelo3Esperado = "Fiat Brava SX 1.6 16V";
            string preco3Esperado = "R$ 12.300,00\r\npreço à vista";
            Assert.Equal(modelo3Esperado, modelotabela3);
            Assert.Equal(preco3Esperado, valorAVista3);

        }
        public void GravarDadosEmUmaLista()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='ac31000680']/div/a/h3")));
            string valorAVista = Tabela1ValorAVista.Text;
            string modelotabela = Tabela1Modelo.Text;
            string anoTabela = Tabela1Ano.Text;
            string kmTabela = Tabela1KM.Text;
            string corTabela = Tabela1Cor.Text;
            string cambioTabela = Tabela1Cambio.Text;
            StreamWriter sr = new StreamWriter(@"C:\GIT\APQS\repostest\WebProject\primeiroitem.txt", true);
            sr.WriteLine(valorAVista);
            sr.WriteLine(modelotabela);
            sr.WriteLine(anoTabela);
            sr.WriteLine(kmTabela);
            sr.WriteLine(corTabela);
            sr.WriteLine(cambioTabela);
            sr.WriteLine(Keys.Enter);

            string valorAVista2 = Tabela2Preco.Text;
            string modelotabela2 = Tabela2Modelo.Text;
            string anoTabela2 = Tabela2Ano.Text;
            string kmTabela2 = Tabela2KM.Text;
            string corTabela2 = Tabela2Cor.Text;
            string cambioTabela2 = Tabela2Cambio.Text;
            sr.WriteLine(valorAVista2);
            sr.WriteLine(modelotabela2);
            sr.WriteLine(anoTabela2);
            sr.WriteLine(kmTabela2);
            sr.WriteLine(corTabela2);
            sr.WriteLine(cambioTabela2);


            string valorAVista3 = Tabela3Preco.Text;
            string modelotabela3 = Tabela3Modelo.Text;
            string anoTabela3 = Tabela3Ano.Text;
            string kmTabela3 = Tabela3KM.Text;
            string corTabela3 = Tabela3Cor.Text;
            string cambioTabela3 = Tabela3Cambio.Text;
            sr.WriteLine(valorAVista3);
            sr.WriteLine(modelotabela3);
            sr.WriteLine(anoTabela3);
            sr.WriteLine(kmTabela3);
            sr.WriteLine(corTabela3);
            sr.WriteLine(cambioTabela3);

            sr.Close();
        }
        public void LerEComprarDados(string marca, string modelo) 
        {
            BotaoVoltarParaTelaDeConsulta.Click();
            ConsultarCarrosUsados(marca, modelo);
            LerDadosDaListaEComparar();

        }
        public void LerDadosDaListaEComparar() 
        {
            
            StreamReader sl = new StreamReader(@"C:\GIT\APQS\repostest\WebProject\primeiroitem.txt");
            var testeana = sl.ReadToEnd().ToString();
            var precoAVista1 = testeana.Substring(0, 26);
            var modelo1 = testeana.Substring(28, 21);
            var ano1 = testeana.Substring(51,10);

            //Comprar dados do primeiro carro
            string valorAVistaOriginal = Tabela1ValorAVista.Text;
            string modelotabelaOriginal = Tabela1Modelo.Text;
            string anoTabelaOriginal = Tabela1Ano.Text;
            Assert.Equal(precoAVista1, valorAVistaOriginal);
            Assert.Equal(modelo1, modelotabelaOriginal);
            Assert.Equal(ano1, anoTabelaOriginal);



        }
    }
}
