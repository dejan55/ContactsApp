using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactsApp
{
    public partial class SendSMS : Form
    {
        private static readonly Color BlueColor = Color.FromArgb(27, 93, 198);
        private static readonly Color WhiteColor = Color.FromArgb(255, 255, 255);
        private static readonly Color BlackColor = Color.FromArgb(35, 35, 35);

        public ContactEntry SelectedContact { get; set; }
        private const string ApiKey = "jNutD8o0fsQ-gLQQLhMp4a7it6H1uKHCleEkiIPna0";

        public SendSMS(ContactEntry selectedContact)
        {
            InitializeComponent();
            SelectedContact = selectedContact;
            this.Text = $"Send a SMS to {SelectedContact.FirstName}";
        }

        private void SendSMS_Load(object sender, EventArgs e)
        {
            txtMessage.ForeColor = Color.Gray;
            txtBoxSender.ForeColor = Color.Gray;

            btnSend.Enabled = false;

            this.BackColor = BlackColor;
            this.ForeColor = WhiteColor;

            btnCancel.BackColor = BlackColor;
            btnCancel.ForeColor = BlueColor;
            btnCancel.FlatStyle = FlatStyle.Flat;

            btnSend.BackColor = BlackColor;
            btnSend.ForeColor = BlueColor;
            btnSend.FlatStyle = FlatStyle.Flat;
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

        private void btnSend_Click(object sender, EventArgs e)
        {
            var status = SendSms();
            if (status.Contains("\"status\":\"success\"") && !status.Contains("\"warnings\":"))
            {
                MessageBox.Show("Your message was sent successfully", "Successful",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Your message was not sent successfully", "Unsuccessful",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
            }
        }

        private void txtMessage_KeyUp(object sender, KeyEventArgs e)
        {
            //                     [space][tab] [new line]
            if (txtMessage.Text.Trim(' ', '\t', '\r', '\n') == string.Empty)
                btnSend.Enabled = false;
            else
                btnSend.Enabled = true;

            if (txtBoxSender.Text.Trim().Equals("") ||
                txtBoxSender.Text.Trim().Equals("Enter your name here...") ||
                txtMessage.Text.Trim(' ', '\t', '\r', '\n').Equals("") ||
                txtMessage.Text.Trim().Equals("Enter your message here..."))
            {
                btnSend.Enabled = false;
            }
            else
            {
                btnSend.Enabled = true;
            }
        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
            // do not count the placeholder chars
            if (txtMessage.Text.Trim().Equals("Enter your message here..."))
            {
                lblChars.Text = "0";
                return;
            }

            var numChars = txtMessage.Text.Trim(' ', '\t', '\r', '\n').Length;
            int numMessages = 1;
            if (numChars > 160)
                numMessages += (numChars + 7) / 160;

            if (numMessages > 1)
                lblChars.Text = $"{numChars} ({numMessages})";
            else lblChars.Text = $"{numChars}";
        }

        private void txtMessage_Click(object sender, EventArgs e)
        {
            if (txtMessage.Text.Trim().Equals("Enter your message here..."))
            {
                txtMessage.Text = "";
                txtMessage.ForeColor = BlackColor;
            }
        }

        private void txtMessage_MouseLeave(object sender, EventArgs e)
        {
            if (txtMessage.Text.Trim().Equals(""))
            {
                txtMessage.Text = "Enter your message here...";
                txtMessage.ForeColor = Color.Gray;
            }
        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtMessage.Text.Trim().Equals("Enter your message here..."))
            {
                txtMessage.Text = string.Empty;
                txtMessage.ForeColor = BlackColor;
            }
        }

        private void txtBoxSender_Click(object sender, EventArgs e)
        {
            if (txtBoxSender.Text.Trim().Equals("Enter your name here..."))
            {
                txtBoxSender.Text = "";
                txtBoxSender.ForeColor = BlackColor;
            }
        }

        private void txtBoxSender_MouseLeave(object sender, EventArgs e)
        {
            if (txtBoxSender.Text.Trim().Equals(""))
            {
                txtBoxSender.Text = "Enter your name here...";
                txtBoxSender.ForeColor = Color.Gray;
            }
        }

        private void txtBoxSender_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtBoxSender.Text.Trim().Equals("Enter your name here..."))
            {
                txtBoxSender.Text = "";
                txtBoxSender.ForeColor = BlackColor;
            }
        }

        private void txtBoxSender_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtBoxSender.Text.Trim().Equals("") ||
                txtBoxSender.Text.Trim().Equals("Enter your name here...") ||
                txtMessage.Text.Trim(' ', '\t', '\r', '\n').Equals("") ||
                txtMessage.Text.Trim().Equals("Enter your message here..."))
            {
                btnSend.Enabled = false;
            }
            else
            {
                btnSend.Enabled = true;
            }
        }

        private void SendSMS_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.None || DialogResult == DialogResult.OK)
                e.Cancel = false;
            else if (MessageBox.Show("Are you sure you want to discard the message?", "Discard the message",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                e.Cancel = true;
            else
                e.Cancel = false;
        }

        public string SendSms()
        {
            string result;
            var number = $"00389 {SelectedContact.TelephoneNumber.Substring(1)}";
            var message = txtMessage.Text;
            var sender = txtBoxSender.Text;

            var url =
                "https://api.txtlocal.com/send/?" +
                "apikey=" + ApiKey +
                "&numbers=" + number +
                "&message=" + message +
                "&sender=" + sender;
            Console.WriteLine($"URL: {url}");

            var objRequest = WebRequest.Create(url) as HttpWebRequest;
            if (objRequest == null)
                return string.Empty;

            objRequest.Method = "POST";
            objRequest.ContentLength = Encoding.UTF8.GetByteCount(url);
            objRequest.ContentType = "application/x-www-form-urlencoded";
            try
            {
                using (var myWriter = new StreamWriter(objRequest.GetRequestStream()))
                {
                    myWriter.Write(url);
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

            var objResponse = objRequest.GetResponse() as HttpWebResponse;
            if (objResponse == null)
                return string.Empty;

            using (var sr = new StreamReader(objResponse.GetResponseStream()))
            {
                result = sr.ReadToEnd();
            }

            Console.WriteLine($"RESULT: {result}");
            return result;
        }
    }
}