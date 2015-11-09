var app = Sammy('#result', function () {

    this.get('#/', function () {
        this.redirect('#/home')
    });
    this.get('#/home', homeController.load);

    //this.get('#/', function () {
    //    $('#result').text('INITIAL Content');
    //    $('#requests').text('INITIAL  Content');
    //});

    this.get('#/categories', categoriesController.all);
});

app.run('#/');