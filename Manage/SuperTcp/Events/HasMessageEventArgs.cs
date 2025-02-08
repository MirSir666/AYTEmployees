using System;

namespace SuperTcp.Events
{
    /// <summary>
    /// Arguments to raise with a HasMessage event.
    /// </summary>
    public class HasMessageEventArgs : EventArgs
    {
        /// <summary>
        /// The message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The time at which the message was sent.
        /// </summary>
        public DateTime TimeStamp { get; set; }
    }
}
