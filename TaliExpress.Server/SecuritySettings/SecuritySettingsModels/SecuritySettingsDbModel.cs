using MongoDBService.Classes;

namespace TaliExpress.Server.SecuritySettings.SecuritySettingsModels
{
    public sealed class SecuritySettingsDbModel : AMongoDBItem
    {
        public string SubjectId { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
}