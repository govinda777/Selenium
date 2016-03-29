using Facade.Selenium.Core;
using OpenQA.Selenium;
using Selenium.Core.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Core.Selenium
{
    public class Selenium<T> : ISelenium<T> where T : IWebDriver
    {
        public Element<T> Element { get; set; }

        public Navigation<T> Navigation { get; set; }
    }
}
