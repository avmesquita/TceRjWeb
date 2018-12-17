var ViewModel = function () {
    var self = this;
    self.books = ko.observableArray();
    self.error = ko.observable();    
	self.detail = ko.observable();	
	self.capabase64 = "";
	
    self.newBook = {
        Id: ko.observable(),
        ISBN: ko.observable(),
        Autor: ko.observable(),
        Nome: ko.observable(),
        Preco: ko.observable(),
		DataPublicacao: ko.observable(),
		Capa: ko.observable()
    };

	this.fileUpload = function (data, e) {
		var file = e.target.files[0];
		var reader = new FileReader();
		reader.onloadend = function (onloadend_e) {
			var result = reader.result; // Here is your base 64 encoded file. Do with it what you want.
			self.capabase64 = result;
	    };
		if (file) {
			self.capabase64 = reader.readAsDataURL(file);
		}
	};

    var booksUri = '/api/books/';    

    function ajaxHelper(uri, method, data) {
        self.error('');
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
			data: data ? ko.toJSON(data) : null			
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllBooks() {
        ajaxHelper(booksUri, 'GET').done(function (data) {
            if (data)
            self.books(data);
        });
    }

    self.getBookDetail = function (item) {        
        if (item.Id > 0) {
            ajaxHelper(booksUri + item.Id, 'GET').done(function (data) {
                self.detail(data);
            });
        }
    };

    self.addBook = function (formElement) {
        var book = {            
            ISBN: self.ISBN,
            Autor: self.Autor,
            Nome: self.Nome,
            Preco: self.Preco,
            DataPublicacao: self.DataPublicacao,
			Capa: self.capabase64
        };
        ajaxHelper(booksUri, 'POST', book).done(function (item) {
            self.books.push(item);
        });
    };    
    getAllBooks();    
};

ko.applyBindings(new ViewModel());
