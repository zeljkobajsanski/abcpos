var app = app || {};

app.artikli = (function () {
    var idArtikla;
    
    var model = {
        gvArtikliFocusedRowChanged: function(s, e) {
            idArtikla = s.GetRowKey(s.GetFocusedRowIndex());
            if (!gvZalihe.InCallback()) {
                gvZalihe.PerformCallback();
            }
        },
        gvZaliheBeginCallback: function(s, e) {
            e.customArgs['idArtikla'] = idArtikla;
        }
    };
    return model;
    


}());