var app = app || {};

app.pretragaArtikala = (function () {
    $(document).ready(function() {
        $("#pretragaArtikalaForm").submit(_pretraziArtikle);
    });

    var model = {
        gvPretragaArtikalaBeginCallback: function(s, e) {
            e.customArgs['sifraIliBarKod'] = pretragaArtikala_tbSifraArtikla.GetValue() || undefined;
            e.customArgs['naziv'] = pretragaArtikala_tbNazivArtikla.GetValue() || undefined;
        },
        izaberiArtikle: function () {
            var selected = gvPretragaArtikala.GetSelectedKeysOnPage();
            $("#pretragaArtikala").trigger("IzabraniArtikliIzPretrage", [selected]);
            pretragaArtikalaDialog.Hide();
        },
        ponistiKriterijume: function() {
            pretragaArtikala_tbSifraArtikla.SetValue(null);
            pretragaArtikala_tbNazivArtikla.SetValue(null);
        }
    };
    return model;

    function _pretraziArtikle() {
        if (!gvPretragaArtikala.InCallback()) {
            gvPretragaArtikala.PerformCallback();
        }
        return false;
    }
}());