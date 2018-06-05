using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactsApp.Properties;

namespace ContactsApp
{
    public partial class Form1 : Form
    {
        private static readonly Color BlueColor = Color.FromArgb(27, 93, 198);
        private static readonly Color WhiteColor = Color.FromArgb(255, 255, 255);
        private static readonly Color BlackColor = Color.FromArgb(35, 35, 35);
        private static readonly Label[] Labels = new Label[26];

        private static readonly Font CustomFont = new Font("Verdana", 22F, FontStyle.Regular,
            GraphicsUnit.Point, ((byte) (0)));

        public IDictionary<char, ISet<ContactEntry>> Contacts { get; set; }

        public Form1()
        {
            InitializeComponent();
            Contacts = new SortedDictionary<char, ISet<ContactEntry>>();
            this.DoubleBuffered = true;
            Generate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.View = View.Tile;
            listView1.Visible = true;
            listView1.BackColor = BlackColor;
            listView1.ForeColor = BlueColor;
            listView1.BorderStyle = BorderStyle.None;

            listView2.View = View.Tile;
            listView2.Visible = false;
            listView2.BackColor = BlackColor;
            listView2.ForeColor = BlueColor;
            listView2.BorderStyle = BorderStyle.None;

            txtSearch.BackColor = BlackColor;
            txtSearch.ForeColor = Color.Gray;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;

            this.BackColor = BlackColor;
            this.ForeColor = BlueColor;

            Add_button.BackColor = BlackColor;
            Add_button.ForeColor = BlueColor;
            Add_button.FlatAppearance.BorderSize = 0;
            Add_button.FlatStyle = FlatStyle.Flat;

            btnCancel.BackColor = BlueColor;
            btnCancel.ForeColor = WhiteColor;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            Display();
        }

        private void Generate()
        {
            var contact = new ContactEntry()
            {
                LastName = "Krstev",
                FirstName = "Kostadin",
                TelephoneNumber = "072 256 652"
            };

            char key = contact.FirstName[0];

            if (Contacts.ContainsKey(key))
            {
                Contacts[key].Add(contact);
            }
            else
            {
                Contacts[key] = new HashSet<ContactEntry>(ContactEntry.TelephoneComparer);
                Contacts[key].Add(contact);
            }

            contact = new ContactEntry()
            {
                LastName = "Krstev",
                FirstName = "Andrej",
                TelephoneNumber = "073 354 852"
            };

            key = contact.FirstName[0];

            if (Contacts.ContainsKey(key))
            {
                Contacts[key].Add(contact);
            }
            else
            {
                Contacts[key] = new HashSet<ContactEntry>(ContactEntry.TelephoneComparer);
                Contacts[key].Add(contact);
            }

            contact = new ContactEntry()
            {
                LastName = "Kompirov",
                FirstName = "Kompir",
                TelephoneNumber = "072 354 852"
            };

            key = contact.FirstName[0];

            if (Contacts.ContainsKey(key))
            {
                Contacts[key].Add(contact);
            }
            else
            {
                Contacts[key] = new HashSet<ContactEntry>(ContactEntry.TelephoneComparer);
                Contacts[key].Add(contact);
            }

            contact = new ContactEntry()
            {
                LastName = "Kompirov",
                FirstName = "Balon",
                TelephoneNumber = "071 354 852"
            };

            key = contact.FirstName[0];

            if (Contacts.ContainsKey(key))
            {
                Contacts[key].Add(contact);
            }
            else
            {
                Contacts[key] = new HashSet<ContactEntry>(ContactEntry.TelephoneComparer);
                Contacts[key].Add(contact);
            }

            contact = new ContactEntry()
            {
                LastName = "Nakov",
                FirstName = "Jovan",
                TelephoneNumber = "078 736 391"
            };

            key = contact.FirstName[0];

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

        private void Display()
        {
            listView1.Items.Clear();

            for (int i = 'A'; i <= 'Z'; i++)
            {
                listView1.Groups.Add(new ListViewGroup($"{(char) i}"));
            }

            foreach (var contact in Contacts)
            {
                var sortedSet = contact.Value.OrderBy(c => c.FirstName).ThenBy(c => c.LastName);
                foreach (var contactEntry in sortedSet)
                {
                    var listViewItem = new ListViewItem()
                    {
                        Text = $"{contactEntry}",
                        Group = listView1.Groups[contact.Key - 'A'],
                        ToolTipText = $"{contactEntry.TelephoneNumber}"
                    };
                    listView1.Items.Add(listViewItem);
                }
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            txtSearch.BorderStyle = BorderStyle.Fixed3D;
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            string search = txtSearch.Text.Trim().ToLower();

            if (!search.Equals(""))
            {
                listView1.Visible = false;
                listView2.Visible = btnCancel.Visible = true;
                listView2.Items.Clear();

                foreach (var contact in Contacts)
                {
                    var sortedSet = contact.Value.OrderBy(c => c.FirstName).ThenBy(c => c.LastName);
                    foreach (var contactEntry in sortedSet)
                    {
                        var fullname = $"{contactEntry.FirstName} {contactEntry.LastName}".ToLower();

                        if (fullname.Contains(search))
                        {
                            var listViewItem = new ListViewItem()
                            {
                                Text = $"{contactEntry}",
                                ToolTipText = $"{contactEntry.TelephoneNumber}"
                            };
                            listView2.Items.Add(listViewItem);
                        }
                    }
                }
            }
            else
            {
                listView1.Visible = true;
                listView2.Visible = btnCancel.Visible = false;
                listView2.Items.Clear();
            }
        }


        private void add_event(object sender, EventArgs e)
        {
            AddForm f = new AddForm();
            if (f.ShowDialog() == DialogResult.OK)
            {
                ContactEntry contact = new ContactEntry()
                {
                    FirstName = f.FirstName,
                    LastName = f.LastName,
                    TelephoneNumber = f.TelephoneNumber
                };

                char key = char.ToUpper(contact.FirstName[0]);

                if (Contacts.ContainsKey(key))
                {
                    Contacts[key].Add(contact);
                }
                else
                {
                    Contacts[key] = new HashSet<ContactEntry>(ContactEntry.TelephoneComparer);
                    Contacts[key].Add(contact);
                }

                Display();
            }
        }

        private void Add_button_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            base.OnMouseEnter(e);
        }

        private void Add_button_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            base.OnMouseLeave(e);
        }

        private void listViews_MouseDown(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo test;
            if (listView1.Visible)
                test = listView1.HitTest(e.Location);
            else
                test = listView2.HitTest(e.Location);

            if (test.Location != ListViewHitTestLocations.Label)
                return;
            // debugging purposes
            Console.WriteLine($"{test.Item}");
            var form = new ContactDetails(GetContact(test.Item), Contacts);
            var result = form.ShowDialog();

            if (result == DialogResult.Yes) // update the ListView
            {
                Contacts = form.Contacts;
                Display();
                btnCancel_Click(sender, e);
            }
        }

        private ContactEntry GetContact(ListViewItem selectedItem)
        {
            foreach (var contact in Contacts.Values)
            {
                var result = contact.FirstOrDefault(c => c.TelephoneNumber == selectedItem.ToolTipText);
                if (result != null)
                    return result;
            }

            return null;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Visible = listView2.Visible = false;
            listView1.Visible = true;
            txtSearch.Text = "Search...";
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit the application", "Quit the application",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }
    }
}