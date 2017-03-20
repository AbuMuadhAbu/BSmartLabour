//<![CDATA[ 
$(document).ready(function () {
    (function ($) {
        $.validator.unobtrusive.parseDynamicContent = function (selector) {
            //use the normal unobstrusive.parse method
            $.validator.unobtrusive.parse(selector);

            //get the relevant form
            var form = $(selector).first().closest('form');

            //get the collections of unobstrusive validators, and jquery validators
            //and compare the two
            var unobtrusiveValidation = form.data('unobtrusiveValidation');
            var validator = form.validate();

            $.each(unobtrusiveValidation.options.rules, function (elname, elrules) {
                if (validator.settings.rules[elname] === undefined) {
                    var args = {};
                    $.extend(args, elrules);
                    args.messages = unobtrusiveValidation.options.messages[elname];
                    $('[name="' + elname + '"]').rules("add", args);
                } else {
                    $.each(elrules, function (rulename, data) {
                        if (validator.settings.rules[elname][rulename] === undefined) {
                            var args = {};
                            args[rulename] = data;
                            args.messages = unobtrusiveValidation.options.messages[elname][rulename];
                            $('[name="' + elname + '"]').rules("add", args);
                        }
                    });
                }
            });
        };
    })($);
});
//]]>  


var page = function () {

    $.validator.setDefaults({
        onkeyup: false,
        onfocusout: false,
        onclick: false,
        errorElement: 'span',
        highlight: function (element) {
            $(element).closest(".control-group").addClass("error");
        },
        unhighlight: function (element) {
            $(element).closest(".control-group").removeClass("error");
        },
        showErrors: function (errorMap, errorList) {
            if (errorList.length != 0) {
                toastr.warning(errorList[0].message);
            }
            this.defaultShowErrors();
        }
    });

}();