using System.Collections.Generic;
using System.Windows.Automation;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.WindowsAPI;

namespace addressbook_tests_white
{
    public class GroupHelper : HelperBase
    {
        public static string GROUP_WIN_TITLE = "Group editor";
        public static string DELETE_GROUP_WIN_TITLE = "Delete group";
        public GroupHelper (ApplicationManager manager) : base(manager) { }

        public void Add(GroupData newGroup)
        {
            Window groupsWindow = manager.NavigationHelper.OpenWindow(manager.MainWindow, "groupButton", GROUP_WIN_TITLE);
            manager.MainWindow.Get<Button>("uxNewAddressButton").Click();
            TextBox textBox = (TextBox) groupsWindow.Get(SearchCriteria.ByControlType(ControlType.Edit));
            textBox.Enter(newGroup.Name);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            CloseGroupsDialogue(groupsWindow);
        }
        private void CloseGroupsDialogue(Window window)
        {
            window.Get<Button>("uxCloseAddressButton").Click();
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> groups = new List<GroupData>();
            Window groupsWindow = manager.NavigationHelper.OpenWindow(manager.MainWindow, "groupButton", GROUP_WIN_TITLE);
            TreeNode root = GetRoot(groupsWindow);
            foreach (TreeNode item in root.Nodes)
            {
                groups.Add(new GroupData()
                {
                    Name = item.Text
                });
            }
            CloseGroupsDialogue(groupsWindow);
            return groups;
        }

        public void Remove(int groupToRemove)
        {
            Window groupsWindow = manager.NavigationHelper.OpenWindow(manager.MainWindow, "groupButton", GROUP_WIN_TITLE);
            TreeNode root = GetRoot(groupsWindow);
            root.Nodes[groupToRemove].Click();
            ConfirmGroupRemoval(groupsWindow);
            CloseGroupsDialogue(groupsWindow);
        }

        private void ConfirmGroupRemoval(Window groupsWindow)
        {
            Window deleteGroupWindow = manager.NavigationHelper.OpenWindow(groupsWindow, "uxDeleteAddressButton", DELETE_GROUP_WIN_TITLE);
            deleteGroupWindow.Get<RadioButton>("uxDeleteAllRadioButton").Click();
            deleteGroupWindow.Get<Button>("uxOKAddressButton").Click();
        }

        public List<GroupData> CheckGroups(int groupToRemove)
        {
            List<GroupData> groups = GetGroupList();
            Window groupsWindow = manager.NavigationHelper.OpenWindow(manager.MainWindow, "groupButton", GROUP_WIN_TITLE);
            TreeNode root = GetRoot(groupsWindow);
            int groupsToAdd = ++groupToRemove - root.Nodes.Count;
            CloseGroupsDialogue(groupsWindow);
            if (groupsToAdd <= 0)
            {
                return groups;
            }
            else
            {
                for (int i = 0; i < groupsToAdd; i++)
                {
                    AddDefaultGroup();
                }
                return GetGroupList();
            }
        }

        private static TreeNode GetRoot(Window window)
        {
            Tree tree = window.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0];
            return root;
        }

        private void AddDefaultGroup()
        {
            GroupData group = new GroupData()
            {
                Name = "default"
            };
            Add(group);
        }
    }
}