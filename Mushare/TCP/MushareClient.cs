using Mushare.Mushages;
using System;
using System.Diagnostics;

namespace Mushare.TCP
{
    public delegate void MushageFromServerReceivedEventHandler(Mushage mushage);

    public class MushareClient : Client
    {
        #region Public events

        /// <summary>
        /// Occurs when the server sends a mushage to this client
        /// </summary>
        public event MushageFromServerReceivedEventHandler MushageReceived;
        protected virtual void OnMushageReceived(Mushage mushage) => MushageReceived?.Invoke(mushage);

        protected override void OnRawMessageReceived(byte[] bytes)
        {
            var constructorCode = BitConverter.ToInt32(bytes, 0);
            Type mushageType;
            if (Mushage.Constructors.TryGetValue(constructorCode, out mushageType))
            {
                var result = (Mushage)Activator.CreateInstance(mushageType);
                result.Decode(bytes);
                OnMushageReceived(result);
            }
            else
            {
                Debug.WriteLine($"[ERROR]: MUSHAGE NOT IMPLEMENTED: {constructorCode}");
            }
        }

        #endregion

        #region Send

        /// <summary>
        /// Sends a message to the server
        /// </summary>
        /// <param name="bytes">The content of the message</param>
        /// <exception cref="System.InvalidOperationException">Thrown when the client is not connected</exception>
        public void Send(Mushage mushage)
        {
            Send(mushage.Encode());
        }

        #endregion
    }
}
