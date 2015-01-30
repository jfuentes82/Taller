$(function () {


    $(document).on("click", "a.dialog", function (event) {
        event.preventDefault();

        var currentLinkRef = this;
        var url = $(this).attr("href");
        var title = $(this).attr("title");
        var dialog = $("<div></div>");

        $(dialog)
            .load(url)
            .dialog({
                autoOpen: false
			    , title: "asdadadasd"
			    , width: 500
                , modal: true
			    , minHeight: 200
                , show: 'fade'
                , hide: 'fade'
            });


        //$dialog.dialog("option", "buttons", {
        //    "Submit": function () {
        //        var dlg = $(this);
        //        $.ajax({
        //            url: $url,
        //            type: 'POST',
        //            data: $("#target").serialize(),
        //            success: function (response) {
        //                $(target).html(response);
        //                dlg.dialog('close');
        //                dlg.empty();
        //                $("#ajaxResult").hide().html('Record saved').fadeIn(300, function () {
        //                    var e = this;
        //                    setTimeout(function () { $(e).fadeOut(400); }, 2500);
        //                });
        //            },
        //            error: function (xhr) {
        //                if (xhr.status == 400)
        //                    dlg.html(xhr.responseText, xhr.status);     /* display validation errors in edit dialog */
        //                else
        //                    displayError(xhr.responseText, xhr.status); /* display other errors in separate dialog */

        //            }
        //        });
        //    }
        //});


        $(dialog).dialog('open');
    });
});