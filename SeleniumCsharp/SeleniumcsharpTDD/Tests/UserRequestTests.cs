
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
    public class UserRequestTests
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
            _excelpath = System.IO.Path.GetFullPath("..\\..\\..\\TREDS.Virginia.Gov.QA.TDD\\TestData\\InputData.xlsx");
            _excelUtility = new ExcelUtlity(_excelpath);

            // TEST RESULT INITIALIZE
            _resultpath = System.IO.Path.GetFullPath("..\\..\\..\\TREDS.Virginia.Gov.QA.TDD\\Results\\UserRequestTest_" + _ReportDateTime + ".html");      
            _report = new HTMLReport(_resultpath,"User Request Access Results" );
           _report.TestCaseName = "User Request Functionality";
            BrowserContainer.initBrowser(_browser);
            BrowserContainer.loadApplication(_url);
            _driver = BrowserContainer.driver;          
            Controller.Login login = new Controller.Login(_driver, _report, _excelUtility);
          
            login.TredsLogin(1);
            
        }

        [ClassCleanup()]
        public static void TestCleanup()
        {
            
            BrowserContainer.closeAllBrowsers();
          //  System.Diagnostics.Process.Start(string.Format("C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe \"{0}\"", _resultpath));
        }

        #endregion


        #region Test Methods

        [TestInitialize]
        public void GoToHome()
        {
            Controller.Home homecontroller = new Controller.Home(_driver, _report);
            homecontroller.HomeTab_Click();
        }

        //  THIS TEST IS TO CREATE USER REQUEST
        [TestMethod] 
        public void CreateUserRequestTest()
        {
            try
            {
                _report.TestCaseName = "Create User Request Test";

                Controller.Home homecontroller = new Controller.Home(_driver, _report);
                homecontroller.ClickOnRequestUserAccess();
                Controller.CreateUserRequest createuserrequestcontroller = new Controller.CreateUserRequest(_driver, _excelUtility, _sheetName, _report);
                createuserrequestcontroller.CreateRequestUserAccess(1);
                createuserrequestcontroller.SubmitLater();
              //  homecontroller.ClickOnManageAccessRequests();
                Thread.Sleep(5000);
            }
            catch (Exception ex)
            {
               // throw ex;
            }
        }

        // THIS TEST IS TO VIEW AND VALDIATE REQUEST IN GRID AND ALSO CLICK THE REQUEST AND VALIDATE DATA IN VIEW SCREEN
     [TestMethod]
        public void ViewAndValidateUserRequestTest()
        {
            try
            {
                _report.TestCaseName = "Validate Data In Grid And View Screen Test";
                Controller.Home homecontroller = new Controller.Home(_driver, _report);
                homecontroller.ClickOnManageAccessRequests();
                Thread.Sleep(3000);
                Controller.ManagerAccessRequest ManagerUserRequestController = new Controller.ManagerAccessRequest(_driver, _excelUtility, _sheetName, _report);
                ManagerUserRequestController.ValidateAndClickViewInGrid(1);
                Thread.Sleep(5000);
                Controller.ViewUserRequest ViewUserRequestController = new Controller.ViewUserRequest(_driver, _excelUtility, _sheetName, _report);
                ViewUserRequestController.ValidateUserRequest(1);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
       
        //THIS TEST IS TO EDIT USER REQUEST AND VALIDATE IN VIEW GRID AND ALSO VIEW SCREEN
       [TestMethod]
       public void EditAndSubmitApprovalUserRequestTest()
       {
           try
           {
               _report.TestCaseName = "Edit Request And Validate Data In Grid And View Screen Test";
               Controller.Home homecontroller = new Controller.Home(_driver, _report);
               homecontroller.ClickOnManageAccessRequests();
               Thread.Sleep(3000);
               Controller.ManagerAccessRequest ManagerUserRequestController = new Controller.ManagerAccessRequest(_driver, _excelUtility, _sheetName, _report);
               ManagerUserRequestController.ValidateAndClickEditInGrid(1);
               Thread.Sleep(3000);
               Controller.EditUserRequest EditUserRequestController = new Controller.EditUserRequest(_driver, _excelUtility, _sheetName, _report);
               EditUserRequestController.UpdateUserRequest(2);
               ManagerUserRequestController.ValidateInGrid(2);
               ManagerUserRequestController.ValidateAndClickViewInGrid(2);

               Thread.Sleep(3000);
               Controller.ViewUserRequest ViewUserRequestController = new Controller.ViewUserRequest(_driver, _excelUtility, _sheetName, _report);
               ViewUserRequestController.SubmitForApproval();
               Thread.Sleep(3000);
           }
           catch (Exception ex)
           {
               // throw ex;
           }
       }


       [TestMethod]
       public void ValidateAndApproveRequest()
       {
           try
           {
               
               _report.TestCaseName = "Approve Request by Treds Admin Test";
               Controller.Home homecontroller = new Controller.Home(_driver, _report);
               homecontroller.Logout_Click();
               Controller.Login login = new Controller.Login(_driver, _report, _excelUtility);
               login.TredsLogin(2);
               Thread.Sleep(3000);
               homecontroller.ClickOnReviewAccessRequests();
               Thread.Sleep(2000);
               Controller.ReviewAccessRequest ReviewAccessRequestController = new Controller.ReviewAccessRequest(_driver, _excelUtility, _sheetName, _report);
               ReviewAccessRequestController.ValidateAndClickViewInGrid(2);
               Thread.Sleep(3000);
               Controller.ViewUserRequest ViewUserRequestController = new Controller.ViewUserRequest(_driver, _excelUtility, _sheetName, _report);
               ViewUserRequestController.ValidateUserRequest(2);
               ReviewAccessRequestController.ValidateAndClickApproveInGrid(2);

               Thread.Sleep(2000);
           }
           catch (Exception ex)
           {
               // throw ex;
           }
       }
        #endregion     

    }
}


          