using System;
using System.Collections.Generic;
using System.Text;

namespace AppExamen.Code
{
    public class APIConsumer
    {
        public static Models.Gato[] Gatos(string apiUrl)
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("Content-Type", "application/json");
            var json = api.DownloadString(apiUrl);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Gato[]>(json);
        }

        public static Models.Gato Gato(string apiUrl, string id)
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("Content-Type", "application/json");
            var json = api.DownloadString(apiUrl + "/" + id);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Gato>(json);
        }

        public static string SaveGato(string apiUrl, string id, Models.Gato gato)
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("Content-Type", "application/json");
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(gato);
            api.UploadString(apiUrl + "/" + id, "PUT", json);
            return "OK";
        }

        public static string CreateGato(string apiUrl, Models.Gato gato)
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("Content-Type", "application/json");
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(gato);
            json = api.UploadString(apiUrl, "POST", json);
            return "OK";
        }

        public static string DeleteGato(string apiUrl, string id)
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("Content-Type", "application/json");
            api.UploadString(apiUrl + "/" + id, "DELETE", "");
            return "OK";
        }

    }
}
