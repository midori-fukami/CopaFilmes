viewModel = function () {
    var that = this;
    this.Movies = ko.observableArray(new Array());
    this.Count = ko.observable(0);
    this.selectedMovies = ko.observableArray(new Array());

    this.load = function () {
        $.get("/Movie/GetMovies", function (data) {
            if (data.error == null) {
                that.Movies(data.data);
            }
            else {
                showDialogOK(data.error.message);
            }
        });
    };

    this.checkMovie = function (e) {
        if (!that.canCheck() && !e.isChecked) {
            showDialogOK("Número máximo de filmes selecionado.");
            if (that.selectedMovies().length > 8)
                that.selectedMovies.remove(e.id);
            return false;
        } else {

            e.isChecked = !e.isChecked;

            that.Count(that.selectedMovies().length);

            return true;
        }
    };

    this.canCheck = function () {
        if (that.selectedMovies().length > 8)
            return false;

        return true;
    };

    this.GoToTournamentCommand = function () {
        console.log(that.selectedMovies().length);
        if (that.selectedMovies().length < 8) {
            showDialogOK("Por favor, selecione 8 filmes.");
            return false;
        }
        $.post("/Movie/Tournament", { ids: that.selectedMovies() }, function (data) {
            if (data.error == null && data.data.length == 2) {
                window.location.href = "Movie/Winners?first=" + data.data[0].title + "&second=" + data.data[1].title;
            }
            else {
                showDialogOK(data.error.message);
            }
        });
    };
};

ko.options.deferUpdates = false;
var vm = new viewModel();

$(document).ready(function () {
    ko.applyBindings(vm);
    vm.load();
});