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
    class ClientAccountDetails : WindowBase
    {

        private readonly static SearchCriteria _menubar = SearchCriteria.ByText("menuStrip1");
        private readonly static SearchCriteria _account = SearchCriteria.ByText("Account");
         private readonly static SearchCriteria _closeAccount = SearchCriteria.ByText("Close account");


        internal static void DeleteAccount(string account)
        {
            var menuBar = window.Get<MenuBar>(_menubar);
            menuBar.MenuItem("Account").RaiseClickEvent();
            var closeAccount = menuBar.MenuItem("Account").SubMenu(_closeAccount);
            closeAccount.RaiseClickEvent();

        }


    }
}
