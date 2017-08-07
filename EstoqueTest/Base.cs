using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace EstoqueTest
{
    public class Base
    {
        protected ChromeDriver driver;

        public Base()
        {
            driver = new ChromeDriver();
        }

        [SetUp]
        public void Initialize()
        {
            driver.Navigate().GoToUrl("http://localhost:51154/");

            Console.WriteLine("Opened URL");
        }

        [TearDown]
        public void CleanUp()
        {
            Thread.Sleep(1000);
            driver.Close();

            Console.WriteLine("Closed");
        }
    }
}
