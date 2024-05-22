using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMusicDesktop.Models.DTO
{
    public class EmailInfo
    {
        [JsonProperty("emailRandomId")]
        public string EmailRandomId { get; set; }
    }
}
