using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;


namespace EstoqueTest
{
    public class Add: Base
    {
        [Test]
        public void ExecuteTest()
        {
            driver.FindElementByName("nome").SendKeys("Bala");

            driver.FindElementByName("quantidade").SendKeys("123");

            driver.FindElementByName("preco").SendKeys("32");

            driver.FindElementByName("fornecedor").SendKeys("Luiz");
           
            driver.FindElementByClassName("btn-primary").Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(x => x.SwitchTo().Alert());

            driver.SwitchTo().Alert().Accept();

            Console.WriteLine("Executed Test");
        }

    }
}
