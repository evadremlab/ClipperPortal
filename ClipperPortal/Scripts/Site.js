﻿
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

    function setVisibility(selector, isVisible) {
        console.log(selector);

        if (isVisible) {
            $(selector).removeClass('hidden');
        } else {
            $(selector).addClass('hidden');
        }
    }

    function toggleManufacturerDetails(manufacturer) {
        var isChecked = $(this).is(':checked');
        var selector = '.{0}'.format(manufacturer.toLowerCase());

        setVisibility(selector, isChecked);

        if (manufacturer === 'Other') {
            setVisibility('.other-name', isChecked);
        }

        if (!isChecked) {
            $.each(['Replacement', 'Expansion'], function (outerIndex, outerItem) {
                $.each(['Vehicles', 'ManufacturingDate', 'DeliveryDate'], function (innerIndex, innerItem) {
                    selector = '.{0}{1}{2}'.format(manufacturer, outerItem, innerItem);
                    console.log(selector);
                    $(selector).val('');
                });
            });
            $.each(['NewVehicles', 'NewModel'], function (index, item) {
                selector = '.{0}{1}'.format(manufacturer, item);
                console.log(selector);
                if (!isChecked) {
                    $(selector).val('');
                }
            });
        }
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
        var $row = $el.closest('tr');
        var id = $row.find('td.primary-key').text();
        var url = '/api/{0}API/{1}'.format(recordType, id);
        $.ajax({
            type: 'DELETE',
            url: url,
            success: function (result) {
                window.location.reload();
            },
            error: function (xhr, ajaxOptions, thrownError) {
                showErrorMessage('Error deleting {0}: {1}'.format(recordType, thrownError));
            }
        });
    }

    function bind() {
        if (isPage('.device-survey')) {
            if (isPage('.list-page')) {
                $('.btn-delete').on('click', function () {
                    if (confirm('Delete this DeviceSurvey?')) {
                        ajaxDelete.call(this, 'DeviceSurvey');
                    }
                });
            }
        }
    }

    function toggle(item) {
        var isChecked = $(this).is(':checked');

        if (item === 'ExpectingNewVehicles') {
            setVisibility('.expecting-new-vehicles', isChecked);
        } else {
            toggleManufacturerDetails.call(this, item);
        }
    }

    return {
        bind: bind,
        toggle: toggle,
        startStatusMessageTimer: startStatusMessageTimer
    };
})();
