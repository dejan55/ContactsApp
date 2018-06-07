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
using MixERP.Net.VCards;
using MixERP.Net.VCards.Models;
using MixERP.Net.VCards.Serializer;
using MixERP.Net.VCards.Types;

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

            menuStrip1.BackColor = BlackColor;
            menuStrip1.ForeColor = BlueColor;

            foreach (ToolStripItem item in menuStrip1.Items)
            {
                item.ForeColor = BlueColor;
                item.BackColor = BlackColor;

                if (item is ToolStripMenuItem menuItem)
                {
                    menuItem.MouseEnter += this.ToolStripMenuItem_MouseEnter;
                    menuItem.MouseLeave += this.ToolStripMenuItem_MouseLeave;

                    foreach (var dropDownItem in menuItem.DropDownItems)
                    {
                        if (dropDownItem is ToolStripDropDownItem ddItem)
                        {
                            ddItem.ForeColor = BlueColor;
                            ddItem.BackColor = BlackColor;
                            ddItem.MouseEnter += this.ToolStripMenuItem_MouseEnter;
                            ddItem.MouseLeave += this.ToolStripMenuItem_MouseLeave;
                        }
                    }
                }
            }


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

            /*contact = new ContactEntry()
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
            }*/

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
            if (txtSearch.Text.Trim().Equals("Search..."))
                txtSearch.Text = "";
            txtSearch.BorderStyle = BorderStyle.Fixed3D;
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
        }

        private void txtSearch_MouseEnter(object sender, EventArgs e)
        {
            if (txtSearch.Focused && txtSearch.Text.Trim().Equals("Search..."))
                txtSearch.Text = string.Empty;
        }

        private void txtSearch_MouseLeave(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim().Equals(""))
                txtSearch.Text = "Search...";
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtSearch.Text.Trim().Equals("Search..."))
                txtSearch.Text = "";
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Visible = listView2.Visible = false;
            listView1.Visible = true;
            txtSearch.Text = "Search...";
        }

        private void Add_button_Click(object sender, EventArgs e)
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

                if (IsDuplicate(contact.TelephoneNumber))
                    return;

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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit the application", "Quit the application",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                e.Cancel = true;
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

        private bool IsDuplicate(string number)
        {
            foreach (var entry in Contacts)
            {
                foreach (var usr in entry.Value)
                {
                    if (usr.TelephoneNumber.Equals(number))
                    {
                        MessageBox.Show(
                            "You have this number saved with different name.\n" +
                            $"Here are the informations: {usr} {usr.TelephoneNumber}",
                            "Found duplicate",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                }
            }

            return false;
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Console.WriteLine($"Desktop path: [{desktop}]");

            var path = Path.Combine(desktop, "Vcards");
            Console.WriteLine($"Vcards folder path: [{path}]");

            var vcardPath = Path.Combine(path, "vcard.vcf");
            Console.WriteLine($"Vcard file path [{vcardPath}]");

            Console.WriteLine("Export is starting...");

            try
            {
                Console.WriteLine($"Attempting to create [{path}]...");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                    Console.WriteLine($"Directory [{path}] created.");
                }
                else
                    Console.WriteLine($"Directory [{path}] already exists.");

                if (File.Exists(vcardPath))
                {
                    Console.WriteLine($"Deleting [{vcardPath}]");
                    File.Delete(vcardPath);
                    Console.WriteLine($"Deleted [{vcardPath}]");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"EXCEPTION: {ex.Message}");
                MessageBox.Show($"Export was not successful.\n{ex.Message}", "Error while exporting");
            }

            foreach (var contactsSet in Contacts.Values)
            {
                foreach (var contact in contactsSet)
                {
                    var vcard = new VCard()
                    {
                        Version = VCardVersion.V2_1,
                        FirstName = contact.FirstName,
                        LastName = contact.LastName,
                        Telephones = new List<Telephone>()
                        {
                            new Telephone()
                            {
                                Number = contact.TelephoneNumber,
                                Type = TelephoneType.Cell
                            }
                        }
                    };

                    try
                    {
                        Console.WriteLine($"Attempting to serialize [{contact} " +
                                          $"{contact.TelephoneNumber}]...");
                        File.AppendAllText(vcardPath, vcard.Serialize());
                        Console.WriteLine($"Successfully serialized [{contact} " +
                                          $"{contact.TelephoneNumber}] to [{vcardPath}]");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"EXCEPTION: {ex.Message}");
                        MessageBox.Show($"Export was not successful.\n{ex.Message}",
                            "Error while exporting");
                    }
                }
            }

            Console.WriteLine("Exporting completed");
            MessageBox.Show($"Contacts have been exported to [{vcardPath}]", "Exported successfully",
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string vcardPath = string.Empty;

            var dialog = new OpenFileDialog();
            dialog.Filter = "VCard files (*.vcf) | *.vcf";
            dialog.Title = "Choose a VCard file to import";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                vcardPath = dialog.FileName;
                Console.WriteLine($"[{vcardPath}] was picked.");
            }
            else
            {
                Console.WriteLine("File choosing was canceled!");
                return;
            }

            IEnumerable<VCard> vcards = null;
            try
            {
                Console.WriteLine($"Attempting to deserialize [{vcardPath}]...");
                vcards = Deserializer.Deserialize(vcardPath);
                Console.WriteLine("Deserialization successful!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"EXCEPTION: {ex.Message}");
                MessageBox.Show($"Import was not successful.\n{ex.Message}",
                    "Error while importing");
            }

            if (vcards == null)
                return;

            foreach (var vcard in vcards)
            {
                Console.WriteLine("Creating a contact from the vcard...");
                var contact = new ContactEntry()
                {
                    FirstName = vcard.FirstName,
                    LastName = vcard.LastName,
                    TelephoneNumber = vcard.Telephones.ElementAt(0).Number
                };

                Console.WriteLine("Checking for duplicated contact...");
                if (IsDuplicate(contact.TelephoneNumber))
                {
                    Console.WriteLine($"Duplicate found! [{contact}]");
                    continue;
                }

                Console.WriteLine($"Adding [{contact} {contact.TelephoneNumber}] to the contacts");
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

            Console.WriteLine("Importing completed");
            Display();
            MessageBox.Show($"Contacts have been imported from [{vcardPath}]", "Imported successfully",
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            base.OnMouseEnter(e);
        }

        private void ToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            base.OnMouseLeave(e);
        }
    }
}