namespace 编号
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.CodeDataGrid = new System.Windows.Forms.DataGridView();
            this.产品型号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.产品生产年月 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.产品生产序列号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.产品地址 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.产品信道 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.产品程序版本号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.产品备注 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miniToolStrip = new System.Windows.Forms.MenuStrip();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.备注 = new System.Windows.Forms.TextBox();
            this.程序版本 = new System.Windows.Forms.TextBox();
            this.信道 = new System.Windows.Forms.TextBox();
            this.地址 = new System.Windows.Forms.TextBox();
            this.年月 = new System.Windows.Forms.TextBox();
            this.产品序列号 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.型号 = new TX.Framework.WindowUI.Controls.TXComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txGroupBox2 = new TX.Framework.WindowUI.Controls.TXGroupBox();
            this.txButton4 = new TX.Framework.WindowUI.Controls.TXButton();
            this.txButton3 = new TX.Framework.WindowUI.Controls.TXButton();
            this.txButton1 = new TX.Framework.WindowUI.Controls.TXButton();
            this.txButton2 = new TX.Framework.WindowUI.Controls.TXButton();
            this.Time_now = new System.Windows.Forms.Label();
            this.txGroupBox1 = new TX.Framework.WindowUI.Controls.TXGroupBox();
            this.txButtonOpenPort = new TX.Framework.WindowUI.Controls.TXButton();
            this.txButtonFresh = new TX.Framework.WindowUI.Controls.TXButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txComboBoxBaudrate = new TX.Framework.WindowUI.Controls.TXComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txComboBoxPort = new TX.Framework.WindowUI.Controls.TXComboBox();
            this.txTabControl1 = new TX.Framework.WindowUI.Controls.TXTabControl();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CodeDataGrid)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.txGroupBox2.SuspendLayout();
            this.txGroupBox1.SuspendLayout();
            this.txTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.CodeDataGrid);
            this.tabPage4.Controls.Add(this.menuStrip1);
            this.tabPage4.Location = new System.Drawing.Point(4, 33);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(981, 354);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "数据";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // CodeDataGrid
            // 
            this.CodeDataGrid.AllowUserToAddRows = false;
            this.CodeDataGrid.AllowUserToDeleteRows = false;
            this.CodeDataGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.CodeDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CodeDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.产品型号,
            this.产品生产年月,
            this.产品生产序列号,
            this.产品地址,
            this.产品信道,
            this.产品程序版本号,
            this.产品备注});
            this.CodeDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CodeDataGrid.Location = new System.Drawing.Point(3, 31);
            this.CodeDataGrid.MultiSelect = false;
            this.CodeDataGrid.Name = "CodeDataGrid";
            this.CodeDataGrid.RowTemplate.Height = 27;
            this.CodeDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CodeDataGrid.Size = new System.Drawing.Size(975, 320);
            this.CodeDataGrid.TabIndex = 0;
            // 
            // 产品型号
            // 
            this.产品型号.HeaderText = "产品型号";
            this.产品型号.Name = "产品型号";
            // 
            // 产品生产年月
            // 
            this.产品生产年月.HeaderText = "产品生产年月";
            this.产品生产年月.Name = "产品生产年月";
            this.产品生产年月.Width = 150;
            // 
            // 产品生产序列号
            // 
            this.产品生产序列号.HeaderText = "产品生产序列号";
            this.产品生产序列号.Name = "产品生产序列号";
            this.产品生产序列号.Width = 175;
            // 
            // 产品地址
            // 
            this.产品地址.HeaderText = "产品地址";
            this.产品地址.Name = "产品地址";
            // 
            // 产品信道
            // 
            this.产品信道.HeaderText = "产品信道";
            this.产品信道.Name = "产品信道";
            // 
            // 产品程序版本号
            // 
            this.产品程序版本号.HeaderText = "产品程序版本号";
            this.产品程序版本号.Name = "产品程序版本号";
            this.产品程序版本号.Width = 175;
            // 
            // 产品备注
            // 
            this.产品备注.HeaderText = "产品备注";
            this.产品备注.Name = "产品备注";
            this.产品备注.Width = 200;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.查询ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(975, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导出ToolStripMenuItem,
            this.打开ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 导出ToolStripMenuItem
            // 
            this.导出ToolStripMenuItem.Name = "导出ToolStripMenuItem";
            this.导出ToolStripMenuItem.Size = new System.Drawing.Size(114, 26);
            this.导出ToolStripMenuItem.Text = "导出";
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(114, 26);
            this.打开ToolStripMenuItem.Text = "打开";
            // 
            // 查询ToolStripMenuItem
            // 
            this.查询ToolStripMenuItem.Name = "查询ToolStripMenuItem";
            this.查询ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.查询ToolStripMenuItem.Text = "查找";
            this.查询ToolStripMenuItem.Click += new System.EventHandler(this.查询ToolStripMenuItem_Click);
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AccessibleName = "新项选择";
            this.miniToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.miniToolStrip.Location = new System.Drawing.Point(57, 2);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Size = new System.Drawing.Size(975, 28);
            this.miniToolStrip.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.备注);
            this.tabPage3.Controls.Add(this.程序版本);
            this.tabPage3.Controls.Add(this.信道);
            this.tabPage3.Controls.Add(this.地址);
            this.tabPage3.Controls.Add(this.年月);
            this.tabPage3.Controls.Add(this.产品序列号);
            this.tabPage3.Controls.Add(this.textBox1);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.型号);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.txGroupBox2);
            this.tabPage3.Controls.Add(this.Time_now);
            this.tabPage3.Controls.Add(this.txGroupBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 33);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(981, 354);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "编码";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // 备注
            // 
            this.备注.Location = new System.Drawing.Point(115, 315);
            this.备注.Name = "备注";
            this.备注.Size = new System.Drawing.Size(514, 25);
            this.备注.TabIndex = 35;
            // 
            // 程序版本
            // 
            this.程序版本.Enabled = false;
            this.程序版本.Location = new System.Drawing.Point(486, 227);
            this.程序版本.Name = "程序版本";
            this.程序版本.Size = new System.Drawing.Size(143, 25);
            this.程序版本.TabIndex = 33;
            // 
            // 信道
            // 
            this.信道.Location = new System.Drawing.Point(486, 271);
            this.信道.Name = "信道";
            this.信道.Size = new System.Drawing.Size(143, 25);
            this.信道.TabIndex = 31;
            // 
            // 地址
            // 
            this.地址.Location = new System.Drawing.Point(115, 271);
            this.地址.Name = "地址";
            this.地址.Size = new System.Drawing.Size(143, 25);
            this.地址.TabIndex = 30;
            // 
            // 年月
            // 
            this.年月.Enabled = false;
            this.年月.Location = new System.Drawing.Point(486, 177);
            this.年月.Name = "年月";
            this.年月.Size = new System.Drawing.Size(143, 25);
            this.年月.TabIndex = 29;
            // 
            // 产品序列号
            // 
            this.产品序列号.Enabled = false;
            this.产品序列号.ImeMode = System.Windows.Forms.ImeMode.On;
            this.产品序列号.Location = new System.Drawing.Point(119, 222);
            this.产品序列号.Name = "产品序列号";
            this.产品序列号.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.产品序列号.Size = new System.Drawing.Size(139, 25);
            this.产品序列号.TabIndex = 28;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox1.Location = new System.Drawing.Point(3, 18);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(723, 138);
            this.textBox1.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(36, 315);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 25);
            this.label9.TabIndex = 34;
            this.label9.Text = "备注:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(351, 227);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 25);
            this.label8.TabIndex = 32;
            this.label8.Text = "程序版本:";
            // 
            // 型号
            // 
            this.型号.FormattingEnabled = true;
            this.型号.Items.AddRange(new object[] {
            "AU",
            "AJ"});
            this.型号.Location = new System.Drawing.Point(119, 177);
            this.型号.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.型号.Name = "型号";
            this.型号.Size = new System.Drawing.Size(139, 23);
            this.型号.TabIndex = 9;
            this.型号.Text = "AU";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(403, 271);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 25);
            this.label7.TabIndex = 27;
            this.label7.Text = "信道:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(36, 271);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 25);
            this.label6.TabIndex = 26;
            this.label6.Text = "地址:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(10, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 25);
            this.label5.TabIndex = 25;
            this.label5.Text = "序列号:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(403, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 25);
            this.label4.TabIndex = 24;
            this.label4.Text = "年月:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(36, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 25);
            this.label3.TabIndex = 23;
            this.label3.Text = "型号:";
            // 
            // txGroupBox2
            // 
            this.txGroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.txGroupBox2.BorderColor = System.Drawing.Color.Red;
            this.txGroupBox2.CaptionColor = System.Drawing.Color.DarkOrchid;
            this.txGroupBox2.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.txGroupBox2.Controls.Add(this.txButton4);
            this.txGroupBox2.Controls.Add(this.txButton3);
            this.txGroupBox2.Controls.Add(this.txButton1);
            this.txGroupBox2.Controls.Add(this.txButton2);
            this.txGroupBox2.Location = new System.Drawing.Point(732, 160);
            this.txGroupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txGroupBox2.Name = "txGroupBox2";
            this.txGroupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txGroupBox2.Size = new System.Drawing.Size(244, 169);
            this.txGroupBox2.TabIndex = 9;
            this.txGroupBox2.TabStop = false;
            this.txGroupBox2.Text = "功能";
            this.txGroupBox2.TextMargin = 6;
            // 
            // txButton4
            // 
            this.txButton4.Enabled = false;
            this.txButton4.Image = null;
            this.txButton4.Location = new System.Drawing.Point(18, 29);
            this.txButton4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txButton4.Name = "txButton4";
            this.txButton4.Size = new System.Drawing.Size(100, 123);
            this.txButton4.TabIndex = 5;
            this.txButton4.Text = "生成编码";
            this.txButton4.UseVisualStyleBackColor = true;
            this.txButton4.Click += new System.EventHandler(this.txButton4_Click);
            // 
            // txButton3
            // 
            this.txButton3.Image = null;
            this.txButton3.Location = new System.Drawing.Point(135, 123);
            this.txButton3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txButton3.Name = "txButton3";
            this.txButton3.Size = new System.Drawing.Size(100, 29);
            this.txButton3.TabIndex = 4;
            this.txButton3.Text = "清除";
            this.txButton3.UseVisualStyleBackColor = true;
            this.txButton3.Click += new System.EventHandler(this.txButton3_Click);
            // 
            // txButton1
            // 
            this.txButton1.Enabled = false;
            this.txButton1.Image = null;
            this.txButton1.Location = new System.Drawing.Point(135, 76);
            this.txButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txButton1.Name = "txButton1";
            this.txButton1.Size = new System.Drawing.Size(100, 29);
            this.txButton1.TabIndex = 3;
            this.txButton1.Text = "读出参数";
            this.txButton1.UseVisualStyleBackColor = true;
            this.txButton1.Click += new System.EventHandler(this.txButton1_Click);
            // 
            // txButton2
            // 
            this.txButton2.Enabled = false;
            this.txButton2.Image = null;
            this.txButton2.Location = new System.Drawing.Point(135, 29);
            this.txButton2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txButton2.Name = "txButton2";
            this.txButton2.Size = new System.Drawing.Size(100, 29);
            this.txButton2.TabIndex = 3;
            this.txButton2.Text = "写入参数";
            this.txButton2.UseVisualStyleBackColor = true;
            this.txButton2.Click += new System.EventHandler(this.txButton2_Click);
            // 
            // Time_now
            // 
            this.Time_now.AutoSize = true;
            this.Time_now.BackColor = System.Drawing.Color.Transparent;
            this.Time_now.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Time_now.ForeColor = System.Drawing.Color.Blue;
            this.Time_now.Location = new System.Drawing.Point(729, 331);
            this.Time_now.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Time_now.Name = "Time_now";
            this.Time_now.Size = new System.Drawing.Size(214, 20);
            this.Time_now.TabIndex = 8;
            this.Time_now.Text = "yyyy年MM月dd日 HH:mm:ss";
            // 
            // txGroupBox1
            // 
            this.txGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.txGroupBox1.BorderColor = System.Drawing.Color.Red;
            this.txGroupBox1.CaptionColor = System.Drawing.Color.DarkOrchid;
            this.txGroupBox1.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.txGroupBox1.Controls.Add(this.txButtonOpenPort);
            this.txGroupBox1.Controls.Add(this.txButtonFresh);
            this.txGroupBox1.Controls.Add(this.label2);
            this.txGroupBox1.Controls.Add(this.txComboBoxBaudrate);
            this.txGroupBox1.Controls.Add(this.label1);
            this.txGroupBox1.Controls.Add(this.txComboBoxPort);
            this.txGroupBox1.Location = new System.Drawing.Point(732, 5);
            this.txGroupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txGroupBox1.Name = "txGroupBox1";
            this.txGroupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txGroupBox1.Size = new System.Drawing.Size(244, 151);
            this.txGroupBox1.TabIndex = 7;
            this.txGroupBox1.TabStop = false;
            this.txGroupBox1.Text = "串口设置";
            this.txGroupBox1.TextMargin = 6;
            // 
            // txButtonOpenPort
            // 
            this.txButtonOpenPort.Image = null;
            this.txButtonOpenPort.Location = new System.Drawing.Point(128, 108);
            this.txButtonOpenPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txButtonOpenPort.Name = "txButtonOpenPort";
            this.txButtonOpenPort.Size = new System.Drawing.Size(100, 29);
            this.txButtonOpenPort.TabIndex = 3;
            this.txButtonOpenPort.Text = "打开串口";
            this.txButtonOpenPort.UseVisualStyleBackColor = true;
            this.txButtonOpenPort.Click += new System.EventHandler(this.txButtonOpenPort_Click);
            // 
            // txButtonFresh
            // 
            this.txButtonFresh.Image = null;
            this.txButtonFresh.Location = new System.Drawing.Point(19, 108);
            this.txButtonFresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txButtonFresh.Name = "txButtonFresh";
            this.txButtonFresh.Size = new System.Drawing.Size(100, 29);
            this.txButtonFresh.TabIndex = 3;
            this.txButtonFresh.Text = "刷新串口";
            this.txButtonFresh.UseVisualStyleBackColor = true;
            this.txButtonFresh.Click += new System.EventHandler(this.txButtonFresh_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "波特率：";
            // 
            // txComboBoxBaudrate
            // 
            this.txComboBoxBaudrate.FormattingEnabled = true;
            this.txComboBoxBaudrate.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "56000",
            "57600",
            "115200",
            "128000",
            "256000",
            "460800"});
            this.txComboBoxBaudrate.Location = new System.Drawing.Point(89, 66);
            this.txComboBoxBaudrate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txComboBoxBaudrate.Name = "txComboBoxBaudrate";
            this.txComboBoxBaudrate.Size = new System.Drawing.Size(139, 23);
            this.txComboBoxBaudrate.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "串口号：";
            // 
            // txComboBoxPort
            // 
            this.txComboBoxPort.FormattingEnabled = true;
            this.txComboBoxPort.Location = new System.Drawing.Point(89, 29);
            this.txComboBoxPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txComboBoxPort.Name = "txComboBoxPort";
            this.txComboBoxPort.Size = new System.Drawing.Size(139, 23);
            this.txComboBoxPort.TabIndex = 1;
            // 
            // txTabControl1
            // 
            this.txTabControl1.BaseTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.txTabControl1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txTabControl1.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txTabControl1.CheckedTabColor = System.Drawing.Color.Blue;
            this.txTabControl1.Controls.Add(this.tabPage3);
            this.txTabControl1.Controls.Add(this.tabPage4);
            this.txTabControl1.HeightLightTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txTabControl1.Location = new System.Drawing.Point(3, 2);
            this.txTabControl1.Name = "txTabControl1";
            this.txTabControl1.SelectedIndex = 0;
            this.txTabControl1.Size = new System.Drawing.Size(989, 391);
            this.txTabControl1.TabCornerRadius = 3;
            this.txTabControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 397);
            this.Controls.Add(this.txTabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.miniToolStrip;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "编码";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CodeDataGrid)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.txGroupBox2.ResumeLayout(false);
            this.txGroupBox1.ResumeLayout(false);
            this.txGroupBox1.PerformLayout();
            this.txTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TabPage tabPage4;
        public System.Windows.Forms.DataGridView CodeDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn 产品型号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 产品生产年月;
        private System.Windows.Forms.DataGridViewTextBoxColumn 产品生产序列号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 产品地址;
        private System.Windows.Forms.DataGridViewTextBoxColumn 产品信道;
        private System.Windows.Forms.DataGridViewTextBoxColumn 产品程序版本号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 产品备注;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询ToolStripMenuItem;
        private System.Windows.Forms.MenuStrip miniToolStrip;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox 备注;
        private System.Windows.Forms.TextBox 程序版本;
        private System.Windows.Forms.TextBox 信道;
        private System.Windows.Forms.TextBox 地址;
        private System.Windows.Forms.TextBox 年月;
        private System.Windows.Forms.TextBox 产品序列号;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private TX.Framework.WindowUI.Controls.TXComboBox 型号;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private TX.Framework.WindowUI.Controls.TXGroupBox txGroupBox2;
        private TX.Framework.WindowUI.Controls.TXButton txButton4;
        private TX.Framework.WindowUI.Controls.TXButton txButton3;
        private TX.Framework.WindowUI.Controls.TXButton txButton1;
        private TX.Framework.WindowUI.Controls.TXButton txButton2;
        private System.Windows.Forms.Label Time_now;
        private TX.Framework.WindowUI.Controls.TXGroupBox txGroupBox1;
        private TX.Framework.WindowUI.Controls.TXButton txButtonOpenPort;
        private TX.Framework.WindowUI.Controls.TXButton txButtonFresh;
        private System.Windows.Forms.Label label2;
        private TX.Framework.WindowUI.Controls.TXComboBox txComboBoxBaudrate;
        private System.Windows.Forms.Label label1;
        private TX.Framework.WindowUI.Controls.TXComboBox txComboBoxPort;
        private TX.Framework.WindowUI.Controls.TXTabControl txTabControl1;
    }
}

