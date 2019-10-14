using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using TREDS.Virginia.Gov.QA.Utility;

namespace TREDS.Virginia.Gov.QA.Model
{
    public class Login
    {
        private IWebDriver _driver;
       private string SCRIPT_ENABLE_BORDER = "arguments[0].style.border='2px solid red'";
       private string SCRIPT_DISABLE_BORDER = "arguments[0].style.border='none'";

        public Login(IWebDriver Driver)
        {
            _driver = Driver;
            PageFactory.InitElements(_driver, this);
       
        }

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_BodyPlaceHolder_RightNavPlaceHolder_UcLoginModule1_TredsLogin_UserName")]
        [CacheLookup]
        private IWebElement txtUserName { get; set; }
        
        public string UserName
       {
           get
           {
               return txtUserName.Text;
           }
           set
           {
              // draw a border around the found element

           //    ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_ENABLE_BORDER, txtUserName);
               txtUserName.SendKeys(value);
          //     ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_DISABLE_BORDER, txtUserName);

               
           }
        }
       
        [FindsBy(How = How.Id, Using = "ctl00_ctl00_BodyPlaceHolder_RightNavPlaceHolder_UcLoginModule1_TredsLogin_Password")]
        private IWebElement txtPassword { get; set; }

        public string Password
        {
           get
           {
               return txtPassword.Text;
           }
           set
           {
               ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_ENABLE_BORDER, txtPassword);
               txtPassword.SendKeys(value);
               ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_DISABLE_BORDER, txtPassword);
           }
        }
        [FindsBy(How = How.Name, Using = "ctl00$ctl00$BodyPlaceHolder$RightNavPlaceHolder$UcLoginModule1$TredsLogin$LoginButton")]
        [CacheLookup]
        private IWebElement btnLogin { get; set; }

        public void Login_Click()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_ENABLE_BORDER, btnLogin);
            btnLogin.Click();
         //   ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_DISABLE_BORDER, btnLogin);
        }



        
    }
}
