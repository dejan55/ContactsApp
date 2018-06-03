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
    public partial class Add_Form : Form
    {
        private static readonly Color BlueColor = Color.FromArgb(27, 93, 198);
        private static readonly Color WhiteColor = Color.FromArgb(255, 255, 255);
        private static readonly Color BlackColor = Color.FromArgb(35, 35, 35);
        private bool n1 = false;
        private bool s1 = false;
        private bool t1 = false;

        public String Name { get; set; }
        public String Surname { get; set; }
        public String TelephoneNumber { get; set; }

        public Add_Form()
        {
            InitializeComponent();
        }

        private void Add_Form_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;


            button1.Text = "Add";
            button2.Text = "Cancel";

            button1.BackColor = BlackColor;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;

            button2.BackColor = BlackColor;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;

            this.BackColor = BlackColor;
            this.ForeColor = BlueColor;
            groupBox1.ForeColor = BlueColor;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Name = textBox1.Text;
            Surname = textBox2.Text;
            TelephoneNumber = textBox3.Text;
            DialogResult = DialogResult.OK;
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                errorProvider1.SetError(textBox1, "You must enter a name!");
                n1 = false;
            }
            else
            {
                errorProvider1.SetError(textBox1, "");
                n1 = true;
            }
            if (n1 && s1 && t1)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (textBox2.Text.Equals(""))
            {
                s1 = false;
                errorProvider1.SetError(textBox2, "You must enter a surname!");
            }
            else
            {
                s1 = true;
                errorProvider1.SetError(textBox2, "");
            }

            if (n1 && s1 && t1)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (textBox3.Text.Equals(""))
            {
                t1 = false;
                errorProvider1.SetError(textBox3, "You must enter a telephone number!");
            }
            else
            {
                t1 = true;
                errorProvider1.SetError(textBox3, "");
            }
            if (n1 && s1 && t1)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        
    }
}
