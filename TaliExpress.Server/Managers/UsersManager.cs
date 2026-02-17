using ConfigApp.Classes;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDBService.Classes;
using MongoDBService.Enums;
using TaliExpress.Server.Enums;
using TaliExpress.Server.Models;

namespace TaliExpress.Server.Managers
{
    public sealed class UsersManager : MongoDBServiceManager
    {
        public new string GetCollectionName() => "users";

        public bool FreezeMembership(User user)
        {
            user.Status = (int)UserStatus.Freezed;
            return this.Replace(this.GetCollectionName(), user);
        }

        public bool FindByEmail(string email, out User user)
        {
            return this.FindOneByProperty(this.GetCollectionName(), "Email", email, out user);
        }

        public bool Update(User user)
        {
            return this.Replace(this.GetCollectionName(), user);
        }

        public bool Insert(User user)
        {
            return this.Insert(this.GetCollectionName(), user);
        }
    }
}