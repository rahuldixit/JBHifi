using System;
using TechTalk.SpecFlow;
using TestStack.White.UIA;
using TestStack.White.AutomationElementSearch;
using TestStack.White.Finder;
using TestStack.White.UIItemEvents;
using TestStack.White.WindowsAPI;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.Container;
using TestStack.White.UIItems.Custom;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.ListViewItems;
using TestStack.White.UIItems.PropertyGridItems;
using TestStack.White.UIItems.Scrolling;
using TestStack.White.UIItems.TableItems;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.WindowStripControls;
using TestStack.White.UIItems.WPFUIItems;
using TestStack.White.UIItems.TabItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.WindowStripControls;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.ListBoxItems;
//using System.Windows.Automation;
using TestStack.White;
using TestStack.White.Factory;
using White.Windows;
using System.Configuration;

namespace White.Steps
{
    [Binding]
    public class WhiteSteps
    {
        public static Application application;
     
        [Given(@"I launch the client application")]
        public static void GivenILaunchTheClientApplication()
        {
            application = Application.Launch(ConfigurationSettings.AppSettings["application"]);
            application.WaitWhileBusy();
            ClientSearchForm.GetWindow(application, "Client Search Form");
        }

        
	
        [When(@"I add a new client with name ""(.*)"", street ""(.*)"", street number ""(.*)"", postcode ""(.*)"", city ""(.*)"" and phone number ""(.*)""")]
        public void WhenIAddANewClientWithTheDetails(string name, string street, string streetnumber, string postcode, string city, string phonenumber)
        {
            //identify existing clients
            ClientSearchForm.setExistingClientsCount();
            ClientSearchForm.RaiseNewClientWindow();
            ClientDetails.GetWindow(application, "Client Details");
            ClientDetails.EnterClientName(name);
            ClientDetails.EnterAddress(street,streetnumber,postcode,city);
            ClientDetails.EnterTelephone(phonenumber);            
        }

        [Then(@"client name ""(.*)"" should appear in the existing clients list")]
        public static void ThenClientNameShouldAppearInTheExistingClientsList(string clientName)
        {
            ClientSearchForm.GetWindow(application, "Client Search Form");
 	         
            ClientSearchForm.VerifyClientAdded(clientName);
            
        }

        [When(@"I view client details for ""(.*)""")]
        public void WhenIViewClientDetailsFor(string clientName)
        {
            ClientSearchForm.ViewClientDetails(clientName);
            ClientAccountDetails.GetWindow(application, "Client Details");
        }

        [When(@"I add new account ""(.*)""")]
        public void WhenIAddNewAccount(string account)
        {
            ClientAccount.AddAccount(account);
        }

        [Then(@"the account is displayed in the accounts list ""(.*)""")]
        public void ThenTheAccountIsDisplayedInTheAccountsList(string account)
        {
            ClientAccount.AccountIsInList(account);
        }

        [When(@"I delete account ""(.*)""")]
        public void WhenIDeleteAccount(string account)
        {
           // ClientSearchForm.ViewClientDetails(account);
            ClientAccount.DeleteAccount(account);
            ClientAccountDetails.GetWindow(application, "Account Details");
            ClientAccountDetails.DeleteAccount(account);
        }

        [Then(@"the account does not display in the list ""(.*)""")]
        public void ThenTheAccountDoesNotDisplayInTheList(string account)
        {
            ClientAccountDetails.GetWindow(application, "Client Details");
           
            ClientAccount.AccountIsNotInList(account);
        }

    }
}


