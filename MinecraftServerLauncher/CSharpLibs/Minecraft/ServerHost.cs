using CSharpLibs.ConfigTools;
using CSharpLibs.Networking;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpLibs.Minecraft
{
    class ServerHost
    {
        #region ===== Events =====

        #region Event: ConsoleChanged

        public delegate void ConsoleChangedEventHandler(int serverHostID, string logLevel, string logMessage);

        /// <summary>
        /// Triggers every time the Minecraft server console changes.
        /// </summary>
        public event ConsoleChangedEventHandler ConsoleChanged;

        protected void OnConsoleChanged(string logLevel, string logMessage)
        {
            ConsoleChanged?.Invoke(mvarID, logLevel, logMessage);
        }

        #endregion

        #region Event: PlayerJoined

        /// <summary>
        /// Represents a method that handles a PlayerJoined event.
        /// </summary>
        /// <param name="playerName">The name of the player that joined.</param>
        /// <param name="playerUUID">The Mojang UUID of the player's account.</param>
        /// <param name="ip">The IP address the player connected from.</param>
        public delegate void PlayerJoinedEventHandler(string playerName, string playerUUID, byte[] ip);

        /// <summary>
        /// Triggers when a new player joins the server.
        /// </summary>
        public event PlayerJoinedEventHandler PlayerJoined;

        /// <summary>
        /// Raise the PlayerJoined event.
        /// </summary>
        /// <param name="player"></param>
        protected void OnPlayerJoined(ref PlayerProfile player)
        {
            PlayerJoined?.Invoke(player.Name, player.UUID, player.IP);
        }

        #endregion

        #region Event: PlayerParted

        /// <summary>
        /// Represents the method that handles a PlayerParted event.
        /// </summary>
        /// <param name="playerName">The name of the player that joined.</param>
        /// <param name="playerUUID">The Mojang UUID of the player's account.</param>
        /// <param name="ip">The IP address the player connected from.</param>
        public delegate void PlayerPartedEventHandler(string playerName, string playerUUID, byte[] ip);

        /// <summary>
        /// Triggers when a player parts/disconnects from the game.
        /// </summary>
        public event PlayerPartedEventHandler PlayerParted;

        /// <summary>
        /// Raises the PlayerParted event.
        /// </summary>
        /// <param name="player"></param>
        protected void OnPlayerParted(ref PlayerProfile player)
        {
            PlayerParted?.Invoke(player.Name, player.UUID, player.IP);
        }

        #endregion

        #region Event: ServerStarting

        public delegate void ServerStartingEventHandler(int serverHostID);

        /// <summary>
        /// Triggers when the Minecraft server begin it's startup process.
        /// </summary>
        public event ServerStartingEventHandler ServerStarting;

        protected void OnServerStarting()
        {
            ServerStarting?.Invoke(mvarID);
        }
        #endregion

        #region Event: ServerStarted
        public delegate void ServerStartedEventHandler(int serverHostID);

        /// <summary>
        /// Triggers when the Minecraft server has completed it's startup process
        /// </summary>
        public event ServerStartedEventHandler ServerStarted;
        // This event will be raised once the output parser sees this line;
        // Done (2.631s)!

        protected void OnServerStarted()
        {
            ServerStarted?.Invoke(mvarID);
        }

        #endregion

        #region Event: ServerShuttingDown

        public delegate void ServerShuttingDownEventHandler(int serverHostID);

        /// <summary>
        /// Triggers when the server starts shutting down.
        /// </summary>
        public event ServerShuttingDownEventHandler ServerShuttingDown;

        protected void OnServerShuttingDown()
        {
            ServerShuttingDown?.Invoke(mvarID);
        }

        #endregion

        #region Event: ServerStopped

        public delegate void ServerStoppedEventHandler(int serverHostID);

        /// <summary>
        /// Triggers when the server has stopped completely.
        /// </summary>
        public event ServerStoppedEventHandler ServerStopped;

        protected void OnServerStopped()
        {
            ServerStopped?.Invoke(mvarID);
        }

        #endregion

        #endregion

        #region ===== Internal Helper Methods =====

        #region Method: ConvertIP

        /// <summary>
        /// Converts a 4-Part string array into a byte array for IP stuff.
        /// </summary>
        /// <param name="ipParts">The 4-part string array to convert.</param>
        /// <returns>Returns a 4-byte array containing the converted IP. If mismatched, localhost is returned.</returns>
        private byte[] ConvertIP(string[] ipParts)
        {
            byte[] result = new byte[] { 127, 0, 0, 1 };

            if (ipParts.Length == 4)
            {
                for(int p = 0; p < ipParts.Length; p++)
                {
                    // First attempts to parse the string as an int (FixInt)
                    // Then ensures that the parsed int value is within byte range
                    // Finally puts it into the result array.
                    result[p] = FixByte(FixInt(ipParts[p]));
                }
            }

            return result;
        }

        #endregion

        #region Method: FixByte

        /// <summary>
        /// Ensures that we have an in-range byte value.
        /// </summary>
        /// <param name="value">The value to fix.</param>
        /// <returns>Returns an in-range byte value.</returns>
        private byte FixByte(int value)
        {
            if (value < 0)
            {
                return 0;
            }
            else if (value > 255)
            {
                return 255;
            }
            return (byte)value;
        }

        #endregion

        #region Method: FixInt

        /// <summary>
        /// Attempt to convert the passed string value into an int number.
        /// </summary>
        /// <param name="value">The value of convert.</param>
        /// <returns>Returns the integer representation of the passed string if successful, otherwise zero.</returns>
        private int FixInt(string value)
        {
            int result = 0;

            // Try to parse the string as a number, if not successful
            if (!int.TryParse(value, out result))
            { // force the result to zero
                result = 0;
            }

            return result;
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

        #region Method: GeneratePassword

        private string GeneratePassword()
        {
            const string Letters = "qazxswsfasdfwesecawecaweawec234839439";
            Random rng = new Random(DateTime.Now.Millisecond);
            string result = "";

            for (int i = 0; i < 25; i++)
            {
                int index = 0;
                while (index < 1 || index > Letters.Length)
                {
                    index = rng.Next(1, Letters.Length);
                }
                result += Letters[index - 1];
            }

            return result;
        }

        #endregion

        #region Method: UpdateServerProperties

        /// <summary>
        /// Update the server.properties settings with remote console settings.
        /// </summary>
        /// <param name="enableRCon">When set true, remote console will be enabled allowing control of the server. When false, disables RCon and removes the settings.</param>
        private void UpdateServerProperties(bool enableRCon)
        {
            if (File.Exists(mvarServerPath + "server.properties"))
            {
                INIFile INI = new INIFile(mvarServerPath + "server.properties", true);
                if (enableRCon)
                {
                    INI.SetValue("", "enable-rcon", "true");
                    INI.SetValue("", "rcon.port", mvarRemoteConsolePort.ToString());
                    INI.SetValue("", "rcon.password", RConPassword);
                    INI.SetValue("", "broadcast-rcon-to-ops", "true");
                }
                else
                {
                    INI.SetValue("", "enable-rcon", "false");
                    INI.SetValue("", "broadcast-rcon-to-ops", "false");
                    INI.RemoveKey("", "rcon.port");
                    INI.RemoveKey("", "rcon.password");
                }
                INI.Save();
            }
        }

        #endregion

        #endregion

        #region ===== RemoteConsole Support =====

        SourceRemoteConsole RCon = new SourceRemoteConsole();

        /// <summary>
        /// The current password in use for remote console.
        /// </summary>
        private string RConPassword = "";

        private void RCon_Connected()
        {
            //TODO: add whatever is needed after we've connected
        }

        private void RCon_ConnectFailed(Exception ex)
        {
            //TODO: maybe ?
        }

        private void RCon_Authenticated()
        {
            //TODO: handle that we are authenticated
        }

        private void RCon_AuthenticationFailed()
        {
            //TODO: Handle authentication failures
            // We'll force a disconnect
            RCon.Disconnect();
        }

        private void RCon_ServerResponse(string responseMessage)
        {
            //TODO: Handle incoming server responses
        }

        private void RCon_Disconnected()
        {
            //TODO: Handle other clean up as needed
        }

        private void InitializeRCon()
        {
            RCon.Connected += RCon_Connected;
            RCon.ConnectFailed += RCon_ConnectFailed;

            RCon.Authenticated += RCon_Authenticated;
            RCon.AuthenticationFailed += RCon_AuthenticationFailed;

            RCon.ServerResponse += RCon_ServerResponse;

            RCon.Disconnected += RCon_Disconnected;
        }

        #endregion

        #region ===== Console Parser =====

        // Timestamp
        // Source or Thread
        // Log level
        // Log Message

        private struct LogEntry
        {
            public DateTime Timestamp;
            public string Source;
            public string LogLevel;
            public string LogMessage;

            public LogEntry(DateTime timestamp, string source, string logLevel, string logMessage)
            {
                Timestamp = timestamp;
                Source = source.Trim();
                LogLevel = logLevel.Trim();
                LogMessage = logMessage.Trim();
            }
        }

        // Vanila Server Message
        // [20:29:49] [Server thread/INFO]: Done (10.219s)! For help, type "help" or "?"
        // [20:29:59] [User Authenticator #1/INFO]: UUID of player Mateatdang is 4c1db48f-4d2c-3efa-bd22-b28f56df0ce3
        // [20:30:00] [Server thread/INFO]: Mateatdang[/192.168.10.12:60197] logged in with entity id 146 at ([world]4.805233873224047, 4.0, 21.78309565413898)
        // Spigot Server Message
        // [06:18:32 INFO]: Done (10.193s)! For help, type "help" or "?"
        // [06:30:33 INFO]: UUID of player Mateatdang is 4c1db48f-4d2c-3efa-bd22-b28f56df0ce3
        // [06:30:34 INFO]: Mateatdang[/172.30.1.55:61105] logged in with entity id 245 at ([world]4.805233873224047, 4.0, 21.78309565413898)

        private LogEntry ParseConsoleLine(string consoleLine)
        {
            if(consoleLine.IndexOf("]:") > -1)
            {
                // Grab a copy of the start of the console line, ending at "]:"
                string rawData = consoleLine.Substring(0, consoleLine.IndexOf("]:"));
                // Grab a copy of the log message from the console line, starting just past "]:" and remove any leading and trailing spaces
                string logMessage = consoleLine.Substring(consoleLine.IndexOf("]:") + 2, consoleLine.Length - (consoleLine.IndexOf("]:") + 2)).Trim();
                // Grab a copy of the raw data, only existing loglevel in spigot server
                string sourceInfo = rawData.Substring(rawData.LastIndexOf(' ') + 1, rawData.Length - (rawData.LastIndexOf(' ') + 1));
                // Now that we have sourceInfo, sourceInfo is logLevel
                string[] sourceParts = { "", sourceInfo };
                // ... to get: Source(Empty) and Loglevel
                string source = sourceParts[0];
                string logLevel = sourceParts[1];
                // Lastly, lets grab the timestamp
                string timestamp = rawData.Substring(0, rawData.IndexOf(' '));
                // Remove the leading bracket
                timestamp = timestamp.Replace("[", "").Trim();
                // Split the timestamp parts:
                string[] timestampParts = timestamp.Split(':');
                // Convert the 3 time components
                int hour = FixInt(timestampParts[0]);
                int minute = FixInt(timestampParts[1]);
                int second = FixInt(timestampParts[2]);

                return new LogEntry(new DateTime(
                    DateTime.Now.Year,
                    DateTime.Now.Month,
                    DateTime.Now.Day,
                    hour,
                    minute,
                    second
                    ),
                    source,
                    logLevel,
                    logMessage
                    );
            }

            return new LogEntry(DateTime.Now, "", "", "");
        }

        #endregion

        #region ===== Thread Handling =====

        private Thread ServerThread = null;

        private void RunServer()
        {
            bool ServerShutdownSignaled = false;
            string playerName = "";
            string playerUUID = "";

            OnServerStarting();
            
            Process proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "java",
                    Arguments = "-Xmx" + mvarMemorySize.ToString() + "M -Xms" + mvarMemorySize.ToString() + "M -jar " + mvarServerJar, // + " nogui",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    CreateNoWindow = true,
                    WorkingDirectory = mvarServerPath
                }
            };

            proc.Start();

            while (!proc.StandardOutput.EndOfStream)
            {
                string line = proc.StandardOutput.ReadLine();

                if (line.IndexOf("]:") > -1)
                {
                    LogEntry entry = ParseConsoleLine(line);

                    // if: server thread
                    if (entry.LogMessage.Substring(0, entry.LogMessage.IndexOf(' ')).ToLower() == "done" && entry.LogMessage.ToLower().IndexOf("for help, type") > -1)
                    {
                        // Raise the ServerStarted event :D
                        OnServerStarted();
                    }
                    else if (entry.LogMessage.ToLower() == "stopping the server" || entry.LogMessage.ToLower() == "stopping server")
                    {
                        if (!ServerShutdownSignaled)
                        {
                            // Tell RCon to disconnect, if it's running
                            if (RCon.IsConnected)
                            {
                                RCon.Disconnect();
                            }
                            // Raise the ServerShuttingDown event
                            OnServerShuttingDown();
                            // Indicate that we have already completed this event handling
                            ServerShutdownSignaled = true;
                        }
                    }
                    else if(entry.LogMessage.ToLower().IndexOf("logged in with entity id") > -1 && entry.LogMessage.IndexOf('[') > -1 && entry.LogMessage.IndexOf(']') > -1)
                    {
                        if(playerName.Length > 0 && playerUUID.Length > 0)
                        {
                            // PlayerJoinBug
                            //if(entry.LogMessage.IndexOf(playerName) > -1)
                            //{
                            //    // We need to split the IP the player is connecting from...
                            //    // Then we need to add this player to the online list
                            //    // For reference:
                            //    // [06:30:34 INFO]: Mateatdang[/172.30.1.55:61105] logged in with entity id 245 at ([world]4.805233873224047, 4.0, 21.78309565413898)
                            //    string ipString = entry.LogMessage.Substring(entry.LogMessage.IndexOf('[') + 1, entry.LogMessage.Length - (entry.LogMessage.IndexOf('[') + 1));
                            //    ipString = ipString.Substring(0, ipString.IndexOf(':'));
                            //    // Just in case: remove any leading slash
                            //    ipString = ipString.Replace("/", "");
                            //    // Lets see if there's a period inhere
                            //    if (ipString.IndexOf('.') > -1)
                            //    {
                            //        // Split the possible IP string into it's individual parts
                            //        string[] ipParts = ipString.Split('.');
                            //        // Convert it into a byte array
                            //        byte[] ip = ConvertIP(ipParts);

                            //        // Create the player profile...
                            //        PlayerProfile player = new PlayerProfile(DateTime.Now, playerName, playerUUID, ip);
                                    
                            //        // And add it to the current online list
                            //        lock (mvarOnlinePlayers)
                            //        {
                            //            // Ensures that we keep0 synchronized data across threads
                            //            mvarOnlinePlayers.Add(player);
                            //        }
                            //        //NOTE: if needed, add an event that we can raise when a player joins
                            //        System.Diagnostics.Debug.WriteLine("### >>> " + player.Name + " has joined the game.");
                            //        // Raise the PlayerJoined event
                            //        OnPlayerJoined(ref player);
                            //    }
                            //}
                        }
                    }
                    else if (entry.LogMessage.ToLower().IndexOf(" lost connection:") > -1)
                    {
                        // [21:01:36 INFO]: Mateatdang lost connection: Server closed
                        string firstWord = entry.LogMessage.Substring(0, entry.LogMessage.IndexOf(' '));
                        // The first word is supposed to be a player's name
                        // Check to see if there is some kind of formatting there...
                        // Possible json: {"text":"This is raw text"}
                        if (
                            firstWord.IndexOf('<') + 
                            firstWord.IndexOf('>') + 
                            firstWord.IndexOf('{') + 
                            firstWord.IndexOf('}') + 
                            firstWord.IndexOf('[') + 
                            firstWord.IndexOf(']') + 
                            firstWord.IndexOf(':') + 
                            firstWord.IndexOf('\"') == -8)
                        {
                            PlayerProfile player = new PlayerProfile(DateTime.Now, "", "", new byte[] { 0, 0, 0, 0 });

                            lock (mvarOnlinePlayers)
                            {
                                int playerIndex = -1;

                                for (int p = 0; p < mvarOnlinePlayers.Count; p++)
                                {
                                    if (mvarOnlinePlayers[p].Name == firstWord)
                                    {
                                        playerIndex = p;
                                        break;
                                    }
                                }

                                if (playerIndex > -1)
                                {
                                    player = mvarOnlinePlayers[playerIndex];
                                    mvarOnlinePlayers.RemoveAt(playerIndex);
                                    //NOTE: we could add an event that can be raised when a player disconnects
                                    System.Diagnostics.Debug.WriteLine("### >>> " + firstWord + " has left the game.");
                                }
                            }

                            // Did we find the player that disconnected?
                            if (player.Name.Length > 0 && player.UUID.Length > 0)
                            {
                                // Yes we did, so raise the event!
                                OnPlayerParted(ref player);
                            }
                        }
                    }

                    // Force the playerName and playerUUID variables empty
                    playerName = "";
                    playerUUID = "";
                    // By forcing these two variables to alway be empty here,
                    // we effectively prevent players from being able to cheat the parse
                    // into believing a player has joined.

                    // else if: the rcon listener thread - can't remember the output :P
                    if (entry.LogMessage.ToLower().IndexOf("rcon running on") > -1)
                    {
                        string portInfo = entry.LogMessage.Substring(entry.LogMessage.LastIndexOf(':') + 1, entry.LogMessage.Length - (entry.LogMessage.LastIndexOf(':') + 1));
                        int port = FixInt(portInfo);

                        // Is the console log shown port identical to our configured port?
                        if (port == mvarRemoteConsolePort)
                        {
                            // We can now safely assume the server is listening for rcon connections!
                            // So ... start the rcon
                            RCon.Connect(new byte[] { 127, 0, 0, 1 }, mvarRemoteConsolePort, RConPassword);
                        }
                    }
                    // else if: User Authenticator
                    // We know that we can expect to get:
                    // The player's name (the current name)
                    // The UUID of the player's account (Mojang Account!)
                    // Sample of Login:
                    // [06:30:33 INFO]: UUID of player Mateatdang is 4c1db48f-4d2c-3efa-bd22-b28f56df0ce3
                    if (entry.LogMessage.ToLower().IndexOf("uuid of player") > -1 && entry.LogMessage.ToLower().IndexOf(" is ") > -1)
                    {
                        playerUUID = entry.LogMessage.Substring(entry.LogMessage.LastIndexOf(' ') + 1, entry.LogMessage.Length - (entry.LogMessage.LastIndexOf(' ') + 1));
                        playerName = entry.LogMessage.Substring(0, entry.LogMessage.LastIndexOf(" is "));
                        playerName = playerName.Substring(playerName.LastIndexOf(' ') + 1, playerName.Length - (playerName.LastIndexOf(' ') + 1));

                        // Temp IP address
                        byte[] ip = new byte[] { 0, 0, 0, 0 };

                        // Create the player profile...
                        PlayerProfile player = new PlayerProfile(DateTime.Now, playerName, playerUUID, ip);

                        // And add it to the current online list
                        lock (mvarOnlinePlayers)
                        {
                            // Ensures that we keep0 synchronized data across threads
                            mvarOnlinePlayers.Add(player);
                        }
                        //NOTE: if needed, add an event that we can raise when a player joins
                        System.Diagnostics.Debug.WriteLine("### >>> " + player.Name + " has joined the game.");
                        // Raise the PlayerJoined event
                        OnPlayerJoined(ref player);
                    }
                    //NOTE: We can also add in a connection counter, based on the source: [User Authenticator #1]
                    // Simple thing to do: cut away "user authenticator" and convert to int - expose as property, job done! :)

                    OnConsoleChanged(entry.LogLevel, line);
                }
            }
            proc.WaitForExit();

            proc.Dispose();

            // Clean up the server.properties after run has completed
            UpdateServerProperties(false);
            mvarOnlinePlayers.Clear();
            OnServerStopped();
        }

        #endregion

        #region ===== Properties =====

        /// <summary>
        /// Determines whether this instance is locked: if locked, properites can not be changed while the server is running
        /// </summary>
        private bool Locked = false;

        #region Property: ID

        private int mvarID = 0;

        /// <summary>
        /// Holds the ID of this Minecraft server instance.
        /// </summary>
        public int ID
        {
            get { return mvarID; }
        }

        #endregion

        #region Property: MemorySize

        private int mvarMemorySize = 1024;

        /// <summary>
        /// Determines the memory set aside for java to run this Minecraft server instance.
        /// </summary>
        public int Memorysize
        {
            get { return mvarMemorySize; }
            set
            {
                if (!Locked)
                {
                    if (value >= 1024 && value <= 16384) //TODO: later on: replace with this comp's physical memory max
                    {
                        mvarMemorySize = value;
                    }
                }
            }
        }

        #endregion

        #region Property: OnlinePlayers

        private List<PlayerProfile> mvarOnlinePlayers = new List<PlayerProfile>();

        /// <summary>
        /// Contains a list of currently online players, if any.
        /// </summary>
        public List<PlayerProfile> OnlinePlayers
        {
            get { return mvarOnlinePlayers; }
        }
        #endregion

        #region Property: RemoteConsolePassword

        private string mvarRemoteConsolePassword = "";

        /// <summary>
        /// Indicates the password to use for authentication by means of remote console.
        /// </summary>
        public string RemoteConsolePassword
        {
            get { return mvarRemoteConsolePassword; }
            set
            {
                if (!Locked)
                {
                    if (value.Trim().Length > 0)
                    {
                        mvarRemoteConsolePassword = value.Trim();
                        mvarUseRandomizedRConPassword = false;
                    }
                }
            }
        }

        #endregion

        #region Property: RemoteConsolePort

        private int mvarRemoteConsolePort = 25575;

        /// <summary>
        /// Indicates the port number to use for remote console access to the Minecraft server.
        /// </summary>
        public int RemoteConsolePort
        {
            get { return mvarRemoteConsolePort; }
            set
            {
                if (!Locked)
                {
                    if (value > 1024 && value < 65536) // why use or operation?
                    {
                        mvarRemoteConsolePort = value;
                    }
                }
            }
        }

        #endregion

        #region Property: Running

        /// <summary>
        /// A flag that indicates whether the Minecraft server is running.
        /// </summary>
        public bool Running
        {
            get
            {
                return (ServerThread != null);
            }
        }

        #endregion

        #region Property: ServerJar

        private string mvarServerJar = "";

        /// <summary>
        /// Holds the name of the Minecraft server jar.
        /// </summary>
        public string ServerJar
        {
            get { return mvarServerPath; }
            set
            {
                if (!Locked)
                {
                    if(mvarServerPath.Length > 0)
                    {
                        if(File.Exists(mvarServerPath + value))
                        {
                            mvarServerJar = value;
                        }
                    }
                }
            }
        }

        #endregion

        #region Property: ServerPath

        private string mvarServerPath = "";

        /// <summary>
        /// Determines the path to the Minecraft Server.
        /// </summary>
        public string ServerPath
        {
            get { return mvarServerPath; }
            set
            {
                if (!Locked)
                {
                    if (Directory.Exists(value))
                    {
                        mvarServerPath = FixPath(value.Trim());
                    }
                    else
                    {
                        mvarServerPath = "";
                    }
                }
            }
        }

        #endregion

        #region Property: UseRandomizedRConPassword

        private bool mvarUseRandomizedRConPassword = false;

        /// <summary>
        /// Indicates whether to use randomized remote console passwords.
        /// </summary>
        public bool UseRandomizedRConPassword
        {
            get { return mvarUseRandomizedRConPassword; }
            set
            {
                if (!Locked)
                {
                    mvarUseRandomizedRConPassword = value;
                    if (mvarUseRandomizedRConPassword)
                    {
                        mvarRemoteConsolePassword = "";
                    }
                }
            }
        }

        #endregion

        #endregion

        #region ===== Public Method =====

        #region Public Method: ConfigureServer

        /// <summary>
        /// Configures the path, jar and memory size for this server instance.
        /// </summary>
        /// <param name="serverPath">The path to the Minecraft server.</param>
        /// <param name="serverJar">The filename of the Minecraft server jar.</param>
        /// <param name="memorySize">The amount of memory in megabytes to set aside for the java instance.</param>
        public void ConfigureServer(string serverPath, string serverJar, int memorySize)
        {
            if (!Locked) // <--- will be true when the server is running!
            {
                if (Directory.Exists(serverPath))
                {
                    mvarServerPath = FixPath(serverPath);
                    if (File.Exists(mvarServerPath + serverJar))
                    {
                        mvarServerJar = serverJar;

                        if (memorySize >= 1024 && memorySize <= 16384)
                        {
                            mvarMemorySize = memorySize;
                        }
                    }
                }
            }
        }

        #endregion

        #region Public Method: Start

        /// <summary>
        /// Attempt to start the Minecraft server.
        /// </summary>
        /// <returns>Returns true if the startup wa successful, otherwise false.</returns>
        public bool Start()
        {
            bool validRConConfig = false;

            RConPassword = "";
            if (mvarUseRandomizedRConPassword)
            {
                validRConConfig = true;
                RConPassword = GeneratePassword();
            }
            else if (mvarRemoteConsolePassword.Trim().Length > 0)
            {
                validRConConfig = true;
                RConPassword = mvarRemoteConsolePassword;
            }

            if (mvarServerPath.Length > 0 && mvarServerJar.Length > 0)
            {
                if (validRConConfig)
                {
                    UpdateServerProperties(true);
                }
                if (File.Exists(mvarServerPath + mvarServerJar) && validRConConfig)
                {
                    // Yup: both path and file exists - let's do this!
                    Locked = true; // Prevents properties from being changes!

                    ServerThread = new Thread(new ThreadStart(RunServer));

                    ServerThread.Start();

                    while (!ServerThread.IsAlive)
                        Thread.Sleep(5);

                    return true;
                }
            }

            return false;
        }

        #endregion

        #region Public Method: Stop

        public void Stop()
        {
            if (Running)
            {
                if (RCon.IsConnected)
                {
                    Locked = false;

                    RCon.Execute("stop");
                }
            }
        }

        #endregion

        #endregion

        #region ===== Constructor =====

        public ServerHost(int id)
        {
            mvarID = id;
            mvarMemorySize = 1024;
            mvarServerJar = "";
            mvarServerPath = "";
            Locked = false;

            InitializeRCon();
        }

        #endregion


        #region ===== Execute Command =====
        
        public void Command(string command)
        {
            if (Running)
            {
                if (RCon.IsConnected)
                {
                    RCon.Execute(command);
                }
            }
        }

        #endregion
    }
}
