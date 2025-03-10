namespace ToolsRestartPassApple
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addMailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.từClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.từFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addProxyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.từVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.từFileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Tong_so_mail = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.password = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.API_key = new System.Windows.Forms.TextBox();
            this.soluong = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bnt_start = new System.Windows.Forms.Button();
            this.bnt_stop = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cau_trl1 = new System.Windows.Forms.TextBox();
            this.cau_trl3 = new System.Windows.Forms.TextBox();
            this.cau_trl2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Capture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Proxy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soluong)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.Mail,
            this.Pass,
            this.Status,
            this.Capture,
            this.Proxy});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(6, 158);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(496, 395);
            this.dataGridView1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMailToolStripMenuItem,
            this.addProxyToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(130, 48);
            // 
            // addMailToolStripMenuItem
            // 
            this.addMailToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.từClipboardToolStripMenuItem,
            this.từFileToolStripMenuItem});
            this.addMailToolStripMenuItem.Name = "addMailToolStripMenuItem";
            this.addMailToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.addMailToolStripMenuItem.Text = "Add Mail";
            // 
            // từClipboardToolStripMenuItem
            // 
            this.từClipboardToolStripMenuItem.Name = "từClipboardToolStripMenuItem";
            this.từClipboardToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.từClipboardToolStripMenuItem.Text = "Từ Clipboard";
            this.từClipboardToolStripMenuItem.Click += new System.EventHandler(this.add_mail_clipboard);
            // 
            // từFileToolStripMenuItem
            // 
            this.từFileToolStripMenuItem.Name = "từFileToolStripMenuItem";
            this.từFileToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.từFileToolStripMenuItem.Text = "Từ File";
            this.từFileToolStripMenuItem.Click += new System.EventHandler(this.add_mail_file);
            // 
            // addProxyToolStripMenuItem
            // 
            this.addProxyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.từVToolStripMenuItem,
            this.từFileToolStripMenuItem1});
            this.addProxyToolStripMenuItem.Name = "addProxyToolStripMenuItem";
            this.addProxyToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.addProxyToolStripMenuItem.Text = "Add Proxy";
            // 
            // từVToolStripMenuItem
            // 
            this.từVToolStripMenuItem.Name = "từVToolStripMenuItem";
            this.từVToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.từVToolStripMenuItem.Text = "Từ Clipboard";
            this.từVToolStripMenuItem.Click += new System.EventHandler(this.add_proxy_clipboard);
            // 
            // từFileToolStripMenuItem1
            // 
            this.từFileToolStripMenuItem1.Name = "từFileToolStripMenuItem1";
            this.từFileToolStripMenuItem1.Size = new System.Drawing.Size(142, 22);
            this.từFileToolStripMenuItem1.Text = "Từ File";
            this.từFileToolStripMenuItem1.Click += new System.EventHandler(this.add_proxy_file);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Tong_so_mail);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(35, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(132, 64);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // Tong_so_mail
            // 
            this.Tong_so_mail.AutoSize = true;
            this.Tong_so_mail.Location = new System.Drawing.Point(99, 31);
            this.Tong_so_mail.Name = "Tong_so_mail";
            this.Tong_so_mail.Size = new System.Drawing.Size(13, 13);
            this.Tong_so_mail.TabIndex = 1;
            this.Tong_so_mail.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tổng số mail: ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.password);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.API_key);
            this.groupBox2.Controls.Add(this.soluong);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(183, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(178, 114);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Setting ";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(65, 76);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(75, 20);
            this.password.TabIndex = 6;
            this.password.Text = "Qaz123456789@";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Password: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "API key: ";
            // 
            // API_key
            // 
            this.API_key.Location = new System.Drawing.Point(65, 48);
            this.API_key.Name = "API_key";
            this.API_key.Size = new System.Drawing.Size(75, 20);
            this.API_key.TabIndex = 3;
            this.API_key.Text = "b0ee80e4175a72c405397bdb63ec2805";
            // 
            // soluong
            // 
            this.soluong.Location = new System.Drawing.Point(67, 21);
            this.soluong.Name = "soluong";
            this.soluong.Size = new System.Drawing.Size(45, 20);
            this.soluong.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Số luồng: ";
            // 
            // bnt_start
            // 
            this.bnt_start.Location = new System.Drawing.Point(35, 88);
            this.bnt_start.Name = "bnt_start";
            this.bnt_start.Size = new System.Drawing.Size(68, 29);
            this.bnt_start.TabIndex = 3;
            this.bnt_start.Text = "Run";
            this.bnt_start.UseVisualStyleBackColor = true;
            this.bnt_start.Click += new System.EventHandler(this.bnt_start_Click);
            // 
            // bnt_stop
            // 
            this.bnt_stop.Location = new System.Drawing.Point(109, 88);
            this.bnt_stop.Name = "bnt_stop";
            this.bnt_stop.Size = new System.Drawing.Size(68, 29);
            this.bnt_stop.TabIndex = 4;
            this.bnt_stop.Text = "Stop";
            this.bnt_stop.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(35, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 29);
            this.button1.TabIndex = 5;
            this.button1.Text = "test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.cau_trl1);
            this.groupBox3.Controls.Add(this.cau_trl3);
            this.groupBox3.Controls.Add(this.cau_trl2);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(367, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(135, 114);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Câu hỏi bm";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "3-1 : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "2-1 :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "1-1 : ";
            // 
            // cau_trl1
            // 
            this.cau_trl1.Location = new System.Drawing.Point(44, 21);
            this.cau_trl1.Name = "cau_trl1";
            this.cau_trl1.Size = new System.Drawing.Size(75, 20);
            this.cau_trl1.TabIndex = 7;
            this.cau_trl1.Text = "Trâu";
            // 
            // cau_trl3
            // 
            this.cau_trl3.Location = new System.Drawing.Point(44, 78);
            this.cau_trl3.Name = "cau_trl3";
            this.cau_trl3.Size = new System.Drawing.Size(75, 20);
            this.cau_trl3.TabIndex = 6;
            this.cau_trl3.Text = "Lợn";
            // 
            // cau_trl2
            // 
            this.cau_trl2.Location = new System.Drawing.Point(44, 52);
            this.cau_trl2.Name = "cau_trl2";
            this.cau_trl2.Size = new System.Drawing.Size(75, 20);
            this.cau_trl2.TabIndex = 3;
            this.cau_trl2.Text = "Bò";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(67, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 13);
            this.label8.TabIndex = 1;
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.Width = 35;
            // 
            // Mail
            // 
            this.Mail.HeaderText = "Mail";
            this.Mail.Name = "Mail";
            // 
            // Pass
            // 
            this.Pass.HeaderText = "Pass";
            this.Pass.Name = "Pass";
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.Width = 150;
            // 
            // Capture
            // 
            this.Capture.HeaderText = "Capture";
            this.Capture.Name = "Capture";
            // 
            // Proxy
            // 
            this.Proxy.HeaderText = "Proxy";
            this.Proxy.Name = "Proxy";
            this.Proxy.Width = 70;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(109, 123);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(68, 29);
            this.button2.TabIndex = 7;
            this.button2.Text = "test2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 578);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bnt_stop);
            this.Controls.Add(this.bnt_start);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soluong)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addMailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem từClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem từFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addProxyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem từVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem từFileToolStripMenuItem1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Tong_so_mail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bnt_start;
        private System.Windows.Forms.Button bnt_stop;
        private System.Windows.Forms.NumericUpDown soluong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox API_key;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox cau_trl1;
        private System.Windows.Forms.TextBox cau_trl3;
        private System.Windows.Forms.TextBox cau_trl2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pass;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Capture;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proxy;
        private System.Windows.Forms.Button button2;
    }
}

