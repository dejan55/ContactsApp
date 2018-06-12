using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    [Serializable]
    public class ContactEntry : IEquatable<ContactEntry>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public string ImageBase64 { get; set; }

        public static IEqualityComparer<ContactEntry>
            TelephoneComparer = EqualityComparer<ContactEntry>.Default;

        public ContactEntry()
        {
            FirstName = LastName = TelephoneNumber = Email = ImageBase64 = string.Empty;
        }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName))
                return $"{FirstName} {LastName}";
            if (string.IsNullOrEmpty(FirstName))
                return $"{LastName}";
            if (string.IsNullOrEmpty(LastName))
                return $"{FirstName}";
            return $"{TelephoneNumber}";
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