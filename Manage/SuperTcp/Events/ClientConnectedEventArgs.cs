using System;

namespace SuperTcp.Events
{
    /// <summary>
    /// Arguments to raise with a ClientConnected event.
    /// </summary>
    public class ClientConnectedEventArgs : EventArgs
    {
        /// <summary>
        /// The client that connected.
        /// </summary>
        public System.Net.Sockets.TcpClient Client { get; set; }
    }
}
