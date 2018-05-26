using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    public class ContactEntry : IEquatable<ContactEntry>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TelephoneNumber { get; set; }

        public static IEqualityComparer<ContactEntry>
            TelephoneComparer = EqualityComparer<ContactEntry>.Default;

        public ContactEntry()
        {
            Name = Surname = TelephoneNumber = string.Empty;
        }

        public ContactEntry(string surname, string telephoneNumber)
        {
            Surname = surname;
            TelephoneNumber = telephoneNumber;
        }

        public ContactEntry(string name, string surname, string telephoneNumber)
        {
            Name = name;
            Surname = surname;
            TelephoneNumber = telephoneNumber;
        }

        public override string ToString()
        {
            return $"{Surname} {Name} {TelephoneNumber}";
        }

        public bool Equals(ContactEntry other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(TelephoneNumber, other.TelephoneNumber);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ContactEntry) obj);
        }

        public override int GetHashCode()
        {
            return (TelephoneNumber != null ? TelephoneNumber.GetHashCode() : 0);
        }
    }
}