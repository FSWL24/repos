using DataPoints.Types.OutputTypes;

public class DataPointsDictionaryType : ObjectType<DataPointDictionaryOutput>
{
    protected override void Configure(IObjectTypeDescriptor<DataPointDictionaryOutput> descriptor)
    {

       

        descriptor.Field(f => f.Id).Type<IntType>().Name("Id");
        descriptor.Field(f => f.MSItemId).Type<IntType>().Name("MSItemId");
        descriptor.Field(f => f.ItemSymbol).Type<StringType>().Name("ItemSymbol");
        descriptor.Field(f => f.DisplayName).Type<StringType>().Name("DisplayName");
        descriptor.Field(f => f.Description).Type<StringType>().Name("Description");
        descriptor.Field(f => f.DataType).Type<StringType>().Name("DataType");
        descriptor.Field(f => f.CSBaseItemID).Type<IntType>().Name("CSBaseItemID");
        descriptor.Field(f => f.Multiplier).Type<StringType>().Name("Multiplier");
        descriptor.Field(f => f.ToolTip).Type<StringType>().Name("ToolTip");
        descriptor.Field(f => f.Definition).Type<StringType>().Name("Definition");
        descriptor.Field(f => f.PossibleValues).Type<StringType>().Name("PossibleValues");
        descriptor.Field(f => f.Tips).Type<StringType>().Name("Tips");
        descriptor.Field(f => f.AlterMSItemID).Type<StringType>().Name("AlterMSItemID");
        descriptor.Field(f => f.IntgrStatus).Type<StringType>().Name("IntgrStatus");
        descriptor.Field(f => f.ExcludeETF).Type<StringType>().Name("ExcludeETF");
        descriptor.Field(f => f.IsDefaultSortDesc).Type<StringType>().Name("IsDefaultSortDesc");
        descriptor.Field(f => f.NewDescription).Type<StringType>().Name("NewDescription");
        descriptor.Field(f => f.IBDDI).Type<StringType>().Name("IBDDI");
        descriptor.Field(f => f.DataGrouping).Type<StringType>().Name("DataGrouping");
        descriptor.Field(f => f.WMUpdateFrequency).Type<StringType>().Name("WMUpdateFrequency");
        descriptor.Field(f => f.DJFrequency).Type<StringType>().Name("DJFrequency");
        descriptor.Field(f => f.DJSource).Type<StringType>().Name("DJSource");
        descriptor.Field(f => f.DJType).Type<StringType>().Name("DJType");
        descriptor.Field(f => f.Notes).Type<StringType>().Name("Notes");
        descriptor.Field(f => f.FullCalc).Type<StringType>().Name("FullCalc");
        descriptor.Field(f => f.FrontEndDataItemChartsRIPanel).Type<StringType>().Name("FrontEndDataItemChartsRIPanel");
        descriptor.Field(f => f.LocationInMSApp).Type<StringType>().Name("LocationInMSApp");
        descriptor.Field(f => f.MarketDataAPI).Type<StringType>().Name("MarketDataAPI");
        descriptor.Field(f => f.MDSDataPoint).Type<StringType>().Name("MDSDataPoint");
        descriptor.Field(f => f.HistoricalData).Type<StringType>().Name("HistoricalData");
        descriptor.Field(f => f.WONDataFile).Type<StringType>().Name("WONDataFile");
        descriptor.Field(f => f.JiraDataPointTicket).Type<StringType>().Name("JiraDataPointTicket");
        descriptor.Field(f => f.JiraEngineeringTicket).Type<StringType>().Name("JiraEngineeringTicket");
        descriptor.Field(f => f.LoadingCalcNeitherBoth).Type<StringType>().Name("LoadingCalcNeitherBoth");
    }
}