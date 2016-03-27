var view = new View();
//function SyncNotes() {
//    model.getNotes().success(function (data) {
//        view.SyncArray(data);
//    });
//}

function init(label) {
    ko.applyBindings(view);
    view.SyncNotes();
    if (label != null) { view.selectNote(null, null, label);}
}

var model = {
    getContent: function (name) {
        if (name) {
            return $.get('/api/Note/MyNote');
        }
    },
    createNote: function (label) {
        $.post('/api/Note/CreateNote', { Label: label }).success(function () {
            view.SyncNotes();
        });
    },
    getNotes: function () {
        return $.get('/api/Note/getNotes');
    },
    setNoteContent: function (label,val) {
        $.post('/api/Note/SetContent', { Label: label, Val: val }).success(function () { alert("Updated!");})
    },
    getNoteContent: function (label) {
        return $.post('/api/Note/GetNoteContent', { Label: label});
    }
}

function View() {
    var self = this;
    this.noteName = ko.observable();
    this.noteContent = ko.observable();
    this.noteArray = ko.observableArray([]);
    this.selectedNote = ko.observable();
    this.noteImg = ko.observable('/Home/img/');

    this.createNote = function () {
        model.createNote(this.noteName());
        this.noteName('');
    }

    this.saveNote = function () {
        model.setNoteContent(self.selectedNote, self.noteContent());
    }
    this.SyncNotes = function () {
        model.getNotes().success(function (data) {
            try { self.noteArray(data) }
            catch (err) { alert("Sync Error!"); }
        });
    }
    this.selectNote = function (data, element,lab) {
        if (lab == null) { var label = $(element.target).text(); }
        else { var label = lab;}
        self.selectedNote(label);
        self.noteImg('/Home/Img/' + label);
        model.getNoteContent(label).success(function (data) {
            try { self.noteContent(data) }
            catch (err) { alert("Get Error!"); }
        });
    }
}