namespace webapi.Models.AppSettings
{
    public class GamerFinderDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string UserCollectionName { get; set; } = null!;

        public string UserCredentialsCollectionName { get; set; } = null!;
    }
}
