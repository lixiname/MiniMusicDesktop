using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMusicDesktop.Models
{
    public class DownloadRelate
    {
        public long MusicId { get; set; }
        public long UserId { get; set; }
        public DateTime time { get; set; }
    }
}
