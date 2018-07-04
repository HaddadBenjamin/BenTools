﻿using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using OpenQA.Selenium.Firefox;

namespace Ben.Tools.Development
{
    [TestFixture]
    public class ElasticSearchQueriesTests
    {
        #region Field(s)
        private List<WebBrowserWrapper> WebBrowserWrappers;
        #endregion

        #region Callback(s)
        [OneTimeSetUp]
        public void OnInitializeAllTests()
        {
            WebBrowserWrappers = new List<WebBrowserWrapper>();

            var chromeOptions = new ChromeOptions();
            //var firefoxOptions = new FirefoxOptions();

            chromeOptions.AddArguments("--start-maximized");
            //firefoxOptions.AddArguments("--start-maximized");

            var chromeDriver = new ChromeDriver(chromeOptions);
            //var firefoxDriver = new FirefoxDriver(firefoxOptions);

            WebBrowserWrappers.Add(new WebBrowserWrapper(chromeDriver));
            //WebBrowserWrappers.Add(new WebBrowserWrapper(firefoxDriver));
        }

        [OneTimeTearDown]
        public void OnFinishAllTests()
        {
            WebBrowserWrappers.ForEach(WebBrowserWrapper => WebBrowserWrapper.Dispose());
        }
        #endregion

        #region Test(s)
        [TestCase("", "WHIRLPOOL")]
        [TestCase("iPhone 2", "")]
        [TestCase("iPhone 2", "APPLE")]
        public void ElasticSearchProductQueries(string productName, string brandName)
        {
            WebBrowserWrappers.ForEach(WebBrowserWrapper =>
            {
                WebBrowserWrapper.GoToUrl("http://bo-preprod.apreslachat.com/accueil-administrateur");

                WebBrowserWrapper.UpdateValue("#UserName", "suhji");
                WebBrowserWrapper.UpdateValue("#Password", "123456");

                WebBrowserWrapper.Click("span:contains(\"Connexion\")");

                WebBrowserWrapper.GoToUrl("http://bo-preprod.apreslachat.com/produits/recherche");

                var productNamePosition = WebBrowserWrapper.WaitElementAsPosition("#productName");

                WebBrowserWrapper.UpdateValue(productNamePosition, productName);
                WebBrowserWrapper.UpdateValue("#brandName", brandName);
                WebBrowserWrapper.UpdateValue("#productCreationDate", string.Empty);
                WebBrowserWrapper.UpdateChecked("#MerchantCheckBox", false);
                WebBrowserWrapper.UpdateValue("#merchantIds", "0");

                WebBrowserWrapper.Click(".search_product");

                WebBrowserWrapper.WaitCondition("#products_table tr:visible", "length", numberOfProducts => numberOfProducts > 2, 150000);
            });
        }
        #endregion
    }
}
