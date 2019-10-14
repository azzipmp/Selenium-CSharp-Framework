
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TREDS.Virginia.Gov.QA;
using System.Configuration;
using TREDS.Virginia.Gov.QA.Utility.Helper;
using TREDS.Virginia.Gov.QA.Utility.ExcelLib;
using System.Threading;
using OpenQA.Selenium;


namespace TREDS.Virginia.Gov.QA.TDD
{
    [TestClass]
    public class ProductionSmokeTest
    {

        #region Private Variables

        private static IWebDriver _driver;
            private static String _url;
            private static String _browser;
            private static String _excelpath;
            private static ExcelUtlity _excelUtility;
            private static String _sheetName = "UserRequest";
            private static String _resultpath;
            private static HTMLReport _report;
            private static string _ReportDateTime = System.DateTime.Now.ToString("yyyy-dd-MM.hh.mm");

        #endregion


       #region Test Init And Cleanup

       [ClassInitialize()]
        public static void TestInitialize(TestContext testContext)
        {

            _url = ConfigurationManager.AppSettings["URL"];
            _browser = ConfigurationManager.AppSettings["browser"];           
            Console.WriteLine("Application URL from Config file : " + _url);

            //  TEST DATA INITIALIZE
            _excelpath = System.IO.Path.GetFullPath("..\\..\\..\\TREDS.Virginia.Gov.QA.TDD\\TestData\\ProductionSmokeTest.xlsx");
            _excelUtility = new ExcelUtlity(_excelpath);

            // TEST RESULT INITIALIZE
            _resultpath = System.IO.Path.GetFullPath("..\\..\\..\\TREDS.Virginia.Gov.QA.TDD\\Results\\ProdSmokeTest_" + _ReportDateTime + ".html");      
            _report = new HTMLReport(_resultpath,"User Request Access Results" );
           _report.TestCaseName = "User Request Functionality";
           
           // INITILIZA THE BROWSER
           BrowserContainer.initBrowser(_browser);
           _driver = BrowserContainer.driver;
           BrowserContainer.loadApplication(_url);
           Controller.Login login = new Controller.Login(_driver, _report, _excelUtility);

           login.TredsLogin(1);
            
        }

        [ClassCleanup()]
        public static void TestCleanup()
        {
            
            BrowserContainer.closeAllBrowsers();
       
        }

        #endregion


        #region Test Methods

       

        //  THIS TEST IS TO CREATE USER REQUEST
        [TestMethod] 
        public void TredsLogin()
        {
            try
            {
                _report.TestCaseName = "TredsLogin";
         //       BrowserContainer.loadApplication(_url);
               Controller.Login login = new Controller.Login(_driver, _report, _excelUtility);

               login.TredsLogin(1);
               Thread.Sleep(5000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    
    
        #endregion     

    }
}


          