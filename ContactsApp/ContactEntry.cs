using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    public class ContactEntry
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TelephoneNumber { get; set; }

        public static IComparer<ContactEntry> SurnameComparator =
            Comparer<ContactEntry>.Create((entry1, entry2) => entry1.Surname.CompareTo(entry2.Surname));

        public static IComparer<ContactEntry> NameComparator =
            Comparer<ContactEntry>.Create((entry1, entry2) => entry1.Name.CompareTo(entry2.Name));

        public ContactEntry()
        {
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
    }
}