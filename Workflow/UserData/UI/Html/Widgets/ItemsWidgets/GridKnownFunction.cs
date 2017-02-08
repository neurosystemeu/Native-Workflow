namespace NeuroSystem.Workflow.UserData.UI.Html.Widgets.ItemsWidgets
{
    public enum GridKnownFunction
    {
        //
        // Summary:
        //     No filter would be applied, filter controls would be cleared
        NoFilter = 0,
        //
        // Summary:
        //     Same as: dataField LIKE '/%value/%'
        Contains = 1,
        //
        // Summary:
        //     Same as: dataField NOT LIKE '/%value/%'
        DoesNotContain = 2,
        //
        // Summary:
        //     Same as: dataField LIKE 'value/%'
        StartsWith = 3,
        //
        // Summary:
        //     Same as: dataField LIKE '/%value'
        EndsWith = 4,
        //
        // Summary:
        //     Same as: dataField = value
        EqualTo = 5,
        //
        // Summary:
        //     Same as: dataField != value
        NotEqualTo = 6,
        //
        // Summary:
        //     Same as: dataField > value
        GreaterThan = 7,
        //
        // Summary:
        //     Same as: dataField < value
        LessThan = 8,
        //
        // Summary:
        //     Same as: dataField >= value
        GreaterThanOrEqualTo = 9,
        //
        // Summary:
        //     Same as: dataField <= value
        LessThanOrEqualTo = 10,
        //
        // Summary:
        //     Same as: value1 <= dataField <= value2. Note that value1 and value2 should be
        //     separated by [space] when entered as filter.
        Between = 11,
        //
        // Summary:
        //     Same as: dataField <= value1 && dataField >= value2. Note that value1 and value2
        //     should be separated by [space] when entered as filter.
        NotBetween = 12,
        //
        // Summary:
        //     Same as: dataField = ''
        IsEmpty = 13,
        //
        // Summary:
        //     Same as: dataField != ''
        NotIsEmpty = 14,
        //
        // Summary:
        //     Only null values
        IsNull = 15,
        //
        // Summary:
        //     Only those records that does not contain null values within the corresponding
        //     column
        NotIsNull = 16,
        //
        // Summary:
        //     Custom function will be applied. The filter value should contain a valid filter
        //     expression, including DataField, operators and value
        Custom = 17
    }
}
