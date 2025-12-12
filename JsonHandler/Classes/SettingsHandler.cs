using Eviatar.Zilberman.Validators.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace JsonHandler.Classes
{
    public static class SettingsHandler
    {
        private const string FileName = "Data.json";
        private static Dictionary<string, object>? Settings = new Dictionary<string, object>();

        public static bool Init(string? path = null, string? fileName = null)
        {
            if (!new StringEmptyOrNullValidator().Validate(path) || !new StringEmptyOrNullValidator().Validate(fileName))
            {
                path = Path.Combine(AppContext.BaseDirectory, FileName);
            }
            try
            {
                if (path != null)
                {
                    string data = File.ReadAllText(path);
                    Settings = JsonSerializer.Deserialize<Dictionary<string, object>>(data);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public static object GetValue(string key)
        {
            if (Settings!.TryGetValue(key, out object? result))
            {
                return result;
            }
            return key;
        }
    }
}