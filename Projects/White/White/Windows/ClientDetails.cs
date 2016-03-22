using System;
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
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.Factory;

namespace White.Windows
{
    class ClientDetails : WindowBase
    {

        private readonly static SearchCriteria _clientNameTabPage = SearchCriteria.ByText("tabPage4");
        private readonly static SearchCriteria _clientNameGroupBox = SearchCriteria.ByAutomationId("_clientNameGroupBox");
        private readonly static SearchCriteria _clientNameTextBox = SearchCriteria.ByAutomationId("_clientName");
        private readonly static SearchCriteria _clientNameSaveButton = SearchCriteria.ByText("Save");

        private readonly static SearchCriteria _addressTabPage = SearchCriteria.ByText("tabPage2");
        private readonly static SearchCriteria _addressGroupBox = SearchCriteria.ByText("Specify the clients new address");
        private readonly static SearchCriteria _streetText = SearchCriteria.ByAutomationId("_street");
        private readonly static SearchCriteria _numberText = SearchCriteria.ByAutomationId("_streetNumber");
        private readonly static SearchCriteria _postalCodeText = SearchCriteria.ByAutomationId("_postalCode");
        private readonly static SearchCriteria _cityText = SearchCriteria.ByAutomationId("_city");
        private readonly static SearchCriteria _addressSaveButton = SearchCriteria.ByAutomationId("_addressSaveButton");

        private readonly static SearchCriteria _telephoneTabPage = SearchCriteria.ByText("tabPage3");
        private readonly static SearchCriteria _telephoneGroupBox = SearchCriteria.ByAutomationId("_phoneNumberGroupBox");
        private readonly static SearchCriteria _telephoneNumberTextBox = SearchCriteria.ByAutomationId("_phoneNumber");
        private readonly static SearchCriteria _telephoneSaveButton = SearchCriteria.ByAutomationId("_phoneNumberSaveButton");

           
    

            public static void EnterClientName(string clientName)
            {
                var clientNameTabPage = window.Get<TabPage>(_clientNameTabPage);
                var clientNameGroupBox = clientNameTabPage.Get<GroupBox>(_clientNameGroupBox);
                var clientNameTextBox = clientNameGroupBox.Get<TextBox>(_clientNameTextBox);
                clientNameTextBox.Enter(clientName);
                Button clientNameSaveButton = clientNameTabPage.Get<Button>(_clientNameSaveButton);
                clientNameSaveButton.RaiseClickEvent();

            }

            public static void EnterAddress(string streetName,string streetNumber,string postCode,string city)
            {
                    var addressTabPage = window.Get<TabPage>(_addressTabPage);
                    var addressGroupBox = addressTabPage.Get<GroupBox>(_addressGroupBox);
                    var streetText = addressGroupBox.Get<TextBox>(_streetText);
                    streetText.Enter(streetName);
                    var numberText = addressGroupBox.Get<TextBox>(_numberText);
                    numberText.Enter(streetNumber);
                    var postalcodeText = addressGroupBox.Get<TextBox>(_postalCodeText);
                    postalcodeText.Enter(postCode);
                    var cityText = addressGroupBox.Get<TextBox>(_cityText);
                    cityText.Enter(city);
                    var Save = addressTabPage.Get<Button>(_addressSaveButton);
                    Save.RaiseClickEvent();
            }

    

            public static void EnterTelephone(string telephoneNumber)
            {       var telephoneTabPage = window.Get<TabPage>(_telephoneTabPage);
            var telephoneGroupBox = telephoneTabPage.Get<GroupBox>(_telephoneGroupBox);
            var telephoneNumberTextBox = telephoneGroupBox.Get<TextBox>(_telephoneNumberTextBox);
            telephoneNumberTextBox.Enter(telephoneNumber);
            var telephoneSaveButton = telephoneTabPage.Get<Button>(_telephoneSaveButton);
                    telephoneSaveButton.RaiseClickEvent();
            }
    
    }
}
