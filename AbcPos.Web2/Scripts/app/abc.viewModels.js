var Abc = Abc || {};

Abc.ArtikliViewModel = function() {
    var self = this;
    self.naziv = ko.observable();
    self.sifra = ko.observable();
    self.artikli = ko.observableArray([]);
    self.pretrazi = function() {
        $.get('/api/Artikli', { sifra: self.sifra() || '', naziv: self.naziv() || '' }, function (artikli) {
            self.artikli([]);
            $.each(artikli, function (ix, artikal) {
                self.artikli.push(new Abc.Artikal(artikal.ID, artikal.Sifra, artikal.Naziv, artikal.JM));
            });
        });
    };
    self.columns = [{ field: 'sifra', title: 'Šifra' }, { field: 'naziv', title: 'Naziv artikla' }, { field: 'jedinicaMere', title: 'JM' }];
    self.otkazi = function() {
        self.sifra('');
        self.naziv('');
        self.artikli([]);
    };
};