using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMusicDesktop.Models.DTO
{
    public class MusicAgreedTopSortDTO
    {
        public long MusicId { get; set; }

        public string MusicName { get; set; }

        public int Count { get; set; }

        public int Day { get; set; }

    }
}
