using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.Drawing.Imaging;
using System.IO;

namespace TREDS.Virginia.Gov.QA.Utility.Helper
{
  public  class BrowserContainer
    {
        public  static IWebDriver driver;
      //  public static string ScreenShotPath;
        public static void initBrowser(string browserName)
        {
            switch (browserName)
            {
                case "firefox":
        //    System.Environment.SetEnvironmentVariable("webdriver.gecko.driver", "C:\\VAHSO\\TREDS\\Development\\Release 6.4\\TREDS.Virginia.Gov.QA\\TREDS.Virginia.Gov.QA.TDD\\Drivers\\geckodriver.exe");
                  
                  //  driver = new FirefoxDriver();
                  //  FirefoxDriverService service = FirefoxDriverService.CreateDefaultService("C:\\VAHSO\\TREDS\\Development\\Release 6.4\\TREDS.Virginia.Gov.QA\\TREDS.Virginia.Gov.QA.TDD\\Drivers\\geckodriver.exe");
                  FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();

                     service.FirefoxBinaryPath = @"C:\Users\drn59657\AppData\Local\Mozilla Firefox\firefox.exe";
                    
                 driver = new FirefoxDriver(service);
               //   IWebDriver driver = new FirefoxDriver();

                    break;

                case "ie":

                 //   driver = new InternetExplorerDriver(@"C:\PathTo\IEDriverServer");


                    break;

                case "chrome":

                 //   driver = new ChromeDriver(System.IO.Path.GetFullPath("..\\..\\..\\TREDS.Virginia.Gov.QA.TDD\\Drivers\\"));
                    driver = new ChromeDriver();
                    break;
            }

            
        }

        public static void loadApplication(string url)
        {
             driver.Url = url;
            
          //  driver.Navigate().GoToUrl(url);
           driver.Manage().Window.Maximize();
        }

        public static void closeAllBrowsers()
        {
           
            driver.Dispose();
            driver.Quit();
        }

        public static void ScreenShot(String FileName)

        {
           String ScreenShotPath=System.IO.Path.GetFullPath("..\\..\\..\\TREDS.Virginia.Gov.QA.TDD\\Results");
            
            String location = ScreenShotPath + "\\" + FileName + ".png";
    
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();

            screenshot.SaveAsFile(location, ScreenshotImageFormat.Png);
        }
    }
}

