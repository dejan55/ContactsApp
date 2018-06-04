namespace ContactsApp
{
    partial class Form1
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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Add_button = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(17, 4);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(411, 22);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.Text = "Search...";
            this.txtSearch.Enter += new System.EventHandler(this.textbox1_Enter);
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            this.txtSearch.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // listView1
            // 
            this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(17, 34);
            this.listView1.Margin = new System.Windows.Forms.Padding(4);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(411, 366);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listViews_MouseDown);
            // 
            // Add_button
            // 
            this.Add_button.Location = new System.Drawing.Point(17, 408);
            this.Add_button.Margin = new System.Windows.Forms.Padding(4);
            this.Add_button.Name = "Add_button";
            this.Add_button.Size = new System.Drawing.Size(411, 28);
            this.Add_button.TabIndex = 0;
            this.Add_button.Text = "Add contact";
            this.Add_button.UseVisualStyleBackColor = true;
            this.Add_button.Click += new System.EventHandler(this.add_event);
            this.Add_button.MouseEnter += new System.EventHandler(this.Add_button_MouseEnter);
            this.Add_button.MouseLeave += new System.EventHandler(this.Add_button_MouseLeave);
            // 
            // listView2
            // 
            this.listView2.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView2.Location = new System.Drawing.Point(17, 34);
            this.listView2.Margin = new System.Windows.Forms.Padding(4);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(411, 366);
            this.listView2.TabIndex = 5;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listViews_MouseDown);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancel.Location = new System.Drawing.Point(400, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(25, 19);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "X";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.CausesValidation = false;
            this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnQuit.Location = new System.Drawing.Point(560, 160);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(10, 10);
            this.btnQuit.TabIndex = 1;
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.Add_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnQuit;
            this.ClientSize = new System.Drawing.Size(445, 444);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.Add_button);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.listView2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contacts App";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button Add_button;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnQuit;
    }
}

