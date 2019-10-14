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
    public class CreateUserRequest
    {
        private Model.CreateUserRequest createuserrequestmodel;
        private Model.ManageAccessRequest managerUserRequestModel;
        private IWebDriver _Driver;
        private ExcelUtlity _ExcelUtility;
        private string _SheetName;
        private HTMLReport _report;
        public CreateUserRequest(IWebDriver Driver, ExcelUtlity ExcelUtility, string SheetName, HTMLReport Report)
        {
            _Driver = Driver;
            createuserrequestmodel = new Model.CreateUserRequest(_Driver);

            _ExcelUtility = ExcelUtility;
            _SheetName = SheetName;
            _report = Report;
        
        }
       

        public void CreateRequestUserAccess(int iRownNum)
        {
            try
           {
            Console.WriteLine("CreateUserRequest Controller-> Create User Request Method");
            Console.WriteLine("CreateUserRequest Controller-> Create User Request Method-> Connect EXCEL-> Get the value from EXCEL");
            Console.WriteLine("EXCEL Sheet Name :" + _SheetName);

            String FirstName = _ExcelUtility.getValue(_SheetName, "FirstName", iRownNum);
            String MiddleName = _ExcelUtility.getValue(_SheetName, "MiddleName", iRownNum);
            String LastName = _ExcelUtility.getValue(_SheetName, "LastName", iRownNum);
            String PhoneNumber = _ExcelUtility.getValue(_SheetName, "PhoneNumber", iRownNum);
            String Email = _ExcelUtility.getValue(_SheetName, "Email", iRownNum);
            String Permisions = _ExcelUtility.getValue(_SheetName, "Role", iRownNum);
            String PrimaryPermission = _ExcelUtility.getValue(_SheetName, "PrimaryPermission", iRownNum);
            Console.WriteLine("Print Excel Value :" + FirstName + "," + MiddleName + "," + LastName + "," + PhoneNumber + "," + Email + "," + ","+ Permisions+","+PrimaryPermission);

            string[] Role = Permisions.Split(',');


            createuserrequestmodel.FirstName = FirstName;
            createuserrequestmodel.MiddleName = MiddleName;
            createuserrequestmodel.LastName = LastName;
            createuserrequestmodel.PhoneNumber = PhoneNumber;
            createuserrequestmodel.Email = Email;

            foreach (string _role in Role)
            {
                if (_role == ApplicationRoleType.CIOTDataEntryUsers.GetDescription())
                {
                    createuserrequestmodel.CIOTDataEntryUser_Click();
                }
                else if (_role == ApplicationRoleType.DUIDataEntryUsers.GetDescription())
                {
                    createuserrequestmodel.DUIDataEntryUser_Click();
                 }
                else if (_role == ApplicationRoleType.SearchAndPrintCrashReports.GetDescription())
                {
                    createuserrequestmodel.SearchandPrintCrashReport_Click();
                }
                else if (_role == ApplicationRoleType.SubmitAndApproveCrashReports.GetDescription())
                {
                    createuserrequestmodel.SubmitandApproveCrashReport_Click();
                }
                else if (_role == ApplicationRoleType.SubmitCrashReportsToSupervisor.GetDescription())
                {
                    createuserrequestmodel.SubmitCrashReportToSupervisor_Click();
                }
                else if ( _role == ApplicationRoleType.LawEnforcementClerk.GetDescription())
                {
                    createuserrequestmodel.LawEnforcementClerk_Click();
                }

            }
            
              
            createuserrequestmodel.PrimaryPermission = PrimaryPermission;
            createuserrequestmodel.Save_Click();
            Thread.Sleep(3000);
            _report.WriteResult("Save Create User Request Data", "Request should create", "Request Created", "Pass", "");
           }
            catch (Exception ex)
            {
                _report.WriteResult("Populate data in Create user request form", "Create and Save teh user request ", "Failed in Create User request", "Fail", ex.Message);
                
            }
        }

        //public void ViewAndValidateCreateRequestUserAccess(int iRownNum)
        //{
        //    List<string> TableValues = new List<string>();

        //    try
        //    {
        //        Console.WriteLine("CreateUserRequest Controller-> ViewAndValidateCreateRequestUserAccess Method");
        //        Console.WriteLine("CreateUserRequest Controller-> ViewAndValidateCreateRequestUserAccess Method-> Connect EXCEL-> Get the value from EXCEL");
        //        Console.WriteLine("EXCEL Sheet Name :" + _SheetName);

        //        String sFirstName = _ExcelUtility.getValue(_SheetName, "FirstName", iRownNum);
        //        String sMiddleName = _ExcelUtility.getValue(_SheetName, "MiddleName", iRownNum);
        //        String sLastName = _ExcelUtility.getValue(_SheetName, "LastName", iRownNum);
        //        String sPhoneNumber = _ExcelUtility.getValue(_SheetName, "PhoneNumber", iRownNum);
        //        String sEmail = _ExcelUtility.getValue(_SheetName, "Email", iRownNum);
        //        String sPrimaryPermission = _ExcelUtility.getValue(_SheetName, "PrimaryPermission", iRownNum);
        //        Console.WriteLine("Print Excel Value :" + sFirstName + "," + sMiddleName + "," + sLastName + "," + sPhoneNumber + "," + sEmail + "," + sPrimaryPermission);
                

        //        //TableValues = CommonFunctions.GetTableData(_Driver, createuserrequestmodel.ManageUserRequestResult_table);
        //        List<Model.ManageAccessRequest> TableData = createuserrequestmodel.Get
        //        int GridRow = 1;

        //        //for (int Row = 0; Row <= TableValues.Count; Row=Row+8)
        //        //{
        //        //    Console.WriteLine("Table values: {0}",Row+1 );
        //        //    Console.WriteLine(TableValues[Row+1]);

        //        //      if (sEmail== TableValues[Row+4])
        //        //         {
        //        //     //  _report.WriteResult("Verify and Validate Record in Grid", "All values should match", "All values are matched", "Pass", "");
        //        //     //    _report.WriteResult("Verify and Validate Record in Grid", "Expected Values" + sFirstName + "," + sMiddleName + "," + sLastName + "," + sEmail + ","+sPhoneNumber + "," + sPrimaryPermission, "Actual Values:"+TableValues[Row+1]+","+TableValues[Row+2]+","+
        //        //  //      TableValues[Row+3]+","+TableValues[Row+4]+","+TableValues[Row+5]+","+TableValues[Row+7], "Pass", "");

        //        //       //  TableValues = CommonFunctions.GetIDPropertyFromTableByRow(_Driver, createuserrequestmodel.ManageUserRequestResult_table,);
        //        //         break;
        //        //    }
        //        //      GridRow = GridRow + 1;
        //        //}

        //        foreach (string tr in TableValues)
        //        {
        //            if (sEmail == tr[4])
        //            {
        //                //  _report.WriteResult("Verify and Validate Record in Grid", "All values should match", "All values are matched", "Pass", "");
        //                //    _report.WriteResult("Verify and Validate Record in Grid", "Expected Values" + sFirstName + "," + sMiddleName + "," + sLastName + "," + sEmail + ","+sPhoneNumber + "," + sPrimaryPermission, "Actual Values:"+TableValues[Row+1]+","+TableValues[Row+2]+","+
        //                //      TableValues[Row+3]+","+TableValues[Row+4]+","+TableValues[Row+5]+","+TableValues[Row+7], "Pass", "");

        //                //  TableValues = CommonFunctions.GetIDPropertyFromTableByRow(_Driver, createuserrequestmodel.ManageUserRequestResult_table,);
        //                break;
        //            }
        //            GridRow = GridRow + 1;
        //        }

        //        Console.WriteLine("Grid Value:" + GridRow);

        //        List<string> value = new List<string>();
        //        value = CommonFunctions.GetIDPropertyFromTableByRow(_Driver, createuserrequestmodel.ManageUserRequestResult_table, GridRow);
        //        Console.WriteLine(value.Count);
        //        Console.WriteLine(value[0]);
        //        string id = value[0].Replace("row", "View");


        //        Console.WriteLine(id);//View79
        //     //   _Driver.FindElement(By.Id(id)).Click();
        //        createuserrequestmodel.ViewUserRequest = id;
        //        createuserrequestmodel.ViewUserRequest_Click();

        //        /*
         
        //      List<string> value = new List<string>();
             
        //      value = CommonFunctions.GetIDPropertyFromTableByRow(_Driver, createuserrequestmodel.ManageUserRequestResult_table, 1);
        //       Console.WriteLine(value.Count);
        //       Console.WriteLine(value[0]);
        //       value = CommonFunctions.GetIDPropertyFromTableByRow(_Driver, createuserrequestmodel.ManageUserRequestResult_table, 2);
        //         Console.WriteLine(value.Count);
        //       Console.WriteLine(value[0]);
        //       value = CommonFunctions.GetIDPropertyFromTableByRow(_Driver, createuserrequestmodel.ManageUserRequestResult_table, 3);
        //       Console.WriteLine(value.Count);
        //       Console.WriteLine(value[0]);
        //      //  Console.WriteLine(value[1]);
        //       */
        //    }
        //    catch (Exception ex)
        //    {
        //        _report.WriteResult("Populate data in Create user request form", "Create and Save teh user request ", "Failed in Create User request", "Fail", ex.Message);

        //    }
        //}

        public void SubmitNow()
        {
            try
            {
                createuserrequestmodel.SubmitNow_Click();
                Thread.Sleep(1000);
                createuserrequestmodel.Ok_Click();
                Thread.Sleep(2000);
                _report.WriteResult("Click on Submit Now Request", "Request submitt for approval", "Request submitted for approval", "Pass", "");
            }
            catch (Exception ex)
            {
                _report.WriteResult("Click on Submit Now button", "Request submitte for approval", "Failed in submit request for approval", "Fail", ex.Message);
            }
        }

        public void SubmitLater()
        {
            try
            {
                createuserrequestmodel.btnSubmitLater_Click();
                Thread.Sleep(1000);
                createuserrequestmodel.Ok_Click();
                Thread.Sleep(2000);
                _report.WriteResult("Click on Submit Later Request", "Request created to submit later", "Request created to submit later", "Pass", "");
            }
            catch (Exception ex)
            {
                _report.WriteResult("Click on Submit Later button", "Request submitte for approval", "Failed in submit request for approval", "Fail", ex.Message);
            }
        }
       
    
    
    }

}
