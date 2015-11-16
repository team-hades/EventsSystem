var homeController = function () {

    function load() {
        $.get('Views/homeRequestView.html', function (data) {
            $('#top').html(data);
        });
    }

    return {
        load: load
    };
}();