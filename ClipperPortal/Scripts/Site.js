
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
        setVisibility('.existing-vehicle-details', !isChecked);
        setVisibility('.replacement-vehicle-details', isChecked);
        if (isChecked) {
            $('#ReplacementVehicleDetails').val('');
        } else {
            $('#ExistingVehicleDetails').val('');
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
        var $row = $el.closest('tr');
        var id = $row.find('td.hidden').text(); // assumes that ID is a hidden field
        $.ajax({
            type: 'DELETE',
            url: '/api/{0}sAPI/{1}'.format(recordType, id),
            success: function (result) {
                //showStatusMessage(result.Status);
                //$row.hide(); // so we don't have to refresh the page (but it messes up table striping)
                window.location.reload();
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
