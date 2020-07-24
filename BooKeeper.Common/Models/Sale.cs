namespace BooKeeper.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Newtonsoft.Json;

    public class Sale
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("province")]
        public string Province { get; set; }

        [JsonProperty("telephone")]
        public string Telephone { get; set; }

        [JsonProperty("deliveryData")]
        public object DeliveryData { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

    }
}
