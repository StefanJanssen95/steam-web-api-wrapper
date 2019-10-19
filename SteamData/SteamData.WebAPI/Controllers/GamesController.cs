using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Steam.Models.SteamCommunity;
using SteamAPI;
using SteamAPI.Models.ResultModels;
using SteamWebAPI2.Utilities;

namespace SteamData.WebAPI.Controllers
{
    [Route("api/games")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        [HttpGet("owned/{id}")]
        public Task<ISteamWebResponse<OwnedGamesResultModel>> GetOwned(ulong id)
        {
            return SteamWebInterface.GetOwnedGames(id, true, false);
        }

        [HttpGet("wishlisted/{id}")]
        public Task<ISteamWebResponse<Dictionary<string,WishlistItemModel>>> GetWishlisted(ulong id)
        {
            return SteamWebInterface.GetWishlistedGames(id);
        }
    }
}