using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinAppCede.Models
{
    public class Product
    {
        [JsonProperty ("_id")]
        public string Id { get; set; }
        
        [JsonProperty("image")]
        public string Image { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Descripction { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("score")]
        public double Score { get; set; }

        [JsonProperty("delivery_time")]
        public int DeliveryTime { get; set; }

        [JsonProperty("category")]
        public int Category { get; set; }

        public string FullImageUrl => $"{AppSettings.ApiUrl}/{Image}";
    }
}