using System;
using System.ComponentModel;
using System.Windows.Forms;
using FolderStructureAnalyser.Events;

namespace FolderStructureAnalyser.Components.Support
{
    /// <summary>
    /// Class for object used when a control needs to find a parent of a certain type.
    /// </summary>
    /// <typeparam name="T">The type of the parent to find for the control.</typeparam>
    public class ParentFinder<T> where T : Control
    {
        /// <summary>
        /// The control to find the parent for.
        /// </summary>
        public Control Orphan { get; private set; }

        /// <summary>
        /// Event raised when the parent finder has found the requested parent.
        /// </summary>
        [Category("Searching")]
        [Description("Occurs when the parent finder has found the requested parent.")]
        public event ParentFoundHandler ParentFound;

        /// <summary>
        /// Eventhandler for the event used when the parent finder has found the requested parent.
        /// </summary>
        /// <param name="sender">The parent finder who found the requested parent.</param>
        /// <param name="e">The arguments for the event.</param>
        public delegate void ParentFoundHandler(object sender, ParentFoundArgs e);

        /// <summary>
        /// Method raising the event used when the parent finder has found the requested parent.
        /// </summary>
        /// <param name="e">The arguments for the event.</param>
        protected virtual void OnParentFound(ParentFoundArgs e)
        {
            ParentFound?.Invoke(this, e);
        }

        /// <summary>
        /// Creates an object used when a control needs to find a parent of a certain type.
        /// </summary>
        /// <param name="orphan">The control to find the parent for.</param>
        public ParentFinder(Control orphan)
        {
            Orphan = orphan;
            Orphan.ParentChanged += Control_ParentChanged;

            //TODO: What if the parent is already set in the orphan and hence won't fire the ParentChanged-event?!
        }

        private void Control_ParentChanged(object sender, EventArgs e)
        {
            var ctrl = sender as Control;
            var highestParent = tryGetSearchedParent(ctrl);

            if (highestParent != ctrl)
            {
                if (highestParent is T)
                {
                    var args = new ParentFoundArgs(highestParent);
                    OnParentFound(args);
                }
                else
                {
                    highestParent.ParentChanged += Control_ParentChanged;
                }
            }
        }

        /// <summary>
        /// Tries to get the control that is the parent of the requested type.
        /// </summary>
        /// <param name="ctrl">The control to get the requested parent for.</param>
        /// <returns>The requested parent or the highest possible parent.</returns>
        private Control tryGetSearchedParent(Control ctrl)
        {
            if (ctrl is T || ctrl.Parent == null) { return ctrl; }
            return tryGetSearchedParent(ctrl.Parent);
        }
    }
}
