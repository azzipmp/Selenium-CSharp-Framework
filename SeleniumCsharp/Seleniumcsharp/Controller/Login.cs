using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using System.Threading;
using TREDS.Virginia.Gov.QA.Utility.ExcelLib;
using TREDS.Virginia.Gov.QA.Utility.Helper;

namespace TREDS.Virginia.Gov.QA.Controller
{
   public class Login
    {
       private Model.Login _loginmodel;
       private IWebDriver _driver;
       private Model.Home _homemodel;
       private HTMLReport _report;
       private ExcelUtlity _excelUtility;

       public Login(IWebDriver Driver,HTMLReport Report, ExcelUtlity ExcelObject)
       {

           _driver = Driver;
           _loginmodel = new Model.Login(_driver);
           
          _report = Report;
           _excelUtility = ExcelObject;
       
           
        }
          
       

       //public void TredsLogin(String UserName, String Password)
       public void TredsLogin(int iRowNum)
       {
           Console.WriteLine("Login Controller page -> TredsLogin Method");
           Console.WriteLine("irow number" + iRowNum);
      //     
           _loginmodel.UserName = _excelUtility.getValue("Login", "UserName", iRowNum);
           Console.WriteLine(_loginmodel.UserName);
            _loginmodel.Password = _excelUtility.getValue("Login", "Password", iRowNum);        
           _loginmodel.Login_Click();
           Thread.Sleep(3000);
           _homemodel = new Model.Home(_driver);
           try
           {
               if (_homemodel.IsHomePageLoaded())
               {
                   _report.WriteResult("Login to Treds", "Display home page", "Displayed Home page", "Pass", "");
               }
               else
               {
                   _report.WriteResult("Login to Treds", "Display home page", "Faile to Login", "Fail", "");
               }
           }
           catch (Exception ex)
           {
               _report.WriteResult("Login to Treds", "Display home page", "Faile to Login", "Fail", ex.Message);
           }
            
       
       }

      
    }
}
