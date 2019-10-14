using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using System.Threading;
using TREDS.Virginia.Gov.QA.Utility.Helper;

namespace TREDS.Virginia.Gov.QA.Controller
{
   public class Home
    {
       private Model.Home _homemodel;
       private HTMLReport _report;
       private Model.CreateUserRequest _createuserrequestmodel;
        private IWebDriver _driver;
       public Home(IWebDriver driver,HTMLReport Report)
       {
           _driver = driver;
           _homemodel = new Model.Home(_driver);
           _report = Report;
        
       }



       public void ClickOnRequestUserAccess()
       {
          
           Console.WriteLine("Home Contoller page -> clickOnRequestUserAccess Method");
           _homemodel.RequestUserAccess_Click();
           // Thread.Sleep(2000);
           _createuserrequestmodel = new Model.CreateUserRequest(_driver);
           _createuserrequestmodel.IsFirstNameVisible();
           _report.WriteResult("Click on Request User aceess", "Navigate to Create User request Page", "Displayed Create User request Page", "Pass", "");
       }

       public void ClickOnManageAccessRequests()
       {
         
           Console.WriteLine("Home Contoller page -> clickOnManageAccessRequests Method");
           _homemodel.ManageAccessRequests_Click();
           Thread.Sleep(2000);

       }

       public void ClickOnReviewAccessRequests()
       {

           Console.WriteLine("Home Contoller page -> ClickOnReviewAccessRequests Method");
           _homemodel.ReviewAccessRequests_Click();
           Thread.Sleep(2000);

       }

       public void HomeTab_Click()
       {
           _homemodel.HomeTab_Click();
       }
        
       public void Logout_Click()
       {
           _homemodel.Logout_Click();
       }

    }
}
