namespace AbcPos.BackOffice.Win
{
    partial class Main
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraEditors.TileItemElement tileItemElement3 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement1 = new DevExpress.XtraEditors.TileItemElement();
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager();
            this.windowsUIView1 = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.WindowsUIView();
            this.tileContainer1 = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.TileContainer();
            this.ArtikliTile = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Tile();
            this.document1 = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document();
            this.ZaliheTile = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Tile();
            this.document2 = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            this.alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.windowsUIView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArtikliTile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZaliheTile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document2)).BeginInit();
            this.SuspendLayout();
            // 
            // documentManager1
            // 
            this.documentManager1.MdiParent = this;
            this.documentManager1.View = this.windowsUIView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.windowsUIView1});
            // 
            // windowsUIView1
            // 
            this.windowsUIView1.Appearance.BackColor = System.Drawing.Color.White;
            this.windowsUIView1.Appearance.Options.UseBackColor = true;
            this.windowsUIView1.Caption = "ABC Back Office";
            this.windowsUIView1.ContentContainers.AddRange(new DevExpress.XtraBars.Docking2010.Views.WindowsUI.IContentContainer[] {
            this.tileContainer1});
            this.windowsUIView1.Documents.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseDocument[] {
            this.document1,
            this.document2});
            this.windowsUIView1.Tiles.AddRange(new DevExpress.XtraBars.Docking2010.Views.WindowsUI.BaseTile[] {
            this.ArtikliTile,
            this.ZaliheTile});
            this.windowsUIView1.QueryControl += new DevExpress.XtraBars.Docking2010.Views.QueryControlEventHandler(this.windowsUIView1_QueryControl);
            // 
            // tileContainer1
            // 
            this.tileContainer1.Items.AddRange(new DevExpress.XtraBars.Docking2010.Views.WindowsUI.BaseTile[] {
            this.ArtikliTile,
            this.ZaliheTile});
            this.tileContainer1.Name = "tileContainer1";
            // 
            // ArtikliTile
            // 
            this.ArtikliTile.Appearances.Normal.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ArtikliTile.Appearances.Normal.Options.UseBackColor = true;
            this.ArtikliTile.Document = this.document1;
            tileItemElement3.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            tileItemElement3.Appearance.Normal.Options.UseFont = true;
            tileItemElement3.Text = "Artikli";
            this.ArtikliTile.Elements.Add(tileItemElement3);
            this.tileContainer1.SetID(this.ArtikliTile, 1);
            this.ArtikliTile.Name = "ArtikliTile";
            // 
            // document1
            // 
            this.document1.Caption = "Artikli";
            this.document1.ControlName = "Artikli";
            this.document1.ControlTypeName = "AbcPos.BackOffice.Win.Views.Artikli";
            // 
            // ZaliheTile
            // 
            this.ZaliheTile.Document = this.document2;
            tileItemElement1.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            tileItemElement1.Appearance.Normal.Options.UseFont = true;
            tileItemElement1.Text = "Zalihe";
            this.ZaliheTile.Elements.Add(tileItemElement1);
            this.tileContainer1.SetID(this.ZaliheTile, 2);
            this.ZaliheTile.Name = "ZaliheTile";
            // 
            // document2
            // 
            this.document2.Caption = "Zalihe";
            this.document2.ControlName = "Zalihe";
            this.document2.ControlTypeName = "AbcPos.BackOffice.Win.Views.Zalihe";
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Metropolis";
            // 
            // alertControl1
            // 
            this.alertControl1.FormLocation = DevExpress.XtraBars.Alerter.AlertFormLocation.TopRight;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 548);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "Main";
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.windowsUIView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileContainer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArtikliTile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZaliheTile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.WindowsUIView windowsUIView1;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.TileContainer tileContainer1;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Tile ArtikliTile;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document document1;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Tile ZaliheTile;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document document2;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl1;
    }
}