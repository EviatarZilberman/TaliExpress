using ConfigApp.Classes;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDBService.Classes;
using MongoDBService.Enums;
using TaliExpress.Server.Enums;
using TaliExpress.Server.Models;

namespace TaliExpress.Server.Managers
{
    public class StoresManager : MongoDBServiceManager<Store>
    {
        public new string GetCollectionName() => "stores";
        public new bool Insert(Store store) => base.Insert(store);
        public bool GetByUserId(string id, out Store store) => base.FindOneByProperty("Username", id, out store);
    }
}