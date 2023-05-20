using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace addressbook_tests_white
{
    public class NavigationHelper : HelperBase
    {
        public NavigationHelper(ApplicationManager manager) : base(manager) { }
        public Window OpenWindow(Window currentWindow, string buttonId, string nextWindowTitle)
        {
            currentWindow.Get<Button>(buttonId).Click();
            return currentWindow.ModalWindow(nextWindowTitle);
        }
    }
}
