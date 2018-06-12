using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ContactsApp.Exceptions;
using MixERP.Net.VCards;
using MixERP.Net.VCards.Models;
using MixERP.Net.VCards.Serializer;
using MixERP.Net.VCards.Types;

namespace ContactsApp
{
    public partial class Form1 : Form
    {
        public IDictionary<char, ISet<ContactEntry>> Contacts { get; set; }
        public string SerializationPath { get; set; }
        public string FolderPath { get; set; }

        private static readonly Color BlueColor = Color.FromArgb(27, 93, 198);
        private static readonly Color WhiteColor = Color.FromArgb(255, 255, 255);
        private static readonly Color BlackColor = Color.FromArgb(35, 35, 35);

        public Form1()
        {
            InitializeComponent();
            Contacts = new SortedDictionary<char, ISet<ContactEntry>>();
            this.DoubleBuffered = true;

            FolderPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "ContactsApp");
            Console.WriteLine($"Folder Path: [{FolderPath}]");

            SerializationPath = Path.Combine(FolderPath, "contacts.bin");
            Console.WriteLine($"File path: [{SerializationPath}]");
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

            lblEmpty.Visible = false;
            lblEmpty.BackColor = BlackColor;
            lblEmpty.ForeColor = BlueColor;

            txtSearch.BackColor = BlackColor;
            txtSearch.ForeColor = Color.Gray;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;

            this.BackColor = BlackColor;
            this.ForeColor = BlueColor;

            Add_button.BackColor = BlackColor;
            Add_button.ForeColor = BlueColor;
            Add_button.FlatAppearance.BorderSize = 0;
            Add_button.FlatStyle = FlatStyle.Flat;

            btnCancel.BackColor = BlackColor;
            btnCancel.ForeColor = BlueColor;
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

            if (File.Exists(SerializationPath))
            {
                try
                {
                    using (var stream = new FileStream(SerializationPath, FileMode.Open,
                        FileAccess.Read))
                    {
                        var formatter = new BinaryFormatter();
                        Contacts =
                            (SortedDictionary<char, ISet<ContactEntry>>) formatter.Deserialize(stream);
                    }

                    Console.WriteLine($"Contacts have been successfully deserialized from " +
                                      $"[{SerializationPath}]");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR: Contacts cannot be deserialized\n {ex.Message}");
                }
            }
            else
                Console.WriteLine($"Contacts cannot be deserialized, file does not exists!");

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
                listView1.Groups.Add(new ListViewGroup($"{(char) i}"));

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

            if (Contacts.Count == 0)
            {
                lblEmpty.Text = "       No contacts available.\nPlease add or import contacts.";
                lblEmpty.Visible = true;
                listView1.Visible = listView2.Visible = false;
                txtSearch.ReadOnly = true;
            }
            else
            {
                lblEmpty.Visible = false;
                listView1.Visible = true;
                listView2.Visible = false;
                txtSearch.ReadOnly = false;
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (lblEmpty.Visible)
                return;
            if (txtSearch.Text.Trim().Equals("Search..."))
                txtSearch.Text = "";
            txtSearch.BorderStyle = BorderStyle.Fixed3D;
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (lblEmpty.Visible)
                return;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
        }

        private void txtSearch_MouseEnter(object sender, EventArgs e)
        {
            if (lblEmpty.Visible)
                return;
            if (txtSearch.Text.Trim().Equals("Search..."))
                txtSearch.Text = string.Empty;
            txtSearch.BorderStyle = BorderStyle.Fixed3D;
            txtSearch.Focus();
        }

