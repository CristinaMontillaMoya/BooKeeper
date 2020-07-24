namespace BooKeeper.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Newtonsoft.Json;

    public class Book
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("isbn")]
        public string Isbn { get; set; }

        [JsonProperty("category")]
        public Category Category { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("synopsis")]
        public string Synopsis { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonProperty("stock")]
        public int Stock { get; set; }

        [JsonProperty("imageFullPath")]
        public string ImageFullPath { get; set; }

    }
}
