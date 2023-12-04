namespace SimpLog.Databases.MongoDb.Models.AppSettings
{
    internal class Configuration
    {
        public DatabaseConfiguration? Database_Configuration { get; set; }

        public Log? LogType { get; set; }
    }
}
