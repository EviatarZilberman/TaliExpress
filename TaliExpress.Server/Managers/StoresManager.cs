using MongoDBService.Classes;
using TaliExpress.Server.Models;

namespace TaliExpress.Server.Managers
{
    public class StoresManager : AManager
    {
        public override string GetCollectionName() => "stores";
        public bool Insert(StoreDbModel store) => base.Insert(this.GetCollectionName(), store);
        public bool GetByUserId(string id, out StoreDbModel store) => base.FindOneByProperty(this.GetCollectionName(), "UserId", id, out store);
    }
}