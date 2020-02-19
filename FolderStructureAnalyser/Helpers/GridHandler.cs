using System.Drawing;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base.ViewInfo;

namespace FolderStructureAnalyser.Helpers
{
    /// <summary>
    /// Class for handling grid components.
    /// </summary>
    public static class GridHandler
    {
        /// <summary>
        /// Gets the hit info for a certain position.
        /// </summary>
        /// <param name="grid">The grid holding the hit info.</param>
        /// <param name="screenHitLocation">The location, in screen coordinates, to get the hit info for.</param>
        /// <returns>The hit info for the specified position.</returns>
        public static BaseHitInfo GetHitInfo(GridControl grid, Point screenHitLocation)
        {
            var gridHitLocation = grid.PointToClient(screenHitLocation);
            var view = grid.GetViewAt(gridHitLocation);
            return view.CalcHitInfo(gridHitLocation);
        }
    }
}
