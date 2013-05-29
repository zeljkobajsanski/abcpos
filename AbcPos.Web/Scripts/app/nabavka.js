var app = app || {};
app.nabavka = (function () {

    $(document).ready(function () {
        if (_idDokumenta() == 0) {
            $("#stavka").hide();
            $("#stavkeGrid").hide();
        } else {
            $("#stavka").show();
            $("#stavkeGrid").show();
            _osveziStavke();
            _vidljivaStavka(false);
        }
        
        pretragaArtikalaDialog.SetPopupElementID("tbSifraArtikla");
        $("#pretragaArtikala").bind("IzabraniArtikliIzPretrage", function(e, selected) {
            _dodajArtikle(selected);
            _novaStavka();
        });
        $("#tbSifraArtikla").bind('IzabranArtikal', function(e, artikal) {
            if (artikal != null) {
                $("#StavkaDokumenta_ArtikalID").val(artikal.ID);
                $("#nazivArtikla").text(artikal.Naziv);
                _vidljivaStavka(true);
                kolicina.Focus();
            } else {
                _vidljivaStavka(false);
            }
        });
    });
    

    var model = {
        sacuvanoZaglavlje: function (idDokumenta) {
            $(".idDokumenta").val(idDokumenta);
            $("#stavka").show();
            $("#stavkeGrid").show();
            _novaStavka();
        },
        sacuvajStavku: function() {
            $("#stavkaForm").submit();
        },
        stavkeGridBeginCallback: function(s, e) {
            e.customArgs['idDokumenta'] = _idDokumenta();
        },
        osveziStavke: _osveziStavke,
        novaStavka: _novaStavka,
        izmenaStavke: function(s, e) {
            var idStavke = s.cp_IdStavke;
            $.get(app.root + 'Nabavka/VratiStavkuDokumenta', { id: idStavke }, function(stavka) {
                $("#StavkaDokumenta_ID").val((stavka.ID));
                $("#StavkaDokumenta_ArtikalID").val(stavka.ArtikalID);
                $("#nazivArtikla").text(stavka.Artikal.Naziv);
                tbSifraArtikla.SetValue(stavka.Artikal.Sifra);
                kolicina.SetValue(stavka.Kolicina);
                nabavnaCena.SetValue(stavka.NabavnaCena);
                prodajnaCena.SetValue(stavka.ProdajnaCena);
                _vidljivaStavka(true);
                btnSacuvajStavku.SetText('Izmeni');
                kolicina.Focus();
            });
        },
        obrisiStavku: function (s, e) {
            if (!confirm("Da li želite da obrišete stavku?")) {
                return;
            }
            var idStavke = s.cp_IdStavke;
            $.post(app.root + 'Nabavka/ObrisiStavku', { id: idStavke }, function() {
                _osveziStavke();
            });
        },
        aktivirajDokument: _aktivirajDokument
    };

    return model;

    function _notBusy() {
        
    }
    
    function _vidljivaStavka(vidljiva) {
        if (vidljiva) {
            $("#nazivArtikla").show();
        } else {
            $("#nazivArtikla").hide();
        }
        
        kolicina.SetEnabled(vidljiva);
        nabavnaCena.SetEnabled(vidljiva);
        marza.SetEnabled(vidljiva);
        prodajnaCena.SetEnabled(vidljiva);
        btnSacuvajStavku.SetEnabled(vidljiva);
    }

    function _dodajArtikle(selected) {
        if (selected.length == 0) return;
        var data = {
            idDokumenta: $("#Dokument_ID").val(),
            idArtikala: selected
        };
        $.ajax({
            url: app.root + 'Nabavka/DodajArtikle',
            type: 'POST',
            data: data,
            traditional: true,
            success: _osveziStavke
        });
    }

    function _osveziStavke() {
        if (!gvStavke.InCallback()) {
            gvStavke.PerformCallback();
        }
    }
    
    function _novaStavka() {
        $("#nazivArtikla").text(null);
        $("#StavkaDokumenta_ID").val(0);
        $("#StavkaDokumenta_ArtikalID").val(0);
        tbSifraArtikla.SetValue(null);
        kolicina.SetValue(0);
        nabavnaCena.SetValue(0);
        prodajnaCena.SetValue(0);
        tbSifraArtikla.Focus();
        _vidljivaStavka(false);
        btnSacuvajStavku.SetText('Dodaj');
    }
    
    function _idDokumenta() {
        return $("#Dokument_ID").val();
    }

    function _aktivirajDokument() {
        $.post(app.root + "Nabavka/Aktiviraj", { id: _idDokumenta() }, function() {
            window.open(app.root + "Nabavka", "_self");
        });
    }
}());
