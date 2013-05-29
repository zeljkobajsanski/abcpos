var app = app || {};

function ZaliheViewModel() {
    var self = this,
        idRadnje,
        idZalihe,
        fromCache;

    self.prikazi = function () {
        idRadnje = cmbRadnje.GetValue();
        fromCache = false;
        if (idRadnje) {
            if (!gvZalihe.InCallback()) {
                gvZalihe.PerformCallback();
            }
        }
    };
    self.gvZaliheBeginCallback = function (s, e) {
        e.customArgs['idRadnje'] = idRadnje;
        e.customArgs['id'] = idZalihe;
        e.customArgs['fromCache'] = fromCache;
    };
    self.edit = function (s, e) {
        idZalihe = s.cpId;
        gvZalihe.StartEditRowByKey(idZalihe);
        txtMinZaliha.Focus();
    };
    self.gvZaliheEndCallback = function () {
        idZalihe = undefined;
        fromCache = true;
    };
    self.osveziDijagram = function() {
        fromCache = true;
        if (!dijagram.InCallback()) {
            gvZalihe.GetPageRowValues("ID", function (id) {
                dijagram.PerformCallback({ args: JSON.stringify(id) });
            });
        }
    };
};

app.zalihe = new ZaliheViewModel();