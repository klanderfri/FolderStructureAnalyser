namespace FolderStructureAnalyser.Components.UserPanels
{
    partial class OperationMessageLogCtrl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridControlLogMessages = new DevExpress.XtraGrid.GridControl();
            this.gridViewLogMessages = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnTimestamp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMessage = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLogMessages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLogMessages)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlLogMessages
            // 
            this.gridControlLogMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlLogMessages.Location = new System.Drawing.Point(0, 0);
            this.gridControlLogMessages.MainView = this.gridViewLogMessages;
            this.gridControlLogMessages.Name = "gridControlLogMessages";
            this.gridControlLogMessages.Size = new System.Drawing.Size(922, 305);
            this.gridControlLogMessages.TabIndex = 1;
            this.gridControlLogMessages.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewLogMessages});
            // 
            // gridViewLogMessages
            // 
            this.gridViewLogMessages.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnTimestamp,
            this.gridColumnType,
            this.gridColumnMessage});
            this.gridViewLogMessages.GridControl = this.gridControlLogMessages;
            this.gridViewLogMessages.Name = "gridViewLogMessages";
            this.gridViewLogMessages.OptionsView.ColumnAutoWidth = false;
            // 
            // gridColumnTimestamp
            // 
            this.gridColumnTimestamp.Caption = "Timestamp";
            this.gridColumnTimestamp.FieldName = "Timestamp";
            this.gridColumnTimestamp.Name = "gridColumnTimestamp";
            this.gridColumnTimestamp.OptionsColumn.AllowEdit = false;
            this.gridColumnTimestamp.Visible = true;
            this.gridColumnTimestamp.VisibleIndex = 0;
            this.gridColumnTimestamp.Width = 140;
            // 
            // gridColumnType
            // 
            this.gridColumnType.Caption = "Type";
            this.gridColumnType.FieldName = "Type";
            this.gridColumnType.Name = "gridColumnType";
            this.gridColumnType.OptionsColumn.AllowEdit = false;
            this.gridColumnType.Visible = true;
            this.gridColumnType.VisibleIndex = 1;
            this.gridColumnType.Width = 90;
            // 
            // gridColumnMessage
            // 
            this.gridColumnMessage.Caption = "Message";
            this.gridColumnMessage.FieldName = "Message";
            this.gridColumnMessage.Name = "gridColumnMessage";
            this.gridColumnMessage.OptionsColumn.AllowEdit = false;
            this.gridColumnMessage.Visible = true;
            this.gridColumnMessage.VisibleIndex = 2;
            this.gridColumnMessage.Width = 500;
            // 
            // OperationMessageLogCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControlLogMessages);
            this.Name = "OperationMessageLogCtrl";
            this.Size = new System.Drawing.Size(922, 305);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLogMessages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLogMessages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControlLogMessages;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewLogMessages;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTimestamp;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnType;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnMessage;
    }
}
