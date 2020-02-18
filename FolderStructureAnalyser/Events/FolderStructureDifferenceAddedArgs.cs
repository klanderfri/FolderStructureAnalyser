using System;
using FolderStructureAnalyser.DataObjects;

namespace FolderStructureAnalyser.Events
{
    /// <summary>
    /// Class for object holding the arguments for the event used when a control has found a difference between two folder structures.
    /// </summary>
    public class FolderStructureDifferenceAddedArgs : EventArgs
    {
        /// <summary>
        /// The difference that was added.
        /// </summary>
        public StructureDifference Difference { get; private set; }

        /// <summary>
        /// Creates an object holding the arguments for the event used when a control has found a difference between two folder structures.
        /// </summary>
        /// <param name="difference">The difference that was added.</param>
        public FolderStructureDifferenceAddedArgs(StructureDifference difference)
        {
            Difference = difference;
        }
    }
}
