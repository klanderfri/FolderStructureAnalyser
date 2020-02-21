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
        /// Log message telling how long time an operation took.
        /// </summary>
        [Display(Name = "Operation time")]
        [Description("Log message telling how long time an operation took.")]
        OperationTime,

        /// <summary>
        /// Any other log message.
        /// </summary>
        [Display(Name = "Miscellaneous")]
        [Description("Any other log message.")]
        Miscellaneous
    }
}
