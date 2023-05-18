using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_tests_white
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            List<GroupData> oldGroups = manager.Groups.GetGroupList();
            GroupData newGroup = new GroupData()
            {
                Name = "NewGroup"
            };
            manager.Groups.Add(newGroup);
            List<GroupData> newGroups = manager.Groups.GetGroupList();

            oldGroups.Add(newGroup);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
