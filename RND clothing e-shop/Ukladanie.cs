using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

namespace RND_clothing_e_shop
{
    public static class Ukladanie
    {
        private static string subor = "save.json";

        public static void Save(Uzivatel uzivatel)
        {
            string json = JsonSerializer.Serialize(uzivatel, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(subor, json);
        }

        public static Uzivatel Load()
        {
            if (!File.Exists(subor))
            {
                return null;
            }

            string json = File.ReadAllText(subor);
            return JsonSerializer.Deserialize<Uzivatel>(json);
        }

        public static void DeleteSave()
        {
            if (File.Exists(subor))
            {
                File.Delete(subor);
            }
        }
    }
}