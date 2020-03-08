using System;
using System.Windows.Forms;
using FolderStructureAnalyser.Components.Support;
using FolderStructureAnalyser.Events;

namespace FolderStructureAnalyser.Helpers
{
    /// <summary>
    /// Class for handling user controls
    /// </summary>
    public static class UserControlHandler
    {
        /// <summary>
        /// Finds a specific parent of a control.
        /// </summary>
        /// <typeparam name="TSearchedParent">The type of the parent to search for.</typeparam>
        /// <param name="orphan">The control to find the parent for.</param>
        /// <param name="runWhenParentIsFound">Method to be run when the parent is found.</param>
        public static void FindParent<TSearchedParent>(Control orphan, Action<object, ParentFoundArgs> runWhenParentIsFound) where TSearchedParent : Control
        {
            var parentFinder = new ParentFinder<TSearchedParent>();
            parentFinder.ParentFound += ParentFinder_ParentFound;
            parentFinder.SearchForParent(orphan);

            void ParentFinder_ParentFound(object sender, ParentFoundArgs e)
            {
                runWhenParentIsFound(sender, e);
            }
        }
    }
}
