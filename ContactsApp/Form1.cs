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
            Generate();
            Display();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.View = View.Tile;
            listView2.View = View.Tile;
            listView2.Visible = false;

            textBox1.BackColor = BlackColor;
            textBox1.ForeColor = Color.Gray;
            textBox1.BorderStyle = BorderStyle.None;

            listView1.BackColor = BlackColor;
            listView1.ForeColor = BlueColor;
            listView1.BorderStyle = BorderStyle.None;

            listView2.BackColor = BlackColor;
            listView2.ForeColor = BlueColor;
            listView2.BorderStyle = BorderStyle.None;

            this.BackColor = BlackColor;
            this.ForeColor = BlueColor;

            button1.Text = "Add contact";
            button1.BackColor = BlackColor;
            button1.ForeColor = BlueColor;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;

            button2.Text = "Delete contact";
            button2.BackColor = BlackColor;
            button2.ForeColor = BlueColor;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;

            button3.Text = "Send message";
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.BackColor = BlackColor;
            button3.ForeColor = BlueColor;
        }

        private void Generate()
        {
            var contact = new ContactEntry()
            {
                Surname = "Krstev",
                Name = "Kostadin",
                TelephoneNumber = "072 256 652"
            };

            char key = contact.Name[0];

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
                Surname = "Krstev",
                Name = "Andrej",
                TelephoneNumber = "073 354 852"
            };

            key = contact.Name[0];

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
                Surname = "Kompirov",
                Name = "Kompir",
                TelephoneNumber = "072 354 852"
            };

            key = contact.Name[0];

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
                Surname = "Kompirov",
                Name = "Balon",
                TelephoneNumber = "071 354 852"
            };

            key = contact.Name[0];

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
                var sortedSet = contact.Value.OrderBy(c => c.Name).ThenBy(c => c.Surname);
                foreach (var contactEntry in sortedSet)
                {
                    var listViewItem = new ListViewItem()
                    {
                        Text = $"{contactEntry}",
                        Group = listView1.Groups[contact.Key - 'A']
                    };
                    listView1.Items.Add(listViewItem);
                }
            }
        }

        private void textbox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.Text = "Search";
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            string search = textBox1.Text.ToLower();

            if (!search.Equals(""))
            {
                listView1.Visible = false;
                listView2.Visible = true;
                listView2.Items.Clear();

                foreach (var contact in Contacts)
                {
                    var sortedSet = contact.Value.OrderBy(c => c.Name).ThenBy(c => c.Surname);
                    foreach (var contactEntry in sortedSet)
                    {
                        var fullname = $"{contactEntry.Name} {contactEntry.Surname}".ToLower();

                        if (fullname.Contains(search))
                        {
                            var listViewItem = new ListViewItem()
                            {
                                Text = $"{contactEntry}"
                            };
                            listView2.Items.Add(listViewItem);
                        }
                    }
                }
            }
            else
            {
                listView1.Visible = true;
                listView2.Visible = false;
                listView2.Items.Clear();
            }
        }

        private void delete_event(object sender, EventArgs e)
        {
        }

        private void add_event(object sender, EventArgs e)
        {
            Add_Form f = new Add_Form();
            if (f.ShowDialog() == DialogResult.OK)
            {
                ContactEntry contact = new ContactEntry()
                {
                    Name = f.FirstName,
                    Surname = f.LastName,
                    TelephoneNumber = f.TelephoneNumber
                };

                char key = char.ToUpper(contact.Name[0]);

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
    }
}