namespace AbcPos.Web.Settings
{
    public class LabelSettings : DevExpress.Web.Mvc.LabelSettings
    {
        public LabelSettings(string text, string associatedControl)
        {
            ControlStyle.CssClass = "label";
            Text = text;
            AssociatedControlName = associatedControl;
        }
    }
}