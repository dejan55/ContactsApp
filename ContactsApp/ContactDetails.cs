﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactsApp
{
    public partial class ContactDetails : Form
    {
        private static readonly Color BlueColor = Color.FromArgb(27, 93, 198);
        private static readonly Color WhiteColor = Color.FromArgb(255, 255, 255);
        private static readonly Color BlackColor = Color.FromArgb(35, 35, 35);


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

            groupBox1.ForeColor = WhiteColor;

            label1.ForeColor = BlueColor;
            label2.ForeColor = BlueColor;
            label3.ForeColor = BlueColor;
            label4.ForeColor = BlueColor;

            this.BackColor = BlackColor;
            this.ForeColor = BlueColor;

            btnDelete.BackColor = BlackColor;
            btnDelete.FlatStyle = FlatStyle.Flat;

            btnSendSMS.BackColor = BlackColor;
            btnSendSMS.FlatStyle = FlatStyle.Flat;
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

                btnSave1.Visible = btnSave2.Visible = btnSave3.Visible = false;

                DialogResult = DialogResult.Yes;
            }

            btnSave1.Visible = btnSave2.Visible = btnSave3.Visible = false;
        }

        private void btnSendSMS_Click(object sender, EventArgs e)
        {
            btnSave1.Visible = btnSave2.Visible = btnSave3.Visible = false;

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
            btnSave1.Visible = btnSave2.Visible = btnSave3.Visible = false;
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
                button.BackColor = BlackColor;
                button.ForeColor = BlueColor;
                button.FlatStyle = FlatStyle.Flat;
                button.Font = new Font("Microsoft Sans Serif", 6F, FontStyle.Regular, GraphicsUnit.Point);
                button.Click += this.btnSave_Click;

                textBox.ReadOnly = false;
            }
        }


        private void txt_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (textBox.Text.Trim().Equals(""))
                {
                    errorProvider1.SetError(textBox, "First name cannot be empty!");
                    return;
                }

                errorProvider1.Clear();

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
                        contactSet.Remove(contact);
                        isEdited = true;
                        break;
                    }
                }

                if (isEdited)
                {
                    var contact = new ContactEntry()
                    {
                        FirstName = txtFirstName.Text.Trim(),
                        LastName = txtLastName.Text.Trim(),
                        TelephoneNumber = txtNumber.Text.Trim()
                    };
                    var key = contact.FirstName[0];

                    if (Contacts.ContainsKey(key))
                    {
                        Contacts[key].Add(contact);
                    }
                    else
                    {
                        Contacts[key] = new HashSet<ContactEntry>(ContactEntry.TelephoneComparer);
                        Contacts[key].Add(contact);
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

        private void txtNumber_Validating(object sender, CancelEventArgs e)
        {
            if (txtNumber.Text.Trim().Equals(""))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNumber, "Telephone number cannot be empty!");
            }
            else if (!Regex.IsMatch(txtNumber.Text.Trim(),
                @"^07[0-35-9]\s[0-9]{3}\s[0-9]{3}$", RegexOptions.IgnoreCase))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNumber, "Invalid format! (07X YYY ZZZ)");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.Clear();
            }
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (txtFirstName.Text.Trim().Equals(""))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFirstName, "First name cannot be empty!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.Clear();
            }
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            if (txtLastName.Text.Trim().Equals(""))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtLastName, "Last name cannot be empty!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.Clear();
            }
        }

        private void txt_Click(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                var button = GetButton(textBox.Name);

                if (button == null)
                {
                    Console.WriteLine("Button not found!");
                    return;
                }

                if (button.Visible)
                {
                    if (button.Name == btnSave1.Name)
                        btnSave2.Visible = btnSave3.Visible = false;
                    else if (button.Name == btnSave2.Name)
                        btnSave1.Visible = btnSave3.Visible = false;
                    else if (button.Name == btnSave3.Name)
                        btnSave1.Visible = btnSave2.Visible = false;
                }
                else
                {
                    btnSave1.Visible = btnSave2.Visible = btnSave3.Visible = false;
                }
            }
        }
    }
}