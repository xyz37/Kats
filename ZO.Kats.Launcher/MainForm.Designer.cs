namespace ZO.Kats.Launcher
{
	partial class MainForm
	{
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.tsTime = new System.Windows.Forms.ToolStripStatusLabel();
			this.tsSimsStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.tsLocalIpAddress = new System.Windows.Forms.ToolStripStatusLabel();
			this.tsLogLevel = new System.Windows.Forms.ToolStripDropDownButton();
			this.tsInfo = new System.Windows.Forms.ToolStripMenuItem();
			this.tsDebug = new System.Windows.Forms.ToolStripMenuItem();
			this.tsStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.tsProgress = new System.Windows.Forms.ToolStripProgressBar();
			this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
			this.tcMain = new System.Windows.Forms.TabControl();
			this.tpMonitoring = new System.Windows.Forms.TabPage();
			this.tlpStat = new System.Windows.Forms.TableLayoutPanel();
			this.tpStatistics = new System.Windows.Forms.TabPage();
			this.tpSettings = new System.Windows.Forms.TabPage();
			this.gbConnectInfo = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.ltbUserId = new GS.Win.Forms.UserControls.LabeledTextBox();
			this.lcbAccount = new GS.Win.Forms.UserControls.LabeledComboBox();
			this.mainMenu = new System.Windows.Forms.MenuStrip();
			this.파일ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tsLogin = new System.Windows.Forms.ToolStripMenuItem();
			this.tsLogout = new System.Windows.Forms.ToolStripMenuItem();
			this.xpnlContainerBody.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.tcMain.SuspendLayout();
			this.tpMonitoring.SuspendLayout();
			this.tlpStat.SuspendLayout();
			this.gbConnectInfo.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.mainMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// xpnlContainerBody
			// 
			this.xpnlContainerBody.Controls.Add(this.tcMain);
			this.xpnlContainerBody.Location = new System.Drawing.Point(0, 27);
			this.xpnlContainerBody.Margin = new System.Windows.Forms.Padding(0);
			this.xpnlContainerBody.Padding = new System.Windows.Forms.Padding(10);
			this.xpnlContainerBody.Size = new System.Drawing.Size(1904, 933);
			// 
			// statusStrip
			// 
			this.statusStrip.Font = new System.Drawing.Font("맑은 고딕", 15F);
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsTime,
            this.tsSimsStatus,
            this.tsLocalIpAddress,
            this.tsLogLevel,
            this.tsStatus,
            this.tsProgress});
			this.statusStrip.Location = new System.Drawing.Point(0, 960);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
			this.statusStrip.Size = new System.Drawing.Size(1904, 41);
			this.statusStrip.TabIndex = 5;
			this.statusStrip.Text = "상태 표시";
			// 
			// tsTime
			// 
			this.tsTime.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.tsTime.Name = "tsTime";
			this.tsTime.Size = new System.Drawing.Size(175, 36);
			this.tsTime.Text = "2017-10-16 15:15";
			// 
			// tsSimsStatus
			// 
			this.tsSimsStatus.AutoToolTip = true;
			this.tsSimsStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.tsSimsStatus.ForeColor = System.Drawing.Color.DarkGray;
			this.tsSimsStatus.Name = "tsSimsStatus";
			this.tsSimsStatus.Size = new System.Drawing.Size(107, 36);
			this.tsSimsStatus.Text = "SIMS [OK]";
			// 
			// tsLocalIpAddress
			// 
			this.tsLocalIpAddress.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.tsLocalIpAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(63)))), ((int)(((byte)(35)))));
			this.tsLocalIpAddress.Name = "tsLocalIpAddress";
			this.tsLocalIpAddress.Size = new System.Drawing.Size(127, 36);
			this.tsLocalIpAddress.Text = "192.168.0.31";
			// 
			// tsLogLevel
			// 
			this.tsLogLevel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsLogLevel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsInfo,
            this.tsDebug});
			this.tsLogLevel.Image = global::ZO.Kats.Launcher.Properties.Resources.LogView;
			this.tsLogLevel.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsLogLevel.Name = "tsLogLevel";
			this.tsLogLevel.Size = new System.Drawing.Size(29, 39);
			this.tsLogLevel.Text = "toolStripDropDownButton1";
			this.tsLogLevel.ToolTipText = "Log level";
			// 
			// tsInfo
			// 
			this.tsInfo.BackColor = System.Drawing.Color.LawnGreen;
			this.tsInfo.Checked = true;
			this.tsInfo.CheckOnClick = true;
			this.tsInfo.CheckState = System.Windows.Forms.CheckState.Checked;
			this.tsInfo.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.tsInfo.ForeColor = System.Drawing.Color.Olive;
			this.tsInfo.Name = "tsInfo";
			this.tsInfo.Size = new System.Drawing.Size(127, 24);
			this.tsInfo.Text = "Info";
			// 
			// tsDebug
			// 
			this.tsDebug.CheckOnClick = true;
			this.tsDebug.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.tsDebug.ForeColor = System.Drawing.Color.Coral;
			this.tsDebug.Name = "tsDebug";
			this.tsDebug.Size = new System.Drawing.Size(127, 24);
			this.tsDebug.Text = "Debug";
			// 
			// tsStatus
			// 
			this.tsStatus.Name = "tsStatus";
			this.tsStatus.Size = new System.Drawing.Size(1144, 36);
			this.tsStatus.Spring = true;
			// 
			// tsProgress
			// 
			this.tsProgress.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsProgress.AutoToolTip = true;
			this.tsProgress.MarqueeAnimationSpeed = 50;
			this.tsProgress.Name = "tsProgress";
			this.tsProgress.Size = new System.Drawing.Size(300, 35);
			this.tsProgress.Step = 5;
			this.tsProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			// 
			// tlpMain
			// 
			this.tlpMain.ColumnCount = 1;
			this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpMain.Location = new System.Drawing.Point(0, 611);
			this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
			this.tlpMain.Name = "tlpMain";
			this.tlpMain.RowCount = 2;
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpMain.Size = new System.Drawing.Size(1870, 154);
			this.tlpMain.TabIndex = 5;
			// 
			// tcMain
			// 
			this.tcMain.Controls.Add(this.tpMonitoring);
			this.tcMain.Controls.Add(this.tpStatistics);
			this.tcMain.Controls.Add(this.tpSettings);
			this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tcMain.Location = new System.Drawing.Point(10, 10);
			this.tcMain.Name = "tcMain";
			this.tcMain.SelectedIndex = 0;
			this.tcMain.Size = new System.Drawing.Size(1884, 913);
			this.tcMain.TabIndex = 2;
			// 
			// tpMonitoring
			// 
			this.tpMonitoring.Controls.Add(this.tlpStat);
			this.tpMonitoring.Location = new System.Drawing.Point(4, 32);
			this.tpMonitoring.Name = "tpMonitoring";
			this.tpMonitoring.Padding = new System.Windows.Forms.Padding(3);
			this.tpMonitoring.Size = new System.Drawing.Size(1876, 877);
			this.tpMonitoring.TabIndex = 0;
			this.tpMonitoring.Text = "주문 및 설정";
			this.tpMonitoring.UseVisualStyleBackColor = true;
			// 
			// tlpStat
			// 
			this.tlpStat.ColumnCount = 1;
			this.tlpStat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpStat.Controls.Add(this.gbConnectInfo, 0, 0);
			this.tlpStat.Controls.Add(this.tlpMain, 0, 1);
			this.tlpStat.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpStat.Location = new System.Drawing.Point(3, 3);
			this.tlpStat.Name = "tlpStat";
			this.tlpStat.RowCount = 2;
			this.tlpStat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpStat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 260F));
			this.tlpStat.Size = new System.Drawing.Size(1870, 871);
			this.tlpStat.TabIndex = 0;
			// 
			// tpStatistics
			// 
			this.tpStatistics.Location = new System.Drawing.Point(4, 32);
			this.tpStatistics.Name = "tpStatistics";
			this.tpStatistics.Size = new System.Drawing.Size(928, 851);
			this.tpStatistics.TabIndex = 2;
			this.tpStatistics.Text = " 통    계 ";
			this.tpStatistics.UseVisualStyleBackColor = true;
			// 
			// tpSettings
			// 
			this.tpSettings.Location = new System.Drawing.Point(4, 32);
			this.tpSettings.Name = "tpSettings";
			this.tpSettings.Size = new System.Drawing.Size(928, 851);
			this.tpSettings.TabIndex = 3;
			this.tpSettings.Text = " 설    정 ";
			this.tpSettings.UseVisualStyleBackColor = true;
			// 
			// gbConnectInfo
			// 
			this.gbConnectInfo.Controls.Add(this.tableLayoutPanel1);
			this.gbConnectInfo.Location = new System.Drawing.Point(3, 3);
			this.gbConnectInfo.Name = "gbConnectInfo";
			this.gbConnectInfo.Size = new System.Drawing.Size(886, 79);
			this.gbConnectInfo.TabIndex = 4;
			this.gbConnectInfo.TabStop = false;
			this.gbConnectInfo.Text = "접속 정보";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.ltbUserId, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.lcbAccount, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 27);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(880, 49);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// ltbUserId
			// 
			this.ltbUserId.BackColor = System.Drawing.Color.White;
			this.ltbUserId.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.ltbUserId.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ltbUserId.LabelText = "아 이 디";
			this.ltbUserId.LabelWidth = 130;
			this.ltbUserId.Location = new System.Drawing.Point(3, 3);
			this.ltbUserId.Name = "ltbUserId";
			this.ltbUserId.Size = new System.Drawing.Size(434, 43);
			this.ltbUserId.TabIndex = 0;
			this.ltbUserId.Theme = GS.Win.Forms.UserControls.UserControlThemes.DarkCyan;
			// 
			// lcbAccount
			// 
			this.lcbAccount.BackColor = System.Drawing.Color.White;
			// 
			// 
			// 
			this.lcbAccount.ComboBox.BackColor = System.Drawing.Color.White;
			this.lcbAccount.ComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lcbAccount.ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.lcbAccount.ComboBox.Location = new System.Drawing.Point(0, 0);
			this.lcbAccount.ComboBox.Name = "";
			this.lcbAccount.ComboBox.Size = new System.Drawing.Size(292, 32);
			this.lcbAccount.ComboBox.TabIndex = 0;
			this.lcbAccount.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.lcbAccount.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lcbAccount.LabelText = "증권계좌번호";
			this.lcbAccount.LabelWidth = 130;
			this.lcbAccount.Location = new System.Drawing.Point(443, 3);
			this.lcbAccount.Name = "lcbAccount";
			this.lcbAccount.Size = new System.Drawing.Size(434, 43);
			this.lcbAccount.TabIndex = 1;
			this.lcbAccount.Theme = GS.Win.Forms.UserControls.UserControlThemes.DarkCyan;
			// 
			// mainMenu
			// 
			this.mainMenu.Font = new System.Drawing.Font("맑은 고딕", 10F);
			this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일ToolStripMenuItem});
			this.mainMenu.Location = new System.Drawing.Point(0, 0);
			this.mainMenu.Name = "mainMenu";
			this.mainMenu.Size = new System.Drawing.Size(1904, 27);
			this.mainMenu.TabIndex = 6;
			this.mainMenu.Text = "menuStrip1";
			// 
			// 파일ToolStripMenuItem
			// 
			this.파일ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLogin,
            this.tsLogout});
			this.파일ToolStripMenuItem.Name = "파일ToolStripMenuItem";
			this.파일ToolStripMenuItem.Size = new System.Drawing.Size(64, 23);
			this.파일ToolStripMenuItem.Text = "파일(&F)";
			// 
			// tsLogin
			// 
			this.tsLogin.Name = "tsLogin";
			this.tsLogin.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.L)));
			this.tsLogin.Size = new System.Drawing.Size(205, 24);
			this.tsLogin.Text = "로그 인(&I)";
			// 
			// tsLogout
			// 
			this.tsLogout.Name = "tsLogout";
			this.tsLogout.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.O)));
			this.tsLogout.Size = new System.Drawing.Size(205, 24);
			this.tsLogout.Text = "로그 아웃(&O)";
			// 
			// MainForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(1904, 1001);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.mainMenu);
			this.Font = new System.Drawing.Font("맑은 고딕", 13F);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			this.Name = "MainForm";
			this.Text = ",";
			this.Controls.SetChildIndex(this.mainMenu, 0);
			this.Controls.SetChildIndex(this.statusStrip, 0);
			this.Controls.SetChildIndex(this.xpnlContainerBody, 0);
			this.xpnlContainerBody.ResumeLayout(false);
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.tcMain.ResumeLayout(false);
			this.tpMonitoring.ResumeLayout(false);
			this.tlpStat.ResumeLayout(false);
			this.gbConnectInfo.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.mainMenu.ResumeLayout(false);
			this.mainMenu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripProgressBar tsProgress;
		private System.Windows.Forms.ToolStripStatusLabel tsStatus;
		private System.Windows.Forms.TableLayoutPanel tlpMain;
		private System.Windows.Forms.ToolStripDropDownButton tsLogLevel;
		private System.Windows.Forms.ToolStripMenuItem tsInfo;
		private System.Windows.Forms.ToolStripMenuItem tsDebug;
		private System.Windows.Forms.ToolStripStatusLabel tsSimsStatus;
		private System.Windows.Forms.ToolStripStatusLabel tsLocalIpAddress;
		private System.Windows.Forms.ToolStripStatusLabel tsTime;
		private System.Windows.Forms.TabControl tcMain;
		private System.Windows.Forms.TabPage tpMonitoring;
		private System.Windows.Forms.TabPage tpStatistics;
		private System.Windows.Forms.TabPage tpSettings;
		private System.Windows.Forms.TableLayoutPanel tlpStat;
		private System.Windows.Forms.MenuStrip mainMenu;
		private System.Windows.Forms.ToolStripMenuItem 파일ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem tsLogin;
		private System.Windows.Forms.ToolStripMenuItem tsLogout;
		private System.Windows.Forms.GroupBox gbConnectInfo;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private GS.Win.Forms.UserControls.LabeledTextBox ltbUserId;
		private GS.Win.Forms.UserControls.LabeledComboBox lcbAccount;
	}
}

