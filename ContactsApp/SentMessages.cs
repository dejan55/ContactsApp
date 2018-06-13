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
    public partial class SentMessages : Form
    {
        private static readonly Color BlueColor = Color.FromArgb(27, 93, 198);
        private static readonly Color WhiteColor = Color.FromArgb(255, 255, 255);
        private static readonly Color BlackColor = Color.FromArgb(35, 35, 35);

        public ContactEntry contact { get; set; }
        private int Selected { get; set; }


        public SentMessages(ContactEntry contact)
        {
            InitializeComponent();
            btnBack.Visible = false;
            btnDelete.Visible = false;
            displayMessage.Visible = false;
            this.contact = contact;
            Display();
        }

        private void SentMessages_Load(object sender, EventArgs e)
        {
            this.BackColor = BlackColor;
            this.ForeColor = BlueColor;
            
            this.MaximizeBox = false;

            btnBack.BackColor = BlackColor;
            btnBack.FlatStyle = FlatStyle.Flat;

            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.BackColor = BlackColor;

            listBox1.BackColor = BlackColor;
            listBox1.ForeColor = BlueColor;

            displayMessage.ForeColor = BlueColor;
            displayMessage.BackColor = BlackColor;
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
                foreach (Message m in contact.messages)
                {
                    listBox1.Items.Add(m.ToString());
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception ", e.Message);
            }
        }

        public void ShowMessage()
        {
            Selected = listBox1.SelectedIndex;
            // debbuging
            Console.WriteLine($"Selected index: {Selected}");
            if(Selected >= 0)
            {
                var msgs = contact.messages;
                listBox1.Visible = false;
                btnBack.Visible = true;
                btnDelete.Visible = true;
                displayMessage.Visible = true;
                try
                {
                    displayMessage.Text = msgs[Selected].MessageToString();
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
            listBox1.Visible = true;
            listBox1.ClearSelected();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.RemoveAt(Selected);
                contact.messages.RemoveAt(Selected);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            displayMessage.Text = "";
            displayMessage.Visible = false;
            btnBack.Visible = false;
            btnDelete.Visible = false;
            listBox1.Visible = true;
            listBox1.ClearSelected();
        }

        

        private void listBox1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                var lb = (ListBox)sender;
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
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                var lb = (ListBox)sender;
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
    }
}
