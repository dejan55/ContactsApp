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
            // this.Font = new Font("Verdana", 16F, FontStyle.Regular);

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

            contact = new ContactEntry()
            {
                LastName = "Kompirov",
                FirstName = "Balon",
                TelephoneNumber = "073 654 555"
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

            listView1.Groups.Add(new ListViewGroup("#"));

            for (int i = 'A'; i <= 'Z'; i++)
            {
                listView1.Groups.Add(new ListViewGroup($"{(char) i}"));
            }

            foreach (var contact in Contacts)
            {
                var sortedSet = contact.Value.OrderBy(c => c.FirstName).ThenBy(c => c.LastName);
                foreach (var contactEntry in sortedSet)
                {
                    Console.WriteLine($"Key: {contact.Key}\n" +
                                      $"Contact: {contactEntry} {contactEntry.TelephoneNumber}");

                    ListViewGroup group;
                    if (char.IsLetter(contact.Key))
                        group = listView1.Groups[(contact.Key - 'A') + 1];
                    else
                        group = listView1.Groups[0];

                    string text;
                    if (char.IsLetter(contact.Key))
                        text = $"{contactEntry}";
                    else
                        text = $"{contactEntry.TelephoneNumber}";

                    var listViewItem = new ListViewItem()
                    {
                        Text = text,
                        Group = group,
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
            if (txtSearch.Text.Trim().Equals("Search..."))
                txtSearch.Text = string.Empty;
            txtSearch.BorderStyle = BorderStyle.Fixed3D;
            txtSearch.Focus();
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

            if (!search.Equals("") && !search.Equals("Search..."))
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
                txtSearch.Text = "Search...";
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
                    TelephoneNumber = f.TelephoneNumber,
                    Email = f.Mail
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

        private bool IsDuplicate(string number, bool importing = false)
        {
            foreach (var entry in Contacts)
            {
                foreach (var usr in entry.Value)
                {
                    if (usr.TelephoneNumber.Equals(number))
                    {
                        if (!importing)
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
                return;
            }

            var counter = 0;
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
                        },
                        Emails = new List<Email>()
                        {
                            new Email()
                            {
                                EmailAddress = contact.Email,
                                Type = EmailType.Smtp
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
                        counter++;
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
            MessageBox.Show($"{counter} contacts have been exported to [{vcardPath}]", "Exported successfully",
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var vcardPath = string.Empty;
            var counterUnsuccessful = 0;

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

                ContactEntry contact = null;
                try
                {
                    Email email;
                    var emails = vcard.Emails;
                    if (emails == null)
                        email = new Email() { EmailAddress = string.Empty };
                    else
                    {
                        email = vcard.Emails.ElementAtOrDefault(0);
                        if (email == null)
                            email = new Email() {EmailAddress = string.Empty};
                    }

                    contact = new ContactEntry()
                    {
                        FirstName = vcard.FirstName.Trim(),
                        LastName = vcard.LastName.Trim(),
                        TelephoneNumber = vcard.Telephones.ElementAt(0).Number.Trim(),
                        Email = email.EmailAddress.Trim()
                    };
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"EXCEPTION: {ex.Message}");
                }

                if (contact == null)
                {
                    counterUnsuccessful++;
                    continue;
                }

                Console.WriteLine("Checking for duplicated contact...");
                if (IsDuplicate(contact.TelephoneNumber, importing: true))
                {
                    Console.WriteLine($"Duplicate found! [{contact}]");
                    counterUnsuccessful++;
                    continue;
                }

                Console.WriteLine($"Adding [{contact} {contact.TelephoneNumber}] to the contacts");

                char key;
                if (!string.IsNullOrEmpty(contact.FirstName))
                    key = char.ToUpper(contact.FirstName[0]);
                else
                {
                    if (!string.IsNullOrEmpty(contact.LastName))
                        key = char.ToUpper(contact.LastName[0]);
                    else
                        key = '#';
                }

                if (!char.IsLetter(key) && key != '#')
                    key = '#';

                if (Contacts.ContainsKey(key))
                {
                    Contacts[key].Add(contact);
                }
                else
                {
                    Contacts[key] = new HashSet<ContactEntry>(ContactEntry.TelephoneComparer);
                    Contacts[key].Add(contact);
                }

                Console.WriteLine($"Added [{contact}] to the contacts");
            }

            Console.WriteLine("Importing completed");
            Display();
            MessageBox.Show($"{vcards.Count() - counterUnsuccessful}/{vcards.Count()} contacts have been " +
                            $"imported from [{vcardPath}]", "Imported successfully",
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