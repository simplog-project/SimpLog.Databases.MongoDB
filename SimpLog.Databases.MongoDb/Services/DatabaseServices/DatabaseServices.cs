using MongoDB.Driver;
using SimpLog.Databases.MongoDb.Entities;
using SimpLog.Databases.MongoDb.Models;
using SimpLog.Databases.MongoDb.Models.AppSettings;

namespace SimpLog.Databases.MongoDb.Services.DatabaseServices
{
    internal class DatabaseServices
    {
        public static Configuration conf = ConfigurationServices.ConfigService.BindConfigObject();

        /// <summary>
        /// Depending on the name of the DB, goes to the function for that stuff.
        /// </summary>
        /// <param name="storeLog"></param>
        public static void SaveIntoDatabase(StoreLog storeLog)
            => InsertIntoMongoDb(storeLog);

        /// <summary>
        /// Insert Log into the MongoDb database
        /// </summary>
        /// <param name="storeLog"></param>
        /// <param name="isEmailSend"></param>
        public static void InsertIntoMongoDb(StoreLog storeLog)
        {
            //  Make MongoDb Connection
            MongoClient dbClient = new MongoClient(conf.Database_Configuration.Connection_String);

            //  Get the database
            var database = new MongoClient().GetDatabase(MongoUrl.Create(conf.Database_Configuration.Connection_String).DatabaseName);

            DatabaseMigrations.CreateMongoDbIfNotExists(database);

            int EmailID = 0;

            //  Insert Document into collection StoreLog
            var storeLogCollection = database.GetCollection<StoreLog>("StoreLog");

            storeLog.ID = (int)storeLogCollection.CountDocuments(Builders<StoreLog>.Filter.Empty, new CountOptions() { Hint = "_id_"}) + 1;
            storeLog.Email_ID = EmailID;

            storeLogCollection.InsertOne(storeLog);
        }
    }
}
