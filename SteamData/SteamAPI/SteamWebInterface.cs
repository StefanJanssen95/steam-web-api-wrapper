using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Steam.Models.SteamCommunity;
using SteamAPI.Models.ResultModels;
using SteamWebAPI2.Interfaces;
using SteamWebAPI2.Utilities;

namespace SteamAPI
{
    public static class SteamWebInterface
    {
        private static readonly SteamWebInterfaceFactory WebInterfaceFactory = new SteamWebInterfaceFactory(); // TODO: Add API key

        public static Task<ISteamWebResponse<OwnedGamesResultModel>> GetOwnedGames(ulong steamId, bool includeAppInfo=false, bool includeFreeGames=false)
        {
            var steamInterface = WebInterfaceFactory.CreateSteamWebInterface<PlayerService>(new HttpClient());
            return steamInterface.GetOwnedGamesAsync(steamId, includeAppInfo, includeFreeGames);
        }

        public static async Task<ISteamWebResponse<Dictionary<string,WishlistItemModel>>> GetWishlistedGames(ulong steamId)
        {
            string route = $"https://store.steampowered.com/wishlist/profiles/{steamId}/wishlistdata/?p=0";
            using (var client = new HttpClient())
            {
                var httpResponseMessage = await client.GetAsync(route).ConfigureAwait(false);
                return await HelperClass.HttpResponseMessageToISteamWebResponse<Dictionary<string,WishlistItemModel>>(httpResponseMessage);
            }
        }
    }
}