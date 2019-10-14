using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using  TREDS.Virginia.Gov.QA.Utility.Helper;

namespace TREDS.Virginia.Gov.QA.Model
{
   public class CreateUserRequest
    {
       private IWebDriver _driver;
       private string SCRIPT_ENABLE_BORDER = "arguments[0].style.border='2px solid red'";
       private string SCRIPT_DISABLE_BORDER = "arguments[0].style.border='none'";
       public CreateUserRequest(IWebDriver driver)
       {
           _driver = driver;
           PageFactory.InitElements(driver, this);
         
       }


       //[FindsBy(How = How.Id, Using = "FirstName")]
       //public IWebElement firstnamefield { get; set; }
       [FindsBy(How = How.Id, Using = "FirstName")]
       private IWebElement txtFirstName { get; set; }

       public string FirstName
       { 
           get
           {
               
               //    return "FirstName";
               ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_ENABLE_BORDER, txtFirstName);
               ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_DISABLE_BORDER, txtFirstName);
               return txtFirstName.GetAttribute("value");
                 
           }
           set
           {
               ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_ENABLE_BORDER, txtFirstName);
               txtFirstName.Clear();
               txtFirstName.SendKeys(value);
               ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_DISABLE_BORDER, txtFirstName);
              
           }
       }

      
       public void IsFirstNameVisible()
       {
           CommonFunctions.WaitForElementTobeVisible(_driver, "FirstName");
       }

       [FindsBy(How = How.Id, Using = "MiddleName")]
       private IWebElement txtMiddleName { get; set; }
       public string MiddleName
       {
           get
           {
               ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_ENABLE_BORDER, txtMiddleName);
               ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_DISABLE_BORDER, txtMiddleName);
               return txtMiddleName.GetAttribute("value");
           }
           set
           {
               
               ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_ENABLE_BORDER, txtMiddleName);
               txtMiddleName.Clear();
               txtMiddleName.SendKeys(value);
               ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_DISABLE_BORDER, txtMiddleName);
           }
       }


       [FindsBy(How = How.Id, Using = "LastName")]
       public IWebElement txtLastName { get; set; }

       public string LastName
       {
           get
           {
               ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_ENABLE_BORDER, txtLastName);
               ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_DISABLE_BORDER, txtLastName);
              
               return txtLastName.GetAttribute("value");
           }
           set
           {
               ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_ENABLE_BORDER, txtLastName);
               txtLastName.Clear();
               txtLastName.SendKeys(value);
               ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_DISABLE_BORDER, txtLastName);
             
           }
       }


       [FindsBy(How = How.Id, Using = "PhoneNumber")]
       public IWebElement txtPhoneNumber { get; set; }
       public string PhoneNumber
       {
           get
           {
               ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_ENABLE_BORDER, txtPhoneNumber);
               ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_DISABLE_BORDER, txtPhoneNumber);
               return txtPhoneNumber.GetAttribute("value"); ;
           }
           set
           {
               ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_ENABLE_BORDER, txtPhoneNumber);
               txtPhoneNumber.Clear();
               txtPhoneNumber.SendKeys(value);
               ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_DISABLE_BORDER, txtPhoneNumber);
             
               
           }
       }


       [FindsBy(How = How.Id, Using = "Email")]
       public IWebElement txtEmail { get; set; }

       public string Email
       {
           get
           {
               ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_ENABLE_BORDER, txtEmail);
               ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_DISABLE_BORDER, txtEmail);
               return txtEmail.GetAttribute("value"); ;
           }
           set
           {
              
               ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_ENABLE_BORDER, txtEmail);
               txtEmail.Clear();
               txtEmail.SendKeys(value);
               ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_DISABLE_BORDER, txtEmail);
             
               
           }
       }



       [FindsBy(How = How.XPath, Using = ".//*[@value='CIOT Data Entry Users']")]
       private IWebElement chkCIOTDataEntryUser { get; set; }

       public void CIOTDataEntryUser_Click()
       {

           ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_ENABLE_BORDER, chkCIOTDataEntryUser);
           chkCIOTDataEntryUser.Click();
           ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_DISABLE_BORDER, chkCIOTDataEntryUser);   
          
          
       }



       [FindsBy(How = How.XPath, Using = ".//*[@value='DUI Data Entry Users']")]
       private IWebElement chkDUIDataEntryUser { get; set; }

       public void DUIDataEntryUser_Click()
       {
           
           ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_ENABLE_BORDER, chkDUIDataEntryUser);
           chkDUIDataEntryUser.Click();
           ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_DISABLE_BORDER, chkDUIDataEntryUser);   
              
       }




       [FindsBy(How = How.XPath, Using = ".//*[@value='Law Enforcement Clerk']")]
       public IWebElement chkLawEnforcementClerk { get; set; }

       public void LawEnforcementClerk_Click()
       {
         
               chkLawEnforcementClerk.Click();
           
       }



       [FindsBy(How = How.XPath, Using = ".//*[@value='Search and Print Crash Reports']")]
       public IWebElement chkSearchandPrintCrashReport { get; set; }

       public void SearchandPrintCrashReport_Click()
       {

           chkSearchandPrintCrashReport.Click();
          
       }

       [FindsBy(How = How.XPath, Using = ".//*[@value='Submit and Approve Crash Reports']")]
       public IWebElement chkSubmitandApproveCrashReport { get; set; }

       public void SubmitandApproveCrashReport_Click()
       {

           chkSubmitandApproveCrashReport.Click();
          
       }




       [FindsBy(How = How.XPath, Using = ".//*[@value='Submit Crash Reports to Supervisor']")]
       public IWebElement chkSubmitCrashReportToSupervisor { get; set; }

       public void SubmitCrashReportToSupervisor_Click()
       {
          
          
               chkSubmitCrashReportToSupervisor.Click();
           
       }


       [FindsBy(How = How.Id, Using = "ddlPrimaryPermission")]
       private IWebElement ddlPrimaryPermission { get; set; }
       

       public string PrimaryPermission
       {
           get { return ddlPrimaryPermission.Text; }
           set {
               SelectElement pp = new SelectElement(ddlPrimaryPermission);
               pp.SelectByText(value);
           }
       }

       [FindsBy(How = How.Id, Using = "PrimaryPermission")]
       private IWebElement txtPrimaryPermission { get; set; }


       public string PrimaryPermissionText
       {
           get { return txtPrimaryPermission.GetAttribute("value");  }
           set
           {
             ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_ENABLE_BORDER, txtEmail);
             txtPrimaryPermission.Clear();
               txtPrimaryPermission.SendKeys(value);
               ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_DISABLE_BORDER, txtEmail);             
             
           }
       }


       [FindsBy(How = How.Id, Using = "Save")]
       private IWebElement btnSave { get; set; }

       public void Save_Click()
       {
        
         ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_ENABLE_BORDER, btnSave);
         btnSave.Click();
         ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_DISABLE_BORDER, btnSave); 
           
       }



       [FindsBy(How = How.Id, Using = "Cancel")]
       private IWebElement btnCancel { get; set; }

       public void Cancel_Click()
       {
         
               btnCancel.Click();
       }

       [FindsBy(How = How.Id, Using = "btnErrorYes")]
       private IWebElement btnSubmitNow { get; set; }

       public void SubmitNow_Click()
       {

           if (btnSubmitNow.Displayed)
           {
               ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_ENABLE_BORDER, btnSubmitNow);
               btnSubmitNow.Click();
               ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_DISABLE_BORDER, btnSubmitNow);
           }
          
       }

       [FindsBy(How = How.Id, Using = "btnErrorNo")]
       private IWebElement btnSubmitLater { get; set; }

       public void btnSubmitLater_Click()
       {

           if (btnSubmitLater.Displayed)
           {
               ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_ENABLE_BORDER, btnSubmitLater);
               btnSubmitLater.Click();
               ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_DISABLE_BORDER, btnSubmitLater);
           }
          
       }

       [FindsBy(How = How.Id, Using = "btnErrorOK")]
       private IWebElement btnErrorOK { get; set; }

       public void Ok_Click()
       {
           if (btnErrorOK.Displayed)
           {
               //  ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_ENABLE_BORDER, btnErrorOK);
               btnErrorOK.Click();
               // ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_DISABLE_BORDER, btnErrorOK); 
           }
               
       }


       [FindsBy(How = How.Id, Using = "ManageUserRequestResult_table")]
       private IWebElement tableManageUserRequestResult_table { get; set; }

       public string ManageUserRequestResult_table
       {
           get
           {

               return "ManageUserRequestResult_table";
              
           }
           set
           {  }
       }

     
       private IWebElement _viewUserRequest { get; set; }

       public string ViewUserRequest
       {
           get
           {
               //if (txtFirstName == null)
             //  return "FirstName";
               return "View";
               //else
               //    return txtFirstName.Text;
           }
           set
           {
              // ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_ENABLE_BORDER, txtFirstName);
               _viewUserRequest = _driver.FindElement(By.Id(value));
              // _viewUserRequest.Click();
             //  ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_DISABLE_BORDER, txtFirstName);

           }
       }

       public void ViewUserRequest_Click()
       {
           _viewUserRequest.Click();
       }
    }
}
