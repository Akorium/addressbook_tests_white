using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace addressbook_tests_white
{
    public class ApplicationManager
    {
        private readonly GroupHelper groupHelper;
        private readonly EntryHelper entryHelper;
        private readonly NavigationHelper navigationHelper;
        public static string WIN_TITLE = "Free Address Book";
        public ApplicationManager() 
        {
            Application application = Application.Launch(@"c:\FreeAddressBookPortable\AddressBook.exe");
            MainWindow = application.GetWindow(WIN_TITLE);
            groupHelper = new GroupHelper(this);
            entryHelper = new EntryHelper(this);
            navigationHelper = new NavigationHelper(this);
        }
        public void Stop() 
        {
            MainWindow.Get<Button>("uxExitAddressButton").Click();
        }
        public GroupHelper Groups
        { get { return groupHelper; } }
        public Window MainWindow
        { get; private set; }
        public EntryHelper EntryHelper
        { get { return entryHelper; } }
        public NavigationHelper NavigationHelper
        { get { return navigationHelper; } }
    }
}
