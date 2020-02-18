using System;

namespace FolderStructureAnalyser.Events
{
    /// <summary>
    /// Class for object holding the arguments for the event used when an operation with indeterminable length has progressed.
    /// </summary>
    public class TimedProgressChangedEventArgs : EventArgs
    {
        /// <summary>
        /// The amount of milliseconds that has passed since the operation started.
        /// </summary>
        public long ElapsedMilliseconds { get; private set; }

        /// <summary>
        /// Creates an object holding the arguments for the event used when an operation with indeterminable length has progressed.
        /// </summary>
        /// <param name="elapsedMilliseconds">The amoung of milliseconds that has passed since the operation started.</param>
        public TimedProgressChangedEventArgs(long elapsedMilliseconds)
        {
            ElapsedMilliseconds = elapsedMilliseconds;
        }
    }
}
