using System;
using System.Drawing;
using System.Windows.Forms;

namespace ContactsApp
{
    public partial class SentMessages : Form
    {
        public ContactEntry Contact { get; set; }
        private int Selected { get; set; }

        private static readonly Color BlueColor = Color.FromArgb(27, 93, 198);
        private static readonly Color BlackColor = Color.FromArgb(35, 35, 35);

        public SentMessages(ContactEntry contact)
        {
            InitializeComponent();
            this.Contact = contact;
            Display();
        }

        private void SentMessages_Load(object sender, EventArgs e)
        {
            this.BackColor = BlackColor;
            this.ForeColor = BlueColor;
            this.Text = $"Messages sent to {Contact}";

            label3.Visible = false;

            btnBack.BackColor = BlackColor;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Visible = false;

            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.BackColor = BlackColor;
            btnDelete.Visible = false;

            listBox1.BackColor = BlackColor;
            listBox1.ForeColor = BlueColor;


            displayMessage.ForeColor = BlueColor;
            displayMessage.BackColor = BlackColor;
            displayMessage.Visible = false;
        }

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            base.OnMouseEnter(e);
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            base.OnMouseLeave(e);
        }

        public void Display()
        {
            try
            {
                if (Contact.Messages == null || Contact.Messages.Count == 0)
                {
                    label1.Visible = true;
                    label2.Visible = true;
                    Console.WriteLine("Error messages not found 2018");
                }
                else
                {
                    label1.Visible = false;
                    label2.Visible = false;
                    foreach (Message m in Contact.Messages)
                    {
                        listBox1.Items.Add(m.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception {e.Message}");
            }
        }

        public void ShowMessage()
        {
            Selected = listBox1.SelectedIndex;
            // debbuging
            Console.WriteLine($"Selected index: {Selected}");
            if (Selected >= 0)
            {
                var msgs = Contact.Messages;
                listBox1.Visible = false;
                btnBack.Visible = true;
                btnDelete.Visible = true;
                label3.Visible = true;
                displayMessage.Visible = true;
                try
                {
                    displayMessage.Text = msgs[Selected].MessageToString();
                    label3.Text = $"  Message sent on:\n{msgs[Selected].DateToString()}";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            ShowMessage();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            displayMessage.Text = "";
            displayMessage.Visible = false;
            btnBack.Visible = false;
            btnDelete.Visible = false;
            label3.Visible = false;
            listBox1.Visible = true;
            listBox1.ClearSelected();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.RemoveAt(Selected);
                Contact.Messages.RemoveAt(Selected);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            displayMessage.Text = "";
            displayMessage.Visible = false;
            btnBack.Visible = false;
            btnDelete.Visible = false;
            label3.Visible = false;
            listBox1.Visible = true;
            listBox1.ClearSelected();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void listBox1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                var lb = (ListBox) sender;
                Point pt = new Point(e.X, e.Y);

                var index = lb.IndexFromPoint(pt);
                if (index >= 0)
                {
                    this.Cursor = Cursors.Hand;
                    base.OnMouseEnter(e);
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    base.OnMouseEnter(e);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                var lb = (ListBox) sender;
                Point pt = new Point(e.X, e.Y);

                var index = lb.IndexFromPoint(pt);
                if (index >= 0)
                {
                    ShowMessage();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void SentMessages_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel)
                e.Cancel = false;
            else
                e.Cancel = true;
        }
    }
}