using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMusicDesktop.Models
{
    public class CollectRelate
    {
        public long MusicId { get; set; }
        public long UserId { get; set; }
        public DateTime time { get; set; }
    }
}
