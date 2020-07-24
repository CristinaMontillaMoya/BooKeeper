

namespace BooKeeper.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Newtonsoft.Json;

    public class Root
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("sale")]
        public Sale Sale { get; set; }

        [JsonProperty("isbn")]
        public Book Isbn { get; set; }

    }

}
