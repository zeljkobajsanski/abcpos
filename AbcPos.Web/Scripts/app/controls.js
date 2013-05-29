var app = app || {};

app.controls = (function () {

    var model = {
        ucitajArtikalPoSifri: function(s, e) {
            if (e.htmlEvent.keyCode === 13) {
                var sifra = s.GetValue();
                $.get(app.root + 'Artikli/VratiArtikal', { sifra: sifra }, function (artikal) {
                    $("#tbSifraArtikla").trigger('IzabranArtikal', [artikal]);
                });
            }
        },
        prikaziPretraguArtikala: function (s, e) {
            switch (e.buttonIndex) {
                case 0:
                    s.SetValue(null);
                    break;
                case 1:
                    pretragaArtikalaDialog.Show();
                    break;
            }
            
        }
    }; 

    return model;
}());