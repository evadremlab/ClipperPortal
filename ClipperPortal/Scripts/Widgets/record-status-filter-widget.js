/***
* RecordStatusFilterWidget - Provides filter for Record Status column.
*/

function RecordStatusFilterWidget() {
    /***
    * This method must return type of registered widget type in 'SetFilterWidgetType' method
    */
    this.getAssociatedTypes = function () {
        return ["RecordStatusFilterWidget"];
    };
    /***
    * This method invokes when filter widget was shown on the page
    */
    this.onShow = function () {
        /* Place your on show logic here */
    };

    this.showClearFilterButton = function () {
        return true;
    };
    /***
    * This method will invoke when user was clicked on filter button.
    * container - html element, which must contain widget layout;
    * lang - current language settings;
    * typeName - current column type (if widget assign to multipile types, see: getAssociatedTypes);
    * values - current filter values. Array of objects [{filterValue: '', filterType:'1'}];
    * cb - callback function that must invoked when user want to filter this column. Widget must pass filter type and filter value.
    * data - widget data passed from the server
    */
    this.onRender = function (container, lang, typeName, values, cb, data) {
        //store parameters:
        this.cb = cb;
        this.container = container;
        this.lang = lang;

        //this filterwidget demo supports only 1 filter value for column column
        this.value = values.length > 0 ? values[0] : { filterType: 1, filterValue: "" };

        this.renderWidget(); //onRender filter widget
        this.fillRecordStatuses(["Planned", "Completed"]); // with static data
        this.registerEvents(); //handle events
    };
    this.renderWidget = function () {
        var html = '<p>Select Record Status to filter:</p>\
                    <select style="width:250px;" class="grid-filter-type list form-control"></select>';
        this.container.append(html);
    };
    /***
    * Method fills select list with data.
    */
    this.fillRecordStatuses = function (items) {
        var list = this.container.find(".list");
        for (var i = 0; i < items.length; i++) {
            var selected = items[i] === this.value.filterValue ? ' selected="selected"' : '';
            list.append('<option{0} value="{1}">{1}</option>'.format(selected, items[i]));
        }
    };
    /***
    * Internal method that register event handlers for 'apply' button.
    */
    this.registerEvents = function () {
        //get list with calendar years
        var list = this.container.find(".list");
        //save current context:
        var $context = this;
        //register onclick event handler
        list.change(function () {
            //invoke callback with selected filter values:
            var values = [{ filterValue: $(this).val(), filterType: 1 /* Equals */ }];
            $context.cb(values);
        });
    };
}   