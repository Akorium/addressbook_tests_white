using System;

namespace addressbook_tests_white
{
    public class GroupData : IComparable <GroupData>, IEquatable<GroupData>
    {
        public string Name { get; set; }

        public int CompareTo(GroupData other)
        {
            return Name.CompareTo(other.Name);
        }

        public bool Equals(GroupData other)
        {
            return Name.Equals(other.Name);
        }
    }
}
