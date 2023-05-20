using System;

namespace addressbook_tests_white
{
    public class EntryData : IEquatable<EntryData>, IComparable<EntryData>
    {
        public EntryData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public string Firstname { get; set; }
        public string Lastname { get;  set; }

        public int CompareTo(EntryData other)
        {
            return Firstname.CompareTo(other.Firstname);
        }

        public bool Equals(EntryData other)
        {
            return Firstname.Equals(other.Firstname);
        }
    }
}
