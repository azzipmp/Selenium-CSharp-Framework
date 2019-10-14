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
    public class ManagerAccessRequest
    {
        private Model.ManageAccessRequest managerUserRequestModel;
        private IWebDriver _Driver;
        private ExcelUtlity _ExcelUtility;
        private string _SheetName;
        private HTMLReport _report;

        public ManagerAccessRequest(IWebDriver Driver, ExcelUtlity ExcelUtility, string SheetName, HTMLReport Report)
        {
            _Driver = Driver;
            managerUserRequestModel = new Model.ManageAccessRequest(_Driver);
            _ExcelUtility = ExcelUtility;
            _SheetName = SheetName;
            _report = Report;
        
        }

        public void ValidateAndClickViewInGrid(int iRownNum)
        {
            List<string> TableValues = new List<string>();

            try
            {
                Console.WriteLine("CreateUserRequest Controller-> ViewAndValidateCreateRequestUserAccess Method");
                Console.WriteLine("CreateUserRequest Controller-> ViewAndValidateCreateRequestUserAccess Method-> Connect EXCEL-> Get the value from EXCEL");
                Console.WriteLine("EXCEL Sheet Name :" + _SheetName);

                String sFirstName = _ExcelUtility.getValue(_SheetName, "FirstName", iRownNum);
                String sMiddleName = _ExcelUtility.getValue(_SheetName, "MiddleName", iRownNum);
                String sLastName = _ExcelUtility.getValue(_SheetName, "LastName", iRownNum);
                String sPhoneNumber = _ExcelUtility.getValue(_SheetName, "PhoneNumber", iRownNum);
                String sEmail = _ExcelUtility.getValue(_SheetName, "Email", iRownNum);
                String sPrimaryPermission = _ExcelUtility.getValue(_SheetName, "PrimaryPermission", iRownNum);
                Console.WriteLine("Print Excel Value :" + sFirstName + "," + sMiddleName + "," + sLastName + "," + sPhoneNumber + "," + sEmail + "," + sPrimaryPermission);
                

                //TableValues = CommonFunctions.GetTableData(_Driver, createuserrequestmodel.ManageUserRequestResult_table);
                List<Model.ManageAccessRequest> TableData = managerUserRequestModel.GetTableData();

              
                
                foreach (Model.ManageAccessRequest ur in TableData)
                {
                    if (sEmail == ur.Email)
                    {
                        string id = ur.Id.Replace("row", "View");
                        managerUserRequestModel.View = id;
                        managerUserRequestModel.View_Click();
                        break;
                    }
                }

               

            }
            catch (Exception ex)
            {
                _report.WriteResult("Validate data in Manage Request Grid", "Data should match ", "Failed in Data match", "Fail", ex.Message);

            }
        }


        public void ValidateAndClickEditInGrid(int iRownNum)
        {
            List<string> TableValues = new List<string>();

            try
            {
                Console.WriteLine("CreateUserRequest Controller-> ViewAndValidateCreateRequestUserAccess Method");
                Console.WriteLine("CreateUserRequest Controller-> ViewAndValidateCreateRequestUserAccess Method-> Connect EXCEL-> Get the value from EXCEL");
                Console.WriteLine("EXCEL Sheet Name :" + _SheetName);

                String sFirstName = _ExcelUtility.getValue(_SheetName, "FirstName", iRownNum);
                String sMiddleName = _ExcelUtility.getValue(_SheetName, "MiddleName", iRownNum);
                String sLastName = _ExcelUtility.getValue(_SheetName, "LastName", iRownNum);
                String sPhoneNumber = _ExcelUtility.getValue(_SheetName, "PhoneNumber", iRownNum);
                String sEmail = _ExcelUtility.getValue(_SheetName, "Email", iRownNum);
                String sPrimaryPermission = _ExcelUtility.getValue(_SheetName, "PrimaryPermission", iRownNum);
                Console.WriteLine("Print Excel Value :" + sFirstName + "," + sMiddleName + "," + sLastName + "," + sPhoneNumber + "," + sEmail + "," + sPrimaryPermission);


                //TableValues = CommonFunctions.GetTableData(_Driver, createuserrequestmodel.ManageUserRequestResult_table);
                List<Model.ManageAccessRequest> TableData = managerUserRequestModel.GetTableData();


                foreach (Model.ManageAccessRequest ur in TableData)
                {
                    
                         if (sEmail == ur.Email)
                    
                    {
                        string id = ur.Id.Replace("row", "Edit");
                        managerUserRequestModel.Edit = id;
                        managerUserRequestModel.Edit_Click();
                        break;
                    }
                }



            }
            catch (Exception ex)
            {
                _report.WriteResult("Validate data in Manage Request Grid", "Data should match ", "Failed in Data match", "Fail", ex.Message);

            }
        }


        public void ValidateInGrid(int iRownNum)
        {
            List<string> TableValues = new List<string>();

            try
            {
                Console.WriteLine("CreateUserRequest Controller-> ValidateInGrid Method");
                Console.WriteLine("CreateUserRequest Controller-> ValidateInGrid Method-> Connect EXCEL-> Get the value from EXCEL");
                Console.WriteLine("EXCEL Sheet Name :" + _SheetName);

                String sFirstName = _ExcelUtility.getValue(_SheetName, "FirstName", iRownNum);
                String sMiddleName = _ExcelUtility.getValue(_SheetName, "MiddleName", iRownNum);
                String sLastName = _ExcelUtility.getValue(_SheetName, "LastName", iRownNum);
                String sPhoneNumber = _ExcelUtility.getValue(_SheetName, "PhoneNumber", iRownNum);
                String sEmail = _ExcelUtility.getValue(_SheetName, "Email", iRownNum);
                String sPrimaryPermission = _ExcelUtility.getValue(_SheetName, "PrimaryPermission", iRownNum);
                Console.WriteLine("Print Excel Value :" + sFirstName + "," + sMiddleName + "," + sLastName + "," + sPhoneNumber + "," + sEmail + "," + sPrimaryPermission);


                //TableValues = CommonFunctions.GetTableData(_Driver, createuserrequestmodel.ManageUserRequestResult_table);
                List<Model.ManageAccessRequest> TableData = managerUserRequestModel.GetTableData();


                foreach (Model.ManageAccessRequest ur in TableData)
                {
                    if ((sEmail == ur.Email) && (sFirstName == ur.FirstName) && (sMiddleName == ur.MiddleName) && (sLastName == ur.LastName)  && (sPhoneNumber == ur.PhoneNumber))
                    {
                       // string id = ur.Id.Replace("row", "Edit");
                       // managerUserRequestModel.Edit = id;
                       // managerUserRequestModel.Edit_Click();
                       // break;
                        _report.WriteResult("Validate data in Manage Acess Request Grid", "Values should match ", "Values Matched", "Pass","");

                    }
                }



            }
            catch (Exception ex)
            {
                _report.WriteResult("Validate data in Manage Request Grid", "Data should match ", "Failed in Data match", "Fail", ex.Message);

            }
        }
    
    }

}
