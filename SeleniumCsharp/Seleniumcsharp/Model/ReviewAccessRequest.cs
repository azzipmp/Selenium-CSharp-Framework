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
    public class ReviewAccessRequest
    {
        private IWebDriver _driver;
        private string SCRIPT_ENABLE_BORDER = "arguments[0].style.border='2px solid red'";
        private string SCRIPT_DISABLE_BORDER = "arguments[0].style.border='none'";

        public ReviewAccessRequest()
        {
        }

        public ReviewAccessRequest(IWebDriver Driver)
        {
            _driver = Driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.Id, Using = "ReviewAccessRequestResult_table")]
        private IWebElement tableReviewAccessRequestResult_table { get; set; }
        public string ReviewAccessRequestResult_table
        {
            get
            {

                return "ReviewAccessRequestResult_table";

            }
            set
            { 
            }
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

        private IWebElement _approve { get; set; }

        public string Approve
        {
            get
            {
                return "Approve";
            }
            set
            {
                _approve = _driver.FindElement(By.Id(value));
            }
        }

        public void Approve_Click()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_ENABLE_BORDER, _approve);
            _approve.Click();
            ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_DISABLE_BORDER, _approve);

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

        [FindsBy(How = How.Id, Using = "btnApproveOK")]
        private IWebElement btnApproveOK { get; set; }

        public void Yes_Click()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_ENABLE_BORDER, btnApproveOK);
            btnApproveOK.Click();
        }


        [FindsBy(How = How.Id, Using = "btnApproveNo")]
        private IWebElement btnApproveNo { get; set; }

        public void No_Click()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript(SCRIPT_ENABLE_BORDER, btnApproveNo);
            btnApproveNo.Click();
        }


        public string Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public string SubmittedBy { get; set; }

        public  List<ReviewAccessRequest> GetTableData()
        {
            IWebElement TableElement = _driver.FindElement(By.Id(ReviewAccessRequestResult_table));
            IList<IWebElement> TableRow = TableElement.FindElements(By.TagName("tr"));
            IList<IWebElement> RowTD;
            List<ReviewAccessRequest> ArrTableValues = new List<ReviewAccessRequest>();
            ReviewAccessRequest ur;

            foreach (IWebElement Row in TableRow)
            {
                ur = new ReviewAccessRequest();
                RowTD = Row.FindElements(By.TagName("td"));
                ur.Id = Row.GetAttribute("id");
                ur.FirstName = RowTD[1].Text;
                ur.MiddleName = RowTD[2].Text;
                ur.LastName = RowTD[3].Text;
                ur.Department = RowTD[4].Text;
                ur.SubmittedBy = RowTD[5].Text;

                ArrTableValues.Add(ur);
            }

            return ArrTableValues;
        }
        
    }
}
