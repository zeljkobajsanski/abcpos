using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace AbcPos.Web.Settings
{
    public static class GridSettings
    {
        public static void EditButtton(GridViewSettings settings, UrlHelper urlHelper)
        {
            settings.CommandColumn.EditButton.Visible = true;
            settings.CommandColumn.EditButton.Image.Url = urlHelper.Content("~/Content/images/edit.png");
            settings.CommandColumn.EditButton.Image.ToolTip = "Izmeni";
        }

        public static void UpdateButton(GridViewSettings settings, UrlHelper urlHelper)
        {
            settings.CommandColumn.UpdateButton.Visible = true;
            settings.CommandColumn.UpdateButton.Image.Url = urlHelper.Content("~/Content/images/ok_32.png");
            settings.CommandColumn.UpdateButton.Image.ToolTip = "Potvrdi";
        }

        public static void CancelButton(GridViewSettings settings, UrlHelper urlHelper)
        {
            settings.CommandColumn.CancelButton.Visible = true;
            settings.CommandColumn.CancelButton.Image.Url = urlHelper.Content("~/Content/images/cancel_32.png");
            settings.CommandColumn.CancelButton.Image.ToolTip = "Otkaži";
        }
    }
}