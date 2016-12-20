
//$.validator.addMethod('requiredif', function (value, element, parameters) {
//    var desiredvalue = parameters.desiredvalue;
//    desiredvalue = (desiredvalue == null ? '' : desiredvalue).toString();
//    var controlType = $("input[id$='" + parameters.dependentproperty + "']").attr("type");
//    var actualvalue = {}
//    if (controlType == "checkbox" || controlType == "radio") {
//        var control = $("input[id$='" + parameters.dependentproperty + "']:checked");
//        actualvalue = control.val();
//    } else {
//        actualvalue = $("#" + parameters.dependentproperty).val();
//    }
//    if ($.trim(desiredvalue).toLowerCase() === $.trim(actualvalue).toLocaleLowerCase()) {
//        var isValid = $.validator.methods.required.call(this, value, element, parameters);
//        return isValid;
//    }
//    return true;
//});
"use strict";

// so we don't break IE when Developer Tools not open

if (typeof console === 'undefined') {
    console = {
        log: $.noop,
        error: $.noop,
        warn: $.noop
    };
}

/*	--------------------------------------------------
	Custom JS Prototypes
	-------------------------------------------------- */

String.prototype.format = function () {
    //
    // usage:
    //
    // var template = '{0} and {1} and {2}';
    // console.log(template.format(99, 'yes', true));
    //
    var i, re, s = this;
    //
    // String.prototype.format.cache is a form of function "memoization" 
    // where all unique RegExp objects created are cached for re-use.
    //
    if (!String.prototype.format.cache) {
        String.prototype.format.cache = {};
    }
    for (i = 0; i < arguments.length; i++) {
        if (!String.prototype.format.cache[i]) {
            String.prototype.format.cache[i] = new RegExp('\\{' + (i) + '\\}', 'g');
        }
        re = String.prototype.format.cache[i];
        s = s.replace(re, arguments[i]);
    }
    return s;
};

String.prototype.isEmpty = function () {
    return ($.trim(this).length <= 0);
};

String.prototype.isNotEmpty = function () {
    return (this.isEmpty() === false);
};

String.prototype.hasValue = function () {
    return this.isNotEmpty();
};

String.prototype.padLeft = function (width) {
    return this.length >= width ? this : new Array(width - this.length + 1).join('0') + this;
}

/*	--------------------------------------------------
	PageManager
	-------------------------------------------------- */

var PageManager = (function () {

    function isPage(selector) {
        return $(selector).get(0);
    }

    function setVisibility(selector, hide) {
        if (hide) {
            $(selector).addClass('hidden');
        } else {
            $(selector).removeClass('hidden');
        }
    }

    function hideshowOtherManufacturer(manufacturer) {
        var hide = manufacturer !== 'other';
        setVisibility('.other-manufacturer', hide);
        if (hide) {
            $('#OtherManufacturer').val('');
        }
    }

    function hideshowExistingVehicleDetails(isChecked) {
        var hide = !isChecked;
        setVisibility('.existing-vehicle-details', hide);
        if (hide) {
            $('#HaveExistingVehicleDetails').prop('checked', false);
        }
    }

    function bindManufacturer() {
        $('#Manufacturer').on('change', function () {
            hideshowOtherManufacturer($(this).val());
        });
    }

    function bindHaveExistingVehicles() {
        $('#HaveExistingVehicles').on('change', function () {
            hideshowExistingVehicleDetails($(this).prop('checked'));
        });
    }

    function startStatusMessageTimer() {
        setTimeout(function () {
            $('.status-message').hide().removeClass('error-message');
        }, 6000);
    }

    function showStatusMessage(msg) {
        startStatusMessageTimer();
        return $('.status-message').text(msg).show();
    }

    function showErrorMessage(msg) {
        showStatusMessage(msg).addClass('error-message');
    }

    function ajaxDelete(recordType) {
        var $el = $(this);
        $.ajax({
            type: 'DELETE',
            url: '/api/{0}sAPI/{1}'.format(recordType, $el.data().id),
            success: function (result) {
                showStatusMessage(result.Status);
                $el.closest('tr').hide(); // so we don't have to refresh the page
            },
            error: function (xhr, ajaxOptions, thrownError) {
                showErrorMessage('Error deleting {0}: {1}'.format(recordType, thrownError));
            }
        });
    }

    function bind() {
        $('.datetimepicker').datetimepicker();

        if (isPage('.expansion-details')) {
            if (isPage('.details-page')) {
                bindManufacturer();
                bindHaveExistingVehicles();
            } else if (isPage('.list-page')) {
                $('.btn-delete').on('click', function () {
                    if (confirm('Delete this Expansion Detail?')) {
                        ajaxDelete.call(this, 'ExpansionDetail');
                    }
                });
            }
        } else if (isPage('.replacement-vehicles')) {
            if (isPage('.details-page')) {
                bindManufacturer();
            } else if (isPage('.list-page')) {
                $('.btn-delete').on('click', function () {
                    if (confirm('Delete this Replacement Vehicle?')) {
                        ajaxDelete.call(this, 'ReplacementVehicle');
                    }
                });
            }
        }
    }

    return {
        bind: bind,
        startStatusMessageTimer: startStatusMessageTimer
    };
})();
