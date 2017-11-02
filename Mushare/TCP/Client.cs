// Made by  Lonami Exo
// Created: 01-05-2016
// Edited:  02-05-2016
//   (C) LonamiWebs

using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;

// TODO when done, update .cs
namespace Mushare
{
    public delegate void ConnectionEstabilishedEventHandler();
    public delegate void ConnectionFailedEventHandler();
    public delegate void ConnectionLostEventHandler();

    public delegate void RawMessageFromServerReceivedEventHandler(byte[] bytes);

    public class Client
    {
        #region Constant values

        const int BUFFER_SIZE = 1024; // max message length
        const int DEFAULT_PORT = 10203; // default connection port

        #endregion

        #region Private fields

        // used to store the received message
        byte[] receiveBuffer;

        // the client socket which connects to the server
        Socket client;

        #endregion

        #region Public properties

        /// <summary>
        /// Determines whether the client is connected to a server or not
        /// </summary>
        public bool IsConnected { get; private set; }

        #endregion

        #region Public events

        /// <summary>
        /// Occurs when the client succesfully estabilishes a connection with the server
        /// </summary>
        public event ConnectionEstabilishedEventHandler Connected;
        protected virtual void OnClientConnected() => Connected?.Invoke();

        /// <summary>
        /// Occurs when the connection with the server was lost,
        /// either because the client was kicked by the server or any other reason
        /// </summary>
        public event ConnectionLostEventHandler Disconnected;
        protected virtual void OnClientDisconnected() => Disconnected?.Invoke();

        /// <summary>
        /// Occurs when the server sends a raw message to this client
        /// </summary>
        public event RawMessageFromServerReceivedEventHandler RawMessageReceived;
        protected virtual void OnRawMessageReceived(byte[] bytes) => RawMessageReceived?.Invoke(bytes);

        public event ConnectionFailedEventHandler ConnectionFailed;
        protected virtual void OnClientConnectionFailed() => ConnectionFailed?.Invoke();

        #endregion

        #region Connect

        /// <summary>
        /// Connects to the desired IP with an optional specified port.
        /// Returns true if the connection was estabilished successfully
        /// </summary>
        /// <param name="ip">The IP where the client will connect to</param>
        /// <param name="port">The port used for estabilishing the connection</param>
        /// <exception cref="System.InvalidOperationException">Thrown when the client is already connected</exception>
        public bool Connect(string ip, int port = DEFAULT_PORT)
        {
            CheckDisconnected();

            try
            {
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                client.BeginConnect(new IPEndPoint(IPAddress.Parse(ip), port), ConnetCallback, client);
                return true;
            }
            catch
            {
                client = null;
                IsConnected = false;
                return false;
            }
        }

        void ConnetCallback(IAsyncResult iar)
        {
            try
            {
                // end the async connection
                var client = (Socket)iar.AsyncState;
                client.EndConnect(iar);

                IsConnected = true;

                // start receiving messages from the server
                receiveBuffer = new byte[BUFFER_SIZE];
                client.BeginReceive(receiveBuffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveCallback, client);

                OnClientConnected();
            }
            catch (SocketException) { OnClientConnectionFailed(); }
        }

        #endregion

        #region Disconnect

        /// <summary>
        /// Disconnects the client from the server (if connected)
        /// </summary>
        public void Disconnect()
        {
            if (!IsConnected)
                return;

            IsConnected = false;

            client.Disconnect(false);
            client.Close();
            client.Dispose();
            client = null;

            OnClientDisconnected();
        }

        #endregion

        #region Receive

        void ReceiveCallback(IAsyncResult iar)
        {
            // retrieve the client
            var client = (Socket)iar.AsyncState;
            try
            {
                // read the bytes and take only those we read
                var bytesRead = client.EndReceive(iar);
                var result = receiveBuffer.Take(bytesRead).ToArray();

                // empty the buffer and start receiving again
                receiveBuffer = new byte[BUFFER_SIZE];
                client.BeginReceive(receiveBuffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveCallback, client);

                OnRawMessageReceived(result);
            }
            catch (SocketException)
            {
                Disconnect();
            }
        }

        #endregion

        #region Send

        /// <summary>
        /// Sends a message to the server
        /// </summary>
        /// <param name="bytes">The content of the message</param>
        /// <exception cref="System.InvalidOperationException">Thrown when the client is not connected</exception>
        public bool Send(byte[] bytes)
        {
            CheckConnected();

            try
            {
                client.BeginSend(bytes, 0, Math.Min(bytes.Length, BUFFER_SIZE), SocketFlags.None, SendCallback, client);
                return true;
            }
            catch { return false; }
        }

        void SendCallback(IAsyncResult iar)
        {
            var client = (Socket)iar.AsyncState;
            client.EndSend(iar);
        }

        #endregion

        #region Errors

        // make sure we're disconnected
        void CheckDisconnected()
        {
            if (IsConnected)
                throw new InvalidOperationException("The client is already connected");
        }

        // make sure we're connected
        void CheckConnected()
        {
            if (!IsConnected)
                throw new InvalidOperationException("The client isn't connected!");
        }

        #endregion
    }
}
