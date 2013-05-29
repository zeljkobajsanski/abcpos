using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.UI.WebControls;
using AbcPos.Web.ViewModels;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.Mvc;

namespace AbcPos.Web.Settings
{
    public sealed class PretragaArtikalaPopupSettings : PopupControlSettings
    {
        public PretragaArtikalaPopupSettings(HtmlHelper html)
        {
            Name = "pretragaArtikalaDialog";
            PopupVerticalAlign = DevExpress.Web.ASPxClasses.PopupVerticalAlign.Below;
            PopupHorizontalAlign = DevExpress.Web.ASPxClasses.PopupHorizontalAlign.LeftSides;
            SetContent(() => html.RenderPartial("PretragaArtikala/_PretragaArtikala", new PretragaArtikalaViewModel()));
            HeaderText = "Pretraga artikala";
            Width = Unit.Pixel(448);
            //Height = Unit.Pixel(600);
            Modal = true;
            ClientSideEvents.PopUp = "function() {pretragaArtikala_tbNazivArtikla.Focus(); gvPretragaArtikala.UnselectRows()}";
            PopupAction = PopupAction.None;
        }
    }
}