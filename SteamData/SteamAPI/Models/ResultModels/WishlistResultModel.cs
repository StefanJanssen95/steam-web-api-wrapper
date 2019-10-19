using System;
using System.Collections.Generic;

namespace SteamAPI.Models.ResultModels
{
    public class WishlistResultModel : Dictionary<string, string>
    {
    }

    public class WishlistItemModel
    {
        public string Name { get; set; }
        public ulong Added { get; set; }
        public string Background { get; set; }
        public string Capsule { get; set; }
        public bool IsFreeGame { get; set; }
        public int Priority { get; set; }
        public ulong ReleaseDate { get; set; }
        public string ReleaseString { get; set; }
        public string ReviewDesc { get; set; }
        public int ReviewScore { get; set; }
        public int ReviewsPercent { get; set; }
        public string ReviewsTotal { get; set; }
        public string Type { get; set; }
        public bool Win { get; set; }
        public bool Linux { get; set; }
        public bool Mac { get; set; }
        
        public List<WishListItemPrice> Subs { get; set; }
    }

    public class WishListItemPrice
    {
        public string DiscountBlock { get; set; }
        public int DiscountPct { get; set; }
        public int Id { get; set; }
        public int Price { get; set; }
    }
}