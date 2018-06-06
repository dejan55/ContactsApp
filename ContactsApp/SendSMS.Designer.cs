namespace ContactsApp
{
    partial class SendSMS
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblChars = new System.Windows.Forms.Label();
            this.txtBoxSender = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.AcceptsReturn = true;
            this.txtMessage.AcceptsTab = true;
            this.txtMessage.Location = new System.Drawing.Point(12, 34);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMessage.MaxLength = 765;
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(401, 139);
            this.txtMessage.TabIndex = 3;
            this.txtMessage.Text = "Enter your message here...";
            this.txtMessage.Click += new System.EventHandler(this.txtMessage_Click);
            this.txtMessage.TextChanged += new System.EventHandler(this.txtMessage_TextChanged);
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyDown);
            this.txtMessage.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyUp);
            this.txtMessage.MouseLeave += new System.EventHandler(this.txtMessage_MouseLeave);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(12, 198);
            this.btnSend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(77, 33);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            this.btnSend.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnSend.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnCancel
            // 
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(336, 198);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(77, 33);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnCancel.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // lblChars
            // 
            this.lblChars.AutoSize = true;
            this.lblChars.Location = new System.Drawing.Point(195, 177);
            this.lblChars.Name = "lblChars";
            this.lblChars.Size = new System.Drawing.Size(16, 17);
            this.lblChars.TabIndex = 4;
            this.lblChars.Text = "0";
            // 
            // txtBoxSender
            // 
            this.txtBoxSender.Location = new System.Drawing.Point(12, 4);
            this.txtBoxSender.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxSender.Name = "txtBoxSender";
            this.txtBoxSender.Size = new System.Drawing.Size(401, 22);
            this.txtBoxSender.TabIndex = 2;
            this.txtBoxSender.Text = "Enter your name here...";
            this.txtBoxSender.Click += new System.EventHandler(this.txtBoxSender_Click);
            this.txtBoxSender.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxSender_KeyDown);
            this.txtBoxSender.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBoxSender_KeyUp);
            this.txtBoxSender.MouseLeave += new System.EventHandler(this.txtBoxSender_MouseLeave);
            // 
            // SendSMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(427, 249);
            this.Controls.Add(this.txtBoxSender);
            this.Controls.Add(this.lblChars);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "SendSMS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Send SMS";
            this.Load += new System.EventHandler(this.SendSMS_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblChars;
        private System.Windows.Forms.TextBox txtBoxSender;
    }
}