        private void txtSearch_MouseLeave(object sender, EventArgs e)
        {
            if (lblEmpty.Visible)
                return;
            if (txtSearch.Text.Trim().Equals(""))
                txtSearch.Text = "Search...";
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (lblEmpty.Visible)
                return;
            if (txtSearch.Text.Trim().Equals("Search..."))
                txtSearch.Text = "";
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (lblEmpty.Visible)
                return;
            string search = txtSearch.Text.Trim().ToLower();

            if (!search.Equals("") && !search.Equals("search..."))
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
                btnCancel_Click(sender, e);
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

            Console.WriteLine($"Attempting to create directory [{FolderPath}]...");
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    Directory.CreateDirectory(FolderPath);
                    Console.WriteLine($"Successfully created [{FolderPath}] directory");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR: Directory on path [{FolderPath}] cannot be created!\n" +
                                      $"{ex.Message}");
                    return;
                }
            }
            else
                Console.WriteLine($"Directory [{FolderPath}] already exists!");


            Console.WriteLine($"Starting serialization to [{SerializationPath}] ...");
            try
            {
                var myFile = new FileInfo(SerializationPath);
                if (myFile.Exists)
                    myFile.Attributes &= ~FileAttributes.Hidden;

                using (var stream = new FileStream(SerializationPath, FileMode.Create, FileAccess.Write))
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(stream, Contacts);
                }

                Console.WriteLine($"Contacts have been successfully serialized to [{SerializationPath}]");
                File.SetAttributes(SerializationPath,
                    File.GetAttributes(SerializationPath) | FileAttributes.Hidden);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: Cannot serialize contacts!\n{ex.Message}");
            }

            try
            {
                Console.WriteLine("Attempting to remove Images directory...");
                if (Directory.Exists("Images"))
                {
                    Directory.Delete("Images", recursive: true);
                    Console.WriteLine("Images directory removed!");
                }
                else
                    Console.WriteLine("Images directory does not exists!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"Folder path: [{FolderPath}]");

            var path = Path.Combine(FolderPath, "Vcards");
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
                    Console.WriteLine($"Directory [{path}] already exists!");

                if (File.Exists(vcardPath))
                {
                    Console.WriteLine($"Deleting [{vcardPath}]...");
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
                        },
                        Photo = new Photo(true, "PNG", contact.ImageBase64)
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

            Console.WriteLine($"Exporting completed ({counter} contacts exported)");
            if (counter != 0)
                MessageBox.Show($"{counter} contacts have been exported to [{vcardPath}]",
                    "Exported successfully", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            else
                MessageBox.Show("No contacts were exported",
                    "Export was not performed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
                        email = new Email() {EmailAddress = string.Empty};
                    else
                    {
                        email = vcard.Emails.ElementAtOrDefault(0);
                        if (email == null)
                            email = new Email() {EmailAddress = string.Empty};
                    }

                    string number;

                    try
                    {
                        number = NormalizeNumber(vcard.Telephones.ElementAt(0).Number.Trim());
                    }
                    catch (InvalidNumberFormatException ex)
                    {
                        Console.WriteLine($"This application supports only mobile phone numbers!\n" +
                                          $"{ex.Message}");
                        counterUnsuccessful++;
                        continue;
                    }

                    var photo = vcard.Photo;
                    var photoString = string.Empty;
                    if (photo != null)
                        photoString = photo.Contents;

                    contact = new ContactEntry()
                    {
                        FirstName = DecodeQuotedPrintable(vcard.FirstName.Trim()),
                        LastName = DecodeQuotedPrintable(vcard.LastName.Trim()),
                        TelephoneNumber = number.Trim(),
                        Email = email.EmailAddress.Trim(),
                        ImageBase64 = photoString
                    };
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"EXCEPTION: {ex.Message}");
                }

                if (contact == null)
                {
                    Console.WriteLine("Skipping null contact.");
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

            Display();
            btnCancel_Click(sender, e);
            Console.WriteLine($"Importing completed " +
                              $"({vcards.Count() - counterUnsuccessful}/{vcards.Count()})");
            MessageBox.Show($"{vcards.Count() - counterUnsuccessful}/{vcards.Count()} contacts have " +
                            $"been imported from [{vcardPath}]", "Imported successfully",
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void removeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove all of your contacts?",
                    "Remove all contacts", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.Yes)
            {
                Contacts.Clear();
                Display();
                btnCancel_Click(sender, e);
            }
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
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return true;
                    }
                }
            }

            return false;
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

        private static string NormalizeNumber(string number)
        {
            if (Regex.IsMatch(number,
                @"^07[0-35-9]\s[0-9]{3}\s[0-9]{3}$", RegexOptions.IgnoreCase))
                return number; // 07X YYY ZZZ

            var sb = new StringBuilder();

            if (number.StartsWith("+389 ")) // +389 7X YYY ZZZ
                sb.Append(number.Replace("+389 ", "0"));
            else if (number.StartsWith("+389")) // +3897X YYY ZZZ
                sb.Append(number.Replace("+389", "0"));
            else if (number.StartsWith("00389 ")) // 00389 7X YYY ZZZ
                sb.Append(number.Replace("00389 ", "0"));
            else if (number.StartsWith("00389")) // 003897X YYY ZZZ
                sb.Append(number.Replace("00389", "0"));
            else // 07X YYY ZZZ or 07XYYYZZZ
                sb.Append(number);

            if (!Regex.IsMatch(sb.ToString(),
                    @"^07[0-35-9]\s?[0-9]{3}\s?[0-9]{3}$", RegexOptions.IgnoreCase))
                // 07X YY YZZ or 07X YYYZ ZZ or similar
                throw new InvalidNumberFormatException($"Number {sb} is not a valid telephone number");

            if (sb.ToString().Split(' ').Length < 3)
                for (int i = 0, j = 0; i < sb.Length; i++, j++)
                    if ((i == 3 && sb[i] != ' ') || (i == 7 && sb[i] != ' '))
                        sb.Insert(i, ' ');

            if (!Regex.IsMatch(sb.ToString(),
                    @"^07[0-35-9]\s[0-9]{3}\s[0-9]{3}$", RegexOptions.IgnoreCase))
                // if not 07X YYY ZZZ
                throw new InvalidNumberFormatException($"Number {sb} is not a valid telephone number");

            return sb.ToString();
        }

        public string DecodeQuotedPrintable(string encoded)
        {
            if (!Regex.IsMatch(encoded, @"^(=[0-9a-f]{2}){1,}", RegexOptions.IgnoreCase))
                return encoded;

            var output = new List<byte>();

            for (int i = 0; i < encoded.Length; i++)
            {
                if (encoded[i] == '=')
                {
                    var sHex = encoded.Substring(i + 1, 2);
                    var hex = Convert.ToInt32(sHex, 16);
                    var b = Convert.ToByte(hex);
                    output.Add(b);
                    i += 2;
                }
            }

            return Encoding.UTF8.GetString(output.ToArray());
        }
    }
}