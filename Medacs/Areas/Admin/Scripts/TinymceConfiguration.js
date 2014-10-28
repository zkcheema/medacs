
    $(".mceEditor").tinymce({
        script_url: "/Scripts/tinymce/jquery.tinymce.min.js",
        theme: "advanced",
        editor_selector: "mceEditor",
        plugins: "emotions,spellchecker,advhr,insertdatetime,preview",
        theme_advanced_buttons1: "bold,italic,underline,|,justifyleft,justifycenter,justifyright,fontsizeselect",
        theme_advanced_buttons2: "cut,copy,paste,|,bullist,numlist,|,outdent,indent,|,undo,redo,|,link,unlink,anchor,|,code,|,spellchecker,advhr,,removeformat,|,sub,sup,|,charmap",
        theme_advanced_toolbar_location: "top",
        theme_advanced_toolbar_align: "left",
        theme_advanced_statusbar_location: "bottom",
        theme_advanced_resizing: true
    });