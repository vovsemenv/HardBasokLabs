using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
namespace HardBasokLabs
{
    class Program
    {
        static void Main(string[] args)
        {
            var driver = new ChromeDriver("C:/Users/vovse/Desktop/basok");
            driver.Url = "https://vk.com/";
            var emailEl = driver.FindElement(By.CssSelector("#index_email"));
            var passEl = driver.FindElement(By.CssSelector("#index_pass"));
            var loginBtn = driver.FindElement(By.CssSelector("#index_login_button"));
            emailEl.SendKeys("vova100006");
            passEl.SendKeys("vov$emenV");
            loginBtn.Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => driver.Url == "https://vk.com/feed" || driver.Url == $"https://vk.com/login?m=1&email=vova100006");
            
        }
    }
}
