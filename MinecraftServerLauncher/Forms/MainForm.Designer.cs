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
            this.components = new System.ComponentModel.Container();
            this.lblPathInfo = new System.Windows.Forms.Label();
            this.txtMinecraftServerPath = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.lblMemoryInfo = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpServerControl = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtTeacherIPaddress = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnDefault = new System.Windows.Forms.Button();
            this.btnStart2 = new System.Windows.Forms.Button();
            this.btnServerInfo = new System.Windows.Forms.Button();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.btnGamemode_survival = new System.Windows.Forms.Button();
            this.btnGamemode_creative = new System.Windows.Forms.Button();
            this.btnGamemode_spectator = new System.Windows.Forms.Button();
            this.grpGamemode = new System.Windows.Forms.GroupBox();
            this.btnGamemode_adventure = new System.Windows.Forms.Button();
            this.grpDifficulty = new System.Windows.Forms.GroupBox();
            this.btnDifficulty_hard = new System.Windows.Forms.Button();
            this.btnDifficulty_normal = new System.Windows.Forms.Button();
            this.btnDifficulty_easy = new System.Windows.Forms.Button();
            this.btnDifficulty_peaceful = new System.Windows.Forms.Button();
            this.grpTime = new System.Windows.Forms.GroupBox();
            this.chkboxTimeFix = new System.Windows.Forms.CheckBox();
            this.btnTime_night = new System.Windows.Forms.Button();
            this.btnTime_day = new System.Windows.Forms.Button();
            this.grpWeather = new System.Windows.Forms.GroupBox();
            this.chkboxWeatherFix = new System.Windows.Forms.CheckBox();
            this.btnWeatherThunder = new System.Windows.Forms.Button();
            this.btnWeatherRain = new System.Windows.Forms.Button();
            this.btnWeatherClear = new System.Windows.Forms.Button();
            this.grpGiveItem = new System.Windows.Forms.GroupBox();
            this.comboItemPlayer = new System.Windows.Forms.ComboBox();
            this.numItem = new System.Windows.Forms.NumericUpDown();
            this.comboItemName = new System.Windows.Forms.ComboBox();
            this.btnGive = new System.Windows.Forms.Button();
            this.comboItemCategory = new System.Windows.Forms.ComboBox();
            this.grpDisable = new System.Windows.Forms.GroupBox();
            this.grpOption = new System.Windows.Forms.GroupBox();
            this.chkCommandPaused = new System.Windows.Forms.CheckBox();
            this.chkPreventExplode = new System.Windows.Forms.CheckBox();
            this.chkWorldEdit = new System.Windows.Forms.CheckBox();
            this.chkPlayerInvincible = new System.Windows.Forms.CheckBox();
            this.chkPreventPK = new System.Windows.Forms.CheckBox();
            this.chkChatPaused = new System.Windows.Forms.CheckBox();
            this.playerList = new System.Windows.Forms.ListBox();
            this.grpPlayers = new System.Windows.Forms.GroupBox();
            this.btnUnfreezeAll = new System.Windows.Forms.Button();
            this.btnFreezeAll = new System.Windows.Forms.Button();
            this.btnWebStart = new System.Windows.Forms.Button();
            this.btnWebStop = new System.Windows.Forms.Button();
            this.grpWebServer = new System.Windows.Forms.GroupBox();
            this.txtWorldFolder = new System.Windows.Forms.TextBox();
            this.btnCompress = new System.Windows.Forms.Button();
            this.grpWorldControl = new System.Windows.Forms.GroupBox();
            this.btnWorldMove = new System.Windows.Forms.Button();
            this.btnWorldCreate = new System.Windows.Forms.Button();
            this.comboWorldProperty = new System.Windows.Forms.ComboBox();
            this.txtWorldName = new System.Windows.Forms.TextBox();
            this.contextMenuPlayerList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.opToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.freezeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unfreezeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bringToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpFreeze = new System.Windows.Forms.GroupBox();
            this.grpTimer = new System.Windows.Forms.GroupBox();
            this.numTimerSec = new System.Windows.Forms.NumericUpDown();
            this.lblTimer = new System.Windows.Forms.Label();
            this.btnTimerStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.grpServerControl.SuspendLayout();
            this.grpGamemode.SuspendLayout();
            this.grpDifficulty.SuspendLayout();
            this.grpTime.SuspendLayout();
            this.grpWeather.SuspendLayout();
            this.grpGiveItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numItem)).BeginInit();
            this.grpDisable.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.grpPlayers.SuspendLayout();
            this.grpWebServer.SuspendLayout();
            this.grpWorldControl.SuspendLayout();
            this.contextMenuPlayerList.SuspendLayout();
            this.grpFreeze.SuspendLayout();
            this.grpTimer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimerSec)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPathInfo
            // 
            this.lblPathInfo.AutoSize = true;
            this.lblPathInfo.Location = new System.Drawing.Point(6, 17);
            this.lblPathInfo.Name = "lblPathInfo";
            this.lblPathInfo.Size = new System.Drawing.Size(139, 12);
            this.lblPathInfo.TabIndex = 0;
            this.lblPathInfo.Text = "Path to Minecraft server";
            // 
            // txtMinecraftServerPath
            // 
            this.txtMinecraftServerPath.Location = new System.Drawing.Point(6, 32);
            this.txtMinecraftServerPath.Name = "txtMinecraftServerPath";
            this.txtMinecraftServerPath.Size = new System.Drawing.Size(160, 21);
            this.txtMinecraftServerPath.TabIndex = 1;
            this.txtMinecraftServerPath.TextChanged += new System.EventHandler(this.txtMinecraftServerPath_TextChanged);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(172, 31);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(82, 23);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "&Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Visible = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // lblMemoryInfo
            // 
            this.lblMemoryInfo.AutoSize = true;
            this.lblMemoryInfo.Location = new System.Drawing.Point(260, 31);
            this.lblMemoryInfo.Name = "lblMemoryInfo";
            this.lblMemoryInfo.Size = new System.Drawing.Size(52, 12);
            this.lblMemoryInfo.TabIndex = 3;
            this.lblMemoryInfo.Text = "&Memory";
            this.lblMemoryInfo.Visible = false;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(318, 32);
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
            this.numericUpDown1.Visible = false;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(87, 59);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grpServerControl
            // 
            this.grpServerControl.Controls.Add(this.btnRefresh);
            this.grpServerControl.Controls.Add(this.txtTeacherIPaddress);
            this.grpServerControl.Controls.Add(this.btnStart);
            this.grpServerControl.Controls.Add(this.btnStop);
            this.grpServerControl.Location = new System.Drawing.Point(12, 12);
            this.grpServerControl.Name = "grpServerControl";
            this.grpServerControl.Size = new System.Drawing.Size(330, 53);
            this.grpServerControl.TabIndex = 6;
            this.grpServerControl.TabStop = false;
            this.grpServerControl.Text = "Server";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(249, 20);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 26;
            this.btnRefresh.Text = "refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtTeacherIPaddress
            // 
            this.txtTeacherIPaddress.Location = new System.Drawing.Point(168, 20);
            this.txtTeacherIPaddress.Name = "txtTeacherIPaddress";
            this.txtTeacherIPaddress.ReadOnly = true;
            this.txtTeacherIPaddress.Size = new System.Drawing.Size(75, 21);
            this.txtTeacherIPaddress.TabIndex = 16;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(6, 20);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 12;
            this.btnStart.Text = "시작";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(87, 20);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "중지";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(249, 58);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(75, 23);
            this.btnDefault.TabIndex = 17;
            this.btnDefault.Text = "default";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Visible = false;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // btnStart2
            // 
            this.btnStart2.Location = new System.Drawing.Point(6, 59);
            this.btnStart2.Name = "btnStart2";
            this.btnStart2.Size = new System.Drawing.Size(75, 23);
            this.btnStart2.TabIndex = 0;
            this.btnStart2.Text = "Start";
            this.btnStart2.UseVisualStyleBackColor = true;
            this.btnStart2.Visible = false;
            this.btnStart2.Click += new System.EventHandler(this.btnStart2_Click);
            // 
            // btnServerInfo
            // 
            this.btnServerInfo.Location = new System.Drawing.Point(168, 59);
            this.btnServerInfo.Name = "btnServerInfo";
            this.btnServerInfo.Size = new System.Drawing.Size(75, 23);
            this.btnServerInfo.TabIndex = 7;
            this.btnServerInfo.Text = "&Info";
            this.btnServerInfo.UseVisualStyleBackColor = true;
            this.btnServerInfo.Visible = false;
            this.btnServerInfo.Click += new System.EventHandler(this.btnServerInfo_Click);
            // 
            // txtCommand
            // 
            this.txtCommand.Location = new System.Drawing.Point(348, 469);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(504, 21);
            this.txtCommand.TabIndex = 10;
            this.txtCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCommand_KeyDown);
            // 
            // txtConsole
            // 
            this.txtConsole.AcceptsReturn = true;
            this.txtConsole.BackColor = System.Drawing.SystemColors.Window;
            this.txtConsole.Location = new System.Drawing.Point(348, 248);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ReadOnly = true;
            this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtConsole.Size = new System.Drawing.Size(504, 218);
            this.txtConsole.TabIndex = 12;
            this.txtConsole.TextChanged += new System.EventHandler(this.txtConsole_TextChanged);
            // 
            // btnGamemode_survival
            // 
            this.btnGamemode_survival.Location = new System.Drawing.Point(6, 20);
            this.btnGamemode_survival.Name = "btnGamemode_survival";
            this.btnGamemode_survival.Size = new System.Drawing.Size(75, 23);
            this.btnGamemode_survival.TabIndex = 13;
            this.btnGamemode_survival.Text = "survival";
            this.btnGamemode_survival.UseVisualStyleBackColor = true;
            this.btnGamemode_survival.Click += new System.EventHandler(this.btnGamemode_survival_Click);
            // 
            // btnGamemode_creative
            // 
            this.btnGamemode_creative.Location = new System.Drawing.Point(87, 20);
            this.btnGamemode_creative.Name = "btnGamemode_creative";
            this.btnGamemode_creative.Size = new System.Drawing.Size(75, 23);
            this.btnGamemode_creative.TabIndex = 14;
            this.btnGamemode_creative.Text = "creative";
            this.btnGamemode_creative.UseVisualStyleBackColor = true;
            this.btnGamemode_creative.Click += new System.EventHandler(this.btnGamemode_creative_Click);
            // 
            // btnGamemode_spectator
            // 
            this.btnGamemode_spectator.Location = new System.Drawing.Point(249, 20);
            this.btnGamemode_spectator.Name = "btnGamemode_spectator";
            this.btnGamemode_spectator.Size = new System.Drawing.Size(75, 23);
            this.btnGamemode_spectator.TabIndex = 15;
            this.btnGamemode_spectator.Text = "spectator";
            this.btnGamemode_spectator.UseVisualStyleBackColor = true;
            this.btnGamemode_spectator.Click += new System.EventHandler(this.btnGamemode_spectator_Click);
            // 
            // grpGamemode
            // 
            this.grpGamemode.Controls.Add(this.btnGamemode_adventure);
            this.grpGamemode.Controls.Add(this.btnGamemode_spectator);
            this.grpGamemode.Controls.Add(this.btnGamemode_survival);
            this.grpGamemode.Controls.Add(this.btnGamemode_creative);
            this.grpGamemode.Location = new System.Drawing.Point(12, 71);
            this.grpGamemode.Name = "grpGamemode";
            this.grpGamemode.Size = new System.Drawing.Size(330, 53);
            this.grpGamemode.TabIndex = 17;
            this.grpGamemode.TabStop = false;
            this.grpGamemode.Text = "Gamemode";
            // 
            // btnGamemode_adventure
            // 
            this.btnGamemode_adventure.Location = new System.Drawing.Point(168, 20);
            this.btnGamemode_adventure.Name = "btnGamemode_adventure";
            this.btnGamemode_adventure.Size = new System.Drawing.Size(75, 23);
            this.btnGamemode_adventure.TabIndex = 18;
            this.btnGamemode_adventure.Text = "adventure";
            this.btnGamemode_adventure.UseVisualStyleBackColor = true;
            this.btnGamemode_adventure.Click += new System.EventHandler(this.btnGamemode_adventure_Click);
            // 
            // grpDifficulty
            // 
            this.grpDifficulty.Controls.Add(this.btnDifficulty_hard);
            this.grpDifficulty.Controls.Add(this.btnDifficulty_normal);
            this.grpDifficulty.Controls.Add(this.btnDifficulty_easy);
            this.grpDifficulty.Controls.Add(this.btnDifficulty_peaceful);
            this.grpDifficulty.Location = new System.Drawing.Point(12, 130);
            this.grpDifficulty.Name = "grpDifficulty";
            this.grpDifficulty.Size = new System.Drawing.Size(330, 53);
            this.grpDifficulty.TabIndex = 18;
            this.grpDifficulty.TabStop = false;
            this.grpDifficulty.Text = "Difficulty";
            // 
            // btnDifficulty_hard
            // 
            this.btnDifficulty_hard.Location = new System.Drawing.Point(249, 20);
            this.btnDifficulty_hard.Name = "btnDifficulty_hard";
            this.btnDifficulty_hard.Size = new System.Drawing.Size(75, 23);
            this.btnDifficulty_hard.TabIndex = 21;
            this.btnDifficulty_hard.Text = "hard";
            this.btnDifficulty_hard.UseVisualStyleBackColor = true;
            this.btnDifficulty_hard.Click += new System.EventHandler(this.btnDifficulty_hard_Click);
            // 
            // btnDifficulty_normal
            // 
            this.btnDifficulty_normal.Location = new System.Drawing.Point(168, 20);
            this.btnDifficulty_normal.Name = "btnDifficulty_normal";
            this.btnDifficulty_normal.Size = new System.Drawing.Size(75, 23);
            this.btnDifficulty_normal.TabIndex = 20;
            this.btnDifficulty_normal.Text = "normal";
            this.btnDifficulty_normal.UseVisualStyleBackColor = true;
            this.btnDifficulty_normal.Click += new System.EventHandler(this.btnDifficulty_normal_Click);
            // 
            // btnDifficulty_easy
            // 
            this.btnDifficulty_easy.Location = new System.Drawing.Point(87, 20);
            this.btnDifficulty_easy.Name = "btnDifficulty_easy";
            this.btnDifficulty_easy.Size = new System.Drawing.Size(75, 23);
            this.btnDifficulty_easy.TabIndex = 19;
            this.btnDifficulty_easy.Text = "easy";
            this.btnDifficulty_easy.UseVisualStyleBackColor = true;
            this.btnDifficulty_easy.Click += new System.EventHandler(this.btnDifficulty_easy_Click);
            // 
            // btnDifficulty_peaceful
            // 
            this.btnDifficulty_peaceful.Location = new System.Drawing.Point(6, 20);
            this.btnDifficulty_peaceful.Name = "btnDifficulty_peaceful";
            this.btnDifficulty_peaceful.Size = new System.Drawing.Size(75, 23);
            this.btnDifficulty_peaceful.TabIndex = 19;
            this.btnDifficulty_peaceful.Text = "peaceful";
            this.btnDifficulty_peaceful.UseVisualStyleBackColor = true;
            this.btnDifficulty_peaceful.Click += new System.EventHandler(this.btnDifficulty_peaceful_Click);
            // 
            // grpTime
            // 
            this.grpTime.Controls.Add(this.chkboxTimeFix);
            this.grpTime.Controls.Add(this.btnTime_night);
            this.grpTime.Controls.Add(this.btnTime_day);
            this.grpTime.Location = new System.Drawing.Point(12, 248);
            this.grpTime.Name = "grpTime";
            this.grpTime.Size = new System.Drawing.Size(330, 53);
            this.grpTime.TabIndex = 19;
            this.grpTime.TabStop = false;
            this.grpTime.Text = "Time";
            // 
            // chkboxTimeFix
            // 
            this.chkboxTimeFix.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkboxTimeFix.Checked = true;
            this.chkboxTimeFix.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkboxTimeFix.Location = new System.Drawing.Point(249, 20);
            this.chkboxTimeFix.Name = "chkboxTimeFix";
            this.chkboxTimeFix.Size = new System.Drawing.Size(75, 23);
            this.chkboxTimeFix.TabIndex = 20;
            this.chkboxTimeFix.Text = "fix";
            this.chkboxTimeFix.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkboxTimeFix.UseVisualStyleBackColor = true;
            this.chkboxTimeFix.CheckedChanged += new System.EventHandler(this.chkboxTimeFix_CheckedChanged);
            // 
            // btnTime_night
            // 
            this.btnTime_night.Location = new System.Drawing.Point(87, 20);
            this.btnTime_night.Name = "btnTime_night";
            this.btnTime_night.Size = new System.Drawing.Size(75, 23);
            this.btnTime_night.TabIndex = 21;
            this.btnTime_night.Text = "night";
            this.btnTime_night.UseVisualStyleBackColor = true;
            this.btnTime_night.Click += new System.EventHandler(this.btnTime_night_Click);
            // 
            // btnTime_day
            // 
            this.btnTime_day.Location = new System.Drawing.Point(6, 20);
            this.btnTime_day.Name = "btnTime_day";
            this.btnTime_day.Size = new System.Drawing.Size(75, 23);
            this.btnTime_day.TabIndex = 20;
            this.btnTime_day.Text = "day";
            this.btnTime_day.UseVisualStyleBackColor = true;
            this.btnTime_day.Click += new System.EventHandler(this.btnTime_day_Click);
            // 
            // grpWeather
            // 
            this.grpWeather.Controls.Add(this.chkboxWeatherFix);
            this.grpWeather.Controls.Add(this.btnWeatherThunder);
            this.grpWeather.Controls.Add(this.btnWeatherRain);
            this.grpWeather.Controls.Add(this.btnWeatherClear);
            this.grpWeather.Location = new System.Drawing.Point(12, 189);
            this.grpWeather.Name = "grpWeather";
            this.grpWeather.Size = new System.Drawing.Size(330, 53);
            this.grpWeather.TabIndex = 20;
            this.grpWeather.TabStop = false;
            this.grpWeather.Text = "Weather";
            // 
            // chkboxWeatherFix
            // 
            this.chkboxWeatherFix.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkboxWeatherFix.Checked = true;
            this.chkboxWeatherFix.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkboxWeatherFix.Location = new System.Drawing.Point(249, 20);
            this.chkboxWeatherFix.Name = "chkboxWeatherFix";
            this.chkboxWeatherFix.Size = new System.Drawing.Size(75, 23);
            this.chkboxWeatherFix.TabIndex = 21;
            this.chkboxWeatherFix.Text = "fix";
            this.chkboxWeatherFix.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkboxWeatherFix.UseVisualStyleBackColor = true;
            this.chkboxWeatherFix.CheckedChanged += new System.EventHandler(this.chkboxWeatherFix_CheckedChanged);
            // 
            // btnWeatherThunder
            // 
            this.btnWeatherThunder.Location = new System.Drawing.Point(168, 20);
            this.btnWeatherThunder.Name = "btnWeatherThunder";
            this.btnWeatherThunder.Size = new System.Drawing.Size(75, 23);
            this.btnWeatherThunder.TabIndex = 23;
            this.btnWeatherThunder.Text = "thunder";
            this.btnWeatherThunder.UseVisualStyleBackColor = true;
            this.btnWeatherThunder.Click += new System.EventHandler(this.btnWeatherThunder_Click);
            // 
            // btnWeatherRain
            // 
            this.btnWeatherRain.Location = new System.Drawing.Point(87, 20);
            this.btnWeatherRain.Name = "btnWeatherRain";
            this.btnWeatherRain.Size = new System.Drawing.Size(75, 23);
            this.btnWeatherRain.TabIndex = 22;
            this.btnWeatherRain.Text = "rain";
            this.btnWeatherRain.UseVisualStyleBackColor = true;
            this.btnWeatherRain.Click += new System.EventHandler(this.btnWeatherRain_Click);
            // 
            // btnWeatherClear
            // 
            this.btnWeatherClear.Location = new System.Drawing.Point(6, 20);
            this.btnWeatherClear.Name = "btnWeatherClear";
            this.btnWeatherClear.Size = new System.Drawing.Size(75, 23);
            this.btnWeatherClear.TabIndex = 21;
            this.btnWeatherClear.Text = "clear";
            this.btnWeatherClear.UseVisualStyleBackColor = true;
            this.btnWeatherClear.Click += new System.EventHandler(this.btnWeatherClear_Click);
            // 
            // grpGiveItem
            // 
            this.grpGiveItem.Controls.Add(this.comboItemPlayer);
            this.grpGiveItem.Controls.Add(this.numItem);
            this.grpGiveItem.Controls.Add(this.comboItemName);
            this.grpGiveItem.Controls.Add(this.btnGive);
            this.grpGiveItem.Controls.Add(this.comboItemCategory);
            this.grpGiveItem.Location = new System.Drawing.Point(12, 307);
            this.grpGiveItem.Name = "grpGiveItem";
            this.grpGiveItem.Size = new System.Drawing.Size(330, 72);
            this.grpGiveItem.TabIndex = 22;
            this.grpGiveItem.TabStop = false;
            this.grpGiveItem.Text = "Give item";
            // 
            // comboItemPlayer
            // 
            this.comboItemPlayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboItemPlayer.FormattingEnabled = true;
            this.comboItemPlayer.Location = new System.Drawing.Point(168, 20);
            this.comboItemPlayer.Name = "comboItemPlayer";
            this.comboItemPlayer.Size = new System.Drawing.Size(156, 20);
            this.comboItemPlayer.TabIndex = 31;
            // 
            // numItem
            // 
            this.numItem.Location = new System.Drawing.Point(168, 46);
            this.numItem.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.numItem.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numItem.Name = "numItem";
            this.numItem.Size = new System.Drawing.Size(75, 21);
            this.numItem.TabIndex = 26;
            this.numItem.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // comboItemName
            // 
            this.comboItemName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboItemName.FormattingEnabled = true;
            this.comboItemName.Location = new System.Drawing.Point(6, 46);
            this.comboItemName.Name = "comboItemName";
            this.comboItemName.Size = new System.Drawing.Size(156, 20);
            this.comboItemName.TabIndex = 24;
            // 
            // btnGive
            // 
            this.btnGive.Location = new System.Drawing.Point(249, 45);
            this.btnGive.Name = "btnGive";
            this.btnGive.Size = new System.Drawing.Size(75, 23);
            this.btnGive.TabIndex = 24;
            this.btnGive.Text = "give";
            this.btnGive.UseVisualStyleBackColor = true;
            this.btnGive.Click += new System.EventHandler(this.btnGive_Click);
            // 
            // comboItemCategory
            // 
            this.comboItemCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboItemCategory.FormattingEnabled = true;
            this.comboItemCategory.Location = new System.Drawing.Point(6, 20);
            this.comboItemCategory.Name = "comboItemCategory";
            this.comboItemCategory.Size = new System.Drawing.Size(156, 20);
            this.comboItemCategory.TabIndex = 24;
            this.comboItemCategory.SelectedIndexChanged += new System.EventHandler(this.comboItemCategory_SelectedIndexChanged);
            // 
            // grpDisable
            // 
            this.grpDisable.Controls.Add(this.btnDefault);
            this.grpDisable.Controls.Add(this.lblPathInfo);
            this.grpDisable.Controls.Add(this.txtMinecraftServerPath);
            this.grpDisable.Controls.Add(this.btnOpen);
            this.grpDisable.Controls.Add(this.lblMemoryInfo);
            this.grpDisable.Controls.Add(this.numericUpDown1);
            this.grpDisable.Controls.Add(this.btnStart2);
            this.grpDisable.Controls.Add(this.btnSave);
            this.grpDisable.Controls.Add(this.btnServerInfo);
            this.grpDisable.Location = new System.Drawing.Point(391, 347);
            this.grpDisable.Name = "grpDisable";
            this.grpDisable.Size = new System.Drawing.Size(451, 100);
            this.grpDisable.TabIndex = 23;
            this.grpDisable.TabStop = false;
            this.grpDisable.Text = "Disable";
            this.grpDisable.Visible = false;
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.chkCommandPaused);
            this.grpOption.Controls.Add(this.chkPreventExplode);
            this.grpOption.Controls.Add(this.chkWorldEdit);
            this.grpOption.Controls.Add(this.chkPlayerInvincible);
            this.grpOption.Controls.Add(this.chkPreventPK);
            this.grpOption.Controls.Add(this.chkChatPaused);
            this.grpOption.Location = new System.Drawing.Point(12, 385);
            this.grpOption.Name = "grpOption";
            this.grpOption.Size = new System.Drawing.Size(330, 108);
            this.grpOption.TabIndex = 24;
            this.grpOption.TabStop = false;
            this.grpOption.Text = "Option";
            // 
            // chkCommandPaused
            // 
            this.chkCommandPaused.AutoSize = true;
            this.chkCommandPaused.Location = new System.Drawing.Point(168, 20);
            this.chkCommandPaused.Name = "chkCommandPaused";
            this.chkCommandPaused.Size = new System.Drawing.Size(88, 16);
            this.chkCommandPaused.TabIndex = 25;
            this.chkCommandPaused.Text = "명령어 제한";
            this.chkCommandPaused.UseVisualStyleBackColor = true;
            this.chkCommandPaused.CheckedChanged += new System.EventHandler(this.chkCommandPaused_CheckedChanged);
            // 
            // chkPreventExplode
            // 
            this.chkPreventExplode.AutoSize = true;
            this.chkPreventExplode.Checked = true;
            this.chkPreventExplode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPreventExplode.Location = new System.Drawing.Point(6, 86);
            this.chkPreventExplode.Name = "chkPreventExplode";
            this.chkPreventExplode.Size = new System.Drawing.Size(172, 16);
            this.chkPreventExplode.TabIndex = 25;
            this.chkPreventExplode.Text = "폭발로 인한 지형 변화 제거";
            this.chkPreventExplode.UseVisualStyleBackColor = true;
            this.chkPreventExplode.CheckedChanged += new System.EventHandler(this.chkPreventExplode_CheckedChanged);
            // 
            // chkWorldEdit
            // 
            this.chkWorldEdit.AutoSize = true;
            this.chkWorldEdit.Location = new System.Drawing.Point(6, 64);
            this.chkWorldEdit.Name = "chkWorldEdit";
            this.chkWorldEdit.Size = new System.Drawing.Size(104, 16);
            this.chkWorldEdit.TabIndex = 25;
            this.chkWorldEdit.Text = "월드 변경 제한";
            this.chkWorldEdit.UseVisualStyleBackColor = true;
            this.chkWorldEdit.CheckedChanged += new System.EventHandler(this.chkWorldEdit_CheckedChanged);
            // 
            // chkPlayerInvincible
            // 
            this.chkPlayerInvincible.AutoSize = true;
            this.chkPlayerInvincible.Location = new System.Drawing.Point(168, 42);
            this.chkPlayerInvincible.Name = "chkPlayerInvincible";
            this.chkPlayerInvincible.Size = new System.Drawing.Size(100, 16);
            this.chkPlayerInvincible.TabIndex = 25;
            this.chkPlayerInvincible.Text = "플레이어 무적";
            this.chkPlayerInvincible.UseVisualStyleBackColor = true;
            this.chkPlayerInvincible.CheckedChanged += new System.EventHandler(this.chkPlayerInvincible_CheckedChanged);
            // 
            // chkPreventPK
            // 
            this.chkPreventPK.AutoSize = true;
            this.chkPreventPK.Checked = true;
            this.chkPreventPK.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPreventPK.Location = new System.Drawing.Point(6, 42);
            this.chkPreventPK.Name = "chkPreventPK";
            this.chkPreventPK.Size = new System.Drawing.Size(144, 16);
            this.chkPreventPK.TabIndex = 25;
            this.chkPreventPK.Text = "플레이어 간 피해 제거";
            this.chkPreventPK.UseVisualStyleBackColor = true;
            this.chkPreventPK.CheckedChanged += new System.EventHandler(this.chkPreventPK_CheckedChanged);
            // 
            // chkChatPaused
            // 
            this.chkChatPaused.AutoSize = true;
            this.chkChatPaused.Location = new System.Drawing.Point(6, 20);
            this.chkChatPaused.Name = "chkChatPaused";
            this.chkChatPaused.Size = new System.Drawing.Size(76, 16);
            this.chkChatPaused.TabIndex = 25;
            this.chkChatPaused.Text = "채팅 제한";
            this.chkChatPaused.UseVisualStyleBackColor = true;
            this.chkChatPaused.CheckedChanged += new System.EventHandler(this.chkChatPaused_CheckedChanged);
            // 
            // playerList
            // 
            this.playerList.FormattingEnabled = true;
            this.playerList.IntegralHeight = false;
            this.playerList.ItemHeight = 12;
            this.playerList.Location = new System.Drawing.Point(6, 20);
            this.playerList.Name = "playerList";
            this.playerList.Size = new System.Drawing.Size(156, 200);
            this.playerList.TabIndex = 19;
            this.playerList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.playerList_MouseUp);
            // 
            // grpPlayers
            // 
            this.grpPlayers.Controls.Add(this.playerList);
            this.grpPlayers.Location = new System.Drawing.Point(684, 12);
            this.grpPlayers.Name = "grpPlayers";
            this.grpPlayers.Size = new System.Drawing.Size(168, 230);
            this.grpPlayers.TabIndex = 26;
            this.grpPlayers.TabStop = false;
            this.grpPlayers.Text = "Players";
            // 
            // btnUnfreezeAll
            // 
            this.btnUnfreezeAll.Location = new System.Drawing.Point(87, 20);
            this.btnUnfreezeAll.Name = "btnUnfreezeAll";
            this.btnUnfreezeAll.Size = new System.Drawing.Size(75, 23);
            this.btnUnfreezeAll.TabIndex = 31;
            this.btnUnfreezeAll.Text = "Unfreeze";
            this.btnUnfreezeAll.UseVisualStyleBackColor = true;
            this.btnUnfreezeAll.Click += new System.EventHandler(this.btnUnfreezeAll_Click);
            // 
            // btnFreezeAll
            // 
            this.btnFreezeAll.Location = new System.Drawing.Point(6, 20);
            this.btnFreezeAll.Name = "btnFreezeAll";
            this.btnFreezeAll.Size = new System.Drawing.Size(75, 23);
            this.btnFreezeAll.TabIndex = 31;
            this.btnFreezeAll.Text = "Freeze";
            this.btnFreezeAll.UseVisualStyleBackColor = true;
            this.btnFreezeAll.Click += new System.EventHandler(this.btnFreezeAll_Click);
            // 
            // btnWebStart
            // 
            this.btnWebStart.Location = new System.Drawing.Point(6, 20);
            this.btnWebStart.Name = "btnWebStart";
            this.btnWebStart.Size = new System.Drawing.Size(75, 23);
            this.btnWebStart.TabIndex = 27;
            this.btnWebStart.Text = "웹서버시작";
            this.btnWebStart.UseVisualStyleBackColor = true;
            this.btnWebStart.Visible = false;
            this.btnWebStart.Click += new System.EventHandler(this.btnWebStart_Click);
            // 
            // btnWebStop
            // 
            this.btnWebStop.Location = new System.Drawing.Point(87, 20);
            this.btnWebStop.Name = "btnWebStop";
            this.btnWebStop.Size = new System.Drawing.Size(75, 23);
            this.btnWebStop.TabIndex = 28;
            this.btnWebStop.Text = "웹서버정지";
            this.btnWebStop.UseVisualStyleBackColor = true;
            this.btnWebStop.Visible = false;
            this.btnWebStop.Click += new System.EventHandler(this.btnWebStop_Click);
            // 
            // grpWebServer
            // 
            this.grpWebServer.Controls.Add(this.txtWorldFolder);
            this.grpWebServer.Controls.Add(this.btnCompress);
            this.grpWebServer.Controls.Add(this.btnWebStart);
            this.grpWebServer.Controls.Add(this.btnWebStop);
            this.grpWebServer.Location = new System.Drawing.Point(348, 12);
            this.grpWebServer.Name = "grpWebServer";
            this.grpWebServer.Size = new System.Drawing.Size(330, 53);
            this.grpWebServer.TabIndex = 29;
            this.grpWebServer.TabStop = false;
            this.grpWebServer.Text = "WebServer";
            // 
            // txtWorldFolder
            // 
            this.txtWorldFolder.Location = new System.Drawing.Point(168, 20);
            this.txtWorldFolder.Name = "txtWorldFolder";
            this.txtWorldFolder.Size = new System.Drawing.Size(75, 21);
            this.txtWorldFolder.TabIndex = 30;
            // 
            // btnCompress
            // 
            this.btnCompress.Location = new System.Drawing.Point(249, 20);
            this.btnCompress.Name = "btnCompress";
            this.btnCompress.Size = new System.Drawing.Size(75, 23);
            this.btnCompress.TabIndex = 30;
            this.btnCompress.Text = "압축";
            this.btnCompress.UseVisualStyleBackColor = true;
            this.btnCompress.Click += new System.EventHandler(this.btnCompress_Click);
            // 
            // grpWorldControl
            // 
            this.grpWorldControl.Controls.Add(this.btnWorldMove);
            this.grpWorldControl.Controls.Add(this.btnWorldCreate);
            this.grpWorldControl.Controls.Add(this.comboWorldProperty);
            this.grpWorldControl.Controls.Add(this.txtWorldName);
            this.grpWorldControl.Location = new System.Drawing.Point(348, 71);
            this.grpWorldControl.Name = "grpWorldControl";
            this.grpWorldControl.Size = new System.Drawing.Size(330, 53);
            this.grpWorldControl.TabIndex = 30;
            this.grpWorldControl.TabStop = false;
            this.grpWorldControl.Text = "World";
            // 
            // btnWorldMove
            // 
            this.btnWorldMove.Location = new System.Drawing.Point(249, 20);
            this.btnWorldMove.Name = "btnWorldMove";
            this.btnWorldMove.Size = new System.Drawing.Size(75, 23);
            this.btnWorldMove.TabIndex = 29;
            this.btnWorldMove.Text = "move";
            this.btnWorldMove.UseVisualStyleBackColor = true;
            this.btnWorldMove.Click += new System.EventHandler(this.btnWorldMove_Click);
            // 
            // btnWorldCreate
            // 
            this.btnWorldCreate.Location = new System.Drawing.Point(168, 20);
            this.btnWorldCreate.Name = "btnWorldCreate";
            this.btnWorldCreate.Size = new System.Drawing.Size(75, 23);
            this.btnWorldCreate.TabIndex = 28;
            this.btnWorldCreate.Text = "create";
            this.btnWorldCreate.UseVisualStyleBackColor = true;
            this.btnWorldCreate.Click += new System.EventHandler(this.btnWorldCreate_Click);
            // 
            // comboWorldProperty
            // 
            this.comboWorldProperty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboWorldProperty.FormattingEnabled = true;
            this.comboWorldProperty.Location = new System.Drawing.Point(87, 22);
            this.comboWorldProperty.Name = "comboWorldProperty";
            this.comboWorldProperty.Size = new System.Drawing.Size(75, 20);
            this.comboWorldProperty.TabIndex = 27;
            // 
            // txtWorldName
            // 
            this.txtWorldName.Location = new System.Drawing.Point(6, 22);
            this.txtWorldName.Name = "txtWorldName";
            this.txtWorldName.Size = new System.Drawing.Size(75, 21);
            this.txtWorldName.TabIndex = 22;
            // 
            // contextMenuPlayerList
            // 
            this.contextMenuPlayerList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opToolStripMenuItem,
            this.deopToolStripMenuItem,
            this.freezeToolStripMenuItem,
            this.unfreezeToolStripMenuItem,
            this.bringToToolStripMenuItem});
            this.contextMenuPlayerList.Name = "contextMenuPlayerList";
            this.contextMenuPlayerList.Size = new System.Drawing.Size(134, 114);
            this.contextMenuPlayerList.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuPlayerList_ItemClicked);
            // 
            // opToolStripMenuItem
            // 
            this.opToolStripMenuItem.Name = "opToolStripMenuItem";
            this.opToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.opToolStripMenuItem.Text = "Op";
            // 
            // deopToolStripMenuItem
            // 
            this.deopToolStripMenuItem.Name = "deopToolStripMenuItem";
            this.deopToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.deopToolStripMenuItem.Text = "De-op";
            // 
            // freezeToolStripMenuItem
            // 
            this.freezeToolStripMenuItem.Name = "freezeToolStripMenuItem";
            this.freezeToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.freezeToolStripMenuItem.Text = "Freeze";
            // 
            // unfreezeToolStripMenuItem
            // 
            this.unfreezeToolStripMenuItem.Name = "unfreezeToolStripMenuItem";
            this.unfreezeToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.unfreezeToolStripMenuItem.Text = "Unfreeze";
            // 
            // bringToToolStripMenuItem
            // 
            this.bringToToolStripMenuItem.Name = "bringToToolStripMenuItem";
            this.bringToToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.bringToToolStripMenuItem.Text = "Teleport all";
            // 
            // grpFreeze
            // 
            this.grpFreeze.Controls.Add(this.btnUnfreezeAll);
            this.grpFreeze.Controls.Add(this.btnFreezeAll);
            this.grpFreeze.Location = new System.Drawing.Point(348, 130);
            this.grpFreeze.Name = "grpFreeze";
            this.grpFreeze.Size = new System.Drawing.Size(330, 53);
            this.grpFreeze.TabIndex = 31;
            this.grpFreeze.TabStop = false;
            this.grpFreeze.Text = "Freeze";
            // 
            // grpTimer
            // 
            this.grpTimer.Controls.Add(this.btnTimerStart);
            this.grpTimer.Controls.Add(this.lblTimer);
            this.grpTimer.Controls.Add(this.numTimerSec);
            this.grpTimer.Location = new System.Drawing.Point(348, 189);
            this.grpTimer.Name = "grpTimer";
            this.grpTimer.Size = new System.Drawing.Size(330, 53);
            this.grpTimer.TabIndex = 32;
            this.grpTimer.TabStop = false;
            this.grpTimer.Text = "Timer";
            // 
            // numTimerSec
            // 
            this.numTimerSec.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numTimerSec.Location = new System.Drawing.Point(87, 21);
            this.numTimerSec.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.numTimerSec.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTimerSec.Name = "numTimerSec";
            this.numTimerSec.Size = new System.Drawing.Size(156, 21);
            this.numTimerSec.TabIndex = 32;
            this.numTimerSec.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Location = new System.Drawing.Point(29, 25);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(29, 12);
            this.lblTimer.TabIndex = 33;
            this.lblTimer.Text = "시간";
            // 
            // btnTimerStart
            // 
            this.btnTimerStart.Location = new System.Drawing.Point(249, 20);
            this.btnTimerStart.Name = "btnTimerStart";
            this.btnTimerStart.Size = new System.Drawing.Size(75, 23);
            this.btnTimerStart.TabIndex = 33;
            this.btnTimerStart.Text = "Start";
            this.btnTimerStart.UseVisualStyleBackColor = true;
            this.btnTimerStart.Click += new System.EventHandler(this.btnTimerStart_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 502);
            this.Controls.Add(this.grpTimer);
            this.Controls.Add(this.grpFreeze);
            this.Controls.Add(this.grpWorldControl);
            this.Controls.Add(this.grpWebServer);
            this.Controls.Add(this.grpPlayers);
            this.Controls.Add(this.grpGiveItem);
            this.Controls.Add(this.grpOption);
            this.Controls.Add(this.grpDisable);
            this.Controls.Add(this.grpWeather);
            this.Controls.Add(this.grpTime);
            this.Controls.Add(this.grpDifficulty);
            this.Controls.Add(this.grpGamemode);
            this.Controls.Add(this.txtConsole);
            this.Controls.Add(this.txtCommand);
            this.Controls.Add(this.grpServerControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Minecraft Server Launcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.grpServerControl.ResumeLayout(false);
            this.grpServerControl.PerformLayout();
            this.grpGamemode.ResumeLayout(false);
            this.grpDifficulty.ResumeLayout(false);
            this.grpTime.ResumeLayout(false);
            this.grpWeather.ResumeLayout(false);
            this.grpGiveItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numItem)).EndInit();
            this.grpDisable.ResumeLayout(false);
            this.grpDisable.PerformLayout();
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.grpPlayers.ResumeLayout(false);
            this.grpWebServer.ResumeLayout(false);
            this.grpWebServer.PerformLayout();
            this.grpWorldControl.ResumeLayout(false);
            this.grpWorldControl.PerformLayout();
            this.contextMenuPlayerList.ResumeLayout(false);
            this.grpFreeze.ResumeLayout(false);
            this.grpTimer.ResumeLayout(false);
            this.grpTimer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimerSec)).EndInit();
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
        private System.Windows.Forms.Button btnStart2;
        private System.Windows.Forms.Button btnServerInfo;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnGamemode_survival;
        private System.Windows.Forms.Button btnGamemode_creative;
        private System.Windows.Forms.Button btnGamemode_spectator;
        private System.Windows.Forms.TextBox txtTeacherIPaddress;
        private System.Windows.Forms.GroupBox grpGamemode;
        private System.Windows.Forms.Button btnGamemode_adventure;
        private System.Windows.Forms.GroupBox grpDifficulty;
        private System.Windows.Forms.Button btnDifficulty_hard;
        private System.Windows.Forms.Button btnDifficulty_normal;
        private System.Windows.Forms.Button btnDifficulty_easy;
        private System.Windows.Forms.Button btnDifficulty_peaceful;
        private System.Windows.Forms.GroupBox grpTime;
        private System.Windows.Forms.CheckBox chkboxTimeFix;
        private System.Windows.Forms.Button btnTime_night;
        private System.Windows.Forms.Button btnTime_day;
        private System.Windows.Forms.GroupBox grpWeather;
        private System.Windows.Forms.CheckBox chkboxWeatherFix;
        private System.Windows.Forms.Button btnWeatherThunder;
        private System.Windows.Forms.Button btnWeatherRain;
        private System.Windows.Forms.Button btnWeatherClear;
        private System.Windows.Forms.GroupBox grpGiveItem;
        private System.Windows.Forms.GroupBox grpDisable;
        private System.Windows.Forms.Button btnGive;
        private System.Windows.Forms.ComboBox comboItemName;
        private System.Windows.Forms.ComboBox comboItemCategory;
        private System.Windows.Forms.GroupBox grpOption;
        private System.Windows.Forms.CheckBox chkCommandPaused;
        private System.Windows.Forms.CheckBox chkPreventExplode;
        private System.Windows.Forms.CheckBox chkWorldEdit;
        private System.Windows.Forms.CheckBox chkPlayerInvincible;
        private System.Windows.Forms.CheckBox chkPreventPK;
        private System.Windows.Forms.CheckBox chkChatPaused;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.NumericUpDown numItem;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox grpPlayers;
        private System.Windows.Forms.ListBox playerList;
        private System.Windows.Forms.Button btnWebStart;
        private System.Windows.Forms.Button btnWebStop;
        private System.Windows.Forms.GroupBox grpWebServer;
        private System.Windows.Forms.Button btnCompress;
        private System.Windows.Forms.TextBox txtWorldFolder;
        private System.Windows.Forms.GroupBox grpWorldControl;
        private System.Windows.Forms.Button btnWorldMove;
        private System.Windows.Forms.Button btnWorldCreate;
        private System.Windows.Forms.ComboBox comboWorldProperty;
        private System.Windows.Forms.TextBox txtWorldName;
        private System.Windows.Forms.ComboBox comboItemPlayer;
        private System.Windows.Forms.ContextMenuStrip contextMenuPlayerList;
        private System.Windows.Forms.ToolStripMenuItem opToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem freezeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unfreezeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bringToToolStripMenuItem;
        private System.Windows.Forms.Button btnUnfreezeAll;
        private System.Windows.Forms.Button btnFreezeAll;
        private System.Windows.Forms.GroupBox grpFreeze;
        private System.Windows.Forms.GroupBox grpTimer;
        private System.Windows.Forms.Button btnTimerStart;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.NumericUpDown numTimerSec;
    }
}

