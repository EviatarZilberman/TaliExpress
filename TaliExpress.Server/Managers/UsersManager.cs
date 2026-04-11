using ConfigApp.Classes;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDBService.Classes;
using MongoDBService.Enums;
using TaliExpress.Server.Enums;
using TaliExpress.Server.Models;

namespace TaliExpress.Server.Managers
{
    public sealed class UsersManager : AManager
    {
        public bool FreezeMembership(UserDbModel user)
        {
            user.Status = (int)UserStatus.Freezed;
            return this.Replace(this.GetCollectionName(), user);
        }

        public bool FindByEmail(string email, out UserDbModel user) => this.FindOneByProperty(this.GetCollectionName(), "Email", email, out user);

        public bool Update(UserDbModel user) => this.Replace(this.GetCollectionName(), user);

        public bool Insert(UserDbModel user) => this.Insert(this.GetCollectionName(), user);

        public override string GetCollectionName() => "users";
    }
}