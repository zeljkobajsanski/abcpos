using DevExpress.Web.Mvc;

namespace AbcPos.Web.Settings
{
    public class RadnjaComboBoxSettings : ComboBoxSettings
    {
        public RadnjaComboBoxSettings()
        {
            Properties.ClientInstanceName = "cmbRadnje";
            ControlStyle.CssClass = "editor";
            Properties.TextField = "Naziv";
            Properties.ValueType = typeof (int);
            Properties.ValueField = "ID";
            ShowModelErrors = true;
        }

        public RadnjaComboBoxSettings(string name) : this()
        {
            Name = name;
        }
    }
}