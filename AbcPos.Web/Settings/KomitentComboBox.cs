using DevExpress.Web.Mvc;

namespace AbcPos.Web.Settings
{
    public class KomitentComboBox : ComboBoxSettings
    {
        public KomitentComboBox()
        {
            this.Properties.TextField = "Naziv";
            this.Properties.ValueType = typeof(int);
            this.Properties.ValueField = "ID";
            this.ControlStyle.CssClass = "editor";
            this.ShowModelErrors = true;
        }

        public KomitentComboBox(string name) : this()
        {
            Name = name;
        }
    }
}