using System.Drawing;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;

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
        public static GridHitInfo GetHitInfo(GridControl grid, Point screenHitLocation)
        {
            var gridHitLocation = grid.PointToClient(screenHitLocation);
            var view = grid.GetViewAt(gridHitLocation) as GridView;
            return view.CalcHitInfo(gridHitLocation);
        }

        /// <summary>
        /// Gets the hit info for a certain position.
        /// </summary>
        /// <param name="tree">The tree holding the hit info.</param>
        /// <param name="screenHitLocation">The location, in screen coordinates, to get the hit info for.</param>
        /// <returns>The hit info for the specified position.</returns>
        public static TreeListHitInfo GetHitInfo(TreeList tree, Point screenHitLocation)
        {
            var treeHitLocation = tree.PointToClient(screenHitLocation);
            return tree.CalcHitInfo(treeHitLocation);
        }

        /// <summary>
        /// Tells if something has hit a certain column.
        /// </summary>
        /// <param name="column">The column that may or may not be hit.</param>
        /// <param name="position">The position of the hit in screen coordinates.</param>
        /// <returns>TRUE if the column is hit, else FALSE.</returns>
        public static bool HasHitColumn(TreeListColumn column, Point position)
        {
            var hitInfo = GetHitInfo(column.TreeList, position);
            return hitInfo.Node != null && hitInfo.Column == column;
        }

        /// <summary>
        /// Tells if something has hit a certain column.
        /// </summary>
        /// <param name="column">The column that may or may not be hit.</param>
        /// <param name="position">The position of the hit in screen coordinates.</param>
        /// <returns>TRUE if the column is hit, else FALSE.</returns>
        public static bool HasHitColumn(GridColumn column, Point position)
        {
            var hitInfo = GetHitInfo(column.View.GridControl, position);
            return hitInfo.Column != null && hitInfo.Column == column;
        }
    }
}
