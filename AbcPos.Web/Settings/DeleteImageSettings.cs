using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace AbcPos.Web.Settings
{
    public sealed class DeleteImageSettings : ImageEditSettings
    {
        public DeleteImageSettings(UrlHelper urlHelper)
        {
            ImageUrl = urlHelper.Content("~/Content/images/cancel_16.png");
            ControlStyle.Cursor = "pointer";
            ToolTip = "Obriši";
        }

        public DeleteImageSettings(UrlHelper urlHelper, string name) : this(urlHelper)
        {
            Name = name;
        }
    }
}