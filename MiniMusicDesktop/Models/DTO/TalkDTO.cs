using MiniMusicDesktop.Models.Common.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMusicDesktop.Models.DTO
{
    public class TalkDTO
    {
        public long MusicId { get; set; }
        public string MusicName { get; set; }
        public long UploadUserId { get; set; }

        public long TalkId { get; set; }
        public string TalkUId { get; set; }

        public string Contents { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public UserStateEnum State { get; set; }

    }
}
