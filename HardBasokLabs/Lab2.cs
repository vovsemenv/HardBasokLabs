using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
namespace HardBasokLabs
{
    public class Lab2
    {
        IWebDriver driver;    
        public static List<string> Readtestvals(string url)
        {
            var storage = new List<string>();
            StreamReader sr = new StreamReader(url);
            while (sr.Peek() >= 0)
            {               
                    storage.Add(sr.ReadLine());
            }
            return storage;
        }
        public (string, List<String>) inputData(string url = "../../../DataFile.txt")
        {
            
            var storage = new List<string>();
            string img = "undefined";

            StreamReader sr = new StreamReader(url);
            while (sr.Peek() >= 0)
            {
                if (img == "undefined")
                {
                    img = sr.ReadLine();
                }
                else
                {
                    storage.Add(sr.ReadLine());
                }
            }
            
            return (img, storage);
        }
        public List<string> checkPages(string img, List<string> storage)
        {
            driver = new ChromeDriver("C:/Users/vovse/Desktop/basok");
            var res = new List<string>();

            foreach (var href in storage)
            {
                driver.Url = href;
                try
                {
                    var k = driver.FindElement(By.CssSelector($"img[src='{img}']"));
                    res.Add(href);

                }
                catch { continue; };

            }
            driver.Close();
            return res;
        }
        public static void writeFile(string url, List<string> storage)
        {
            using (StreamWriter fstream = new StreamWriter(url))
            {
                foreach (var href in storage)
                {
                    fstream.WriteLine(href);
                }
            }
        }
        public void everything(string inputUrl = "../../../../DataFile.txt", string outputUrl = "../../../../OutputFile.txt")
        {
            (var img, var storage) = this.inputData(inputUrl);
            var res = checkPages(img, storage);
            writeFile(outputUrl, res);
        }

    }
}
