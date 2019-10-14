Install-Package Selenium.WebDriver -Version 3.5.2
Install-Package Selenium.Support -Version 3.5.2
Install-Package SpecRun.SpecFlow


http://specflow.org/guidance/first-steps/


For BDD
1. Install-Package Newtonsoft.Json -Version 10.0.3
2. Install-Package SpecFlow -Version 2.2.1
3. Install-Package SpecRun.SpecFlow -Version 1.6.3 



%AppData%\..\Local\Microsoft\VisualStudio\11.0\ComponentModelCache

remove componentmodelcache folder

STep 1: Installed Selenium.Firefox.WebDriver from Tools->nuget package manger-> packt manager solution
step2: updated firfox to 56.0
step3: selenium latest version
step4:    FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();

                     service.FirefoxBinaryPath = @"C:\Users\drn59657\AppData\Local\Mozilla Firefox\firefox.exe";
                    
                 driver = new FirefoxDriver(service);
            