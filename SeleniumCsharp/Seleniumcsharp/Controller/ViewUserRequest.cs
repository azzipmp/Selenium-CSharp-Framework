using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using TREDS.Virginia.Gov.QA.Utility.ExcelLib;
using TREDS.Virginia.Gov.QA.Utility.Helper;

namespace TREDS.Virginia.Gov.QA.Controller
{
    public class ViewUserRequest
    {
      //  private Model.CreateUserRequest createuserrequestmodel;
        private Model.ViewUserRequest viewuserrequestmodel;
        private IWebDriver _Driver;
        private ExcelUtlity _ExcelUtility;
        private string _SheetName;
        private HTMLReport _report;

        public ViewUserRequest(IWebDriver Driver, ExcelUtlity ExcelUtility, string SheetName, HTMLReport Report)
        {
            _Driver = Driver;
         //   createuserrequestmodel = new Model.CreateUserRequest(_Driver);
            viewuserrequestmodel = new Model.ViewUserRequest(_Driver);
            _ExcelUtility = ExcelUtility;
            _SheetName = SheetName;
            _report = Report;
        
        }

        public void SubmitForApproval()
        {
            viewuserrequestmodel.SubmitForApproval_Click();
            viewuserrequestmodel.SubmitForApprovalYes_Click();
            Thread.Sleep(2000);
        }

        public void ValidateUserRequest(int iRownNum)
        {
            List<string> TableValues = new List<string>();

            try
            {
                Console.WriteLine("ViewUserRequest Controller-> ValidateUserRequest Method");
                Console.WriteLine("ViewUserRequest Controller-> ValidateUserRequest Method-> Connect EXCEL-> Get the value from EXCEL");
                Console.WriteLine("EXCEL Sheet Name :" + _SheetName);

                String ExpFirstName = _ExcelUtility.getValue(_SheetName, "FirstName", iRownNum);
                String ExpMiddleName = _ExcelUtility.getValue(_SheetName, "MiddleName", iRownNum);
                String ExpLastName = _ExcelUtility.getValue(_SheetName, "LastName", iRownNum);
                String ExpPhoneNumber = _ExcelUtility.getValue(_SheetName, "PhoneNumber", iRownNum);
                String ExpEmail = _ExcelUtility.getValue(_SheetName, "Email", iRownNum);
                String ExpPrimaryPermission = _ExcelUtility.getValue(_SheetName, "PrimaryPermission", iRownNum);
                Console.WriteLine("Print Excel Value :" + ExpFirstName + "," + ExpMiddleName + "," + ExpLastName + "," + ExpPhoneNumber + "," + ExpEmail + "," + ExpPrimaryPermission);

                String ActFirstName = viewuserrequestmodel.FirstName;
                String ActMiddleName = viewuserrequestmodel.MiddleName;
                String ActLastName = viewuserrequestmodel.LastName;
                String ActPhoneNumber = viewuserrequestmodel.PhoneNumber;
                String ActEmail = viewuserrequestmodel.Email;
                String ActPrimaryPermission = viewuserrequestmodel.PrimaryPermissionText;

                if ((ExpFirstName == ActFirstName) && (ExpMiddleName == ActMiddleName) && (ExpLastName == ActLastName)
                    && (ExpPhoneNumber == ActPhoneNumber) && (ExpEmail == ActEmail) && (ExpPrimaryPermission == ActPrimaryPermission))
                {
                    _report.WriteResult("Validate values in View user request page", "Values should be match ", "All values are matched", "Pass", "");

                }
                else
                {
                    _report.WriteResult("Validate values in View user request page", "Values should be match ", "All values are not matched", "Fail", "");
                 //   _report.WriteResult("Validate values in View user request page", "Expected values:  " + ExpFirstName + ", " + ExpMiddleName + " ," + ExpLastName
                    //    + " ," + ActPhoneNumber + " ," + ActEmail + " ," + ActPrimaryPermission, "All values are not matched:" + ActFirstName
                    //    + " ," + ActMiddleName + " ," + ActLastName + " ," + ActPhoneNumber + " ," + ActEmail + " ," + ActPrimaryPermission, "Fail", "");
                }
                viewuserrequestmodel.Cancel_Click();

                  }
            catch (Exception ex)
            {
                _report.WriteResult("Validate values in View user request page", "Values should be match ", "All values are not matched", "Fail", ex.Message);

            }
        }
     
    }

}
