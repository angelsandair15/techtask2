using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using OpenQA.Selenium.Interactions;


namespace AmaysimTest

{

    [TestFixture]
    public class TestClass
    {
        protected IWebDriver driver;

        [Test]
        public void TestManageSettings()
        {
            var driverpath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var testopt = new ChromeOptions();

            testopt.AddArgument(@"--incognito");
            testopt.AddArgument(@"--start-maximized");
            driver = new ChromeDriver(driverpath, testopt);

            driver.Url = "https://www.amaysim.com.au/";
            driver.Manage().Window.Maximize();
            WaitOnPage(3);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.FindElement(By.XPath("//a[contains(@href,'/my-account/my-amaysim/login')]")).Click();
            driver.FindElement(By.XPath(".//*[@id='username']")).SendKeys("0468340754");
            driver.FindElement(By.XPath(".//*[@id='password']")).SendKeys("theHoff34");
            driver.FindElement(By.XPath("//button[contains(text(),'login')]")).Click();
            driver.FindElement(By.XPath("//a[contains(text(),'Manage plan')]")).Click();
            driver.FindElement(By.XPath("//a[contains(@href,'/my-account/my-amaysim/settings')]")).Click();
            driver.FindElement(By.XPath(".//*[@id='edit_settings_phone_label']")).Click();
            driver.FindElement(By.XPath(".//*[@id='my_amaysim2_setting_phone_label']")).Clear();
            driver.FindElement(By.XPath(".//*[@id='my_amaysim2_setting_phone_label']")).SendKeys("Allen Test");
            driver.FindElement(By.XPath(".//*[@value='Save']")).Submit();
            WaitOnPage(2);
            driver.FindElement(By.XPath("//a[contains(@href,'/my-account/my-amaysim/payment-method') and text()='Prepaid, BPay']")).Click();
            driver.FindElement(By.XPath(".//*[@class='small-4 columns text-right']")).Click();
            driver.FindElement(By.XPath(".//*[@id='payment_method_option']")).SendKeys("BPAY / Vouchers");
            WaitOnPage(1);
            driver.FindElement(By.XPath(".//*[@value='Save']")).Click();
            ModalClose();
            driver.FindElement(By.XPath("//a[contains(@href,'/my-account/my-amaysim/settings')]")).Click();
            driver.FindElement(By.XPath(".//*[@id='edit_settings_recharge_pin']")).Click();
            driver.FindElement(By.XPath(".//*[@id='my_amaysim2_setting_topup_pw']")).Clear();
            driver.FindElement(By.XPath(".//*[@id='my_amaysim2_setting_topup_pw']")).SendKeys("2345");
            driver.FindElement(By.XPath(".//*[@value='Save']")).Click();
            WaitOnPage(2);
            IWebElement checkbox = driver.FindElement(By.XPath(".//label[@for='my_amaysim2_setting_caller_id_out']"));
            checkbox.Click();
            ModalClose2();
            WaitOnPage(1);
            driver.FindElement(By.XPath(".//label[@for='my_amaysim2_setting_caller_waiting']")).Click();
            ModalClose2();
            driver.FindElement(By.XPath(".//label[@for='my_amaysim2_setting_voice_mail']")).Click();
            ModalClose2();
            driver.FindElement(By.XPath(".//label[@for='my_amaysim2_setting_usage_alert']")).Click();
            driver.FindElement(By.XPath("//a[@id='confirm_popup_yes']")).Click();
            ModalClose2();
            GoToBottomPage();
            driver.FindElement(By.XPath(".//label[@for='my_amaysim2_setting_intl_roaming']")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            VerifyIntRoaming();
            WaitOnPage(1);
            driver.FindElement(By.XPath(".//*[@id='edit_settings_call_forwarding']")).Click();
            driver.FindElement(By.XPath(".//*[@class='confirm_popup_confirm button-green-action small-12 columns text-center']")).Click();
            WaitOnPage(1);
            driver.FindElement(By.XPath("//span[contains(text(),'No')]")).Click();
            driver.FindElement(By.XPath("//span[contains(text(),'Yes')]")).Click();
            driver.FindElement(By.XPath(".//*[@id='my_amaysim2_setting_call_divert_number']")).Clear();
            driver.FindElement(By.XPath(".//*[@id='my_amaysim2_setting_call_divert_number']")).SendKeys("0412345679");
            WaitOnPage(1);
            driver.FindElement(By.XPath(".//*[@value='Save']")).Click();
            WaitOnPage(1);

            VerifyCallForwardError();
            WaitOnPage(1);
            driver.FindElement(By.XPath(".//*[@id='edit_settings_premium_sms_limit']")).Click();
            driver.FindElement(By.XPath(".//*[@id='my_amaysim2_setting_psms_spend']")).SendKeys("$20");
            WaitOnPage(1);
            driver.FindElement(By.XPath(".//*[@value='Save']")).Click();
            WaitOnPage(1);
            driver.FindElement(By.XPath("//a[contains(@href,'/my-account/my-amaysim/settings')]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            WaitOnPage(1);
            ClickAutoCreditTopUp();
            //driver.FindElement(By.XPath("//a[@id='edit_settings_auto_recharge']")).Click();
            WaitOnPage(1);
            ClickAutoCreditTopUpNo();
            //driver.FindElement(By.XPath("//span[contains(text(),'No')]")).Click();
            WaitOnPage(1);
            driver.FindElement(By.XPath("//span[contains(text(),'Yes')]")).Click();
            driver.FindElement(By.XPath(".//*[@id='my_amaysim2_setting_auto_topup_min_balance']")).SendKeys("$10");
            driver.FindElement(By.XPath(".//*[@id='my_amaysim2_setting_auto_topup_amount']")).SendKeys("$15");
            driver.FindElement(By.XPath(".//*[@value='Save']")).Click();

            Console.WriteLine("Manage Settings Passed!!");
            DriverQuit();
        }


        public void WaitOnPage(int seconds)
        {
            System.Threading.Thread.Sleep(seconds * 1000);
        }


        public void DriverQuit()
        {
            Process[] chromeDriverProcesses = Process.GetProcessesByName("chromedriver");

            foreach (var chromeDriverProcess in chromeDriverProcesses)
            {
                chromeDriverProcess.Kill();
            }
        }
        public void ModalClose()
        {

            bool staleElement = true;
            while (staleElement)
            {
                try
                {
                    driver.FindElement(By.XPath("//div[@id='common_popup']//a[@class='close-reveal-modal'][contains(text(),'×')]")).Click();
                    staleElement = false;

                }
                catch (StaleElementReferenceException e)
                {
                    staleElement = true;
                }
            }
        }

        public void ModalClose2()
        {

            bool staleElement = true;
            while (staleElement)
            {
                try
                {
                    driver.FindElement(By.XPath("//div[@class='form_info_popup reveal-modal padding-none open']//a[@class='close-reveal-modal'][contains(text(),'×')]")).Click();
                    staleElement = false;

                }
                catch (StaleElementReferenceException e)
                {
                    staleElement = true;
                }
            }
        }

        public void VerifyCallForwardError()
        {

            try
            {

                driver.FindElements(By.XPath("//h1[@class='ama-hero-heading popup-error white']"));
                Console.WriteLine("Error on Call Forwarding encountered");
                ModalClose();
                driver.FindElement(By.XPath("//a[@id='cancel_settings_call_forwarding']")).Click();
            }
            catch (TimeoutException e)
            {
                Console.WriteLine("No Error encountred on Call Forwarding");
                ModalClose2();
            }
            catch (WebDriverException e)
            {
                Console.WriteLine("No Error encountred on Call Forwarding");
                ModalClose2();
            }


        }
        public void VerifyIntRoaming()
        {

            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//a[@id='confirm_popup_yes']")));
                try
                {
                    driver.FindElement(By.XPath("//a[@id='confirm_popup_yes']")).Click();
                    ModalClose2();
                }
                catch (WebDriverException e)
                {
                    ModalClose2();
                }
            }
            catch (TimeoutException e)
            {
                ModalClose2();
            }

        }

        public void GoToBottomPage()
        {
            var elem = driver.FindElement(By.XPath("//div[contains(text(),'Automatically top up your credit when you run low')]"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(elem);
            actions.Perform();
        }

        public void ClickAutoCreditTopUpNo()
        {
            var nobutton = driver.FindElement(By.XPath("//span[contains(text(),'No')]"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(nobutton);
            actions.Perform();
            nobutton.Click();
        }

        public void ClickAutoCreditTopUp()
        {
            var editbutton = driver.FindElement(By.XPath("//a[@id='edit_settings_auto_recharge']"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(editbutton);
            actions.Perform();
            editbutton.Click();
        }


    }

}
