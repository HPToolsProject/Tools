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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CHECK = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Proxy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addMailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.từClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.từFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addProxyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.từVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.từFileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.chọnTấtCảToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chọnBôiĐenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bỏChọnTấtCảToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xóaProxyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tongproxy = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dachon = new System.Windows.Forms.Label();
            this.Tong_so_mail = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.randompasscheck = new System.Windows.Forms.CheckBox();
            this.password = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.API_key = new System.Windows.Forms.TextBox();
            this.soluong = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bnt_start = new System.Windows.Forms.Button();
            this.bnt_stop = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cau_trl1 = new System.Windows.Forms.TextBox();
            this.cau_trl3 = new System.Windows.Forms.TextBox();
            this.cau_trl2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.Chieudai = new System.Windows.Forms.NumericUpDown();
            this.Chieurong = new System.Windows.Forms.NumericUpDown();
            this.kotatchrome = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox_loaimail = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soluong)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Chieudai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chieurong)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CHECK,
            this.STT,
            this.Mail,
            this.Pass,
            this.Proxy,
            this.Status});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(12, 198);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(467, 368);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // CHECK
            // 
            this.CHECK.FillWeight = 30F;
            this.CHECK.HeaderText = "#";
            this.CHECK.Name = "CHECK";
            this.CHECK.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CHECK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CHECK.Width = 30;
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.Width = 40;
            // 
            // Mail
            // 
            this.Mail.FillWeight = 70F;
            this.Mail.HeaderText = "Mail";
            this.Mail.Name = "Mail";
            this.Mail.Width = 70;
            // 
            // Pass
            // 
            this.Pass.FillWeight = 50F;
            this.Pass.HeaderText = "Pass";
            this.Pass.Name = "Pass";
            this.Pass.Width = 50;
            // 
            // Proxy
            // 
            this.Proxy.FillWeight = 60F;
            this.Proxy.HeaderText = "Proxy";
            this.Proxy.Name = "Proxy";
            this.Proxy.Width = 60;
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMailToolStripMenuItem,
            this.addProxyToolStripMenuItem,
            this.chọnTấtCảToolStripMenuItem,
            this.chọnBôiĐenToolStripMenuItem,
            this.bỏChọnTấtCảToolStripMenuItem,
            this.xóaToolStripMenuItem,
            this.xóaProxyToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(151, 158);
            // 
            // addMailToolStripMenuItem
            // 
            this.addMailToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.từClipboardToolStripMenuItem,
            this.từFileToolStripMenuItem});
            this.addMailToolStripMenuItem.Name = "addMailToolStripMenuItem";
            this.addMailToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
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
            this.addProxyToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
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
            // chọnTấtCảToolStripMenuItem
            // 
            this.chọnTấtCảToolStripMenuItem.Name = "chọnTấtCảToolStripMenuItem";
            this.chọnTấtCảToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.chọnTấtCảToolStripMenuItem.Text = "Chọn tất cả";
            this.chọnTấtCảToolStripMenuItem.Click += new System.EventHandler(this.chọnTấtCảToolStripMenuItem_Click);
            // 
            // chọnBôiĐenToolStripMenuItem
            // 
            this.chọnBôiĐenToolStripMenuItem.Name = "chọnBôiĐenToolStripMenuItem";
            this.chọnBôiĐenToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.chọnBôiĐenToolStripMenuItem.Text = "Chọn bôi đen";
            this.chọnBôiĐenToolStripMenuItem.Click += new System.EventHandler(this.chọnBôiĐenToolStripMenuItem_Click);
            // 
            // bỏChọnTấtCảToolStripMenuItem
            // 
            this.bỏChọnTấtCảToolStripMenuItem.Name = "bỏChọnTấtCảToolStripMenuItem";
            this.bỏChọnTấtCảToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.bỏChọnTấtCảToolStripMenuItem.Text = "Bỏ chọn tất cả";
            this.bỏChọnTấtCảToolStripMenuItem.Click += new System.EventHandler(this.bỏChọnTấtCảToolStripMenuItem_Click);
            // 
            // xóaToolStripMenuItem
            // 
            this.xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
            this.xóaToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.xóaToolStripMenuItem.Text = "Xóa đã chọn";
            this.xóaToolStripMenuItem.Click += new System.EventHandler(this.xóaToolStripMenuItem_Click);
            // 
            // xóaProxyToolStripMenuItem
            // 
            this.xóaProxyToolStripMenuItem.Name = "xóaProxyToolStripMenuItem";
            this.xóaProxyToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.xóaProxyToolStripMenuItem.Text = "Xóa proxy";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tongproxy);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.dachon);
            this.groupBox1.Controls.Add(this.Tong_so_mail);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(142, 83);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // tongproxy
            // 
            this.tongproxy.AutoSize = true;
            this.tongproxy.Location = new System.Drawing.Point(80, 59);
            this.tongproxy.Name = "tongproxy";
            this.tongproxy.Size = new System.Drawing.Size(13, 13);
            this.tongproxy.TabIndex = 5;
            this.tongproxy.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 59);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "Tổng số proxy: ";
            // 
            // dachon
            // 
            this.dachon.AutoSize = true;
            this.dachon.Location = new System.Drawing.Point(55, 38);
            this.dachon.Name = "dachon";
            this.dachon.Size = new System.Drawing.Size(13, 13);
            this.dachon.TabIndex = 3;
            this.dachon.Text = "0";
            // 
            // Tong_so_mail
            // 
            this.Tong_so_mail.AutoSize = true;
            this.Tong_so_mail.Location = new System.Drawing.Point(75, 16);
            this.Tong_so_mail.Name = "Tong_so_mail";
            this.Tong_so_mail.Size = new System.Drawing.Size(13, 13);
            this.Tong_so_mail.TabIndex = 1;
            this.Tong_so_mail.Text = "0";
            this.Tong_so_mail.Click += new System.EventHandler(this.Tong_so_mail_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 38);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Đã chọn:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tổng số mail: ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.randompasscheck);
            this.groupBox2.Controls.Add(this.password);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.API_key);
            this.groupBox2.Controls.Add(this.soluong);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(160, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(178, 124);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Setting ";
            // 
            // randompasscheck
            // 
            this.randompasscheck.AutoSize = true;
            this.randompasscheck.Location = new System.Drawing.Point(65, 101);
            this.randompasscheck.Name = "randompasscheck";
            this.randompasscheck.Size = new System.Drawing.Size(100, 17);
            this.randompasscheck.TabIndex = 7;
            this.randompasscheck.Text = "Random pass ?";
            this.randompasscheck.UseVisualStyleBackColor = true;
            this.randompasscheck.CheckedChanged += new System.EventHandler(this.randompasscheck_CheckedChanged);
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(65, 76);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(95, 20);
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
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "2Captcha API: ";
            // 
            // API_key
            // 
            this.API_key.Location = new System.Drawing.Point(85, 48);
            this.API_key.Name = "API_key";
            this.API_key.Size = new System.Drawing.Size(75, 20);
            this.API_key.TabIndex = 3;
            this.API_key.Text = "b0ee80e4175a72c405397bdb63ec2805";
            // 
            // soluong
            // 
            this.soluong.Location = new System.Drawing.Point(67, 21);
            this.soluong.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.soluong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.soluong.Name = "soluong";
            this.soluong.Size = new System.Drawing.Size(45, 20);
            this.soluong.TabIndex = 2;
            this.soluong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
            this.bnt_start.Location = new System.Drawing.Point(12, 104);
            this.bnt_start.Name = "bnt_start";
            this.bnt_start.Size = new System.Drawing.Size(68, 48);
            this.bnt_start.TabIndex = 3;
            this.bnt_start.Text = "Run";
            this.bnt_start.UseVisualStyleBackColor = true;
            this.bnt_start.Click += new System.EventHandler(this.bnt_start_Click);
            // 
            // bnt_stop
            // 
            this.bnt_stop.Location = new System.Drawing.Point(86, 104);
            this.bnt_stop.Name = "bnt_stop";
            this.bnt_stop.Size = new System.Drawing.Size(68, 48);
            this.bnt_stop.TabIndex = 4;
            this.bnt_stop.Text = "Stop";
            this.bnt_stop.UseVisualStyleBackColor = true;
            this.bnt_stop.Click += new System.EventHandler(this.bnt_stop_Click);
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
            this.groupBox3.Location = new System.Drawing.Point(344, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(135, 106);
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
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(414, 147);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(65, 13);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "File Kết Quả";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label19.Location = new System.Drawing.Point(158, 147);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(69, 13);
            this.label19.TabIndex = 450;
            this.label19.Text = "Tỉ lệ Chrome:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label20.Location = new System.Drawing.Point(278, 147);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(15, 16);
            this.label20.TabIndex = 451;
            this.label20.Text = "X";
            // 
            // Chieudai
            // 
            this.Chieudai.Location = new System.Drawing.Point(227, 143);
            this.Chieudai.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.Chieudai.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Chieudai.Name = "Chieudai";
            this.Chieudai.Size = new System.Drawing.Size(45, 20);
            this.Chieudai.TabIndex = 452;
            this.Chieudai.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // Chieurong
            // 
            this.Chieurong.Location = new System.Drawing.Point(299, 143);
            this.Chieurong.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.Chieurong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Chieurong.Name = "Chieurong";
            this.Chieurong.Size = new System.Drawing.Size(45, 20);
            this.Chieurong.TabIndex = 453;
            this.Chieurong.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // kotatchrome
            // 
            this.kotatchrome.AutoSize = true;
            this.kotatchrome.Location = new System.Drawing.Point(383, 119);
            this.kotatchrome.Name = "kotatchrome";
            this.kotatchrome.Size = new System.Drawing.Size(92, 17);
            this.kotatchrome.TabIndex = 454;
            this.kotatchrome.Text = "Ko tắt chrome";
            this.kotatchrome.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 158);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(68, 24);
            this.button2.TabIndex = 455;
            this.button2.Text = "test";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox_loaimail
            // 
            this.comboBox_loaimail.FormattingEnabled = true;
            this.comboBox_loaimail.Items.AddRange(new object[] {
            "Freneet",
            "Mail.bg",
            "Mail.com",
            "Gmx.com",
            "Gmx.net"});
            this.comboBox_loaimail.Location = new System.Drawing.Point(307, 171);
            this.comboBox_loaimail.Name = "comboBox_loaimail";
            this.comboBox_loaimail.Size = new System.Drawing.Size(145, 21);
            this.comboBox_loaimail.TabIndex = 456;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label10.Location = new System.Drawing.Point(227, 175);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 13);
            this.label10.TabIndex = 457;
            this.label10.Text = "Chọn loại mail: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 575);
            this.Controls.Add(this.comboBox_loaimail);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.kotatchrome);
            this.Controls.Add(this.Chieurong);
            this.Controls.Add(this.Chieudai);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.bnt_stop);
            this.Controls.Add(this.bnt_start);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tool Recover Pass Apple - Oh My Life";
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
            ((System.ComponentModel.ISupportInitialize)(this.Chieudai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chieurong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox cau_trl1;
        private System.Windows.Forms.TextBox cau_trl3;
        private System.Windows.Forms.TextBox cau_trl2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CHECK;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pass;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proxy;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.Label dachon;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolStripMenuItem chọnTấtCảToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chọnBôiĐenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bỏChọnTấtCảToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xóaToolStripMenuItem;
        private System.Windows.Forms.CheckBox randompasscheck;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown Chieudai;
        private System.Windows.Forms.NumericUpDown Chieurong;
        private System.Windows.Forms.Label tongproxy;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox kotatchrome;
        private System.Windows.Forms.ToolStripMenuItem xóaProxyToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox_loaimail;
        private System.Windows.Forms.Label label10;
    }
}

