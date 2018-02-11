namespace GS.IPO.KIS.Forms
{
	partial class FullScreenForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FullScreenForm));
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.tsTime = new System.Windows.Forms.ToolStripStatusLabel();
			this.tsFcsStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.tsPlcStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.tsIpsStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.tsSimsStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.tsLocalIpAddress = new System.Windows.Forms.ToolStripStatusLabel();
			this.tsLogLevel = new System.Windows.Forms.ToolStripDropDownButton();
			this.tsInfo = new System.Windows.Forms.ToolStripMenuItem();
			this.tsDebug = new System.Windows.Forms.ToolStripMenuItem();
			this.tsStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.tsProgress = new System.Windows.Forms.ToolStripProgressBar();
			this.statusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// xpnlContainerBody
			// 
			this.xpnlContainerBody.Margin = new System.Windows.Forms.Padding(0);
			this.xpnlContainerBody.Padding = new System.Windows.Forms.Padding(10);
			this.xpnlContainerBody.Size = new System.Drawing.Size(1904, 960);
			// 
			// statusStrip
			// 
			this.statusStrip.Font = new System.Drawing.Font("맑은 고딕", 16F);
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsTime,
            this.tsFcsStatus,
            this.tsPlcStatus,
            this.tsIpsStatus,
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
			this.tsTime.Size = new System.Drawing.Size(192, 36);
			this.tsTime.Text = "2017-10-16 15:15";
			// 
			// tsFcsStatus
			// 
			this.tsFcsStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.tsFcsStatus.Name = "tsFcsStatus";
			this.tsFcsStatus.Size = new System.Drawing.Size(106, 36);
			this.tsFcsStatus.Text = "FCS [OK]";
			// 
			// tsPlcStatus
			// 
			this.tsPlcStatus.AutoToolTip = true;
			this.tsPlcStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.tsPlcStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsPlcStatus.Name = "tsPlcStatus";
			this.tsPlcStatus.Size = new System.Drawing.Size(107, 36);
			this.tsPlcStatus.Text = "PLC [OK]";
			// 
			// tsIpsStatus
			// 
			this.tsIpsStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.tsIpsStatus.Name = "tsIpsStatus";
			this.tsIpsStatus.Size = new System.Drawing.Size(100, 36);
			this.tsIpsStatus.Text = "IPS [OK]";
			// 
			// tsSimsStatus
			// 
			this.tsSimsStatus.AutoToolTip = true;
			this.tsSimsStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.tsSimsStatus.ForeColor = System.Drawing.Color.DarkGray;
			this.tsSimsStatus.Name = "tsSimsStatus";
			this.tsSimsStatus.Size = new System.Drawing.Size(119, 36);
			this.tsSimsStatus.Text = "SIMS [OK]";
			// 
			// tsLocalIpAddress
			// 
			this.tsLocalIpAddress.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.tsLocalIpAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(63)))), ((int)(((byte)(35)))));
			this.tsLocalIpAddress.Name = "tsLocalIpAddress";
			this.tsLocalIpAddress.Size = new System.Drawing.Size(140, 36);
			this.tsLocalIpAddress.Text = "192.168.0.31";
			// 
			// tsLogLevel
			// 
			this.tsLogLevel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsLogLevel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsInfo,
            this.tsDebug});
			this.tsLogLevel.Image = global::GS.IPO.KIS.Properties.Resources.LogView;
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
			this.tsInfo.Size = new System.Drawing.Size(128, 24);
			this.tsInfo.Text = "Info";
			// 
			// tsDebug
			// 
			this.tsDebug.CheckOnClick = true;
			this.tsDebug.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.tsDebug.ForeColor = System.Drawing.Color.Coral;
			this.tsDebug.Name = "tsDebug";
			this.tsDebug.Size = new System.Drawing.Size(128, 24);
			this.tsDebug.Text = "Debug";
			// 
			// tsStatus
			// 
			this.tsStatus.Name = "tsStatus";
			this.tsStatus.Size = new System.Drawing.Size(789, 36);
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
			// FullScreenForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(1904, 1001);
			this.Controls.Add(this.statusStrip);
			this.Font = new System.Drawing.Font("맑은 고딕", 20F);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			this.Name = "FullScreenForm";
			this.Text = "K-Packet 통합 관리 시스템";
			this.Controls.SetChildIndex(this.statusStrip, 0);
			this.Controls.SetChildIndex(this.xpnlContainerBody, 0);
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel tsPlcStatus;
		private System.Windows.Forms.ToolStripProgressBar tsProgress;
		private System.Windows.Forms.ToolStripStatusLabel tsStatus;
		private System.Windows.Forms.ToolStripDropDownButton tsLogLevel;
		private System.Windows.Forms.ToolStripMenuItem tsInfo;
		private System.Windows.Forms.ToolStripMenuItem tsDebug;
		private System.Windows.Forms.ToolStripStatusLabel tsSimsStatus;
		private System.Windows.Forms.ToolStripStatusLabel tsLocalIpAddress;
		private System.Windows.Forms.ToolStripStatusLabel tsTime;
		private System.Windows.Forms.ToolStripStatusLabel tsFcsStatus;
		private System.Windows.Forms.ToolStripStatusLabel tsIpsStatus;
	}
}

