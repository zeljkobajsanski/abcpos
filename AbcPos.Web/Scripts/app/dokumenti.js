var app = app || {};

app.dokumenti = (function () {

    var idIzabranogDokumenta;
    var model = {
        pretrazi: _pretrazi,
        gvDokumentiBeginCallback: function (s, e) {
            e.customArgs['odDatuma'] = moment(odDatuma.GetValue()).format();
            e.customArgs['doDatuma'] = moment(doDatuma.GetValue()).format();
            e.customArgs['idRadnje'] = cmbRadnje.GetValue();
        },
        prikaziStavkeRacuna: function(s, e) {
            idIzabranogDokumenta = s.cpIdDokumenta;
            if (idIzabranogDokumenta && !gvStavke.InCallback()) {
                gvStavke.PerformCallback();
            }
        },
        stavkeRacunaBeginCallback: function(s, e) {
            e.customArgs['idDokumenta'] = idIzabranogDokumenta;
        }
    };

    return model;

    function _pretrazi() {
        if (!gvDokumenti.InCallback()) {
            gvDokumenti.PerformCallback();
        }
    }
}());