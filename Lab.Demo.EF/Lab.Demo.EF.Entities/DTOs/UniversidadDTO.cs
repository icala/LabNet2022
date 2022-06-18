using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab.Demo.EF.Entities.DTOs
{
    public class UniversidadDTO
    {
        public List<string> domains { get; set; }
        public List<string> web_pages { get; set; }

        [JsonProperty("state-province")]
        public string StateProvince { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public string alpha_two_code { get; set; }
    }
}