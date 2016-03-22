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
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace White.Windows
{
    class ClientAccount : WindowBase
    {

        private readonly static SearchCriteria _menuBar = SearchCriteria.ByAutomationId("menuStrip1");
        private readonly static SearchCriteria _accountsmenuItem = SearchCriteria.ByText("Accounts");
        private readonly static SearchCriteria _AddNewAccount = SearchCriteria.ByText("Add new account");
        private readonly static SearchCriteria _mainTab = SearchCriteria.ByAutomationId("tabControl1");
        private readonly static SearchCriteria _clientaccountsgroupBox = SearchCriteria.ByText("Client accounts");
        private readonly static SearchCriteria _list = SearchCriteria.ByAutomationId("_accounts");
        private readonly static SearchCriteria _addAccountGroup = SearchCriteria.ByAutomationId("groupBox3");
        private readonly static SearchCriteria _accountName = SearchCriteria.ByAutomationId("_newAccountName");
        private readonly static SearchCriteria _accountCreate = SearchCriteria.ByAutomationId("_newAccountCreateButton");
       
        internal static void AddAccount(string AccountName)
        {
            var menuBar =  window.Get<MenuBar>(_menuBar);
            menuBar.RaiseClickEvent();
            var ClientMenuItem = menuBar.MenuItemBy(_accountsmenuItem);
            ClientMenuItem.RaiseClickEvent();
            var addAccount = ClientMenuItem.Get(_AddNewAccount);
            addAccount.Click();
            var AccountNameTextField = window.Get(_accountName);
            AccountNameTextField.Enter(AccountName);
            var accountCreateButton = window.Get(_accountCreate);
            accountCreateButton.Click();
        }

        internal static void AccountIsInList(string account)
        {
            var mainTab = window.Get<Tab>(_mainTab);
            var groupBox = mainTab.Get<GroupBox>(_clientaccountsgroupBox);
            var list = groupBox.Get<ListBox>(_list);
            try{
            var listItem = list.Items.Find(t=>t.Text.Contains(account));            
            }
            catch(Exception)
            {
                Assert.Fail();
            }
        }

        internal static void DeleteAccount(string account)
        {
            var mainTab = window.Get<Tab>(_mainTab);
            var groupBox = mainTab.Get<GroupBox>(_clientaccountsgroupBox);
            var list = groupBox.Get<ListBox>(_list);
            var listItem = list.Items.Find(t=>t.Text.Contains(account));            
            //var text = listItem.Text;
            listItem.DoubleClick();
        }

        internal static void AccountIsNotInList(string account)
        {
            var mainTab = window.Get<Tab>(_mainTab);
            var groupBox = mainTab.Get<GroupBox>(_clientaccountsgroupBox);
            var list = groupBox.Get<ListBox>(_list);
           var listItem = list.Items.Find(t=>t.Text.Contains(account));  
            if(listItem!=null)
                throw new AssertFailedException("Account is not closed");
        
        }

    
    }
}
