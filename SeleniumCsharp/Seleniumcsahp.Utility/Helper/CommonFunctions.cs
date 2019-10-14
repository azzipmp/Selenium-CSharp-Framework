using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace TREDS.Virginia.Gov.QA.Utility.Helper
{
    public static class CommonFunctions
    {
        public static void WaitForPageLoad(IWebDriver driver, String PageName)
        {
              try
            {

            Console.WriteLine(" Common functions -> Waiting for page to load");

           // WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            wait.Until(ExpectedConditions.TitleContains(PageName));

       
              }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                throw ex;
               // Assert.Fail("Element not found!")
            }
        }
        public static void WaitForElementTobeVisible(IWebDriver driver, String Element)
        {
            try
            {

                Console.WriteLine(" Common functions -> Waiting for Element to be visible");
               // IWebElement element = driver.FindElement(bylocator);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
        //     wait.Until(ExpectedConditions.ElementIsVisible(Element));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(Element)));
              //  wait.Until(ExpectedConditions.ElementExists(By.Id(Element)));
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                // Assert.Fail("Element not found!")
            }
        }

        public static void VaidatePage1(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));

            Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                //Console.WriteLine(Web.FindElement(By.Id("target")).GetAttribute("innerHTML"));
                return true;
            });
            wait.Until(waitForElement);
        }
    
      
        public static bool isPresent2(this IWebDriver driver, By bylocator)
        {
            bool variable = true;
            try
            {
                IWebElement element = driver.FindElement(bylocator);

            }
            catch (NoSuchElementException)
            {
                variable = false;
            }
            return variable;
        }

        public static bool doesWebElementExist(this IWebDriver driver, string linkexist)
        {
            try
            {
                driver.FindElement(By.XPath(linkexist));
                return true;
            }
            catch (NoSuchElementException )
            {
                return false;
            }
        }

        public static List<string> GetTableData(IWebDriver driver, String Element)
        {
            IWebElement TableElement = driver.FindElement(By.Id(Element));
            IList<IWebElement> TableRow = TableElement.FindElements(By.TagName("tr"));
            IList<IWebElement> RowTD;
            List<string> ArrTableValues = new List<string>();

            foreach (IWebElement Row in TableRow)
            {
                RowTD = Row.FindElements(By.TagName("td"));

                foreach (IWebElement td in RowTD)
                {
                    ArrTableValues.Add(td.Text);
                }
                
                for (int Rowdata = 0; Rowdata <= RowTD.Count - 1; Rowdata++)
                {
                    ArrTableValues.Add(RowTD[Rowdata].Text);
                }
            }
         
            return ArrTableValues;
         }

        public static List<string> GetTableDataByRow(IWebDriver driver, String Element, int Row)
        {
            IWebElement TableElement = driver.FindElement(By.Id(Element));
            IList<IWebElement> TableRow = TableElement.FindElements(By.XPath("//*[@id="+"'"+Element+"'"+"]/tbody/tr[" + Row + "]"));
            IList<IWebElement> RowTD;
            List<string> ArrTableValuesByRow = new List<string>();

            foreach (IWebElement RowRecord in TableRow)
            {

                RowTD = RowRecord.FindElements(By.TagName("td"));

                for (int Rowdata = 0; Rowdata <= RowTD.Count - 1; Rowdata++)
                {
                    ArrTableValuesByRow.Add(RowTD[Rowdata].Text);
                }

            }
           
            return ArrTableValuesByRow;
        }

        public static List<string> GetIDPropertyFromTableByRow(IWebDriver driver, String Element, int Row)
        {
            IWebElement TableElement = driver.FindElement(By.Id(Element));           
            IList<IWebElement> TableRow = TableElement.FindElements(By.XPath("//*[@id=" + "'" + Element + "'" + "]/tbody/tr[" + Row + "]"));
           // IList<IWebElement> RowTD;
            List<string> ArrTableValuesByRow = new List<string>();  

            foreach (IWebElement RowRecord in TableRow)
            {                
                Console.WriteLine("Each row id : " + RowRecord.GetAttribute("id"));
                ArrTableValuesByRow.Add(RowRecord.GetAttribute("id"));
             //   RowTD = RowRecord.FindElements(By.TagName("td"));
               
             //   for (int Rowdata = 0; Rowdata <= 2; Rowdata++)
            //    {
               
                //    ArrTableValuesByRow.Add(RowTD[Rowdata].GetAttribute("id"));
              //  }

            }
      
             return ArrTableValuesByRow;
         }

   }
}
