using CSharpLibs.ConfigTools;
using CSharpLibs.Minecraft;
using CSharpLibs.Networking;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Management;
using System.IO.Compression;
using Microsoft.Win32;
using System.Net.NetworkInformation;

namespace MinecraftServerLauncher
{
    public partial class MainForm : Form
    {
        ServerProfileConfig config = new ServerProfileConfig();

        string json = "";

        System.Diagnostics.Process process = new System.Diagnostics.Process();
        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
        string processName = null;

        #region ===== Run Server Handling =====

        private ServerHost MinecraftServer = null;

        private bool MinecraftServerRunning = false;

        private readonly string executablePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);

        private readonly string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        private void MinecraftServer_ServerStarting(int serverHostID)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<int>(MinecraftServer_ServerStarting), serverHostID);
                return;
            }

            // Past this line, it's thread safe and copied over to the main thread.

            System.Diagnostics.Debug.WriteLine("<<" + serverHostID.ToString() + ">> Minecraft server is starting up.");
            txtConsole.Text += "Minecraft server is starting up..." + Environment.NewLine;
            btnStart.Enabled = false;
        }

        private void MinecraftServer_ConsoleChanged(int serverHostID, string logLevel, string logMessage)
        {
        
            // here it's thread safe :)
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action<int, string, string>(MinecraftServer_ConsoleChanged), serverHostID, logLevel, logMessage);
                    return;
                }

                System.Diagnostics.Debug.WriteLine("<<" + serverHostID.ToString() + ":" + logLevel + ">> " + logMessage);
                txtConsole.Text += logMessage + Environment.NewLine;
            }
            catch
            {

            }

        }

        private void MinecraftServer_ServerStarted(int serverHostID)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<int>(MinecraftServer_ServerStarted), serverHostID);
                return;
            }

            // Yup..

            System.Diagnostics.Debug.WriteLine("<<" + serverHostID.ToString() + ">> Minecraft server started!");

            btnStop.Enabled = true;

            MinecraftServerRunning = true;

            txtCommand.Enabled = true;

            enableButton();
        }

        private void MinecraftServer_PlayerJoined(string playerName, string playerUUID, byte[] ip)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string, string, byte[]>(MinecraftServer_PlayerJoined), playerName, playerUUID, ip);
                return;
            }

            // Past this it's safe to mess with the UI and this data
            updatePlayerInformation();
        }

        private void MinecraftServer_PlayerParted(string playerName, string playerUUID, byte[] ip)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string, string, byte[]>(MinecraftServer_PlayerParted), playerName, playerUUID, ip);
                return;
            }

            // Past this it's safe to mess with the UI and this data
            updatePlayerInformation();
        }

        private void MinecraftServer_ServerShuttingDown(int serverHostID)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<int>(MinecraftServer_ServerShuttingDown), serverHostID);
                return;
            }

            //

            System.Diagnostics.Debug.WriteLine("<<" + serverHostID.ToString() + ">> Minecraft server IS SHUTTING DOWN!!!");

            btnStop.Enabled = false;
            btnStart.Enabled = true; //
            MinecraftServerRunning = false;

            txtCommand.Enabled = false;
            disableButton();
        }

        private void MinecraftServer_ServerStopped(int serverHostID)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<int>(MinecraftServer_ServerStopped), serverHostID);
                return;
            }

            System.Diagnostics.Debug.WriteLine("<<" + serverHostID.ToString() + ">> Minecraft server stopped.");
            txtConsole.Text += "Minecraft server stopped." + Environment.NewLine;

            btnStart.Enabled = true;

            MinecraftServerRunning = false;
            disableButton();   
        }

        private void InitializeMinecraftServer()
        {
            MinecraftServer.ServerStarting += MinecraftServer_ServerStarting;
            MinecraftServer.ConsoleChanged += MinecraftServer_ConsoleChanged;
            MinecraftServer.ServerStarted += MinecraftServer_ServerStarted;

            MinecraftServer.PlayerJoined += MinecraftServer_PlayerJoined;
            MinecraftServer.PlayerParted += MinecraftServer_PlayerParted;

            MinecraftServer.ServerShuttingDown += MinecraftServer_ServerShuttingDown;
            MinecraftServer.ServerStopped += MinecraftServer_ServerStopped;
        }

        #endregion

        #region ===== JSON parsing =====

        /// <summary>
        /// Load itemData.json file.
        /// </summary>
        public void loadJson()
        {
            string execPath = executablePath;
            string jsonFile = "itemData.json";

            if (execPath.Length > 0)
            {
                if (execPath[execPath.Length - 1] != '\\')
                {
                    execPath += '\\';
                }
            }
            string jsonFilePathName = execPath + jsonFile;

            try
            {
                if (jsonFilePathName.Length > 0)
                {
                    if (File.Exists(jsonFilePathName))
                    {
                        System.Diagnostics.Debug.WriteLine("itemData.json file exists.");
                        System.Diagnostics.Debug.WriteLine(jsonFilePathName);

                        json = System.IO.File.ReadAllText(jsonFilePathName);
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("itemData.json file doesn't exist.");
                    }
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// initialize grpGiveitem.
        /// </summary>
        public void initItemData()
        {
            var objects = JObject.Parse(json);

            foreach (var cat in objects)
            {
                comboItemCategory.Items.Add(cat.Key);   
            }
            if (comboItemCategory.Items.Count != 0)
            {
                comboItemCategory.SelectedIndex = 0;
            }
        }

        #endregion

        #region ===== Combobox Management =====

        /// <summary>
        /// Combobox item initialization
        /// </summary>
        public void comboInit()
        {
            comboItemPlayer.Items.Add("모든 플레이어");
            comboItemPlayer.SelectedIndex = 0;
        }

        /// <summary>
        /// Update playerList and Combobox when players join or logout
        /// </summary>
        public void updatePlayerInformation()
        {
            playerList.Items.Clear();
            comboItemPlayer.Items.Clear();
            comboItemPlayer.Items.Add("모든 플레이어");
            for (int p = 0; p < MinecraftServer.OnlinePlayers.Count; p++)
            {
                playerList.Items.Add(MinecraftServer.OnlinePlayers[p].Name);
                comboItemPlayer.Items.Add(MinecraftServer.OnlinePlayers[p].Name);
            }
            comboItemPlayer.SelectedIndex = 0;
        }

        #endregion

        #region ===== Control Events =====

        #region Event: Deprecated Function
        // ===== Deprecated Function =====
        private void txtMinecraftServerPath_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            
            config.Save();
            config.Load();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Minecraft server jar|*.jar";
            dialog.Multiselect = false;
            dialog.CheckFileExists = true;

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                txtMinecraftServerPath.Text = dialog.FileName;
            }

            dialog.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string filePathName = txtMinecraftServerPath.Text.Trim();

            if (filePathName.Length > 0)
            {
                if (File.Exists(filePathName))
                {
                    config.MinecraftPath = filePathName.Substring(0, filePathName.LastIndexOf('\\') + 1);
                    config.MinecraftJar = filePathName.Substring(filePathName.LastIndexOf('\\') + 1, filePathName.Length - (filePathName.LastIndexOf('\\') + 1));
                    config.MemorySize = (int)numMemory.Value;
                    config.Save();
                    btnSave.Enabled = false;
                }
            }
            else
            {
                //TODO: throw an error message to the user!
                MessageBox.Show(
                    "The path and filename of the Minecraft server jar that you have specified is not valid.\n\nPlease check and try again.",
                    "Invalid Minecraft server jar!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                    );
                txtMinecraftServerPath.Focus();
            }
        }

        private void btnStart2_Click(object sender, EventArgs e)
        {
            if (config.MinecraftPath.Length > 0 && config.MinecraftJar.Length > 0 && config.MemorySize > 0)
            {
                MinecraftServer.RemoteConsolePort = 26665;
                MinecraftServer.UseRandomizedRConPassword = true;
                MinecraftServer.ConfigureServer(config.MinecraftPath, config.MinecraftJar, config.MemorySize);
                if (!MinecraftServer.Start())
                {
                    MessageBox.Show(
                        "Some configuration mismatch prevented the server from starting!\n\nPlease check the configuration and try again.",
                        "Unable to start Minecraft server!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation
                        );
                }
            }
        }

        private void btnServerInfo_Click(object sender, EventArgs e)
        {
            if (config.MinecraftPath.Length > 0 && config.MinecraftJar.Length > 0)
            {
                INIFile serverProp = new INIFile();
                serverProp.VirtualGrouping = true;
                serverProp.Load(config.MinecraftPath + "server.properties");

                string msg = "";
                msg += "Server MOTD: " + serverProp.GetValue("", "motd") + "\n";
                msg += "RCon port: " + serverProp.GetValue("", "rcon.port") + "\n";
                msg += "RCon password: " + serverProp.GetValue("", "rcon.password") + "\n";

                MessageBox.Show(msg);
            }
        }
        #endregion

        private void btnStart_Click(object sender, EventArgs e)
        {
            removeSourcecode();

            string curPath = executablePath;
            string curJar = "MinecraftServer.Jar";
            
            if (curPath.Length > 0)
            {
                if (curPath[curPath.Length - 1] != '\\')
                {
                    curPath += '\\';
                }
            }
            string curFilePathName = curPath + curJar;

            if (curFilePathName.Length > 0)
            {
                if (File.Exists(curFilePathName))
                {
                    config.MinecraftPath = curPath;
                    config.MinecraftJar = curJar;
                    config.MemorySize = Convert.ToInt32(numMemory.Value);
                    config.Save();

                    if (config.MinecraftPath.Length > 0 && config.MinecraftJar.Length > 0 && config.MemorySize > 0)
                    {
                        MinecraftServer.RemoteConsolePort = 26665;
                        MinecraftServer.UseRandomizedRConPassword = true;
                        MinecraftServer.ConfigureServer(config.MinecraftPath, config.MinecraftJar, config.MemorySize);
                        if (!MinecraftServer.Start())
                        {
                            MessageBox.Show(
                                "Some configuration mismatch prevented the server from starting!\n\nPlease check the configuration and try again.",
                                "Unable to start Minecraft server!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation
                                );
                        }
                    }
                }
            }
            else
            {
                //TODO: throw an error message to the user!
                MessageBox.Show(
                    "The path and filename of the Minecraft server jar that you have specified is not valid.\n\nPlease check and try again.",
                    "Invalid Minecraft server jar!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                    );
            }

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            MinecraftServer.Stop();
        }

        private void txtConsole_TextChanged(object sender, EventArgs e)
        {
            txtConsole.SelectionStart = txtConsole.Text.Length;
            txtConsole.ScrollToCaret();
        }

        private void txtCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MinecraftServer.Command(txtCommand.Text);
                txtCommand.Text = String.Empty;
            }
        }

        private void comboItemCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            var objects = JObject.Parse(json);

            comboItemName.Items.Clear();
            foreach (var item in objects[comboItemCategory.Text])
            {
                JProperty jProperty = item.ToObject<JProperty>();
                string propertyName = jProperty.Name;
                comboItemName.Items.Add(propertyName);
            }

            if (comboItemName.Items.Count != 0)
            {
                comboItemName.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Update world list when user clickes combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboWorldList_Click(object sender, EventArgs e)
        {
            string[] worldDirectories = Directory.GetDirectories(executablePath);
            comboWorldList.Items.Clear();
            string directoryName = "";
            foreach (string s in Directory.GetDirectories(executablePath))
            {
                directoryName = s.Remove(0, executablePath.Length + 1);
                if (directoryName.ToLower() != "logs" &&
                    directoryName.ToLower() != "plugins" &&
                    directoryName.ToLower() != "scriptcraft" &&
                    directoryName.ToLower() != "webserver" &&
                    directoryName.ToLower() != "world_nether" &&
                    directoryName.ToLower() != "world_the_end")
                {
                    comboWorldList.Items.Add(directoryName);
                }
            }
        }

        #endregion

        #region ===== MainForm Events =====

        private void MainForm_Load(object sender, EventArgs e)
        {
            MinecraftServer = new ServerHost(398475);
            InitializeMinecraftServer();
            loadJson();
            initItemData();
            comboInit();

            string[] property = { "flat", "normal", "largebiomes", "amplified" };
            comboWorldProperty.Items.AddRange(property);
            comboWorldProperty.SelectedIndex = 0;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (config.MinecraftPath.Length > 0 && config.MinecraftJar.Length > 0)
            {
                string path = config.MinecraftPath;
                if(path[path.Length-1] != '\\')
                {
                    path += '\\';
                }
                txtMinecraftServerPath.Text = path + config.MinecraftJar;
                numMemory.Value = config.MemorySize;
            }
            else
            {
                numMemory.Value = 1024;
            }

            btnSave.Enabled = false;

            btnStart.Enabled = true;
            btnStop.Enabled = false;

            // For the RCon test...
            //btnConnect.Enabled = true;
            //btnDisconnect.Enabled = false;
            txtCommand.Enabled = false;
            //btnExecute.Enabled = false;

            disableButton();
            btnWebStop.Enabled = false;
            
            txtTeacherIPaddress.Text = GetLocalIPAddress();
            checkNodejsInstalled();
        }

        /// <summary>
        /// When Mainform closes, server stop.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!btnStart.Enabled && !btnStop.Enabled)
            {
                e.Cancel = true;
            }
            else
            {
                MinecraftServer.Command("stop");
            }
        }

        #endregion

        #region ===== Get Local IP =====

        /// <summary>
        /// Get serverhost IP
        /// </summary>
        /// <returns>serverhost IP</returns>
        public static string GetLocalIPAddress()
        {
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters)
            {
                IPInterfaceProperties adapterProperties = adapter.GetIPProperties();
                GatewayIPAddressInformationCollection addresses = adapterProperties.GatewayAddresses;
                if (addresses.Count > 0)
                {
                    foreach (UnicastIPAddressInformation ip in adapter.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            //Console.WriteLine(ip.Address.ToString());
                            return ip.Address.ToString();
                        }
                    }
                }
            }

            return null;
        }

        #endregion

        #region ===== Button Events =====

        private void btnGamemode_survival_Click(object sender, EventArgs e)
        {
            MinecraftServer.Command("gamemode survival @a");
        }

        private void btnGamemode_creative_Click(object sender, EventArgs e)
        {
            MinecraftServer.Command("gamemode creative @a");
        }

        private void btnGamemode_spectator_Click(object sender, EventArgs e)
        {
            MinecraftServer.Command("gamemode spectator @a");
        }

        private void btnGamemode_adventure_Click(object sender, EventArgs e)
        {
            MinecraftServer.Command("gamemode adventure @a");
        }

        private void btnDifficulty_peaceful_Click(object sender, EventArgs e)
        {
            MinecraftServer.Command("difficulty peaceful");
        }

        private void btnDifficulty_easy_Click(object sender, EventArgs e)
        {
            MinecraftServer.Command("difficulty easy");
        }

        private void btnDifficulty_normal_Click(object sender, EventArgs e)
        {
            MinecraftServer.Command("difficulty normal");
        }

        private void btnDifficulty_hard_Click(object sender, EventArgs e)
        {
            MinecraftServer.Command("difficulty hard");
        }

        private void btnTime_day_Click(object sender, EventArgs e)
        {
            MinecraftServer.Command("time set day");
        }

        private void btnTime_night_Click(object sender, EventArgs e)
        {
            MinecraftServer.Command("time set night");
        }

        private void btnWeatherClear_Click(object sender, EventArgs e)
        {
            weatherPlayer("clear");
        }

        private void btnWeatherRain_Click(object sender, EventArgs e)
        {
            weatherPlayer("rain");
        }

        private void btnWeatherThunder_Click(object sender, EventArgs e)
        {
            weatherPlayer("thunder");
        }

        /// <summary>
        /// If it checks, time doesn't change.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkboxTimeFix_CheckedChanged(object sender, EventArgs e)
        {
            if (chkboxTimeFix.Checked == true)
            {
                MinecraftServer.Command("gamerule doDaylightCycle false");
            }

            if (chkboxTimeFix.Checked == false)
            {
                MinecraftServer.Command("gamerule doDaylightCycle true");
            }
        }

        /// <summary>
        /// If it checks, weather doesn't change.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkboxWeatherFix_CheckedChanged(object sender, EventArgs e)
        {
            if (chkboxWeatherFix.Checked == true)
            {
                MinecraftServer.Command("gamerule doWeatherCycle false");
            }

            if (chkboxWeatherFix.Checked == false)
            {
                MinecraftServer.Command("gamerule doWeatherCycle true");
            }
        }

        /// <summary>
        /// If it checks, all player without operators can't chat.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkChatPaused_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChatPaused.Checked == true)
            {
                MinecraftServer.Command("chatPaused true");
            }

            if (chkChatPaused.Checked == false)
            {
                MinecraftServer.Command("chatPaused false");
            }
        }

        /// <summary>
        /// If it checks, all player without operators can't execute command.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkCommandPaused_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCommandPaused.Checked == true)
            {
                MinecraftServer.Command("commandPaused true");
            }

            if (chkCommandPaused.Checked == false)
            {
                MinecraftServer.Command("commandPaused false");
            }
        }

        /// <summary>
        /// If it checks, all player can't damage other players.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkPreventPK_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPreventPK.Checked == true)
            {
                MinecraftServer.Command("preventPK true");
            }

            if (chkPreventPK.Checked == false)
            {
                MinecraftServer.Command("preventPK false");
            }
        }

        /// <summary>
        /// If it checks, all players become invincible. (No damage)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkPlayerInvincible_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPlayerInvincible.Checked == true)
            {
                MinecraftServer.Command("playerInvincible true");
            }

            if (chkPlayerInvincible.Checked == false)
            {
                MinecraftServer.Command("playerInvincible false");
            }
        }

        /// <summary>
        /// If if checks, prevent players changing terrain.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkWorldEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWorldEdit.Checked == true)
            {
                MinecraftServer.Command("preventWorldEdit true");
            }

            if (chkWorldEdit.Checked == false)
            {
                MinecraftServer.Command("preventWorldEdit false");
            }
        }

        /// <summary>
        /// If it checks, prevent explodes changing terrain.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkPreventExplode_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPreventExplode.Checked == true)
            {
                MinecraftServer.Command("preventExplode true");
            }

            if (chkPreventExplode.Checked == false)
            {
                MinecraftServer.Command("preventExplode false");
            }
        }

        private void chkAllowFlight_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllowFlight.Checked == true)
            {
                MinecraftServer.Command("allowflight true");
            }
            else
            {
                MinecraftServer.Command("allowflight false");
            }
        }

        /// <summary>
        /// Set default class settings (Disabled)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDefault_Click(object sender, EventArgs e)
        {
            //// error
            //MinecraftServer.Command("classdefault");
            //chkboxTimeFix.Checked = true;
            //chkboxWeatherFix.Checked = true;
            //chkPreventPK.Checked = true;
            //chkPreventExplode.Checked = true;
        }

        /// <summary>
        /// Give item to all players.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGive_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboItemName.Text != "" && comboItemCategory.Text != "")
                {
                    var objects = JObject.Parse(json);

                    var dataName = objects[comboItemCategory.Text][comboItemName.Text]["dataName"];
                    var dataValue = objects[comboItemCategory.Text][comboItemName.Text]["dataValue"];
                    var numOfItem = numItem.Value;

                    //Console.WriteLine("give @a " + dataName + " "+ numOfItem + " " + dataValue);
                    if(comboItemPlayer.SelectedIndex == 0)
                    {
                        MinecraftServer.Command("give @a " + dataName + " " + numOfItem + " " + dataValue);
                    }
                    else
                    {
                        MinecraftServer.Command("give "+ comboItemPlayer.Text + " " + dataName + " " + numOfItem + " " + dataValue);
                    }
                    
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// Freeze all players
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFreezeAll_Click(object sender, EventArgs e)
        {
            MinecraftServer.Command("freeze @a");
        }

        /// <summary>
        /// Unfreeze all players
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUnfreezeAll_Click(object sender, EventArgs e)
        {
            MinecraftServer.Command("unfreeze @a");
        }

        /// <summary>
        /// make all players blind
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBlind_Click(object sender, EventArgs e)
        {
            MinecraftServer.Command("blind @a");
        }

        /// <summary>
        /// make all players unblind
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUnBlind_Click(object sender, EventArgs e)
        {
            MinecraftServer.Command("unblind @a");
        }

        /// <summary>
        /// Set timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTimerStart_Click(object sender, EventArgs e)
        {
            MinecraftServer.Command("timer " + numTimerSec.Value);
        }

        /// <summary>
        /// Refresh source code.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            MinecraftServer.Command("js refresh()");
            txtConsole.Text += "코드를 새로고침하였습니다." + Environment.NewLine;
        }

        /// <summary>
        /// When player is in other world (not "world" world), change world weather
        /// </summary>
        /// <param name="weather"></param>
        private void weatherPlayer(string weather)
        {
            if (playerList.Items.Count > 0)
            {
                MinecraftServer.Command("weatherplayer " + weather + " " + playerList.Items[0]);
            }
            else
            {
                MinecraftServer.Command("weatherplayer " + weather);
            }

        }

        /// <summary>
        /// Compress world directory from minecraft server directory to desktop.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCompress_Click(object sender, EventArgs e)
        {
            string worldDirectory = "";

            if (comboWorldList.SelectedItem == null) {
                return;
            }
            else
            {
                worldDirectory = comboWorldList.SelectedItem.ToString();
            }

            string directoryPath = FixPath(executablePath) + worldDirectory; // sourceDir
            string newPath = FixPath(desktopPath) + worldDirectory; // Temp destDir
            string zipFileName = worldDirectory + ".zip"; // zipFile
            string zipFilePath = FixPath(desktopPath) + zipFileName; // zipFilePath

            if (Directory.Exists(directoryPath)) // Check sourceDir exist
            {
                if (File.Exists(zipFilePath)) // Check zipFile exist
                {
                    //File.Delete(zipFilePath); // Delete previous zipFile to overwrite zipFile
                    txtConsole.Text += "오류: 바탕화면에 이미 " + zipFileName + " 파일이 존재하여 압축할 수 없습니다." + Environment.NewLine;
                    return;
                }
                if (Directory.Exists(newPath)) // Check destDir exist
                {
                    //Directory.Delete(newPath, true); // Delete previous destDir to overwrite destDir
                    txtConsole.Text += "오류: 바탕화면에 " + worldDirectory + " 디렉토리가 존재하여 압축할 수 없습니다." + Environment.NewLine;
                    return;
                }
                Directory.CreateDirectory(newPath); // Create new destDir
                DirectoryCopy(directoryPath, newPath, true); // Copy from source to destination
                ZipFile.CreateFromDirectory(newPath, zipFilePath); // Make zipFile
                Directory.Delete(newPath, true); // Delete destDir

                txtConsole.Text += "바탕화면에 " + zipFileName + " 파일이 생성되었습니다." + Environment.NewLine;
                return;
            }
            else
            {
                txtConsole.Text += "오류: " + worldDirectory + " 디렉토리가 존재하지 않습니다." + Environment.NewLine;
                return;
            }
        }

        #region Button: World Control

        /// <summary>
        /// Create new world
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWorldCreate_Click(object sender, EventArgs e)
        {
            if (txtWorldName.Text != "")
            {
                MinecraftServer.Command("create " + txtWorldName.Text + " " + comboWorldProperty.SelectedItem);
            }
            else
            {
                txtConsole.Text += "생성할 맵 이름을 입력해주세요." + Environment.NewLine;
            }
        }

        /// <summary>
        /// Move other world
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWorldMove_Click(object sender, EventArgs e)
        {
            if (txtWorldName.Text != "")
            {
                MinecraftServer.Command("move " + txtWorldName.Text);
            }
            else
            {
                txtConsole.Text += "이동할 맵 이름을 입력해주세요." + Environment.NewLine;
            }
        }

        #endregion

        #endregion

        #region ===== Form Enable/Disable =====

        /// <summary>
        /// Enable Contorols and buttons.
        /// </summary>
        public void enableButton()
        {
            grpDifficulty.Enabled = true;
            grpGamemode.Enabled = true;
            grpGive.Enabled = true;
            grpOption.Enabled = true;
            grpTime.Enabled = true;
            grpWeather.Enabled = true;
            grpPlayers.Enabled = true;
            grpWorldControl.Enabled = true;
            grpPlayerControl.Enabled = true;
            grpTimer.Enabled = true;
            btnDefault.Enabled = true;
            btnRefresh.Enabled = true;
        }

        /// <summary>
        /// Disable Controls and Buttons.
        /// </summary>
        public void disableButton()
        {
            grpDifficulty.Enabled = false;
            grpGamemode.Enabled = false;
            grpGive.Enabled = false;
            grpOption.Enabled = false;
            grpTime.Enabled = false;
            grpWeather.Enabled = false;
            grpPlayers.Enabled = false;
            grpWorldControl.Enabled = false;
            grpPlayerControl.Enabled = false;
            grpTimer.Enabled = false;
            btnDefault.Enabled = false;
            btnRefresh.Enabled = false;
        }

        #endregion

        #region ===== Sourcecode Cleanup =====

        /// <summary>
        /// When server starts, delete all previous source code.
        /// </summary>
        public void removeSourcecode()
        {
            string execPath = executablePath;
            string codeSubdir = "scriptcraft\\plugins\\usercodes\\";

            if (execPath.Length > 0)
            {
                if (execPath[execPath.Length - 1] != '\\')
                {
                    execPath += '\\';
                }
            }
            string codeDir = execPath + codeSubdir;

            try
            {
                string[] filePaths = Directory.GetFiles(codeDir);
                foreach (string filePath in filePaths)
                {
                    var name = new FileInfo(filePath).Name;
                    name = name.ToLower();
                    if (name != "watcher.js")
                    {
                        File.Delete(filePath);
                    }
                }
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        #endregion

        #region ===== WebServer Handling =====

        /// <summary>
        /// WebServer Start
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWebStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (processName == null)
                {
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/C cd ./webServer && npm install -g express && npm start";
                    process.StartInfo = startInfo;
                    process.Start();
                    processName = process.ProcessName;
                    txtConsole.Text += "MinecraftEditorServer is started..." + Environment.NewLine;
                    btnWebStart.Enabled = false;
                    btnWebStop.Enabled = true;
                }
                else
                {
                    txtConsole.Text += "오류: 웹 서버가 이미 실행 중입니다." + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                txtConsole.Text += ex;
                txtConsole.Text += "오류: 최신 버전의 Java와 Nodejs를 설치하세요." + Environment.NewLine;
                throw;
            }
        }

        /// <summary>
        /// WebServer Stop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWebStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (processName != null)
                {
                    KillProcessAndChildren(process.Id);
                    processName = null;
                    txtConsole.Text += "MinecraftEditorServer is stopped..." + Environment.NewLine;
                    btnWebStart.Enabled = true;
                    btnWebStop.Enabled = false;
                }
                else
                {
                    txtConsole.Text += "오류: 웹 서버가 실행 중이지 않습니다." + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                txtConsole.Text += ex;
                txtConsole.Text += "오류: 웹 서버를 중지하는데 문제가 발생했습니다." + Environment.NewLine;
                throw;
            }
        }

        #endregion

        #region ===== Internal Helper Methods =====

        #region Method: KillProcessAndChildren

        /// <summary>
        /// Kill a process, and all of its children, grandchildren, etc.
        /// </summary>
        /// <param name="pid">Process ID.</param>
        private static void KillProcessAndChildren(int pid)
        {
            // Cannot close 'system idle process'.
            if (pid == 0)
            {
                return;
            }
            ManagementObjectSearcher searcher = new ManagementObjectSearcher
                    ("Select * From Win32_Process Where ParentProcessID=" + pid);
            ManagementObjectCollection moc = searcher.Get();
            foreach (ManagementObject mo in moc)
            {
                KillProcessAndChildren(Convert.ToInt32(mo["ProcessID"]));
            }
            try
            {
                Process proc = Process.GetProcessById(pid);
                proc.Kill();
            }
            catch (ArgumentException)
            {
                // Process already exited.
            }
        }

        #endregion

        #region Method: FixPath

        /// <summary>
        ///  Ensures that the path ahs a trailing backslash
        /// </summary>
        /// <param name="path">The path to fix.</param>
        /// <returns>Returns the passed path with a trailing backslash.</returns>
        private string FixPath(string path)
        {
            if (path.Length > 0)
                if (path[path.Length - 1] != '\\')
                    return path + '\\';

            return path;
        }


        #endregion

        #region Method: DirectoryCopy

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

        #endregion

        #region Method: checkNodejsInstalled

        /// <summary>
        /// Check Node.js is installed
        /// </summary>
        private void checkNodejsInstalled()
        {
            try
            {
                string value64 = string.Empty;
                string value32 = string.Empty;
                string NodejsVerMessage = "현재 Node.js 버전 : ";

                RegistryKey localKey = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
                localKey = localKey.OpenSubKey(@"SOFTWARE\Node.js");

                RegistryKey localKey32 = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry32);
                localKey32 = localKey32.OpenSubKey(@"SOFTWARE\Node.js");

                if (localKey == null && localKey32 == null)
                {
                    showNodejsDialog();

                    return;
                }
                else if (localKey != null && localKey32 != null)
                {
                    if (localKey.GetValue("Version") != null)
                    {
                        value64 = localKey.GetValue("Version").ToString();
                        txtConsole.Text += NodejsVerMessage + value64 + Environment.NewLine;
                    }
                    else if (localKey32.GetValue("Version") != null)
                    {
                        value32 = localKey32.GetValue("Version").ToString();
                        txtConsole.Text += NodejsVerMessage + value32 + Environment.NewLine;
                    }
                    else
                    {
                        showNodejsDialog();
                    }

                    return;
                }
                else if (localKey != null)
                {
                    if (localKey.GetValue("Version") != null)
                    {
                        value64 = localKey.GetValue("Version").ToString();
                        txtConsole.Text += NodejsVerMessage + value64 + Environment.NewLine;
                    }
                    else
                    {
                        showNodejsDialog();
                    }

                    return;
                }
                else if (localKey32 != null)
                {
                    if (localKey32.GetValue("Version") != null)
                    {
                        value32 = localKey32.GetValue("Version").ToString();
                        txtConsole.Text += NodejsVerMessage + value32 + Environment.NewLine;
                    }
                    else
                    {
                        showNodejsDialog();
                    }

                    return;
                }

            }
            catch (Exception ex)  //just for demonstration...it's always best to handle specific exceptions
            {
                //react appropriately
                txtConsole.Text += ex + Environment.NewLine;
            }
        }

        /// <summary>
        /// When Node.js isn't installed, ask the user to download Node.js.
        /// </summary>
        private void showNodejsDialog()
        {
            string message = "Node.js가 설치되어 있지 않아 프로그램이 제대로 동작하지 않을 수 있습니다. Node.js 다운로드 페이지로 이동하시겠습니까?";
            string title = "Coala Launcher";
            string notInstatllMessage = "Node.js가 설치되어 있지 않습니다.";

            if (MessageBox.Show(
message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk
) == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("https://nodejs.org/ko/");
            }

            txtConsole.Text += notInstatllMessage + Environment.NewLine;
        }

        #endregion

        #endregion

        #region ===== ContextMenu Control =====

        /// <summary>
        /// When clicking right mouse button, select item and pop-up context menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void playerList_MouseUp(object sender, MouseEventArgs e)
        {
            int location = playerList.IndexFromPoint(e.Location);
            if (e.Button == MouseButtons.Right)
            {
                if (location != -1)
                {
                    playerList.SelectedIndex = location;                //Index selected
                    contextMenuPlayerList.Show(playerList.PointToScreen(e.Location));   //Show Menu
                }
            }
        }

        /// <summary>
        /// PlayerList ContextMenu right-click event function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuPlayerList_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.ToString().ToLower() == "op")
            {
                MinecraftServer.Command("op " + playerList.SelectedItem.ToString());
            }
            else if (e.ClickedItem.ToString().ToLower() == "de-op")
            {
                MinecraftServer.Command("deop " + playerList.SelectedItem.ToString());
            }
            else if (e.ClickedItem.ToString().ToLower() == "freeze")
            {
                MinecraftServer.Command("freeze " + playerList.SelectedItem.ToString());
            }
            else if (e.ClickedItem.ToString().ToLower() == "unfreeze")
            {
                MinecraftServer.Command("unfreeze " + playerList.SelectedItem.ToString());
            }
            else if (e.ClickedItem.ToString().ToLower() == "teleport all")
            {
                MinecraftServer.Command("come " + playerList.SelectedItem.ToString());
            }
            else if (e.ClickedItem.ToString().ToLower() == "blind")
            {
                MinecraftServer.Command("blind " + playerList.SelectedItem.ToString());
            }
            else if (e.ClickedItem.ToString().ToLower() == "unblind")
            {
                MinecraftServer.Command("unblind " + playerList.SelectedItem.ToString());
            }
        }

        #endregion

        #region ===== Constructor =====

        /// <summary>
        /// MainForm Constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            //this.Shown += MainForm_Shown;
        }

        #endregion

    }
}
