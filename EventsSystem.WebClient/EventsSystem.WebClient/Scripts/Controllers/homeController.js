var homeController = function () {

    function load() {
        $.get('Views/homeRequestView.html', function (data) {
            $('#requests').html(data);
        });
    }

    return {
        load: load
    };
}();