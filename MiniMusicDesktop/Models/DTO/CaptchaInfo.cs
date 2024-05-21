using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMusicDesktop.Models.DTO
{
    public class CaptchaInfo
    {
        public CaptchaInfo() { }
        public string Id { get; set; }
        [JsonProperty("img")]
        public byte[] ArrayByteOfCaptchaImage { get; set; }

        public Stream ImageStream => new MemoryStream(ArrayByteOfCaptchaImage);
}
}
