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
    public class ManageAccessRequest
    {
        private IWebDriver _driver;
        private string SCRIPT_ENABLE_BORDER = "arguments[0].style.border='2px solid red'";
        private string SCRIPT_DISABLE_BORDER = "arguments[0].style.border='none'";

        public ManageAccessRequest()
        {
        }

        public ManageAccessRequest(IWebDriver Driver)
        {
            _driver = Driver;
            PageFactory.InitElements(_driver, this);
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
            { }
        }

        private IWebElement _view { get; set; }
        public string View
        {
           get
           {
               return "View";
           }
           set
           {
               _view = _driver.FindElement(By.Id(value));
           }
        }

        public void View_Click()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_ENABLE_BORDER, _view);
            _view.Click();
            ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_DISABLE_BORDER, _view);

        }

        private IWebElement _edit { get; set; }

        public string Edit
        {
            get
            {
                return "Edit";
            }
            set
            {
                _edit = _driver.FindElement(By.Id(value));
            }
        }

        public void Edit_Click()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_ENABLE_BORDER, _edit);
            _edit.Click();
            ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_DISABLE_BORDER, _edit);

        }


        private IWebElement _delete { get; set; }

        public string Delete
        {
            get
            {
                return "Delete";
            }
            set
            {
                _delete = _driver.FindElement(By.Id(value));
            }
        }

        public void Delete_Click()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_ENABLE_BORDER, _delete);
            _delete.Click();
            ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_DISABLE_BORDER, _delete);
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public  List<ManageAccessRequest> GetTableData()
        {
            IWebElement TableElement = _driver.FindElement(By.Id(ManageUserRequestResult_table));
            IList<IWebElement> TableRow = TableElement.FindElements(By.TagName("tr"));
            IList<IWebElement> RowTD;
            List<ManageAccessRequest> ArrTableValues = new List<ManageAccessRequest>();
            ManageAccessRequest ur;

            foreach (IWebElement Row in TableRow)
            {
                ur = new ManageAccessRequest();
                RowTD = Row.FindElements(By.TagName("td"));
                ur.Id = Row.GetAttribute("id");
                ur.FirstName = RowTD[1].Text;
                ur.MiddleName = RowTD[2].Text;
                ur.LastName = RowTD[3].Text;
                ur.Email = RowTD[4].Text;
                ur.PhoneNumber = RowTD[5].Text;
                ArrTableValues.Add(ur);
            }

            return ArrTableValues;
        }
        
    }
}
