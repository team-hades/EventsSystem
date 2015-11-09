var categoriesController = function () {

    function all() {
        $.get('Views/categoriesRequestView.html', function (data) {
            $('#requests').html(data);
        });
    }

    return {
        all: all
    };
}();