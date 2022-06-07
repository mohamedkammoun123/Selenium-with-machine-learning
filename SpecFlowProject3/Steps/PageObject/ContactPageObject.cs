using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Globalization;
using System.Text.RegularExpressions;

namespace SpecFlowProject2.Steps.PageObject
{
    class ContactPageObject
    {
        private Boolean phoneButtonIsClicked;
        private Boolean emailButtonIsClicked;
        private Boolean englishButtonIsClicked;
        private Boolean frenchButtonIsClicked;
        IWebDriver driver;
        String url = "https://cgcashgroup-dev-01.azurewebsites.net/gic/contact-page";
        public ContactPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }
        private IWebElement firstNameInputText => driver.FindElement(By.Id("firstName"));
        private IWebElement lastNameInputText => driver.FindElement(By.Id("lastName"));
        private IWebElement englishButton => driver.FindElement(By.XPath("/html/body/app-root/simplywhite-layout/page-container/div/div[1]/app-contact-page/div/div[2]/form/div/div[3]/div/button[1]"));
        private IWebElement frenshButton => driver.FindElement(By.XPath("/html/body/app-root/simplywhite-layout/page-container/div/div[1]/app-contact-page/div/div[2]/form/div/div[3]/div/button[2]"));
        private IWebElement byPhoneButton => driver.FindElement(By.XPath("/html/body/app-root/simplywhite-layout/page-container/div/div[1]/app-contact-page/div/div[2]/form/div/div[5]/div/button[1]"));
        private IWebElement byEmailButton => driver.FindElement(By.XPath("/html/body/app-root/simplywhite-layout/page-container/div/div[1]/app-contact-page/div/div[2]/form/div/div[5]/div/button[2]"));
        private IWebElement buttonSubmmitRequest => driver.FindElement(By.XPath("/html/body/app-root/simplywhite-layout/page-container/div/div[1]/app-contact-page/div/div[2]/form/div/div[8]/button"));
        private IWebElement phoneInputText => driver.FindElement(By.Id("phoneNumberCompo"));
        private IWebElement emailInputText => driver.FindElement(By.Id("email"));

        public void goDownToElement()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();",buttonSubmmitRequest);
        }
        public void setFirstNameInLabel(String firstName)
        {
            firstNameInputText.SendKeys(firstName);
        }

        public void setLastNameInLabel(String lastName)
        {
            lastNameInputText.SendKeys(lastName);
        }
        public void pressEnglishButton()
        {
            Actions actions = new Actions(driver);
            actions.Click(englishButton).Build().Perform();
            englishButtonIsClicked = true;
            frenchButtonIsClicked = false;
        }
        public void pressFrenchButton()
        {
            Actions actions = new Actions(driver);
            actions.Click(frenshButton).Build().Perform();
            frenchButtonIsClicked = true;
            englishButtonIsClicked = false;
        }

        public void pressByPhoneButton() 
        {
            Actions actions = new Actions(driver);
            actions.Click(byPhoneButton).Build().Perform();
            phoneButtonIsClicked = true;
            emailButtonIsClicked = false;
        }
        public void pressByEmailButton()
        {
            Actions actions = new Actions(driver);
            actions.Click(byEmailButton).Build().Perform();
            emailButtonIsClicked = true;
            emailButtonIsClicked = false;
        }
        public void pressSubbmitButton()
        {
            Actions actions = new Actions(driver);
            actions.Click(buttonSubmmitRequest).Build().Perform();
        }
        public void setPhoneInLabel(String phone)
        {
            phoneInputText.SendKeys(phone);
        }
        public void setEmailInLabel(String email)
        {
            emailInputText.SendKeys(email);
        }
        public Boolean phoneButtonIsItClicked()
        {
            return phoneButtonIsClicked;
        }
        public Boolean emailButtonIsItClicked()
        {
            return emailButtonIsClicked;
        }
        public Boolean englishButtonIsItClicked()
        {
            return englishButtonIsClicked;
        }
        public Boolean frenchButtonIsItClicked()
        {
            return frenchButtonIsClicked;
        }
        public  bool IsAllLetters(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsLetter(c))
                    return false;
            }
            return true;
        }

        public Boolean IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        public Boolean IsValidPhoneNumber(String phoneNumber)
        {
            if (!Regex.Match(phoneNumber, @"^[1-9]\d{2}-[1-9]\d{2}-\d{4}$").Success)
            {
                return true;
            }
            return false;
        }

    }
}
