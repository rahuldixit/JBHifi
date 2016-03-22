using System;
using System.Drawing;

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
using System.Threading;

namespace White.Windows
{
    public class ClientSearchForm : WindowBase
    {

            private readonly static SearchCriteria _ExistingClientsTab = SearchCriteria.ByAutomationId("tabControl1");
            private readonly static SearchCriteria _ExistingClientsTabPage = SearchCriteria.ByText("tabPage1");
            private readonly static SearchCriteria _ExistingClientsGroupBox = SearchCriteria.ByText("Existing clients");
            private readonly static SearchCriteria _ExistingClientsList = SearchCriteria.ByAutomationId("_clients");
            private readonly static SearchCriteria _ClientsMenuBar = SearchCriteria.ByAutomationId("menuStrip1");
            private readonly static SearchCriteria _ClientMenuItem = SearchCriteria.ByText("Client");
            private readonly static SearchCriteria _AddNewClientMenuItem = SearchCriteria.ByText("Add a new client");
            public static int listCount;

            public static void setExistingClientsCount()
        {
            var ExistingClientsTab = window.Get<Tab>(_ExistingClientsTab);
            var ExistingClientsTabPage = ExistingClientsTab.Get<TabPage>(_ExistingClientsTabPage);
            var ExistingClientsGroupBox = ExistingClientsTabPage.Get<GroupBox>(_ExistingClientsGroupBox);
            var ExistingClientsList = ExistingClientsGroupBox.Get<ListBox>(_ExistingClientsList);
            listCount = ExistingClientsList.Items.Count;
        }

        public static void RaiseNewClientWindow()
        {
            //raise client name window
            var ClientsMenuBar = window.Get<MenuBar>(_ClientsMenuBar);
            var ClientMenuItem = ClientsMenuBar.MenuItemBy(_ClientMenuItem);
            var AddNewClientMenuItem = ClientMenuItem.SubMenu(_AddNewClientMenuItem);
            AddNewClientMenuItem.RaiseClickEvent();
        }

    
        public static void VerifyClientAdded(string clientName)
        {
             var ExistingClientsTab = window.Get<Tab>(_ExistingClientsTab);
             //var ExistingClientsTabPage = ExistingClientsTab.Get<TabPage>(_ExistingClientsTabPage);
             var ExistingClientsGroupBox = ExistingClientsTab.Get<GroupBox>(_ExistingClientsGroupBox);
             var ExistingClientsList = ExistingClientsGroupBox.Get<ListBox>(_ExistingClientsList);
             Thread.Sleep(2000);
             var listItem = ExistingClientsList.Items.Item(listCount);
             Assert.IsTrue(listItem.Text == clientName);
        }

        internal static void ViewClientDetails(string account)
        {
            var ExistingClientsTab = window.Get<Tab>(_ExistingClientsTab);
            //var ExistingClientsTabPage = ExistingClientsTab.Get<TabPage>(_ExistingClientsTabPage);
            var ExistingClientsGroupBox = ExistingClientsTab.Get<GroupBox>(_ExistingClientsGroupBox);
            var ExistingClientsList = ExistingClientsGroupBox.Get<ListBox>(_ExistingClientsList);
            Thread.Sleep(2000);          
            ExistingClientsList.Select(account);
            
        
        }
    }
}
