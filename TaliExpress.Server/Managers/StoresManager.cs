using ConfigApp.Classes;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDBService.Classes;
using MongoDBService.Enums;
using TaliExpress.Server.Enums;
using TaliExpress.Server.Models;

namespace TaliExpress.Server.Managers
{
    public class StoresManager : MongoDBServiceManager
    {
        public new string GetCollectionName() => "stores";
        public bool Insert(StoreDbModel store) => base.Insert(this.GetCollectionName(), store);
        public bool GetByUserId(string id, out StoreDbModel store) => base.FindOneByProperty(this.GetCollectionName(), "Username", id, out store);
    }
}