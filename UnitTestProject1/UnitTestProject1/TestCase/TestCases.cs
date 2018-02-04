using OpenQA.Selenium;
using System;
using System.Drawing.Imaging;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System.Configuration;
using UnitTestProject1.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace UnitTestProject1.TestCase
{
    [TestClass]
    public class TestCases
    {

        //IWebDriver driver = new ChromeDriver();
        
       
   
        IWebDriver driver = new ChromeDriver();

        string screendir = ConfigurationManager.AppSettings["ScreeDir"];

        [TestMethod]

        public void right()
        {
          
            driver.Url = ConfigurationManager.AppSettings["URL"];
            var loginPage = new LoginPage(driver);
            loginPage.Login("right");
            takeScreenShot("right", ScreenshotImageFormat.Png);
            var b = "http://mantis-prova.base2.com.br/my_view_page.php";
            Assert.AreNotEqual(driver.Url, b);
        }


        [TestMethod]

        public void wrong()
        {
            driver.Url = ConfigurationManager.AppSettings["URL"];
            var a = "Your account may be disabled or blocked or the username/password you entered is incorrect.";
            var loginPage = new LoginPage(driver);
            loginPage.Login("wrong");
            takeScreenShot("wrong", ScreenshotImageFormat.Png);
            var b = driver.FindElement(By.XPath("//html//body//div//font")).Text;
            Assert.AreEqual(a, b);
        }
        [TestMethod]

        public void noUser()
        {
            driver.Url = ConfigurationManager.AppSettings["URL"];
            var a = "Your account may be disabled or blocked or the username/password you entered is incorrect.";
            var loginPage = new LoginPage(driver);
            loginPage.Login("noUser");
            var b = driver.FindElement(By.XPath("//html//body//div//font")).Text;
            Assert.AreEqual(a, b);
            takeScreenShot("noUser", ScreenshotImageFormat.Png);
            driver.Close();
        }
        [TestMethod]

        public void Empty()
        {

            driver.Url = ConfigurationManager.AppSettings["URL"];
            var a = "Your account may be disabled or blocked or the username/password you entered is incorrect.";
            var loginPage = new LoginPage(driver);
            loginPage.Login("Empty");
            var b = driver.FindElement(By.XPath("//html//body//div//font")).Text;
            Assert.AreEqual(a, b);
            takeScreenShot("Empty", ScreenshotImageFormat.Png);
            driver.Close();
        }
        [TestMethod]
        public void noPasswd()
        {

            driver.Url = ConfigurationManager.AppSettings["URL"];
            var a = "Your account may be disabled or blocked or the username/password you entered is incorrect.";
            var loginPage = new LoginPage(driver);
            loginPage.Login("noPasswd");
            var b = driver.FindElement(By.XPath("//html//body//div//font")).Text;
            Assert.AreEqual(a, b);
            takeScreenShot("noPasswd", ScreenshotImageFormat.Png);
            driver.Close();
        }
        [TestMethod]
        public void recPass()
        {
            var urllost = "http://mantis-prova.base2.com.br/lost_pwd.php";
            driver.Url = ConfigurationManager.AppSettings["URL"];
            RecPasswdPage recpasswd = new RecPasswdPage();
            recpasswd.RecLink(driver);
            recpasswd.RecPass(driver);
            recpasswd.Recovery("RecPass");
            takeScreenShot("RecPass", ScreenshotImageFormat.Png);

            Assert.AreEqual(urllost, driver.Url);

        }
       
        [TestMethod]

        public void reportIssueEmpty()
        {
            var msga = "A necessary field \"Summary\" was empty. Please recheck your inputs.";
            driver.Url = ConfigurationManager.AppSettings["URL"];
            var loginPage = new LoginPage(driver);
            loginPage.Login("Correto");
            System.Threading.Thread.Sleep(2000);
            ReportIssuePage Submit = new ReportIssuePage(driver);
            System.Threading.Thread.Sleep(2000);
            var msgb = driver.FindElement(By.XPath("/html/body/div[2]/table/tbody/tr[2]/td/p")).Text;
            Assert.AreEqual(msga, msgb);

        }
        public void takeScreenShot(string filename, ScreenshotImageFormat format)
        {
            ITakesScreenshot screenshothandler = driver as ITakesScreenshot;
            Screenshot screenshot = screenshothandler.GetScreenshot();
            screenshot.SaveAsFile(filename + ".png",format);

        }
        [TestMethod]
        public void changePass()
        {
            driver.Url = ConfigurationManager.AppSettings["URL"];
            var a = driver.Url;
            right();
            ChangePass changepass = new ChangePass();
            changepass.MyAccount(driver);
            changepass.changePass(driver);
            changepass.ClickChange(driver, "Change");
            driver.Url = ConfigurationManager.AppSettings["URL"];
            var loginPage = new LoginPage(driver);
            loginPage.Login("ChangePass");
            takeScreenShot("changePass", ScreenshotImageFormat.Png);
            Assert.AreEqual(a, driver.Url);
        }


    }

    }
