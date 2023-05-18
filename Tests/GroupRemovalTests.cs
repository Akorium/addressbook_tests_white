using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_tests_white
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        private readonly int _groupToRemove = 4;
        [Test]
        public void GroupRemovalTest()
        {
            List <GroupData> oldGroups = manager.Groups.CheckGroups(_groupToRemove);
            manager.Groups.Remove(_groupToRemove);
            List<GroupData> newGroups = manager.Groups.GetGroupList();
            oldGroups.RemoveAt(_groupToRemove);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
