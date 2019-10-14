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
    public class EditUserRequest
    {
        private Model.CreateUserRequest createuserrequestmodel;
    
        private IWebDriver _Driver;
        private ExcelUtlity _ExcelUtility;
        private string _SheetName;
        private HTMLReport _report;

        public EditUserRequest(IWebDriver Driver, ExcelUtlity ExcelUtility, string SheetName, HTMLReport Report)
        {
            _Driver = Driver;
            createuserrequestmodel = new Model.CreateUserRequest(_Driver);

            _ExcelUtility = ExcelUtility;
            _SheetName = SheetName;
            _report = Report;
        
        }       

        public void UpdateUserRequest(int iRownNum)
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

                
                createuserrequestmodel.FirstName = ExpFirstName;
                createuserrequestmodel.MiddleName = ExpMiddleName;
                createuserrequestmodel.LastName = ExpLastName;
                createuserrequestmodel.PhoneNumber = ExpPhoneNumber;
                //Email disabled for edit functionality
             //   createuserrequestmodel.Email = ExpEmail;
                
                //createuserrequestmodel.CIOTDataEntryUser_Click();
                createuserrequestmodel.PrimaryPermission = ExpPrimaryPermission;
                Thread.Sleep(2000);
                createuserrequestmodel.Save_Click();
                Thread.Sleep(3000);
                _report.WriteResult("Update the Create User Request Data", "Request should update", "Request Updated", "Pass", "");
            }
              

            catch (Exception ex)
            {
                _report.WriteResult("Validate values in View user request page", "Values should be match ", "All values are not matched", "Fail", ex.Message);

            }
        }
     
    }

}
