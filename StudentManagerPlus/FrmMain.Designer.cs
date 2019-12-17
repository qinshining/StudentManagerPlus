namespace StudentManagerPlus
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCurrentUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.系统SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChangePwd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSwitchAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.学员管理MToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiImportStudents = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiStudentManage = new System.Windows.Forms.ToolStripMenuItem();
            this.成绩管理JToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiScoreAnalysis = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiScoreQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.考勤管理AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSignAttendance = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiAttendanceQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiVisitOfficialWeb = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUpdateSys = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiAboutUs = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnSwitchAccount = new System.Windows.Forms.Button();
            this.btnScoreAnalysis = new System.Windows.Forms.Button();
            this.btnAttendanceManage = new System.Windows.Forms.Button();
            this.btnStudentManage = new System.Windows.Forms.Button();
            this.btnVisitOfficialWeb = new System.Windows.Forms.Button();
            this.btnUpdateSys = new System.Windows.Forms.Button();
            this.btnChangePwd = new System.Windows.Forms.Button();
            this.btnScoreQuery = new System.Windows.Forms.Button();
            this.btnSignAttendance = new System.Windows.Forms.Button();
            this.btnAddStudent = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(7)))), ((int)(((byte)(35)))));
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnMin);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 50);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Frm_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Frm_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Frm_MouseUp);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(1158, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 30);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "×";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnMin
            // 
            this.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMin.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMin.ForeColor = System.Drawing.Color.White;
            this.btnMin.Location = new System.Drawing.Point(1117, 9);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(35, 30);
            this.btnMin.TabIndex = 2;
            this.btnMin.Text = "▂";
            this.btnMin.UseVisualStyleBackColor = true;
            this.btnMin.Click += new System.EventHandler(this.BtnMin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(49, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "学员信息管理系统";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Highlight;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblVersion,
            this.toolStripStatusLabel3,
            this.lblCurrentUser});
            this.statusStrip1.Location = new System.Drawing.Point(0, 653);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1200, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusLabel1.Text = "版本号：";
            // 
            // lblVersion
            // 
            this.lblVersion.ForeColor = System.Drawing.Color.White;
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(66, 17);
            this.lblVersion.Text = "lblVersion";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabel3.Text = "当前用户：";
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.ForeColor = System.Drawing.Color.White;
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(92, 17);
            this.lblCurrentUser.Text = "lblCurrentUser";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统SToolStripMenuItem,
            this.学员管理MToolStripMenuItem,
            this.成绩管理JToolStripMenuItem,
            this.考勤管理AToolStripMenuItem,
            this.帮助HToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 50);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1200, 25);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 系统SToolStripMenuItem
            // 
            this.系统SToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiChangePwd,
            this.tsmiSwitchAccount,
            this.toolStripSeparator1,
            this.tsmiExit});
            this.系统SToolStripMenuItem.Name = "系统SToolStripMenuItem";
            this.系统SToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.系统SToolStripMenuItem.Text = "系统(&S)";
            // 
            // tsmiChangePwd
            // 
            this.tsmiChangePwd.Name = "tsmiChangePwd";
            this.tsmiChangePwd.Size = new System.Drawing.Size(140, 22);
            this.tsmiChangePwd.Text = "密码修改(&C)";
            this.tsmiChangePwd.Click += new System.EventHandler(this.TsmiChangePwd_Click);
            // 
            // tsmiSwitchAccount
            // 
            this.tsmiSwitchAccount.Name = "tsmiSwitchAccount";
            this.tsmiSwitchAccount.Size = new System.Drawing.Size(140, 22);
            this.tsmiSwitchAccount.Text = "账号切换(&T)";
            this.tsmiSwitchAccount.Click += new System.EventHandler(this.TsmiSwitchAccount_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(137, 6);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(140, 22);
            this.tsmiExit.Text = "退出(&E)";
            this.tsmiExit.Click += new System.EventHandler(this.TsmiExit_Click);
            // 
            // 学员管理MToolStripMenuItem
            // 
            this.学员管理MToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddStudent,
            this.tsmiImportStudents,
            this.toolStripSeparator5,
            this.tsmiStudentManage});
            this.学员管理MToolStripMenuItem.Name = "学员管理MToolStripMenuItem";
            this.学员管理MToolStripMenuItem.Size = new System.Drawing.Size(88, 21);
            this.学员管理MToolStripMenuItem.Text = "学员管理(&M)";
            // 
            // tsmiAddStudent
            // 
            this.tsmiAddStudent.Name = "tsmiAddStudent";
            this.tsmiAddStudent.Size = new System.Drawing.Size(166, 22);
            this.tsmiAddStudent.Text = "添加学员(&A)";
            this.tsmiAddStudent.Click += new System.EventHandler(this.TsmiAddStudent_Click);
            // 
            // tsmiImportStudents
            // 
            this.tsmiImportStudents.Name = "tsmiImportStudents";
            this.tsmiImportStudents.Size = new System.Drawing.Size(166, 22);
            this.tsmiImportStudents.Text = "批量导入学员(&I)";
            this.tsmiImportStudents.Click += new System.EventHandler(this.TsmiImportStudents_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(163, 6);
            // 
            // tsmiStudentManage
            // 
            this.tsmiStudentManage.Name = "tsmiStudentManage";
            this.tsmiStudentManage.Size = new System.Drawing.Size(166, 22);
            this.tsmiStudentManage.Text = "学员信息管理(&Q)";
            this.tsmiStudentManage.Click += new System.EventHandler(this.TsmiStudentManage_Click);
            // 
            // 成绩管理JToolStripMenuItem
            // 
            this.成绩管理JToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiScoreAnalysis,
            this.toolStripSeparator4,
            this.tsmiScoreQuery});
            this.成绩管理JToolStripMenuItem.Name = "成绩管理JToolStripMenuItem";
            this.成绩管理JToolStripMenuItem.Size = new System.Drawing.Size(81, 21);
            this.成绩管理JToolStripMenuItem.Text = "成绩管理(&J)";
            // 
            // tsmiScoreAnalysis
            // 
            this.tsmiScoreAnalysis.Name = "tsmiScoreAnalysis";
            this.tsmiScoreAnalysis.Size = new System.Drawing.Size(178, 22);
            this.tsmiScoreAnalysis.Text = "成绩查询与分析(&Q)";
            this.tsmiScoreAnalysis.Click += new System.EventHandler(this.TsmiScoreAnalysis_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(175, 6);
            // 
            // tsmiScoreQuery
            // 
            this.tsmiScoreQuery.Name = "tsmiScoreQuery";
            this.tsmiScoreQuery.Size = new System.Drawing.Size(178, 22);
            this.tsmiScoreQuery.Text = "成绩快速查询(&S)";
            this.tsmiScoreQuery.Click += new System.EventHandler(this.TsmiScoreQuery_Click);
            // 
            // 考勤管理AToolStripMenuItem
            // 
            this.考勤管理AToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSignAttendance,
            this.toolStripSeparator3,
            this.tsmiAttendanceQuery});
            this.考勤管理AToolStripMenuItem.Name = "考勤管理AToolStripMenuItem";
            this.考勤管理AToolStripMenuItem.Size = new System.Drawing.Size(84, 21);
            this.考勤管理AToolStripMenuItem.Text = "考勤管理(&A)";
            // 
            // tsmiSignAttendance
            // 
            this.tsmiSignAttendance.Name = "tsmiSignAttendance";
            this.tsmiSignAttendance.Size = new System.Drawing.Size(142, 22);
            this.tsmiSignAttendance.Text = "考勤打卡(&R)";
            this.tsmiSignAttendance.Click += new System.EventHandler(this.TsmiSignAttendance_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(139, 6);
            // 
            // tsmiAttendanceQuery
            // 
            this.tsmiAttendanceQuery.Name = "tsmiAttendanceQuery";
            this.tsmiAttendanceQuery.Size = new System.Drawing.Size(142, 22);
            this.tsmiAttendanceQuery.Text = "考勤查询(&Q)";
            this.tsmiAttendanceQuery.Click += new System.EventHandler(this.TsmiAttendanceQuery_Click);
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiVisitOfficialWeb,
            this.tsmiUpdateSys,
            this.toolStripSeparator2,
            this.tsmiAboutUs});
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.帮助HToolStripMenuItem.Text = "帮助(&H)";
            // 
            // tsmiVisitOfficialWeb
            // 
            this.tsmiVisitOfficialWeb.Name = "tsmiVisitOfficialWeb";
            this.tsmiVisitOfficialWeb.Size = new System.Drawing.Size(141, 22);
            this.tsmiVisitOfficialWeb.Text = "访问官网(&X)";
            this.tsmiVisitOfficialWeb.Click += new System.EventHandler(this.TsmiVisitOfficialWeb_Click);
            // 
            // tsmiUpdateSys
            // 
            this.tsmiUpdateSys.Name = "tsmiUpdateSys";
            this.tsmiUpdateSys.Size = new System.Drawing.Size(141, 22);
            this.tsmiUpdateSys.Text = "系统升级(&U)";
            this.tsmiUpdateSys.Click += new System.EventHandler(this.TsmiUpdateSys_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(138, 6);
            // 
            // tsmiAboutUs
            // 
            this.tsmiAboutUs.Name = "tsmiAboutUs";
            this.tsmiAboutUs.Size = new System.Drawing.Size(141, 22);
            this.tsmiAboutUs.Text = "关于我们(&A)";
            this.tsmiAboutUs.Click += new System.EventHandler(this.TsmiAboutUs_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 75);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.label4);
            this.splitContainer.Panel1.Controls.Add(this.label3);
            this.splitContainer.Panel1.Controls.Add(this.label2);
            this.splitContainer.Panel1.Controls.Add(this.btnExit);
            this.splitContainer.Panel1.Controls.Add(this.btnImport);
            this.splitContainer.Panel1.Controls.Add(this.btnSwitchAccount);
            this.splitContainer.Panel1.Controls.Add(this.btnScoreAnalysis);
            this.splitContainer.Panel1.Controls.Add(this.btnAttendanceManage);
            this.splitContainer.Panel1.Controls.Add(this.btnStudentManage);
            this.splitContainer.Panel1.Controls.Add(this.btnVisitOfficialWeb);
            this.splitContainer.Panel1.Controls.Add(this.btnUpdateSys);
            this.splitContainer.Panel1.Controls.Add(this.btnChangePwd);
            this.splitContainer.Panel1.Controls.Add(this.btnScoreQuery);
            this.splitContainer.Panel1.Controls.Add(this.btnSignAttendance);
            this.splitContainer.Panel1.Controls.Add(this.btnAddStudent);
            this.splitContainer.Panel1.Controls.Add(this.monthCalendar1);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("splitContainer.Panel2.BackgroundImage")));
            this.splitContainer.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.splitContainer.Size = new System.Drawing.Size(1200, 578);
            this.splitContainer.SplitterDistance = 260;
            this.splitContainer.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Location = new System.Drawing.Point(17, 427);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(220, 1);
            this.label4.TabIndex = 2;
            this.label4.Text = "label2";
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Location = new System.Drawing.Point(17, 497);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(220, 1);
            this.label3.TabIndex = 2;
            this.label3.Text = "label2";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Location = new System.Drawing.Point(17, 357);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 1);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(133)))), ((int)(((byte)(255)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(132, 515);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(105, 35);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "退出系统";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(133)))), ((int)(((byte)(255)))));
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnImport.ForeColor = System.Drawing.Color.White;
            this.btnImport.Image = ((System.Drawing.Image)(resources.GetObject("btnImport.Image")));
            this.btnImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImport.Location = new System.Drawing.Point(132, 445);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(105, 35);
            this.btnImport.TabIndex = 9;
            this.btnImport.Text = "批量导入";
            this.btnImport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // btnSwitchAccount
            // 
            this.btnSwitchAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(133)))), ((int)(((byte)(255)))));
            this.btnSwitchAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSwitchAccount.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSwitchAccount.ForeColor = System.Drawing.Color.White;
            this.btnSwitchAccount.Image = ((System.Drawing.Image)(resources.GetObject("btnSwitchAccount.Image")));
            this.btnSwitchAccount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSwitchAccount.Location = new System.Drawing.Point(132, 375);
            this.btnSwitchAccount.Name = "btnSwitchAccount";
            this.btnSwitchAccount.Size = new System.Drawing.Size(105, 35);
            this.btnSwitchAccount.TabIndex = 7;
            this.btnSwitchAccount.Text = "账号切换";
            this.btnSwitchAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSwitchAccount.UseVisualStyleBackColor = false;
            this.btnSwitchAccount.Click += new System.EventHandler(this.BtnSwitchAccount_Click);
            // 
            // btnScoreAnalysis
            // 
            this.btnScoreAnalysis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(133)))), ((int)(((byte)(255)))));
            this.btnScoreAnalysis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScoreAnalysis.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnScoreAnalysis.ForeColor = System.Drawing.Color.White;
            this.btnScoreAnalysis.Image = ((System.Drawing.Image)(resources.GetObject("btnScoreAnalysis.Image")));
            this.btnScoreAnalysis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnScoreAnalysis.Location = new System.Drawing.Point(132, 305);
            this.btnScoreAnalysis.Name = "btnScoreAnalysis";
            this.btnScoreAnalysis.Size = new System.Drawing.Size(105, 35);
            this.btnScoreAnalysis.TabIndex = 5;
            this.btnScoreAnalysis.Text = "成绩分析";
            this.btnScoreAnalysis.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnScoreAnalysis.UseVisualStyleBackColor = false;
            this.btnScoreAnalysis.Click += new System.EventHandler(this.BtnScoreAnalysis_Click);
            // 
            // btnAttendanceManage
            // 
            this.btnAttendanceManage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(133)))), ((int)(((byte)(255)))));
            this.btnAttendanceManage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAttendanceManage.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAttendanceManage.ForeColor = System.Drawing.Color.White;
            this.btnAttendanceManage.Image = ((System.Drawing.Image)(resources.GetObject("btnAttendanceManage.Image")));
            this.btnAttendanceManage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAttendanceManage.Location = new System.Drawing.Point(132, 253);
            this.btnAttendanceManage.Name = "btnAttendanceManage";
            this.btnAttendanceManage.Size = new System.Drawing.Size(105, 35);
            this.btnAttendanceManage.TabIndex = 3;
            this.btnAttendanceManage.Text = "考勤管理";
            this.btnAttendanceManage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAttendanceManage.UseVisualStyleBackColor = false;
            this.btnAttendanceManage.Click += new System.EventHandler(this.BtnAttendanceManage_Click);
            // 
            // btnStudentManage
            // 
            this.btnStudentManage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(133)))), ((int)(((byte)(255)))));
            this.btnStudentManage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStudentManage.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStudentManage.ForeColor = System.Drawing.Color.White;
            this.btnStudentManage.Image = ((System.Drawing.Image)(resources.GetObject("btnStudentManage.Image")));
            this.btnStudentManage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStudentManage.Location = new System.Drawing.Point(132, 201);
            this.btnStudentManage.Name = "btnStudentManage";
            this.btnStudentManage.Size = new System.Drawing.Size(105, 35);
            this.btnStudentManage.TabIndex = 1;
            this.btnStudentManage.Text = "学员管理";
            this.btnStudentManage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStudentManage.UseVisualStyleBackColor = false;
            this.btnStudentManage.Click += new System.EventHandler(this.BtnStudentManage_Click);
            // 
            // btnVisitOfficialWeb
            // 
            this.btnVisitOfficialWeb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(133)))), ((int)(((byte)(255)))));
            this.btnVisitOfficialWeb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVisitOfficialWeb.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnVisitOfficialWeb.ForeColor = System.Drawing.Color.White;
            this.btnVisitOfficialWeb.Image = ((System.Drawing.Image)(resources.GetObject("btnVisitOfficialWeb.Image")));
            this.btnVisitOfficialWeb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVisitOfficialWeb.Location = new System.Drawing.Point(17, 515);
            this.btnVisitOfficialWeb.Name = "btnVisitOfficialWeb";
            this.btnVisitOfficialWeb.Size = new System.Drawing.Size(105, 35);
            this.btnVisitOfficialWeb.TabIndex = 10;
            this.btnVisitOfficialWeb.Text = "访问官网";
            this.btnVisitOfficialWeb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVisitOfficialWeb.UseVisualStyleBackColor = false;
            this.btnVisitOfficialWeb.Click += new System.EventHandler(this.BtnVisitOfficialWeb_Click);
            // 
            // btnUpdateSys
            // 
            this.btnUpdateSys.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(133)))), ((int)(((byte)(255)))));
            this.btnUpdateSys.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateSys.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUpdateSys.ForeColor = System.Drawing.Color.White;
            this.btnUpdateSys.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateSys.Image")));
            this.btnUpdateSys.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateSys.Location = new System.Drawing.Point(17, 445);
            this.btnUpdateSys.Name = "btnUpdateSys";
            this.btnUpdateSys.Size = new System.Drawing.Size(105, 35);
            this.btnUpdateSys.TabIndex = 8;
            this.btnUpdateSys.Text = "系统升级";
            this.btnUpdateSys.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdateSys.UseVisualStyleBackColor = false;
            this.btnUpdateSys.Click += new System.EventHandler(this.BtnUpdateSys_Click);
            // 
            // btnChangePwd
            // 
            this.btnChangePwd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(133)))), ((int)(((byte)(255)))));
            this.btnChangePwd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePwd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnChangePwd.ForeColor = System.Drawing.Color.White;
            this.btnChangePwd.Image = ((System.Drawing.Image)(resources.GetObject("btnChangePwd.Image")));
            this.btnChangePwd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChangePwd.Location = new System.Drawing.Point(17, 375);
            this.btnChangePwd.Name = "btnChangePwd";
            this.btnChangePwd.Size = new System.Drawing.Size(105, 35);
            this.btnChangePwd.TabIndex = 6;
            this.btnChangePwd.Text = "密码修改";
            this.btnChangePwd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnChangePwd.UseVisualStyleBackColor = false;
            this.btnChangePwd.Click += new System.EventHandler(this.BtnChangePwd_Click);
            // 
            // btnScoreQuery
            // 
            this.btnScoreQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(133)))), ((int)(((byte)(255)))));
            this.btnScoreQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScoreQuery.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnScoreQuery.ForeColor = System.Drawing.Color.White;
            this.btnScoreQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnScoreQuery.Image")));
            this.btnScoreQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnScoreQuery.Location = new System.Drawing.Point(17, 305);
            this.btnScoreQuery.Name = "btnScoreQuery";
            this.btnScoreQuery.Size = new System.Drawing.Size(105, 35);
            this.btnScoreQuery.TabIndex = 4;
            this.btnScoreQuery.Text = "成绩浏览";
            this.btnScoreQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnScoreQuery.UseVisualStyleBackColor = false;
            this.btnScoreQuery.Click += new System.EventHandler(this.BtnScoreQuery_Click);
            // 
            // btnSignAttendance
            // 
            this.btnSignAttendance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(133)))), ((int)(((byte)(255)))));
            this.btnSignAttendance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignAttendance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSignAttendance.ForeColor = System.Drawing.Color.White;
            this.btnSignAttendance.Image = ((System.Drawing.Image)(resources.GetObject("btnSignAttendance.Image")));
            this.btnSignAttendance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSignAttendance.Location = new System.Drawing.Point(17, 253);
            this.btnSignAttendance.Name = "btnSignAttendance";
            this.btnSignAttendance.Size = new System.Drawing.Size(105, 35);
            this.btnSignAttendance.TabIndex = 2;
            this.btnSignAttendance.Text = "考勤打卡";
            this.btnSignAttendance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSignAttendance.UseVisualStyleBackColor = false;
            this.btnSignAttendance.Click += new System.EventHandler(this.BtnSignAttendance_Click);
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(133)))), ((int)(((byte)(255)))));
            this.btnAddStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddStudent.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddStudent.ForeColor = System.Drawing.Color.White;
            this.btnAddStudent.Image = ((System.Drawing.Image)(resources.GetObject("btnAddStudent.Image")));
            this.btnAddStudent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddStudent.Location = new System.Drawing.Point(17, 201);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(105, 35);
            this.btnAddStudent.TabIndex = 0;
            this.btnAddStudent.Text = "添加学员";
            this.btnAddStudent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddStudent.UseVisualStyleBackColor = false;
            this.btnAddStudent.Click += new System.EventHandler(this.BtnAddStudent_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(17, 9);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1200, 675);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "学员信息管理系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblVersion;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel lblCurrentUser;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 系统SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiChangePwd;
        private System.Windows.Forms.ToolStripMenuItem tsmiSwitchAccount;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem 学员管理MToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddStudent;
        private System.Windows.Forms.ToolStripMenuItem tsmiImportStudents;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem tsmiStudentManage;
        private System.Windows.Forms.ToolStripMenuItem 成绩管理JToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiScoreAnalysis;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tsmiScoreQuery;
        private System.Windows.Forms.ToolStripMenuItem 考勤管理AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiSignAttendance;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmiAttendanceQuery;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiVisitOfficialWeb;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpdateSys;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiAboutUs;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnSwitchAccount;
        private System.Windows.Forms.Button btnScoreAnalysis;
        private System.Windows.Forms.Button btnAttendanceManage;
        private System.Windows.Forms.Button btnStudentManage;
        private System.Windows.Forms.Button btnVisitOfficialWeb;
        private System.Windows.Forms.Button btnUpdateSys;
        private System.Windows.Forms.Button btnChangePwd;
        private System.Windows.Forms.Button btnScoreQuery;
        private System.Windows.Forms.Button btnSignAttendance;
        private System.Windows.Forms.Button btnAddStudent;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}