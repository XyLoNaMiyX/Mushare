// Made by  Lonami Exo
// Created: 01-05-2016
// Edited:  02-05-2016
//   (C) LonamiWebs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Mushare
{
    public delegate void ClientConnectedEventHandler(int clientId);
    public delegate void ClientDisconnectedEventHandler(int clientId);

    public delegate void RawMessageFromClientReceivedEventHandler(int clientId, byte[] message);

    public class Server
    {
        #region Sub classes

        // class that holds both a client socket and it's ID
        class ClientId
        {
            public Socket Client { get; set; }
            public int ID { get; set; }

            public ClientId(Socket client, int id)
            {
                Client = client;
                ID = id;
            }
        }

        #endregion

        #region Constant values

        const int BACKLOG = 4; // how many clients can try joining at the same time?
        const int BUFFER_SIZE = 1024; // max message length

        #endregion

        #region Private fields

        // the server socket which listens for more clients
        Socket server;

        // the connected clients
        List<ClientId> clients;

        // keep track of the current client id
        int currentCliendId;

        // used to store the received message
        byte[] receiveBuffer;

        // cache our public ip
        string cachedPublicIp;

        #endregion

        #region Public properties

        /// <summary>
        /// Determines whether the server is running or not
        /// </summary>
        public bool Running { get; private set; }

        /// <summary>
        /// Gets a list of the connected client ids
        /// </summary>
        public List<int> ConnectedClients
        {
            get
            {
                var result = new List<int>(clients.Count);
                foreach (var client in clients)
                    result.Add(client.ID);

                return result;
            }
        }

        int _MaxClients = 20;
        /// <summary>
        /// Gets or sets the maximum clients.
        /// If the value set is less than the previous one, 
        /// the last client will be kicked if the maximum amount was connected
        /// </summary>
        public int MaxClients
        {
            get { return _MaxClients; }
            set
            {
                _MaxClients = value;
                while (clients.Count > _MaxClients)
                    clients.RemoveAt(clients.Count - 1);
            }
        }

        int _Port = 10203;
        /// <summary>
        /// Gets or sets the port where the server will bind.
        /// The server must be closed before changing this value
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the value is outside 1 and 65535</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when the server is running</exception>
        public int Port
        {
            get { return _Port; }
            set
            {
                if (_Port == value)
                    return;

                if (value < 1 && value > ushort.MaxValue)
                    throw new ArgumentOutOfRangeException("Port must be between 1 and 65535 (inclusive)");

                if (Running)
                    throw new InvalidOperationException("Cannot change the port while the server is running");

                _Port = value;
            }
        }

        /// <summary>
        /// When set to true, after a client sends a message to the server,
        /// the server will resend the same message to all the other connected clients
        /// </summary>
        public bool ClientToClient { get; set; }

        #endregion

        #region Public events

        /// <summary>
        /// Occurs when a new client connects
        /// </summary>
        public event ClientConnectedEventHandler ClientConnected;
        protected virtual void OnClientConnected(int clientId) => ClientConnected?.Invoke(clientId);

        /// <summary>
        /// Occurs when a client disconnects
        /// </summary>
        public event ClientDisconnectedEventHandler ClientDisconnected;
        protected virtual void OnClientDisconnected(int clientId) => ClientDisconnected?.Invoke(clientId);

        /// <summary>
        /// Occurs when a new client sends a raw message to the server
        /// </summary>
        public event RawMessageFromClientReceivedEventHandler RawMessageReceived;
        protected virtual void OnRawMessageReceived(int clientId, byte[] message)
        {
            RawMessageReceived?.Invoke(clientId, message);
            if (ClientToClient)
                Broadcast(message, clientId);
        }

        #endregion

        #region Start

        /// <summary>
        /// Starts the server. Returns true if the operation was succesful
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown when the server is already running</exception>
        public bool Start()
        {
            if (Running)
                throw new InvalidOperationException("The server is already running");

            try
            {
                // create socked, bind to port
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                server.Bind(new IPEndPoint(IPAddress.Any, Port));
                server.Listen(BACKLOG);

                // start listening for clients
                clients = new List<ClientId>();
                server.BeginAccept(AcceptSocketCallback, server);

                Running = true;
            }
            catch
            {
                server = null;
                Running = false;
            }

            return Running;
        }

        void AcceptSocketCallback(IAsyncResult iar)
        {
            // retrieve server and accept next client
            var server = (Socket)iar.AsyncState;
            server.BeginAccept(AcceptSocketCallback, server);

            // get the new connected client
            var client = server.EndAccept(iar);
            var clientId = new ClientId(client, currentCliendId);

            // start receiving from it
            receiveBuffer = new byte[BUFFER_SIZE];
            client.BeginReceive(receiveBuffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveCallback, clientId);

            // add the client to our list
            clients.Add(clientId);
            OnClientConnected(currentCliendId++);
        }

        #endregion

        #region Stop

        /// <summary>
        /// Stops the server, kicking all the clients first
        /// </summary>
        public void Stop()
        {
            Running = false;

            server.Shutdown(SocketShutdown.Both);
            server.Close();
        }

        #endregion

        #region Receive

        void ReceiveCallback(IAsyncResult iar)
        {
            // retrieve the client
            var client = (ClientId)iar.AsyncState;
            try
            {
                // read the bytes and take only those we read
                var bytesRead = client.Client.EndReceive(iar);
                var result = receiveBuffer.Take(bytesRead).ToArray();

                // empty the buffer and start receiving again
                receiveBuffer = new byte[BUFFER_SIZE];
                client.Client.BeginReceive(receiveBuffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveCallback, client);

                // notify message received
                OnRawMessageReceived(client.ID, result);
            }
            catch (SocketException)
            {
                KickClient(client);
            }
        }

        #endregion

        #region Send

        /// <summary>
        /// Sends a message to the desired client given its ID. Returns true if the message was successfully sent
        /// </summary>
        /// <param name="id">The ID of the client who will receive this message</param>
        /// <param name="bytes">The content of the message</param>
        public bool Send(int id, byte[] bytes)
        {
            return Send(GetClient(id), bytes);
        }

        /// <summary>
        /// Sends a message to all the connected clients. Returns true if the message was successfully sent to all
        /// </summary>
        /// <param name="bytes">The content of the message</param>
        public bool Broadcast(byte[] bytes) => Broadcast(bytes, -1);

        // broadcast a message to everyone except someone
        bool Broadcast(byte[] bytes, int except)
        {
            var disconnectedClients = new List<ClientId>();
            foreach (var client in clients)
                if (client.ID != except)
                    if (!Send(client, bytes)) // if failed to send
                        disconnectedClients.Add(client); // save it to kick him

            // kick all the disconnected clients
            foreach (var disconnectedClient in disconnectedClients)
                KickClient(disconnectedClient);

            // if there's any kicked client, some message failed
            return disconnectedClients.Count > 0;
        }

        // send a message to an specific client, return true if the operation was successful
        bool Send(ClientId client, byte[] bytes)
        {
            try
            {
                client.Client.BeginSend(bytes, 0, Math.Min(bytes.Length, BUFFER_SIZE),
                    SocketFlags.None, SendCallback, client);

                return true;
            }
            catch { return false; }
        }

        void SendCallback(IAsyncResult iar)
        {
            var client = (ClientId)iar.AsyncState;
            client.Client.EndSend(iar);
        }

        #endregion

        #region Kick client

        /// <summary>
        /// Kicks a client from the server
        /// </summary>
        /// <param name="id">The ID of the client to kick</param>
        public void KickClient(int id)
        {
            foreach (var client in clients)
                if (client.ID == id)
                {
                    KickClient(client);
                    break;
                }
        }

        /// <summary>
        /// Kicks all the connected clients
        /// </summary>
        public void KickAll()
        {
            foreach (var client in clients)
                KickClient(client);
            clients.Clear();
        }

        // kick client, shutting it down first
        void KickClient(ClientId clientId)
        {
            try
            {
                clientId.Client.Shutdown(SocketShutdown.Both);
                clientId.Client.Close();
            }
            catch { }

            clients.Remove(clientId);
        }

        #endregion

        #region Get client by ID

        ClientId GetClient(int id)
        {
            foreach (var client in clients)
                if (client.ID == id)
                    return client;

            throw new KeyNotFoundException("There's no client with that ID");
        }

        #endregion

        #region Get public IP

        public string GetPublicIP()
        {
            if (cachedPublicIp == null)
            {
                using (var wc = new WebClient())
                    cachedPublicIp = wc.DownloadString("http://icanhazip.com/");
            }

            return cachedPublicIp;
        }

        #endregion
    }
}
