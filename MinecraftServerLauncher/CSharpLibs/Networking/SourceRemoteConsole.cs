using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpLibs.Networking
{
    class SourceRemoteConsole
    {

        private IPAddress RemoteIP = new IPAddress(new byte[] { 127, 0, 0, 1 });

        private int RemotePort = 25575; // The default Minecraft server RCon port

        private string AuthenticationPassword = ""; // Start up empty

        private bool ClientAuthenticated = false;

        private volatile bool DisconnectClient = false;

        #region ===== Events =====

        #region Event: Connected

        public delegate void ConnectEventHandler();

        /// <summary>
        /// Triggers once a connection to the remote server has been established.
        /// </summary>
        public event ConnectEventHandler Connected;

        protected void OnConnected()
        {
            Connected?.Invoke();
        }

        #endregion

        #region Event: ConnectFailed

        public delegate void ConnectFailedEventHandler(Exception ex);

        /// <summary>
        /// Triggers if the attempt at connecting to the remote server fails.
        /// </summary>
        public event ConnectFailedEventHandler ConnectFailed;

        protected void OnConnectFailed(Exception ex)
        {
            ConnectFailed?.Invoke(ex);
        }

        #endregion

        #region Event: Disconnected

        public delegate void DisconnectEventHandler();

        /// <summary>
        /// Triggers when disconnected from the remote server. This could either be the client disconnecting from the server or the server disconnecting the client.
        /// </summary>
        public event DisconnectEventHandler Disconnected;

        protected void OnDisconnected()
        {
            Disconnected?.Invoke();
        }

        #endregion

        #region Event: Authenticated

        public delegate void AuthenticatedEventHandler();

        /// <summary>
        /// Triggers upon successful authentication.
        /// </summary>
        public event AuthenticatedEventHandler Authenticated;

        protected void OnAuthenticated()
        {
            Authenticated?.Invoke();
        }

        #endregion

        #region Event: AuthenticationFailed

        public delegate void AuthenticationFailedEventHandler();

        /// <summary>
        /// Triggers if the attempt at authenticating failed. This is most likely due to incorrect password.
        /// </summary>
        public event AuthenticationFailedEventHandler AuthenticationFailed;

        protected void OnAuthenticationFailed()
        {
            AuthenticationFailed?.Invoke();
        }

        #endregion

        #region Event: ServerResponse

        public delegate void ServerResponseEventHandler(string responseMessage);

        /// <summary>
        /// Triggers when a response is received from the remote server.
        /// </summary>
        public event ServerResponseEventHandler ServerResponse;

        protected void OnServerResponse(string responseMessage)
        {
            ServerResponse?.Invoke(responseMessage);
        }

        #endregion

        #endregion

        #region ===== Packet Handling =====

        private Random RNG = null;

        /// <summary>
        /// Will always contain the last used packet ID number.
        /// </summary>
        private int LastPacketID = 0;

        #region Private Method: GeneratePacketID

        /// <summary>
        /// Generates a randomized packet ID number.
        /// </summary>
        /// <returns>Returns a randomized positive int-32 packet ID number.</returns>
        private int GeneratePacketID()
        {
            return RNG.Next(100, int.MaxValue - 100);
        }

        #endregion

        #region Private Method: ConvertInt32

        /// <summary>
        /// Converts the passed int (32-bit signed) into a forced little-endian byte array.
        /// </summary>
        /// <param name="value">The int (32-bit signed) value to convert.</param>
        /// <returns>Returns a forced little-endian byte array containing the original int value.</returns>
        private byte[] ConvertInt32(int value)
        {
            byte[] intBytes = BitConverter.GetBytes(value);

            // If the byte order is not Little-Endian
            if (!BitConverter.IsLittleEndian)
            { // Reverse the byte order
                Array.Reverse(intBytes);
            }

            // Returns the result
            return intBytes;
        }

        /// <summary>
        /// Converts the passed byte array into a 32-bit signed int value.
        /// </summary>
        /// <param name="value">The byte array value to convert.</param>
        /// <returns>Rerturns a 32-bit signed int value.</returns>
        private int ConvertInt32(byte[] value)
        {
            return ConvertInt32(value, 0);
        }

        /// <summary>
        /// Converts the passed byte array, starting at the specified startIndex, int a 32-bit signed int value.
        /// </summary>
        /// <param name="value">The byte array value to convert.</param>
        /// <param name="startIndex">The position at which to start the int position.</param>
        /// <returns>Rerturns a 32-bit signed int value.</returns>
        private int ConvertInt32(byte[] value, int startIndex)
        {
            if (startIndex < value.Length - 4)
            {
                byte[] tempValue = new byte[4];

                Array.Copy(value, startIndex, tempValue, 0, 4);
                
                if (!BitConverter.IsLittleEndian)
                {
                    Array.Reverse(tempValue);
                }

                return BitConverter.ToInt32(tempValue, 0);
            }

            return 0;
        }

        #endregion

        #region Private Method: ConvertPacket

        private const int SERVERDATA_AUTH = 3;
        private const int SERVERDATA_AUTH_RESPONSE = 2;
        private const int SERVERDATA_AUTH_FAIL = -1;
        private const int SERVERDATA_EXECCOMMAND = 2;
        private const int SERVERDATA_RESPONSE_VALUE = 0;

        /// <summary>
        /// Generate a vaild RCon packet, based on the specified packet type with the specified payload.
        /// </summary>
        /// <param name="packetType">The type of packet to generate.</param>
        /// <param name="payload">The payload to include.</param>
        /// <returns>Return a valid RCon protocol packet as a byte array.</returns>
        private byte[] ConvertPacket(int packetType, string payload)
        {
            byte[] packetBody = Encoding.ASCII.GetBytes(payload);
            int packetSize = packetBody.Length;

            packetSize += 4; // Four bytes to hold the packetID.
            packetSize += 4; // Four bytes to hold the packet type.
            packetSize += 1; // One byte to zero-terminate the packetBody.
            packetSize += 1; // One byte to zero-terminate the empty string at the end of the packet.

            int packetID = GeneratePacketID();
            LastPacketID = packetID; // Store this ID for later verification
            byte[] packetIDBytes = ConvertInt32(packetID);
            byte[] packetTypeBytes = ConvertInt32(packetType);
            byte[] packetSizeBytes = ConvertInt32(packetSize);

            byte[] result = new byte[packetSize + 4];

            Array.Copy(packetSizeBytes, 0, result, 0, packetSizeBytes.Length);
            Array.Copy(packetIDBytes, 0, result, 4, packetIDBytes.Length);
            Array.Copy(packetTypeBytes, 0, result, 8, packetTypeBytes.Length);
            Array.Copy(packetBody, 0, result, 12, packetBody.Length);

            result[result.Length - 2] = 0;
            result[result.Length - 1] = 0;

            return result;
        }

        /// <summary>
        /// Expects a valid RCon protocol packet. Splits the packet data into it's packet type, packet ID and returns the payload if any.
        /// </summary>
        /// <param name="packet">The RCon protocol packet to convert.</param>
        /// <param name="packetType">The type of packet received.</param>
        /// <param name="packetID">The ID number of this packet.</param>
        /// <returns>Returns the payload found in the packet, if any - otherwise an empty string.</returns>
        private string ConvertPacket(byte[] packet, out int packetType, out int packetID)
        {
            int packetSize = ConvertInt32(packet, 0);

            // Verify that the received packet is of correct size
            if (packet.Length == packetSize + 4)
            {
                if (packet[packet.Length - 2] == 0 && packet[packet.Length-1] == 0)
                {
                    packetID = ConvertInt32(packet, 4);
                    packetType = ConvertInt32(packet, 8);

                    int payloadLength = packetSize - (4 + 4 + 2);
                    string payload = "";

                    if (payloadLength > 0)
                    {
                        byte[] payloadBytes = new byte[payloadLength];
                        Array.Copy(packet, 12, payloadBytes, 0, payloadLength);
                        payload = Encoding.Default.GetString(payloadBytes);
                    }

                    return payload;
                }

            }

            packetType = SERVERDATA_AUTH_FAIL;
            packetID = SERVERDATA_AUTH_FAIL;

            return "";
        }

        #endregion

        #endregion

        #region ===== Send Handling =====

        private Queue<byte[]> SendQueue = new Queue<byte[]>();

        #region Private Method: SendToServer

        /// <summary>
        /// Queues up the passed packet to be sent to the remote server.
        /// </summary>
        /// <param name="packet">The RCon packet to queue up for sending.</param>
        private void SendToServer(byte[] packet)
        {
            // Thread-lock the send queue
            lock (SendQueue)
            {
                SendQueue.Enqueue(packet);
            }
        }

        /// <summary>
        /// Send the passed command as an RCon packet to the remote server.
        /// </summary>
        /// <param name="payload"></param>
        private void SendToServer(int packetType, string payload)
        {
            SendToServer(ConvertPacket(packetType, payload));
        }
        
        #endregion


        #endregion

        #region ===== Receive Handling =====

        /// <summary>
        /// Processes the data received from the server.
        /// </summary>
        /// <param name="packet">The packet received.</param>
        private void DataReceived(byte[] packet)
        {
            int packetType = 0;
            int packetID = 0;
            string responseMessage = "";

            responseMessage = ConvertPacket(packet, out packetType, out packetID);

            switch (packetType)
            {
                case SERVERDATA_AUTH_RESPONSE:
                    if (packetID == LastPacketID)
                    {
                        OnAuthenticated();

                        ClientAuthenticated = true;
                    }
                    else if (packetID == SERVERDATA_AUTH_FAIL)
                    {
                        OnAuthenticationFailed();
                        //Note: here we could add in a forced disconnect or a authentication retry.
                    }

                    break;
                case SERVERDATA_RESPONSE_VALUE:
                    OnServerResponse(responseMessage);

                    break;
            }
        }

        #endregion


        #region ===== Socket Thread Stuff =====

        private Thread ClientThread = null;

        private Socket ClientSocket = null;

        /// <summary>
        /// Monitors the activities of ther TCP connection and processes the send queue.
        /// </summary>
        private void MonitorConnection()
        {
            bool authenticate = true;

            ClientAuthenticated = false;

            try
            {
                ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ClientSocket.Connect(RemoteIP, RemotePort);
            }
            catch (Exception ex)
            {
                OnConnectFailed(ex);
                StopMonitor(false);    
                return;
            }

            // We are now connected, so raise the event for it
            OnConnected();

            while (true)
            {
                // Are we still connected to the server?
                if (IsConnected)
                {
                    // Do we need to authenticate?
                    if (authenticate)
                    {
                        authenticate = false;
                        // Send an authentication request to the server
                        SendToServer(SERVERDATA_AUTH, AuthenticationPassword);
                    }

                    // First lets check if there is data to receive
                    if(ClientSocket.Poll(10, SelectMode.SelectRead))
                    {
                        // There is data ready to be received!
                        byte[] buffer = new byte[4096];
                        int receivedBytes = 0;

                        try
                        {
                            receivedBytes = ClientSocket.Receive(buffer, buffer.Length, SocketFlags.None);
                        }
                        catch
                        {
                            receivedBytes = 0;
                        }

                        if (receivedBytes > 0)
                        {
                            byte[] data = new byte[receivedBytes];

                            Array.Copy(buffer, 0, data, 0, receivedBytes);

                            DataReceived(data);

                            data = new byte[0];
                        }

                        buffer = new byte[0];
                    }
                    else
                    { // No data to receive: process the send queue

                        // Thread-lock the send queue to prevent of desync
                        lock (SendQueue)
                        {
                            if (SendQueue.Count > 0)
                            {
                                // Grab the next block of data to send ...
                                byte[] dataBlock = SendQueue.Dequeue();
                                try
                                {
                                    ClientSocket.Send(dataBlock, dataBlock.Length, SocketFlags.None);
                                }
                                catch
                                {
                                    // If an error occurs here: it could be because the connection was broken
                                    //                          orphaned or disconnected server side.
                                    DisconnectClient = true;
                                }
                            }
                        } // lock
                    }
                }
                else // if (IsConnected)
                { // Nope, we are not longer conneted so exit the loop
                    break;
                }

                if (DisconnectClient)
                {
                    break;
                }

            } // while (true)

            // We are no longer connected, so do the socket cleanup and raise the Disconnect Event.
            StopMonitor(true);
            
        }

        /// <summary>
        /// Start the connection monitoring thread. 
        /// </summary>
        private void StartMonitor()
        {
            if (!IsConnected && ClientSocket == null)
            {
                ClientThread = new Thread(new ThreadStart(MonitorConnection));
                ClientThread.Start();

                if (!ClientThread.IsAlive)
                {
                    Thread.Sleep(5);
                }
            }
        }

        /// <summary>
        /// Shuts down the TCP connect and terminates the socket and monitoring thread.
        /// </summary>
        /// <param name="raiseDisconnectedEvent">Should the Disconnected event be raised?</param>
        private void StopMonitor(bool raiseDisconnectedEvent)
        {
            if (ClientSocket != null)
            {
                try
                {
                    ClientSocket.Shutdown(SocketShutdown.Both);
                }
                catch { }

                Thread.Sleep(50);

                try
                {
                    ClientSocket.Disconnect(false);
                }
                catch { }

                Thread.Sleep(50);

                try
                {
                    ClientSocket.Close();
                }
                catch { }
            }

            // Clean up both the socket and the monitoring thread.
            ClientSocket = null;
            ClientThread = null;

            // REMEMBER!! To reset your flags, you derp!
            ClientAuthenticated = false;
            DisconnectClient = false; // MUST be set to false, otherwiser it'll force an instant disconnect :P

            // And finally: do we need to raise the Disconnected event?
            if (raiseDisconnectedEvent)
            {
                OnDisconnected();
            }
        }

        #endregion


        #region ===== Properties =====

        #region Property: IsConnected

        /// <summary>
        /// Indicates whether we are still connected or not. 
        /// </summary>
        public bool IsConnected
        {
            get
            {
                bool result = false;

                try
                {
                    result = !(ClientSocket.Poll(1, SelectMode.SelectRead) && ClientSocket.Available == 0);
                }
                catch { }

                return result;
            }
        }

        #endregion

        #endregion

        #region ===== Public Methods =====

        #region Public Method: Connect

        /// <summary>
        /// Attempt to establish a connection to a remote server.
        /// </summary>
        /// <param name="serverIP">The IPAddress od the remote server to connect to.</param>
        /// <param name="serverPort">The port that the remote server is listening on.</param>
        /// <param name="authPassword">The password to authenticate with.</param>
        public void Connect(IPAddress serverIP, int serverPort, string authPassword)
        {
            if ((serverPort > 1024 && serverPort < 65536) && authPassword.Trim().Length > 0)
            {
                // Store the passed values
                RemoteIP = serverIP;
                RemotePort = serverPort;
                AuthenticationPassword = authPassword.Trim();

                // Fire up the monitoring thread, which attempts the connection
                StartMonitor();
            }
        }

        /// <summary>
        /// Attempt to establish a connection to a remote server.
        /// </summary>
        /// <param name="ip">A 4-byte byte array containing the IP to connect to.</param>
        /// <param name="serverPort">The port that the remote server is listening on.</param>
        /// <param name="authPassword">The password to authenticate with.</param>
        public void Connect(byte[] ip, int serverPort, string authPassword)
        {
            if (ip.Length == 4)
            {
                Connect(new IPAddress(ip), serverPort, authPassword);
            }
        }

        #endregion

        #region Public Method: Disconnect
        
        /// <summary>
        /// Disconnects from the remote server.
        /// </summary>
        public void Disconnect()
        {
            if (IsConnected)
            {
                DisconnectClient = true;
            }
        }

        #endregion

        #region Public Method: Execute

        /// <summary>
        /// While connected to a remote server, attempt to execute the passed command.
        /// </summary>
        /// <param name="command">The text command to execute in the remote server's console.</param>
        public void Execute(string command)
        {
            if (IsConnected && ClientAuthenticated)
            {
                SendToServer(SERVERDATA_EXECCOMMAND, command);
            }
        }

        #endregion

        #endregion


        #region ===== Constructor =====

        public SourceRemoteConsole()
        {
            RNG = new Random(DateTime.Now.Millisecond);
        }

        #endregion

    }
}
