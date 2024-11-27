namespace DataPoints.Persistence.Models
{
    public class DataPointDictionary
    {
        public int Id { get; set; }
        public int? MSItemId { get; set; }
        public string? ItemSymbol { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public string? DataType { get; set; }
        public int? CSBaseItemID { get; set; }
        public string? Multiplier { get; set; }
        public string? ToolTip { get; set; }
        public string? Definition { get; set; }
        public string? PossibleValues { get; set; }
        public string? Tips { get; set; }
        public string? AlterMSItemID { get; set; }
        public string? IntgrStatus { get; set; }
        public string? ExcludeETF { get; set; }
        public string? IsDefaultSortDesc { get; set; }
        public string? NewDescription { get; set; }
        public string? IBDDI { get; set; }
        public string? DataGrouping { get; set; }
        public string? WMUpdateFrequency { get; set; }
        public string? DJFrequency { get; set; }
        public string? DJSource { get; set; }
        public string? DJType { get; set; }
        public string? Notes { get; set; }
        public string? FullCalc { get; set; }
        public string? FrontEndDataItemChartsRIPanel { get; set; }
        public string? LocationInMSApp { get; set; }
        public string? MarketDataAPI { get; set; }
        public string? MDSDataPoint { get; set; }
        public string? HistoricalData { get; set; }
        public string? WONDataFile { get; set; }
        public string? JiraDataPointTicket { get; set; }
        public string? JiraEngineeringTicket { get; set; }
        public string? LoadingCalcNeitherBoth { get; set; }
    }
}
