using System;
using System.Windows.Forms;

namespace FolderStructureAnalyser.Events
{
    /// <summary>
    /// Class for object holding the arguments for the event used when a parent finder has found the requested parent.
    /// </summary>
    public class ParentFoundArgs : EventArgs
    {
        /// <summary>
        /// The control parent of the requested type that the finder found.
        /// </summary>
        public Control ParentFound { get; private set; }

        /// <summary>
        /// Creates an object holding the arguments for the event used when a parent finder has found the requested parent.
        /// </summary>
        /// <param name="parentFound">The control parent of the requested type that the finder found.</param>
        public ParentFoundArgs(Control parentFound)
        {
            ParentFound = parentFound;
        }
    }
}
