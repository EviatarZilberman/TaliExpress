using MongoDBService.Classes;
using TaliExpress.Server.SecuritySettings.SecuritySettingsModels;

namespace TaliExpress.Server.SecuritySettings.Managers
{
    public class SecuritySettingsManager : MongoDBServiceManager
    {
        public new string GetCollectionName() => "security_settings";

        public bool Insert(SecuritySettingsDbModel securitySettingsDbModel)
        {
            return this.Insert(this.GetCollectionName(), securitySettingsDbModel);
        }

        public bool FindBySubjectId(string subjectId, out SecuritySettingsDbModel securitySettingsDbModel)
        {
            return this.FindOneByProperty(this.GetCollectionName(), "SubjectId", subjectId, out securitySettingsDbModel);
        }
    }
}