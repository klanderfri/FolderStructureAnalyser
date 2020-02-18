using System;

namespace FolderStructureAnalyser.Events
{
    /// <summary>
    /// Provides data for an event keeping track of the progress of an operation with indeterminable length.
    /// </summary>
    public class TimedProgressChangedEventArgs : EventArgs
    {
        /// <summary>
        /// The amoung of milliseconds that has passed since the operation started.
        /// </summary>
        public long ElapsedMilliseconds { get; private set; }

        /// <summary>
        /// Creates an container holding the data for an event keeping track of the progress of an operation with indeterminable length.
        /// </summary>
        /// <param name="elapsedMilliseconds">The amoung of milliseconds that has passed since the operation started.</param>
        public TimedProgressChangedEventArgs(long elapsedMilliseconds)
        {
            ElapsedMilliseconds = elapsedMilliseconds;
        }
    }
}
