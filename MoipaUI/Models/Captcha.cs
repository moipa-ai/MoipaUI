using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MoipaUI.Models
{
    public class Captcha
    {
        [JsonPropertyName("img")]
        public string ImageBase64 { get; set; }
        [JsonPropertyName("key")]
        public string Key { get; set; }
    }
}
