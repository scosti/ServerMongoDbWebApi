namespace WebApiServer.Models
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string NotesCollectionName { get; set; }
        public string OrdersCollectionName { get; set; }
        public string ProductsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IDatabaseSettings
    {
        string NotesCollectionName { get; set; }
        string OrdersCollectionName { get; set; }
        string ProductsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
