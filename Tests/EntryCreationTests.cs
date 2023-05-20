using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_tests_white
{
    [TestFixture]
    public class EntryCreationTests : TestBase
    {
        [Test]
        public void EntryCreationTest()
        {
            List<EntryData> oldEntries = manager.EntryHelper.GetEntryList();
            EntryData newEntry = new EntryData("NewFirstname", "NewLastname");

            manager.EntryHelper.CreateEntry(newEntry);
            List<EntryData> newEntries = manager.EntryHelper.GetEntryList();
            oldEntries.Add(newEntry);
            oldEntries.Sort();
            newEntries.Sort();

            Assert.AreEqual(oldEntries, newEntries);
        }
    }
}
