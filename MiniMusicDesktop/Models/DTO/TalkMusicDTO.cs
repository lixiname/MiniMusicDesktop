using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MiniMusicDesktop.Models.DTO
{
    public class TalkMusicDTO
    {
        [JsonProperty("musicId")]
        public long MusicId { get; set; }
        [JsonProperty("uploadUserId")]
        public long UploadUserId { get; set; }
        [JsonProperty("talkId")]
        public long TalkId { get; set; }
        [JsonProperty("contents")]
        public string Contents { get; set; }
        [JsonProperty("time")]
        public DateTime time { get; set; }
        [JsonProperty("agreedNum")]
        public int AgreedNum { get; set; }
    }
}
