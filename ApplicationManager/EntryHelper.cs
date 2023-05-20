using System.Collections.Generic;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TableItems;
using TestStack.White.UIItems.WindowItems;

namespace addressbook_tests_white
{
    public class EntryHelper : HelperBase
    {
        private const string _contactEditorTitle = "Contact Editor";
        private const string _submitEntryRemovalTitle = "Question";

        public EntryHelper(ApplicationManager manager) : base(manager) { }

        public List<EntryData> GetEntryList()
        {
            List<EntryData> entries = new List<EntryData>();
            TableRows rows = GetRows();
            foreach (TableRow row in rows)
            {
                string firstname = row.Cells[0].Value.ToString();
                string lastname = row.Cells[1].Value.ToString();
                entries.Add(new EntryData(firstname, lastname));
            }
            return entries;
        }

        private TableRows GetRows()
        {
            Table data = manager.MainWindow.Get<Table>("uxAddressGrid");
            TableRows rows = data.Rows;
            return rows;
        }

        public void CreateEntry(EntryData newEntry)
        {
            Window entryEditorWindow = manager.NavigationHelper.OpenWindow(manager.MainWindow, "uxNewAddressButton", _contactEditorTitle);
            entryEditorWindow.Get<TextBox>("ueFirstNameAddressTextBox").Enter(newEntry.Firstname);
            entryEditorWindow.Get<TextBox>("ueLastNameAddressTextBox").Enter(newEntry.Lastname);
            entryEditorWindow.Get<Button>("uxSaveAddressButton").Click();
        }

        public List<EntryData> ChechEntries(int entryToRemove)
        {
            List<EntryData> entries = GetEntryList();
            TableRows rows = GetRows();
            int entriesToAdd = ++entryToRemove - rows.Count;
            if (entriesToAdd <= 0)
            {
                return entries;
            }
            else
            {
                for (int i = 0; i < entriesToAdd; i++)
                {
                    AddDefaultEntry();
                }
                return GetEntryList();
            }
        }

        private void AddDefaultEntry()
        {
            EntryData defaultEntry = new EntryData("defaultFirstname", "defaultLastname");
            CreateEntry(defaultEntry);
        }

        public void Remove(int entryToRemove)
        {
            TableRows rows = GetRows();
            rows[entryToRemove].Click();
            Window submitEntryRemove = manager.NavigationHelper.OpenWindow(manager.MainWindow, "uxDeleteAddressButton", _submitEntryRemovalTitle);
            Button acceptButton = (Button) submitEntryRemove.Get(SearchCriteria.ByText("Yes"));
            acceptButton.Click();
        }
    }
}
