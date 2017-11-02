using Mushare.Mushages;
using System;
using System.Diagnostics;

namespace Mushare.TCP
{
    public delegate void MushageFromClientReceivedEventHandler(int clientId, Mushage mushage);

    public class MushareServer : Server
    {
        #region Public events

        /// <summary>
        /// Occurs when the server sends a mushage to this client
        /// </summary>
        public event MushageFromServerReceivedEventHandler MushageReceived;
        protected virtual void OnMushageReceived(Mushage mushage) => MushageReceived?.Invoke(mushage);

        protected override void OnRawMessageReceived(int clientId, byte[] bytes)
        {
            var constructorCode = BitConverter.ToInt32(bytes, 0);
            Type mushageType;
            if (Mushage.Constructors.TryGetValue(constructorCode, out mushageType))
            {
                var result = (Mushage)Activator.CreateInstance(mushageType);
                result.Decode(bytes);
                OnMushageReceived(result);
                base.OnRawMessageReceived(clientId, bytes);
            }
            else
            {
                Debug.WriteLine($"[ERROR]: MUSHAGE NOT IMPLEMENTED: {constructorCode}");
            }
        }

        #endregion

        #region Send


        /// <summary>
        /// Sends a message to the desired client given its ID. Returns true if the message was successfully sent
        /// </summary>
        /// <param name="id">The ID of the client who will receive this message</param>
        /// <param name="bytes">The message</param>
        public bool Send(int id, Mushage mushage)
        {
            return Send(id, mushage.Encode());
        }

        /// <summary>
        /// Sends a message to all the connected clients. Returns true if the message was successfully sent to all
        /// </summary>
        /// <param name="bytes">The message</param>
        public bool Broadcast(Mushage mushage) => Broadcast(mushage.Encode());

        #endregion
    }
}
