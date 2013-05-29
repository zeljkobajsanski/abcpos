using System.Web.Mvc;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.Mvc;

namespace AbcPos.Web.Settings
{
    public class PretragaArtikalaButtonEditSettings : ButtonEditSettings
    {
        public PretragaArtikalaButtonEditSettings(UrlHelper urlHelper)
        {
            Name = "tbSifraArtikla";
            //ControlStyle.CssClass = "editor";
            Properties.NullText = "Šifra/Barkod artikla";
            Properties.ClientSideEvents.KeyPress = "app.controls.ucitajArtikalPoSifri";
            var cancelBtn = new EditButton();
            cancelBtn.Image.Url = urlHelper.Content("~/Content/images/cancel_16.png");
            Properties.Buttons.Add(cancelBtn);
            var searchBtn = new EditButton();
            searchBtn.Image.Url = urlHelper.Content("~/Content/images/preview_16.png");
            Properties.Buttons.Add(searchBtn);
            Properties.ClientSideEvents.ButtonClick = "app.controls.prikaziPretraguArtikala";
        }
    }
}