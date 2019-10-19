using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SteamAPI.Models.ResultModels;
using SteamWebAPI2.Utilities;

namespace SteamAPI
{
    public class HelperClass
    {
        private static string CleanupResponseString(string stringToClean)
        {
            if (string.IsNullOrWhiteSpace(stringToClean))
                return string.Empty;
            stringToClean = stringToClean.Replace("\n", "");
            stringToClean = stringToClean.Replace("\t", "");
            return stringToClean;
        }

        public static async Task<ISteamWebResponse<T>> HttpResponseMessageToISteamWebResponse<T>(HttpResponseMessage httpResponseMessage)
        {
            HttpContentHeaders headers = httpResponseMessage.Content?.Headers;
            var steamWebResponse = new SteamWebResponse<T>()
            {
                ContentLength = headers?.ContentLength,
                ContentType = headers?.ContentType?.MediaType,
                ContentTypeCharSet = headers?.ContentType?.CharSet,
                Expires = headers?.Expires,
                LastModified = headers?.LastModified
            };
            if (httpResponseMessage.StatusCode != HttpStatusCode.NoContent && httpResponseMessage.Content != null)
            {
                steamWebResponse.Data = JsonConvert.DeserializeObject<T>(HelperClass.CleanupResponseString(await httpResponseMessage.Content.ReadAsStringAsync()));
            }

            return steamWebResponse;
        }
    }
}