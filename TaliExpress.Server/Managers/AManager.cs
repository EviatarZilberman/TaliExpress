using Microsoft.AspNetCore.Mvc;
using TaliExpress.Server.Enums;

namespace TaliExpress.Server.Managers
{
    public abstract class AManager<T>
    {
        public abstract Task<ReturnCode> Insert(T item);
        public abstract ReturnCode Update([FromBody] T item);
        public abstract ReturnCode Delete([FromBody] string id);
        public abstract ReturnCode GetAll(ref List<T>? items);
        public abstract ReturnCode Get([FromBody] string commonId, ref T? item);
    }
}
