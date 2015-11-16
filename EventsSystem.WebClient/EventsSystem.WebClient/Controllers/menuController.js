var menuController = function () {

    function load() {
        $.get('Views/menuRequestView.html', function (data) {
            $('#results').html(data);
        });
    }

    return {
        load: load
    };
}();