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
    public class ReviewAccessRequest
    {
        private Model.ReviewAccessRequest reviewaccessRequestModel;
        private IWebDriver _Driver;
        private ExcelUtlity _ExcelUtility;
        private string _SheetName;
        private HTMLReport _report;

        public ReviewAccessRequest(IWebDriver Driver, ExcelUtlity ExcelUtility, string SheetName, HTMLReport Report)
        {
            _Driver = Driver;
            reviewaccessRequestModel = new Model.ReviewAccessRequest(_Driver);
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
               // String sPhoneNumber = _ExcelUtility.getValue(_SheetName, "PhoneNumber", iRownNum);
                //String sEmail = _ExcelUtility.getValue(_SheetName, "Email", iRownNum);
               // String sPrimaryPermission = _ExcelUtility.getValue(_SheetName, "PrimaryPermission", iRownNum);
                Console.WriteLine("Print Excel Value :" + sFirstName + "," + sMiddleName + "," + sLastName );
                

                //TableValues = CommonFunctions.GetTableData(_Driver, createuserrequestmodel.ManageUserRequestResult_table);

                List<Model.ReviewAccessRequest> TableData = reviewaccessRequestModel.GetTableData();


                foreach (Model.ReviewAccessRequest ur in TableData)
                {
                    if ((sFirstName == ur.FirstName) && (sLastName == ur.LastName)  && (sMiddleName == ur.MiddleName ))
                    {
                        string id = ur.Id.Replace("row", "View");
                        reviewaccessRequestModel.View = id;
                        reviewaccessRequestModel.View_Click();
                        break;
                    }
                }

              

            }
            catch (Exception ex)
            {
                _report.WriteResult("Validate data in Review Access Request Grid", "Data should match ", "Failed in Data match", "Fail", ex.Message);

            }
        }


        public void ValidateAndClickApproveInGrid(int iRownNum)
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
              //  String sPhoneNumber = _ExcelUtility.getValue(_SheetName, "PhoneNumber", iRownNum);
             //   String sEmail = _ExcelUtility.getValue(_SheetName, "Email", iRownNum);
             //   String sPrimaryPermission = _ExcelUtility.getValue(_SheetName, "PrimaryPermission", iRownNum);
                Console.WriteLine("Print Excel Value :" + sFirstName + "," + sMiddleName + "," + sLastName );

                List<Model.ReviewAccessRequest> TableData = reviewaccessRequestModel.GetTableData();


                foreach (Model.ReviewAccessRequest ur in TableData)
                {
                    if (sFirstName == ur.FirstName & sLastName == ur.LastName & sMiddleName == ur.MiddleName)
                    {
                        string id = ur.Id.Replace("row", "Edit");
                        reviewaccessRequestModel.Approve = id;
                        reviewaccessRequestModel.Approve_Click();
                        Thread.Sleep(1000);
                        reviewaccessRequestModel.Yes_Click();
                        Thread.Sleep(1000);
                        _report.WriteResult("Approve Request in Review Access Requests screen", "Aprove the request ", "Approved the request", "Pass", "");
                        break;
                    }
                }


            }
            catch (Exception ex)
            {
                _report.WriteResult("Approve Request in Review Access Requests screen", "Aprove the request ", "Unable approve the request", "Fail", ex.Message);

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

/*
                //TableValues = CommonFunctions.GetTableData(_Driver, createuserrequestmodel.ManageUserRequestResult_table);
                List<Model.ManageAccessRequest> TableData = managerUserRequestModel.GetTableData();


                foreach (Model.ManageAccessRequest ur in TableData)
                {
                    if (sEmail == ur.Email)
                    {
                       // string id = ur.Id.Replace("row", "Edit");
                       // managerUserRequestModel.Edit = id;
                       // managerUserRequestModel.Edit_Click();
                       // break;
                    }
                }

*/

            }
            catch (Exception ex)
            {
                _report.WriteResult("Validate data in Manage Request Grid", "Data should match ", "Failed in Data match", "Fail", ex.Message);

            }
        }

         
    }


}
