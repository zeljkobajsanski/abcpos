namespace AbcPos.BackOffice.Win.Views
{
    partial class Dobavljaci
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.SifraTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.dobavljacBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.NazivTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForSifra = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForNaziv = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSifra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNaziv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SifraTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dobavljacBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NazivTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSifra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNaziv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.dataLayoutControl1);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(592, 33, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1008, 729);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.SifraTextEdit);
            this.dataLayoutControl1.Controls.Add(this.NazivTextEdit);
            this.dataLayoutControl1.DataSource = this.dobavljacBindingSource1;
            this.dataLayoutControl1.Location = new System.Drawing.Point(405, 12);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(591, 705);
            this.dataLayoutControl1.TabIndex = 5;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // SifraTextEdit
            // 
            this.SifraTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.dobavljacBindingSource1, "Sifra", true));
            this.SifraTextEdit.EnterMoveNextControl = true;
            this.SifraTextEdit.Location = new System.Drawing.Point(41, 12);
            this.SifraTextEdit.Name = "SifraTextEdit";
            this.SifraTextEdit.Size = new System.Drawing.Size(257, 20);
            this.SifraTextEdit.StyleController = this.dataLayoutControl1;
            this.SifraTextEdit.TabIndex = 4;
            // 
            // dobavljacBindingSource1
            // 
            this.dobavljacBindingSource1.DataSource = typeof(AbcPos.BackOffice.Win.Models.Entities.Dobavljac);
            // 
            // NazivTextEdit
            // 
            this.NazivTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.dobavljacBindingSource1, "Naziv", true));
            this.NazivTextEdit.EnterMoveNextControl = true;
            this.NazivTextEdit.Location = new System.Drawing.Point(41, 36);
            this.NazivTextEdit.Name = "NazivTextEdit";
            this.NazivTextEdit.Size = new System.Drawing.Size(257, 20);
            this.NazivTextEdit.StyleController = this.dataLayoutControl1;
            this.NazivTextEdit.TabIndex = 5;
            // 
            // Root
            // 
            this.Root.CustomizationFormText = "Root";
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.emptySpaceItem1,
            this.emptySpaceItem2});
            this.Root.Location = new System.Drawing.Point(0, 0);
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(591, 705);
            this.Root.Text = "Root";
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.CustomizationFormText = "autoGeneratedGroup0";
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForSifra,
            this.ItemForNaziv});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(290, 48);
            this.layoutControlGroup2.Text = "autoGeneratedGroup0";
            // 
            // ItemForSifra
            // 
            this.ItemForSifra.Control = this.SifraTextEdit;
            this.ItemForSifra.CustomizationFormText = "Šifra";
            this.ItemForSifra.Location = new System.Drawing.Point(0, 0);
            this.ItemForSifra.MaxSize = new System.Drawing.Size(290, 24);
            this.ItemForSifra.MinSize = new System.Drawing.Size(290, 24);
            this.ItemForSifra.Name = "ItemForSifra";
            this.ItemForSifra.Size = new System.Drawing.Size(290, 24);
            this.ItemForSifra.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.ItemForSifra.Text = "Šifra";
            this.ItemForSifra.TextSize = new System.Drawing.Size(26, 13);
            // 
            // ItemForNaziv
            // 
            this.ItemForNaziv.Control = this.NazivTextEdit;
            this.ItemForNaziv.CustomizationFormText = "Naziv";
            this.ItemForNaziv.Location = new System.Drawing.Point(0, 24);
            this.ItemForNaziv.Name = "ItemForNaziv";
            this.ItemForNaziv.Size = new System.Drawing.Size(290, 24);
            this.ItemForNaziv.Text = "Naziv";
            this.ItemForNaziv.TextSize = new System.Drawing.Size(26, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 48);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(290, 637);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(290, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(281, 685);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.dobavljacBindingSource1;
            this.gridControl1.Location = new System.Drawing.Point(12, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(389, 705);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSifra,
            this.colNaziv,
            this.colId});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colSifra
            // 
            this.colSifra.Caption = "Šifra";
            this.colSifra.FieldName = "Sifra";
            this.colSifra.Name = "colSifra";
            this.colSifra.OptionsColumn.FixedWidth = true;
            this.colSifra.Visible = true;
            this.colSifra.VisibleIndex = 0;
            this.colSifra.Width = 96;
            // 
            // colNaziv
            // 
            this.colNaziv.FieldName = "Naziv";
            this.colNaziv.Name = "colNaziv";
            this.colNaziv.Visible = true;
            this.colNaziv.VisibleIndex = 1;
            this.colNaziv.Width = 859;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1008, 729);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(393, 709);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dataLayoutControl1;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(393, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(595, 709);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            this.dxErrorProvider1.DataSource = this.dobavljacBindingSource1;
            // 
            // Dobavljaci
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.layoutControl1);
            this.Name = "Dobavljaci";
            this.Text = "Dobavljaci";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SifraTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dobavljacBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NazivTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSifra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNaziv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.BindingSource dobavljacBindingSource1;
        private DevExpress.XtraGrid.Columns.GridColumn colSifra;
        private DevExpress.XtraGrid.Columns.GridColumn colNaziv;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraEditors.TextEdit SifraTextEdit;
        private DevExpress.XtraEditors.TextEdit NazivTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForSifra;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNaziv;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}