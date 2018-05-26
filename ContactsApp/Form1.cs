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

        public Form1()
        {
            InitializeComponent();
            this.BackColor = BlackColor;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var left = 20;
            var top = 20;
            var labelSize = 60;
            var labelOffset = 60;

            for (int i = 1, x = left, y = left; i <= 26; i++, x += labelOffset)
            {
                Labels[i - 1] = new Label();

                Labels[i - 1].AutoSize = true;
                Labels[i - 1].BackColor = BlackColor;
                Labels[i - 1].Font = CustomFont;
                Labels[i - 1].ForeColor = SystemColors.Control;
                Labels[i - 1].Location = new Point(x, y);
                Labels[i - 1].Margin = new Padding(4, 0, 4, 0);
                Labels[i - 1].Name = $"label{(char) ('A' + (i - 1))}";
                Labels[i - 1].Size = new Size(labelSize, labelSize);
                Labels[i - 1].TabIndex = 0;
                Labels[i - 1].Text = $"{(char) ('A' + (i - 1))}";
                Labels[i - 1].MouseEnter += this.label_MouseEnter;
                Labels[i - 1].MouseLeave += this.label_MouseLeave;

                Controls.Add(Labels[i - 1]);

                if (i != 0 && i % 4 == 0)
                {
                    x = left - labelOffset;
                    y += labelOffset;
                }
            }

            this.Width = 5 * labelOffset - left;
            this.Height = 8 * labelSize + top;
        }

        private void label_MouseEnter(object sender, EventArgs e)
        {
            var lbl = (Label) sender;
            lbl.ForeColor = BlueColor;
        }

        private void label_MouseLeave(object sender, EventArgs e)
        {
            var lbl = (Label) sender;
            lbl.ForeColor = WhiteColor;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString().Length != 1)
                return;

            var key = e.KeyCode.ToString()[0];
            Labels[key - 'A'].ForeColor = BlueColor;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString().Length != 1)
                return;

            var key = e.KeyCode.ToString()[0];
            Labels[key - 'A'].ForeColor = WhiteColor;
        }
    }
}