﻿using System;

namespace SuperTcp.Events
{
    /// <summary>
    /// Arguments to raise with a ClientDisconnected event.
    /// </summary>
    public class ClientDisconnectedEventArgs : EventArgs
    {
        /// <summary>
        /// The client that disconnected.
        /// </summary>
        public System.Net.Sockets.TcpClient Client { get; set; }
    }
}
