using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace AbcPos.Web.Settings
{
    public sealed class EditImageSettings : ImageEditSettings
    {
        public EditImageSettings(UrlHelper urlHelper)
        {
            ImageUrl = urlHelper.Content("~/Content/images/edit.png");
            ControlStyle.Cursor = "pointer";
            ToolTip = "Izmeni";
        }

        public EditImageSettings(UrlHelper urlHelper, string name) : this(urlHelper)
        {
            Name = name;
        }
    }
}