using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace TREDS.Virginia.Gov.QA.Utility.Helper
{

    public class TREDSWebElementExtensions
    {
        private string SCRIPT_ENABLE_BORDER = "arguments[0].style.border='2px solid red'";
        private string SCRIPT_DISABLE_BORDER = "arguments[0].style.border='none'";
        private ChromeDriver _driver;
        private string _elementid;

        //public TREDSWebElement(ChromeDriver parentDriver, string id) : base(parentDriver, id)
        //{
        //    _driver = parentDriver;
        //    _elementid = id;
        //}

        //public new void SendKeys(string text) 
        //{
        //    ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_ENABLE_BORDER, this);
        //    base.SendKeys(text);
        //    ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_DISABLE_BORDER, this);
        //}

        //public static IWebElement Test(this IWebElement element)
        //{
 
        //}
    }
}
