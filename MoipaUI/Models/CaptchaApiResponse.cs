using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MoipaUI.Models
{
    public class CaptchaApiResponse<T>
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("data")]
        public T Data { get; set; }
    }
}
