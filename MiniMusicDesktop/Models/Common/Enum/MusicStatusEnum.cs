using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMusicDesktop.Models.Common.Enum
{
    public enum MusicStatusEnum
    {
        [Description("开始")]
        Start = 0,
        [Description("初始化")]
        Init = 1,
        [Description("暂停")]
        Pause = 2,
        [Description("继续")]
        Restart = 3,

        
    }
}
