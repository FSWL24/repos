using DataPoints.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace DataPoints.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<DataPointsDictionary> Dictionary { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=DataPoints;Integrated Security=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataPointsDictionary>(entity =>
            {
                entity.ToTable("Dictionary");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("Id").ValueGeneratedOnAdd();
                entity.Property(e => e.MSItemId).HasColumnName("MSItemId");
                entity.Property(e => e.ItemSymbol).HasColumnName("ItemSymbol").HasMaxLength(512);
                entity.Property(e => e.DisplayName).HasColumnName("DisplayName").HasMaxLength(512);
                entity.Property(e => e.Description).HasColumnName("Description").HasMaxLength(512);
                entity.Property(e => e.DataType).HasColumnName("DataType").HasMaxLength(512);
                entity.Property(e => e.CSBaseItemID).HasColumnName("CSBaseItemID");
                entity.Property(e => e.Multiplier).HasColumnName("Multiplier").HasMaxLength(512);
                entity.Property(e => e.ToolTip).HasColumnName("ToolTip").HasMaxLength(512);
                entity.Property(e => e.Definition).HasColumnName("Definition").HasMaxLength(512);
                entity.Property(e => e.PossibleValues).HasColumnName("PossibleValues").HasMaxLength(512);
                entity.Property(e => e.Tips).HasColumnName("Tips").HasMaxLength(512);
                entity.Property(e => e.AlterMSItemID).HasColumnName("AlterMSItemID").HasMaxLength(512);
                entity.Property(e => e.IntgrStatus).HasColumnName("IntgrStatus").HasMaxLength(512);
                entity.Property(e => e.ExcludeETF).HasColumnName("ExcludeETF").HasMaxLength(512);
                entity.Property(e => e.IsDefaultSortDesc).HasColumnName("IsDefaultSortDesc").HasMaxLength(512);
                entity.Property(e => e.NewDescription).HasColumnName("NewDescription").HasMaxLength(512);
                entity.Property(e => e.IBDDI).HasColumnName("IBDDI").HasMaxLength(512);
                entity.Property(e => e.DataGrouping).HasColumnName("DataGrouping").HasMaxLength(512);
                entity.Property(e => e.WMUpdateFrequency).HasColumnName("WMUpdateFrequency").HasMaxLength(512);
                entity.Property(e => e.DJFrequency).HasColumnName("DJFrequency").HasMaxLength(512);
                entity.Property(e => e.DJSource).HasColumnName("DJSource").HasMaxLength(512);
                entity.Property(e => e.DJType).HasColumnName("DJType").HasMaxLength(512);
                entity.Property(e => e.Notes).HasColumnName("Notes").HasMaxLength(512);
                entity.Property(e => e.FullCalc).HasColumnName("FullCalc").HasMaxLength(512);
                entity.Property(e => e.FrontEndDataItemChartsRIPanel).HasColumnName("FrontEndDataItemChartsRIPanel").HasMaxLength(512);
                entity.Property(e => e.LocationInMSApp).HasColumnName("LocationInMSApp").HasMaxLength(512);
                entity.Property(e => e.MarketDataAPI).HasColumnName("MarketDataAPI").HasMaxLength(512);
                entity.Property(e => e.MDSDataPoint).HasColumnName("MDSDataPoint").HasMaxLength(512);
                entity.Property(e => e.HistoricalData).HasColumnName("HistoricalData").HasMaxLength(512);
                entity.Property(e => e.WONDataFile).HasColumnName("WONDataFile").HasMaxLength(512);
                entity.Property(e => e.JiraDataPointTicket).HasColumnName("JiraDataPointTicket").HasMaxLength(512);
                entity.Property(e => e.JiraEngineeringTicket).HasColumnName("JiraEngineeringTicket").HasMaxLength(512);
                entity.Property(e => e.LoadingCalcNeitherBoth).HasColumnName("LoadingCalcNeitherBoth").HasMaxLength(512);
            });
        }
    }
}
