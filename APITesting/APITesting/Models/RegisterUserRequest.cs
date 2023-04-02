using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace APITesting.Models
{
    public class RegisterUserRequest
    {
        [JsonProperty(PropertyName = "email")]
        public string email { get; set; }
       
        [JsonProperty(PropertyName = "password")]
        public string password { get; set; }

        [JsonProperty(PropertyName = "username")]
        public string username { get; set; }


    }
}
