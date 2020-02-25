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
        /// Log message telling that the runtime of an operation was updatedd.
        /// </summary>
        [Display(Name = "Operation runtime update")]
        [Description("Log message telling that the runtime of an operation was updatedd.")]
        OperationRuntimeUpdate,

        /// <summary>
        /// Any other log message.
        /// </summary>
        [Display(Name = "Miscellaneous")]
        [Description("Any other log message.")]
        Miscellaneous
    }
}
