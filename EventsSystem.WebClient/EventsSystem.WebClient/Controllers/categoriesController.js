var categoriesController = function () {

    function all() {
        $.get('Views/categoriesRequestView.html', function (data) {
            $('#callout').html(data);
        });
    }

    return {
        all: all
    };
}();