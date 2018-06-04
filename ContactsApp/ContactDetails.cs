using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactsApp
{
    public partial class ContactDetails : Form
    {
        public ContactEntry SelectedContact { get; set; }
        public IDictionary<char, ISet<ContactEntry>> Contacts { get; set; }

        public ContactDetails(ContactEntry selectedContact,
            IDictionary<char, ISet<ContactEntry>> contacts)
        {
            InitializeComponent();
            SelectedContact = selectedContact;
            Contacts = contacts;
            this.Text = $"Details for {SelectedContact}";
        }

        private void ContactDetails_Load(object sender, EventArgs e)
        {
            txtFirstName.Text = $"{SelectedContact.FirstName}";
            txtLastName.Text = $"{SelectedContact.LastName}";
            txtNumber.Text = $"{SelectedContact.TelephoneNumber}";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are you sure you want to delete {SelectedContact}?", "Delete a contact",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                foreach (var contactSets in Contacts.Values)
                {
                    var contact = contactSets.FirstOrDefault(
                        c => c.TelephoneNumber == SelectedContact.TelephoneNumber);

                    if (contact != null)
                    {
                        contactSets.Remove(contact);
                        break;
                    }
                }

                DialogResult = DialogResult.Yes;
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}