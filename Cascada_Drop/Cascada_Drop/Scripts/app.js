var arrDialogRef = [];
var curDialogRef = null;

// on load of application
$(function () {

    curDialogRef = $("#productList");

    $(document).on("click", "a.dialog", function (event) {

        event.preventDefault();

        var currentLinkRef = this;
        var url = $(this).attr("href");
        var title = $(this).attr("title");
        var dialog = $("<div></div>");

        $(dialog)
            .load(url)
            .dialog({
                title: title,
                autoOpen: false,
                resizable: false,
                height: 'auto',
                width: '50%',
                minWidth: '400',
                minHeight: '400',
                show: { effect: 'drop', direction: "up" },
                modal: true,
                draggable: true,
                open: function (event, ui) {

                    var me = this;

                    // storing reference
                    arrDialogRef.push({
                        Source: curDialogRef,// parent dialog reference
                        Destination: me, // child or open dialog refernce
                        Element: currentLinkRef, // current link reference
                    });

                    curDialogRef = me;
                },
                close: function (event, ui) {

                    // releasing resource of dialog on close event
                    var me = this;
                    $.each(arrDialogRef, function (i, val) {

                        if (val.Destination == me) {
                            curDialogRef = val.Source;
                            arrDialogRef.splice(i, 1);
                            return false;
                        }
                    });

                    $(this).empty().dialog('destroy').remove();
                }
            });

        $(dialog).dialog('open');
    });

    $(document).on("click", "a.delete", function (event) {

        event.preventDefault();
        var url = $(this).attr("href");

        showMessageBox({
            title: "Question",
            content: "Are you sure want to delete this record?",
            btn1text: "Yes",
            btn2text: "No",
            functionText: "makeAjaxCall",
            parameterList: {
                url: url,
                callback: 'updateSection'
            }
        });
    });

    updateSection(); // update the section of product list on load
});

function onAjaxFailure(response) {
    console.log(response);

    var data = $.parseJSON(response.responseJSON);
    var content = "<ul>";
    for (var key in data) {
        content += "<ol>" + data[key] + "</ol>";
    }

    content += "</ul>"

    showMessageBox({
        title: "Error",
        content: content,
        btn1text: "Ok"
    });
}

function showMessageBox(params) {

    var btn1css;
    var btn2css;

    if (params.btn1text) {
        btn1css = "showcss";
    } else {
        btn1css = "hidecss";
    }

    if (params.btn2text) {
        btn2css = "showcss";
    } else {
        btn2css = "hidecss";
    }

    $("#lblMessage").html(params.content);

    $("#dialog").dialog({
        resizable: false,
        title: params.title,
        modal: true,
        width: 'auto',
        height: 'auto',
        bgiframe: false,
        hide: { effect: 'scale', duration: 400 },
        buttons: [
            {
                text: params.btn1text,
                "class": btn1css,
                click: function () {
                    if (params.functionText) { window[params.functionText](params.parameterList); } // Call function after clicking on button.
                    $("#dialog").dialog('close');
                }
            },
            {
                text: params.btn2text,
                "class": btn2css,
                click: function () {
                    $("#dialog").dialog('close');
                }
            }
        ]
    });
}

function updateSection() {
    
    var source = null;
    var updateContainerId = "";
    var ref = getParentDialogRef();
    if (ref && ref.Destination) {
        source = ref.Destination;
        updateContainerId = source;
    }
    else if (curDialogRef) {
        source = curDialogRef;
        updateContainerId = $("#product-grid");
    }

    var url = $(source).find("form").attr("action");

    if (url) {

        $.get(url, function (data) {
            
            $(updateContainerId).html(data);
        });
    }
}

function getParentDialogRef() {
    if (arrDialogRef && arrDialogRef.length > 0) {
        return arrDialogRef[arrDialogRef.length - 1];
    }

    return null;
}

function closeDialog() {

    var ref = getParentDialogRef();
    if (ref) {
        $(ref.Destination).dialog("close");
    }
}

function updateContainer(response) {
    var ref = getParentDialogRef();

    if (ref) {

        $(ref.Element).parent().find("input[type='hidden']").val(response.Id);
        $(ref.Element).parent().find("input[type='text']").val(response.Name);

        closeDialog();
    }
}

function updateSearchContainer(response) {
    var ref = getParentDialogRef();
    if (ref) {
        $(ref.Destination).html(response);
    }
}

function makeAjaxCall(params) {

    $.ajax({
        type: 'POST',
        url: params.url,
        data: params.parameters,
        dataType: 'json',
        success: function (response) {
            if (response.success) {
                eval(params.callback + '(response)');
            }
        }
    })
}