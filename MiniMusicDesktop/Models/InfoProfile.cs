using MiniMusicDesktop.Models.Common;
using MiniMusicDesktop.Models.Common.Enum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMusicDesktop.Models
{
    public class InfoProfile
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; } = string.Empty;
        public InfoTypeEnum InfoTypes { get; set; } = InfoTypeEnum.NullUser;
        public LoginStateEnum LoginSuccess { get; set; } = LoginStateEnum.Remove;
        [JsonProperty("email")]
        public string? Email { get; set; }
        [JsonProperty("phone")]
        public string? Phone { get; set; }
        [JsonProperty("profilePictureUrl")]
        public string? ProfilePictureUrl { get; set; }
        [JsonProperty("name")]
        public string? Name { get; set; }
        [JsonProperty("userId")]
        public string? UserId { get; set; }
        [JsonProperty("state")]
        public UserStateEnum State { get; set; }
    }
}
