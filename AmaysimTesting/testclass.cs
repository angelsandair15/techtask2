using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;
using System.IO;
using System.Reflection;

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
            driver.FindElement(By.XPath("//a[contains(@href,'/my-account/my-amaysim/login')]")).Click();
            driver.FindElement(By.XPath(".//*[@id='username']")).SendKeys("0468340754");
            driver.FindElement(By.XPath(".//*[@id='password']")).SendKeys("theHoff34");
            driver.FindElement(By.XPath("//button[contains(text(),'login')]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.FindElement(By.XPath("//a[contains(text(),'Manage plan')]")).Click();
            driver.FindElement(By.XPath("//a[contains(@href,'/my-account/my-amaysim/settings')]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.FindElement(By.XPath(".//*[@id='edit_settings_phone_label']")).Click();
            driver.FindElement(By.XPath(".//*[@id='my_amaysim2_setting_phone_label']")).Clear();
            driver.FindElement(By.XPath(".//*[@id='my_amaysim2_setting_phone_label']")).SendKeys("Allen Test");
            driver.FindElement(By.XPath(".//*[@value='Save']")).Click();
            WaitOnPage(3);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            driver.FindElement(By.XPath("//a[contains(@href,'/my-account/my-amaysim/payment-method') and text()='Prepaid, BPay']")).Click();
            driver.FindElement(By.XPath(".//*[@class='small-4 columns text-right']")).Click();
            driver.FindElement(By.XPath(".//*[@id='payment_method_option']")).SendKeys("BPAY / Vouchers");
            driver.FindElement(By.XPath(".//*[@value='Save']")).Click();
            ModalClose();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.FindElement(By.XPath("//a[contains(@href,'/my-account/my-amaysim/settings')]")).Click();
            driver.FindElement(By.XPath(".//*[@id='edit_settings_recharge_pin']")).Click();
            driver.FindElement(By.XPath(".//*[@id='my_amaysim2_setting_topup_pw']")).Clear();
            driver.FindElement(By.XPath(".//*[@id='my_amaysim2_setting_topup_pw']")).SendKeys("2345");
            driver.FindElement(By.XPath(".//*[@value='Save']")).Click();
            WaitOnPage(2);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            IWebElement checkbox = driver.FindElement(By.XPath(".//label[@for='my_amaysim2_setting_caller_id_out']"));
            checkbox.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            ModalClose2();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.FindElement(By.XPath(".//label[@for='my_amaysim2_setting_caller_waiting']")).Click();
            ModalClose2();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.FindElement(By.XPath(".//label[@for='my_amaysim2_setting_voice_mail']")).Click();
            ModalClose2();
            driver.FindElement(By.XPath(".//label[@for='my_amaysim2_setting_usage_alert']")).Click();
            driver.FindElement(By.XPath("//a[@id='confirm_popup_yes']")).Click();
            ModalClose2();
            driver.FindElement(By.XPath(".//label[@for='my_amaysim2_setting_intl_roaming']")).Click();
            driver.FindElement(By.XPath("//a[@id='confirm_popup_yes']")).Click();
            ModalClose2();
            driver.FindElement(By.XPath(".//label[@for='my_amaysim2_setting_intl_roaming']")).Click();
            ModalClose2();
            driver.FindElement(By.XPath(".//*[@id='edit_settings_call_forwarding']")).Click();
            driver.FindElement(By.XPath(".//*[@class='confirm_popup_confirm button-green-action small-12 columns text-center']")).Click();
            driver.FindElement(By.XPath("//span[contains(text(),'No')]")).Click();
            driver.FindElement(By.XPath("//span[contains(text(),'Yes')]")).Click();
            driver.FindElement(By.XPath(".//*[@id='my_amaysim2_setting_call_divert_number']")).Clear();
            driver.FindElement(By.XPath(".//*[@id='my_amaysim2_setting_call_divert_number']")).SendKeys("0412345679");
            driver.FindElement(By.XPath(".//*[@value='Save']")).Click();
            ModalClose2();
            WaitOnPage(1);
            driver.FindElement(By.XPath(".//*[@id='edit_settings_call_forwarding']")).Click();
            driver.FindElement(By.XPath(".//*[@class='confirm_popup_confirm button-green-action small-12 columns text-center']")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.FindElement(By.XPath("//span[contains(text(),'No')]")).Click();
            driver.FindElement(By.XPath(".//*[@value='Save']")).Click();
            ModalClose2();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.FindElement(By.XPath(".//*[@id='edit_settings_premium_sms_limit']")).Click();
            driver.FindElement(By.XPath(".//*[@id='my_amaysim2_setting_psms_spend']")).SendKeys("$20");
            driver.FindElement(By.XPath(".//*[@value='Save']")).Click();
            WaitOnPage(2);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.FindElement(By.XPath("//a[@id='edit_settings_auto_recharge']")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.FindElement(By.XPath("//span[contains(text(),'No')]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.FindElement(By.XPath("//span[contains(text(),'Yes')]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.FindElement(By.XPath(".//*[@id='my_amaysim2_setting_auto_topup_min_balance']")).SendKeys("$10");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.FindElement(By.XPath(".//*[@id='my_amaysim2_setting_auto_topup_amount']")).SendKeys("$20");
            driver.FindElement(By.XPath(".//*[@value='Save']")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.FindElement(By.XPath(".//*[@id='logout-link']")).Click();


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

    }

}