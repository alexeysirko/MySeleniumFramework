using MySeleniumFramework.Elements.ElementTypes;
using MySeleniumFramework.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsuirExample.PageObjects
{
    internal class RegistrationPage : PageObject
    {
        private static TextBox _loginBox = new TextBox(By.Id("rcmloginuser"));
        private TextBox _passwordButton = new TextBox(By.Id("rcmloginpwd"));
        private Button _enterButton = new Button(By.Id("rcmloginsubmit"));

        public RegistrationPage() : base(_loginBox)
        {
        }


        public void EnterCredentials(string login, string password)
        {
            _loginBox.TypeText(login);
            _passwordButton.TypeText(password);
        }

        public void CheckSubmit()
        {
            _enterButton.GetText();
        }
    }
}
