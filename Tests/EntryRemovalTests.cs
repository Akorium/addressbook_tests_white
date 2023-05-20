using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_tests_white
{
    [TestFixture]
    public class EntryRemovalTests : TestBase
    {
        private readonly int _entryToRemove = 4;
        [Test]
        public void EntryRemovalTest()
        {
            List<EntryData> oldEntries = manager.EntryHelper.ChechEntries(_entryToRemove);
            manager.EntryHelper.Remove(_entryToRemove);
            List<EntryData> newEntries = manager.EntryHelper.GetEntryList();
            oldEntries.RemoveAt(_entryToRemove);
            oldEntries.Sort();
            newEntries.Sort();

            Assert.AreEqual(oldEntries, newEntries);
        }
    }
}
