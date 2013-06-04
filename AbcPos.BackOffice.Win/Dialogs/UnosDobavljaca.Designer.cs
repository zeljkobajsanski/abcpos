namespace AbcPos.BackOffice.Win.Dialogs
{
    partial class UnosDobavljaca
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
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.SifraTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.dobavljacBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.NazivTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForSifra = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForNaziv = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SifraTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dobavljacBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NazivTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSifra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNaziv)).BeginInit();
            this.SuspendLayout();
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.DataSource = this.dobavljacBindingSource;
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.SifraTextEdit);
            this.dataLayoutControl1.Controls.Add(this.NazivTextEdit);
            this.dataLayoutControl1.DataSource = this.dobavljacBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(261, 131);
            this.dataLayoutControl1.TabIndex = 1;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // SifraTextEdit
            // 
            this.SifraTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.dobavljacBindingSource, "Sifra", true));
            this.SifraTextEdit.Location = new System.Drawing.Point(41, 12);
            this.SifraTextEdit.Name = "SifraTextEdit";
            this.SifraTextEdit.Size = new System.Drawing.Size(208, 20);
            this.SifraTextEdit.StyleController = this.dataLayoutControl1;
            this.SifraTextEdit.TabIndex = 4;
            // 
            // dobavljacBindingSource
            // 
            this.dobavljacBindingSource.DataSource = typeof(AbcPos.BackOffice.Win.Models.Entities.Dobavljac);
            // 
            // NazivTextEdit
            // 
            this.NazivTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.dobavljacBindingSource, "Naziv", true));
            this.NazivTextEdit.Location = new System.Drawing.Point(41, 36);
            this.NazivTextEdit.Name = "NazivTextEdit";
            this.NazivTextEdit.Size = new System.Drawing.Size(208, 20);
            this.NazivTextEdit.StyleController = this.dataLayoutControl1;
            this.NazivTextEdit.TabIndex = 5;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(261, 131);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
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
            this.layoutControlGroup2.Size = new System.Drawing.Size(241, 111);
            this.layoutControlGroup2.Text = "autoGeneratedGroup0";
            // 
            // ItemForSifra
            // 
            this.ItemForSifra.Control = this.SifraTextEdit;
            this.ItemForSifra.CustomizationFormText = "Sifra";
            this.ItemForSifra.Location = new System.Drawing.Point(0, 0);
            this.ItemForSifra.Name = "ItemForSifra";
            this.ItemForSifra.Size = new System.Drawing.Size(241, 24);
            this.ItemForSifra.Text = "Šifra";
            this.ItemForSifra.TextSize = new System.Drawing.Size(26, 13);
            // 
            // ItemForNaziv
            // 
            this.ItemForNaziv.Control = this.NazivTextEdit;
            this.ItemForNaziv.CustomizationFormText = "Naziv";
            this.ItemForNaziv.Location = new System.Drawing.Point(0, 24);
            this.ItemForNaziv.Name = "ItemForNaziv";
            this.ItemForNaziv.Size = new System.Drawing.Size(241, 87);
            this.ItemForNaziv.Text = "Naziv";
            this.ItemForNaziv.TextSize = new System.Drawing.Size(26, 13);
            // 
            // UnosDobavljaca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 176);
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "UnosDobavljaca";
            this.Text = "Unos dobavljača";
            this.Controls.SetChildIndex(this.dataLayoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SifraTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dobavljacBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NazivTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSifra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNaziv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraEditors.TextEdit SifraTextEdit;
        private System.Windows.Forms.BindingSource dobavljacBindingSource;
        private DevExpress.XtraEditors.TextEdit NazivTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForSifra;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNaziv;
    }
}