using MongoDB.Driver;
using SimpLog.Databases.MongoDb.Models.AppSettings;
using System.Text;

namespace SimpLog.Databases.MongoDb.Services.DatabaseServices
{
    internal class DatabaseMigrations
    {
        public static Configuration conf = ConfigurationServices.ConfigService.BindConfigObject();

        /// <summary>
        /// Create MongoDb tables if not exists
        /// </summary>
        /// <param name="database"></param>
        public static void CreateMongoDbIfNotExists(IMongoDatabase database)
        {
            //  Create collection EmailLog if not exists
            if (!database.ListCollectionNames().ToList().Contains("EmailLog"))
                database.CreateCollectionAsync("EmailLog", new CreateCollectionOptions());

            //  Create collection StoreLog if not exists
            if (!database.ListCollectionNames().ToList().Contains("StoreLog"))
                database.CreateCollectionAsync("StoreLog", new CreateCollectionOptions());
        }
    }
}
