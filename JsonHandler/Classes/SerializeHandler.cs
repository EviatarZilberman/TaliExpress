using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Eviatar.Zilberman.JsonHandler.Classes
{
    public static class SerializeHandler<T>
    {
        public static string Serialize(T item)
        {
            return JsonSerializer.Serialize(item);
        }
    }
}
