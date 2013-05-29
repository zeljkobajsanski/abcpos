namespace AbcPos.Kasa.Forms
{
    partial class Shell
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraEditors.TileItemElement tileItemElement1 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement2 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement3 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement4 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement5 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement6 = new DevExpress.XtraEditors.TileItemElement();
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.windowsUIView1 = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.WindowsUIView(this.components);
            this.tileContainer1 = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.TileContainer(this.components);
            this.SinhronizacijaTile = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Tile(this.components);
            this.document1 = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document(this.components);
            this.PregledProdajeTile = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Tile(this.components);
            this.document4 = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document(this.components);
            this.KasaTile = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Tile(this.components);
            this.document2 = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document(this.components);
            this.document5 = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document(this.components);
            this.PodesavanjaTile = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Tile(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.windowsUIView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SinhronizacijaTile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PregledProdajeTile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KasaTile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PodesavanjaTile)).BeginInit();
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
            this.windowsUIView1.ContentContainers.AddRange(new DevExpress.XtraBars.Docking2010.Views.WindowsUI.IContentContainer[] {
            this.tileContainer1});
            this.windowsUIView1.Documents.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseDocument[] {
            this.document1,
            this.document2,
            this.document4,
            this.document5});
            this.windowsUIView1.LoadingIndicatorProperties.Caption = "Inicijalizacija";
            this.windowsUIView1.Tiles.AddRange(new DevExpress.XtraBars.Docking2010.Views.WindowsUI.BaseTile[] {
            this.SinhronizacijaTile,
            this.KasaTile,
            this.PregledProdajeTile,
            this.PodesavanjaTile});
            this.windowsUIView1.DocumentDeactivated += new DevExpress.XtraBars.Docking2010.Views.DocumentEventHandler(this.DocumentDeactivated);
            this.windowsUIView1.QueryControl += new DevExpress.XtraBars.Docking2010.Views.QueryControlEventHandler(this.LoadControl);
            // 
            // tileContainer1
            // 
            this.tileContainer1.Caption = "ABC Pos";
            this.tileContainer1.Items.AddRange(new DevExpress.XtraBars.Docking2010.Views.WindowsUI.BaseTile[] {
            this.SinhronizacijaTile,
            this.PregledProdajeTile,
            this.KasaTile,
            this.PodesavanjaTile});
            this.tileContainer1.Name = "tileContainer1";
            // 
            // SinhronizacijaTile
            // 
            this.SinhronizacijaTile.Document = this.document1;
            tileItemElement1.Image = global::AbcPos.Kasa.Properties.Resources.database_refresh;
            tileItemElement1.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            tileItemElement1.Text = "SINHRONIZACIJA";
            tileItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopCenter;
            tileItemElement2.Text = "Nije urađena";
            tileItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
            this.SinhronizacijaTile.Elements.Add(tileItemElement1);
            this.SinhronizacijaTile.Elements.Add(tileItemElement2);
            this.SinhronizacijaTile.Name = "SinhronizacijaTile";
            this.SinhronizacijaTile.Properties.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True;
            this.SinhronizacijaTile.Properties.IsLarge = DevExpress.Utils.DefaultBoolean.False;
            // 
            // document1
            // 
            this.document1.Caption = "Sinhronizacija";
            this.document1.ControlName = "Sinhronizacija";
            this.document1.ControlTypeName = "AbcPos.Kasa.Forms.Sinhronizacija";
            // 
            // PregledProdajeTile
            // 
            this.PregledProdajeTile.Document = this.document4;
            tileItemElement3.Image = global::AbcPos.Kasa.Properties.Resources.pie_chart;
            tileItemElement3.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomRight;
            tileItemElement3.Text = "PREGLED PRODAJE";
            tileItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopCenter;
            this.PregledProdajeTile.Elements.Add(tileItemElement3);
            this.tileContainer1.SetID(this.PregledProdajeTile, 3);
            this.PregledProdajeTile.Name = "PregledProdajeTile";
            this.PregledProdajeTile.Properties.IsLarge = DevExpress.Utils.DefaultBoolean.False;
            // 
            // document4
            // 
            this.document4.Caption = "Pregled prodaje";
            this.document4.ControlName = "PregledProdaje";
            this.document4.ControlTypeName = "AbcPos.Kasa.Forms.PregledProdaje";
            // 
            // KasaTile
            // 
            this.KasaTile.Document = this.document2;
            tileItemElement4.Image = global::AbcPos.Kasa.Properties.Resources.cash_register;
            tileItemElement4.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomRight;
            tileItemElement4.Text = "KASA";
            tileItemElement4.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopCenter;
            tileItemElement5.Text = "Nema računa";
            tileItemElement5.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual;
            tileItemElement5.TextLocation = new System.Drawing.Point(0, 16);
            this.KasaTile.Elements.Add(tileItemElement4);
            this.KasaTile.Elements.Add(tileItemElement5);
            this.KasaTile.Group = "";
            this.tileContainer1.SetID(this.KasaTile, 1);
            this.KasaTile.Name = "KasaTile";
            this.KasaTile.Properties.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True;
            // 
            // document2
            // 
            this.document2.Caption = "Kasa";
            this.document2.ControlName = "Kasa";
            this.document2.ControlTypeName = "AbcPos.Kasa.Forms.Kasa";
            // 
            // document5
            // 
            this.document5.Caption = "Podešavanja";
            this.document5.ControlName = "Podesavanja";
            this.document5.ControlTypeName = "AbcPos.Kasa.Forms.Podesavanja";
            // 
            // PodesavanjaTile
            // 
            this.PodesavanjaTile.Document = this.document5;
            tileItemElement6.Image = global::AbcPos.Kasa.Properties.Resources.config_tools;
            tileItemElement6.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            tileItemElement6.Text = "PODEŠAVANJA";
            tileItemElement6.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopCenter;
            this.PodesavanjaTile.Elements.Add(tileItemElement6);
            this.PodesavanjaTile.Group = "2";
            this.tileContainer1.SetID(this.PodesavanjaTile, 4);
            this.PodesavanjaTile.Name = "PodesavanjaTile";
            this.PodesavanjaTile.Properties.IsLarge = DevExpress.Utils.DefaultBoolean.False;
            // 
            // Shell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "Shell";
            this.Text = "ABC Pos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.windowsUIView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileContainer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SinhronizacijaTile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PregledProdajeTile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KasaTile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PodesavanjaTile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.WindowsUIView windowsUIView1;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document document1;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document document2;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document document4;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.TileContainer tileContainer1;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Tile SinhronizacijaTile;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Tile PregledProdajeTile;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Tile KasaTile;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Tile PodesavanjaTile;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document document5;
    }
}