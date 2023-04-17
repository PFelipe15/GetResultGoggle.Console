using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace GoogleSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configurando o Browser
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-gpu", "--headless");
            IWebDriver driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("https://www.google.com");


            // Procura o campo de colocar o texto ai faz a pesquisa
            IWebElement searchBox = driver.FindElement(By.Name("q"));

            Console.WriteLine("Digite o termo a ser Pesquisado:");
            string search = Console.ReadLine();
            searchBox.SendKeys(search);
            searchBox.Submit();

            //Aqui espera a pagina carregar pra só ai requisitar os elementos html
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5); 

            //Aqui ele recebe um array de todos os titulos, anexa numa variavel da instancia
            List<IWebElement> Titles = driver.FindElements(By.ClassName("MBeuO")).ToList();
            //for para listar apenas duas
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine(Titles[i].Text);
            }       
            driver.Quit();
            Console.ReadKey();
        }
    }
}
