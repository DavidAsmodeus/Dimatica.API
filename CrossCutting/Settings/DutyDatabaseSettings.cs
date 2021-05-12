namespace CrossCutting.Settings
{
    public class DutyDatabaseSettings : IDutyDatabaseSettings
    {
        public string DutiesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IDutyDatabaseSettings
    {
        string DutiesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
