namespace CryptocurrencyAnalysisApp.View.CoinsDetail
{
    partial class CoinsDetailView
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
            this.gridControlCoinDetail = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Image = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.Symbol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Algorithm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProofType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ImageUrl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCoinDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlCoinDetail
            // 
            this.gridControlCoinDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlCoinDetail.Location = new System.Drawing.Point(0, 0);
            this.gridControlCoinDetail.MainView = this.gridView1;
            this.gridControlCoinDetail.Name = "gridControlCoinDetail";
            this.gridControlCoinDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageEdit1,
            this.repositoryItemCheckEdit1,
            this.repositoryItemPictureEdit1});
            this.gridControlCoinDetail.Size = new System.Drawing.Size(742, 499);
            this.gridControlCoinDetail.TabIndex = 1;
            this.gridControlCoinDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Image,
            this.Symbol,
            this.FullName,
            this.Algorithm,
            this.ProofType,
            this.ImageUrl});
            this.gridView1.GridControl = this.gridControlCoinDetail;
            this.gridView1.Name = "gridView1";
            this.gridView1.RowHeight = 50;
            this.gridView1.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridView1_CustomUnboundColumnData);
            // 
            // Image
            // 
            this.Image.ColumnEdit = this.repositoryItemPictureEdit1;
            this.Image.FieldName = "Image";
            this.Image.Name = "Image";
            this.Image.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.Image.Visible = true;
            this.Image.VisibleIndex = 0;
            this.Image.Width = 25;
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            this.repositoryItemPictureEdit1.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            // 
            // Symbol
            // 
            this.Symbol.Caption = "Symbol";
            this.Symbol.FieldName = "Name";
            this.Symbol.Name = "Symbol";
            this.Symbol.Visible = true;
            this.Symbol.VisibleIndex = 1;
            this.Symbol.Width = 173;
            // 
            // FullName
            // 
            this.FullName.Caption = "Full Name";
            this.FullName.FieldName = "FullName";
            this.FullName.Name = "FullName";
            this.FullName.Visible = true;
            this.FullName.VisibleIndex = 2;
            this.FullName.Width = 173;
            // 
            // Algorithm
            // 
            this.Algorithm.Caption = "Algorithm";
            this.Algorithm.FieldName = "Algorithm";
            this.Algorithm.Name = "Algorithm";
            this.Algorithm.Visible = true;
            this.Algorithm.VisibleIndex = 3;
            this.Algorithm.Width = 173;
            // 
            // ProofType
            // 
            this.ProofType.Caption = "Proof Type";
            this.ProofType.FieldName = "ProofType";
            this.ProofType.Name = "ProofType";
            this.ProofType.Visible = true;
            this.ProofType.VisibleIndex = 4;
            this.ProofType.Width = 185;
            // 
            // ImageUrl
            // 
            this.ImageUrl.Caption = "ImageUrl";
            this.ImageUrl.FieldName = "ImageUrl";
            this.ImageUrl.Name = "ImageUrl";
            this.ImageUrl.Width = 72;
            // 
            // repositoryItemImageEdit1
            // 
            this.repositoryItemImageEdit1.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.False;
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            this.repositoryItemImageEdit1.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // CoinsDetailView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControlCoinDetail);
            this.Name = "CoinsDetailView";
            this.Size = new System.Drawing.Size(742, 499);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCoinDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlCoinDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Image;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn Symbol;
        private DevExpress.XtraGrid.Columns.GridColumn FullName;
        private DevExpress.XtraGrid.Columns.GridColumn Algorithm;
        private DevExpress.XtraGrid.Columns.GridColumn ProofType;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn ImageUrl;
    }
}
