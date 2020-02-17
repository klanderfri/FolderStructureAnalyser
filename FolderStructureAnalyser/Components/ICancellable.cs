namespace FolderStructureAnalyser.Components
{
    public interface ICancellable
    {
        /// <summary>
        /// Gets a value indicating whether the application has requested cancellation of a background operation.
        /// </summary>
        bool CancellationPending { get; }

        /// <summary>
        /// Requests cancellation of a pending background operation.
        /// </summary>
        void CancelAsync();
    }
}