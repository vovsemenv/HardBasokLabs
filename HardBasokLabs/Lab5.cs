using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

namespace HardBasokLabs
{
    public class Lab5
    {
        IWebDriver driver;
        
        public List<string> loginAndGetOnline(string login, string password)
        {
            driver = new ChromeDriver("C:/Users/vovse/Desktop/basok");
            this.driver.Url = "https://vk.com/";
            var emailEl = driver.FindElement(By.CssSelector("#index_email"));
            var passEl = driver.FindElement(By.CssSelector("#index_pass"));
            var loginBtn = driver.FindElement(By.CssSelector("#index_login_button"));
            emailEl.SendKeys(login);
            passEl.SendKeys(password);
            loginBtn.Click();
            var wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => this.driver.Url == "https://vk.com/feed");

            driver.Url = "https://vk.com/friends";
            wait.Until(driver => this.driver.Url == "https://vk.com/friends");
            var friend = driver.FindElements(By.CssSelector(".friends_field_title > a"));
            var s = new List<string>();
            foreach (var friendname in friend)
            {
                s.Add(friendname.Text);
            }
            driver.Close();
            return s;
        }
        public void loginAndSendMsg(string login, string password, string userId, string msg)
        {
            driver = new ChromeDriver("C:/Users/vovse/Desktop/basok");
            this.driver.Url = "https://vk.com/";
            var emailEl = driver.FindElement(By.CssSelector("#index_email"));
            var passEl = driver.FindElement(By.CssSelector("#index_pass"));
            var loginBtn = driver.FindElement(By.CssSelector("#index_login_button"));
            emailEl.SendKeys(login);
            passEl.SendKeys(password);
            loginBtn.Click();
            var wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => this.driver.Url == "https://vk.com/feed");
            this.driver.Url = $"https://vk.com/im?sel={userId}";
            wait.Until(driver => this.driver.Url == $"https://vk.com/im?sel={userId}");
            var messTextEl = driver.FindElement(By.CssSelector($"#im_editable{userId}"));
            messTextEl.SendKeys(msg);
            messTextEl.SendKeys(Keys.Enter);
            driver.Close();
        }
    }
}
