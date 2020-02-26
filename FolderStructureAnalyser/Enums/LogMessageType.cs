using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FolderStructureAnalyser.Enums
{
    /// <summary>
    /// Tells which kind a log message is.
    /// </summary>
    public enum LogMessageType
    {
        /// <summary>
        /// Log message telling that an operation is about to start.
        /// </summary>
        [Display(Name = "Operation starting")]
        [Description("Log message telling that an operation is about to start.")]
        OperationStarting,

        /// <summary>
        /// Log message telling that the runtime of an operation has been updated.
        /// </summary>
        [Display(Name = "Operation runtime update")]
        [Description("Log message telling that the runtime of an operation has been updated.")]
        OperationRuntimeUpdate,

        /// <summary>
        /// Log message telling that an operation has finished.
        /// </summary>
        [Display(Name = "Operation finished")]
        [Description("Log message telling that an operation has finished.")]
        OperationFinished,

        /// <summary>
        /// Log message telling that an application setting has been changed.
        /// </summary>
        [Display(Name = "Setting changed")]
        [Description("Log message telling that an application setting has been changed.")]
        SettingChanged
    }
}
