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

        private bool isEdited;
        private bool isDeleted;

        public ContactDetails(ContactEntry selectedContact,
            IDictionary<char, ISet<ContactEntry>> contacts)
        {
            InitializeComponent();
            SelectedContact = selectedContact;
            Contacts = contacts;
            this.Text = $"Details for {SelectedContact}";
            isEdited = isDeleted = false;
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
                foreach (var contactSet in Contacts.Values)
                {
                    var contact = contactSet.FirstOrDefault(
                        c => c.TelephoneNumber == SelectedContact.TelephoneNumber);

                    if (contact != null)
                    {
                        contactSet.Remove(contact);
                        isDeleted = true;
                        break;
                    }
                }

                DialogResult = DialogResult.Yes;
            }
        }

        private void btnSendSMS_Click(object sender, EventArgs e)
        {
            var form = new SendSMS(SelectedContact);

            form.ShowDialog();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            if (isEdited)
                DialogResult = DialogResult.Yes;
            else
                DialogResult = DialogResult.Cancel;
        }

        private void txt_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            if (sender is TextBox textBox)
            {
                var button = GetButton(textBox.Name);

                if (button == null)
                {
                    Console.WriteLine("Button not found!");
                    return;
                }

                button.Visible = true;
                button.Click += this.btnSave_Click;
                textBox.ReadOnly = false;
            }
        }

        private void txt_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                var button = GetButton(textBox.Name);

                if (button == null)
                    return;

                var sb = new StringBuilder();
                sb.Append(char.ToUpper(textBox.Text[0])).Append(textBox.Text.Substring(1));
                textBox.Text = sb.ToString();

                textBox.ReadOnly = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                var textbox = GetTextBox(button.Name[button.Name.Length - 1]);

                if (textbox == null)
                    return;

                foreach (var contactSet in Contacts.Values)
                {
                    var contact = contactSet.FirstOrDefault(
                        c => c.TelephoneNumber == SelectedContact.TelephoneNumber);

                    if (contact != null)
                    {
                        contact.FirstName = txtFirstName.Text;
                        contact.LastName = txtLastName.Text;
                        contact.TelephoneNumber = txtNumber.Text;
                        isEdited = true;
                        break;
                    }
                }

                button.Visible = false;
                textbox.ReadOnly = true;
            }
        }

        private Button GetButton(string textBoxName)
        {
            if (textBoxName == "txtFirstName")
                return btnSave1;
            if (textBoxName == "txtLastName")
                return btnSave2;
            if (textBoxName == "txtNumber")
                return btnSave3;
            return null;
        }

        private TextBox GetTextBox(char buttonNum)
        {
            if (int.TryParse(buttonNum.ToString(), out var num))
            {
                if (num == 1)
                    return txtFirstName;
                if (num == 2)
                    return txtLastName;
                if (num == 3)
                    return txtNumber;
            }

            return null;
        }

        private void ContactDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isEdited || isDeleted)
                DialogResult = DialogResult.Yes;
            else
                DialogResult = DialogResult.Cancel;
        }
    }
}