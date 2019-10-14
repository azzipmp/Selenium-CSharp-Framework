using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using TREDS.Virginia.Gov.QA.Utility.Helper;

namespace TREDS.Virginia.Gov.QA.Model
{
    public class Home
    {

        private string SCRIPT_ENABLE_BORDER = "arguments[0].style.border='2px solid red'";
        private string SCRIPT_DISABLE_BORDER = "arguments[0].style.border='none'";
        private IWebDriver _driver;
       
     private String _Title = "TREDS - Home";
     // private String _Title = "abcd";

        public Home(IWebDriver driver)
        {
            _driver = driver;
           PageFactory.InitElements(driver, this);
            
        }

        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                _Title = value;
            }
        }

        [FindsBy(How = How.LinkText, Using = "Request User Access")]
        private IWebElement lnkRequestUserAccess { get; set; }

        public void RequestUserAccess_Click()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_ENABLE_BORDER, lnkRequestUserAccess);
            lnkRequestUserAccess.Click();
        }

        [FindsBy(How = How.LinkText, Using = "Manage Access Requests")]
        private IWebElement lnkManageAccessRequests { get; set; }

        
        public void ManageAccessRequests_Click()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_ENABLE_BORDER, lnkManageAccessRequests);
            lnkManageAccessRequests.Click();
            
        }

        [FindsBy(How = How.LinkText, Using = "Review Access Requests")]
        private IWebElement lnkReviewAccessRequests { get; set; }

        public void ReviewAccessRequests_Click()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_ENABLE_BORDER, lnkReviewAccessRequests);
            lnkReviewAccessRequests.Click();
        }
        public bool IsHomePageLoaded()
        {
            
            try
            {
                CommonFunctions.WaitForPageLoad(_driver, _Title);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_TopMenuPlaceHolder_TopMenuPlaceHolder_ucTopMenuModule_liHome")]
        private IWebElement _homeTab { get; set; }

        public void HomeTab_Click()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_ENABLE_BORDER, _homeTab);
            _homeTab.Click();

        }

        [FindsBy(How = How.LinkText, Using = "Logout")]
        private IWebElement lnkLogout { get; set; }


        public void Logout_Click()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_ENABLE_BORDER, lnkLogout);
            lnkLogout.Click();

        }
    
    }
     
  
}
