namespace SocialMe
{
    partial class Post
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.PageCb = new System.Windows.Forms.CheckedListBox();
            this.GroupCb = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbPrivacy = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cbWall = new System.Windows.Forms.CheckBox();
            this.tbLink = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 356);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(730, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // PageCb
            // 
            this.PageCb.FormattingEnabled = true;
            this.PageCb.Location = new System.Drawing.Point(0, 30);
            this.PageCb.Name = "PageCb";
            this.PageCb.Size = new System.Drawing.Size(180, 319);
            this.PageCb.TabIndex = 1;
            // 
            // GroupCb
            // 
            this.GroupCb.FormattingEnabled = true;
            this.GroupCb.Location = new System.Drawing.Point(186, 30);
            this.GroupCb.Name = "GroupCb";
            this.GroupCb.Size = new System.Drawing.Size(180, 319);
            this.GroupCb.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Your Pages";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Your Groups";
            // 
            // cbPrivacy
            // 
            this.cbPrivacy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPrivacy.FormattingEnabled = true;
            this.cbPrivacy.Items.AddRange(new object[] {
            "Public",
            "Friends",
            "Only Me"});
            this.cbPrivacy.Location = new System.Drawing.Point(499, 179);
            this.cbPrivacy.Name = "cbPrivacy";
            this.cbPrivacy.Size = new System.Drawing.Size(121, 21);
            this.cbPrivacy.TabIndex = 13;
            this.cbPrivacy.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(370, 215);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Post";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // cbWall
            // 
            this.cbWall.AutoSize = true;
            this.cbWall.Location = new System.Drawing.Point(367, 162);
            this.cbWall.Name = "cbWall";
            this.cbWall.Size = new System.Drawing.Size(112, 17);
            this.cbWall.TabIndex = 11;
            this.cbWall.Text = "Post On Your Wall";
            this.cbWall.UseVisualStyleBackColor = true;
            this.cbWall.CheckedChanged += new System.EventHandler(this.cbWall_CheckedChanged);
            // 
            // tbLink
            // 
            this.tbLink.Location = new System.Drawing.Point(426, 136);
            this.tbLink.Name = "tbLink";
            this.tbLink.Size = new System.Drawing.Size(294, 20);
            this.tbLink.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(367, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Who Can See This Post ?";
            this.label5.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(367, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Link:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(367, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Your Post:";
            // 
            // tbMessage
            // 
            this.tbMessage.Location = new System.Drawing.Point(426, 30);
            this.tbMessage.Multiline = true;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(294, 100);
            this.tbMessage.TabIndex = 6;
            // 
            // Post
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(730, 378);
            this.Controls.Add(this.cbPrivacy);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbWall);
            this.Controls.Add(this.tbLink);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GroupCb);
            this.Controls.Add(this.PageCb);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Post";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manager";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.CheckedListBox PageCb;
        private System.Windows.Forms.CheckedListBox GroupCb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbPrivacy;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox cbWall;
        private System.Windows.Forms.TextBox tbLink;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbMessage;

    }
}

