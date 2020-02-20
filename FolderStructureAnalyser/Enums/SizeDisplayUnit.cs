using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FolderStructureAnalyser.Enums
{
    /// <summary>
    /// Tells which unit a size should be displayed as.
    /// </summary>
    public enum SizeDisplayUnit
    {
        /// <summary>
        /// Dynamically selected based on the actual size.
        /// </summary>
        [Display(Name = "Dynamic")]
        [Description("Dynamically selected based on the actual size.")]
        Dynamic,

        /// <summary>
        /// Displayed as MB, regardless of size.
        /// </summary>
        [Display(Name = "MB only")]
        [Description("Displayed as MB, regardless of size.")]
        OnlyMB,

        /// <summary>
        /// Displayed as bytes, regardless of size.
        /// </summary>
        [Display(Name = "Bytes only")]
        [Description("Displayed as bytes, regardless of size.")]
        OnlyBytes
    }
}
