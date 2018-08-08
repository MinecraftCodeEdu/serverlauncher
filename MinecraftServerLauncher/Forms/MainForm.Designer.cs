namespace MinecraftServerLauncher
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
            this.lblPathInfo = new System.Windows.Forms.Label();
            this.txtMinecraftServerPath = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.lblMemoryInfo = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpServerControl = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnServerInfo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.grpServerControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPathInfo
            // 
            this.lblPathInfo.AutoSize = true;
            this.lblPathInfo.Location = new System.Drawing.Point(12, 9);
            this.lblPathInfo.Name = "lblPathInfo";
            this.lblPathInfo.Size = new System.Drawing.Size(139, 12);
            this.lblPathInfo.TabIndex = 0;
            this.lblPathInfo.Text = "Path to Minecraft server";
            // 
            // txtMinecraftServerPath
            // 
            this.txtMinecraftServerPath.Location = new System.Drawing.Point(14, 25);
            this.txtMinecraftServerPath.Name = "txtMinecraftServerPath";
            this.txtMinecraftServerPath.Size = new System.Drawing.Size(441, 21);
            this.txtMinecraftServerPath.TabIndex = 1;
            this.txtMinecraftServerPath.TextChanged += new System.EventHandler(this.txtMinecraftServerPath_TextChanged);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(462, 25);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(82, 23);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "&Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // lblMemoryInfo
            // 
            this.lblMemoryInfo.AutoSize = true;
            this.lblMemoryInfo.Location = new System.Drawing.Point(12, 63);
            this.lblMemoryInfo.Name = "lblMemoryInfo";
            this.lblMemoryInfo.Size = new System.Drawing.Size(52, 12);
            this.lblMemoryInfo.TabIndex = 3;
            this.lblMemoryInfo.Text = "&Memory";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(73, 63);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 21);
            this.numericUpDown1.TabIndex = 4;
            this.numericUpDown1.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(14, 110);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grpServerControl
            // 
            this.grpServerControl.Controls.Add(this.btnStop);
            this.grpServerControl.Controls.Add(this.btnStart);
            this.grpServerControl.Location = new System.Drawing.Point(13, 154);
            this.grpServerControl.Name = "grpServerControl";
            this.grpServerControl.Size = new System.Drawing.Size(596, 149);
            this.grpServerControl.TabIndex = 6;
            this.grpServerControl.TabStop = false;
            this.grpServerControl.Text = "Server control";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(7, 51);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(7, 21);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnServerInfo
            // 
            this.btnServerInfo.Location = new System.Drawing.Point(117, 110);
            this.btnServerInfo.Name = "btnServerInfo";
            this.btnServerInfo.Size = new System.Drawing.Size(75, 23);
            this.btnServerInfo.TabIndex = 7;
            this.btnServerInfo.Text = "&Info";
            this.btnServerInfo.UseVisualStyleBackColor = true;
            this.btnServerInfo.Click += new System.EventHandler(this.btnServerInfo_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 315);
            this.Controls.Add(this.btnServerInfo);
            this.Controls.Add(this.grpServerControl);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.lblMemoryInfo);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.txtMinecraftServerPath);
            this.Controls.Add(this.lblPathInfo);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Minecraft Server Launcher";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.grpServerControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPathInfo;
        private System.Windows.Forms.TextBox txtMinecraftServerPath;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label lblMemoryInfo;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox grpServerControl;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnServerInfo;
    }
}

