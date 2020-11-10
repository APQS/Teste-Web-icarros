using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebProject
{
    public class Global
    {
        public static IWebDriver Webdriver;
        public static IConfiguration configuration;
        public static string Url = "https://www.icarros.com.br/principal/index.jsp";
        public static string CaminhoDriverChrome;
        public WebDriverWait wait;
        public static string CaminhoDriverSafari;
        public static string PastaProjeto;

        public void SelecionarNavegador(Browser browser)
        {
            string caminhoDriver = null; 

            if (browser == Browser.Chrome)
            {
                caminhoDriver = CaminhoDriverChrome;
            }

            Webdriver = CreateWebDriver(browser, caminhoDriver, false);

        }

        public static IWebDriver CreateWebDriver(Browser browser, string pathDriver, bool headless)
        {
            IWebDriver webDriver = null;

            switch (browser)
            {
                case Browser.Chrome:
                    ChromeOptions optionsChr = new ChromeOptions();
                    if (headless)
                        optionsChr.AddArgument("--headless");
                    pathDriver = @"C:\GIT\APQS\repostest\WebProject\WebProject\PageObject_Navegadores\Drivers";
                    webDriver = new ChromeDriver(pathDriver, optionsChr);

                    break;
            }

            return webDriver;
        }

        public enum Browser
        {
            Chrome,
            Firefox,
            Opera,
            Safari,
            Edge,
            IE
        }

        public void AbrirNavegador()
        {
            Global.Webdriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            Global.Webdriver.Manage().Window.Maximize();
            Global.Webdriver.Navigate().GoToUrl(Global.Url);
        }

    }
}
