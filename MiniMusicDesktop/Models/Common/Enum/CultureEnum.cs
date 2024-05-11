using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMusicDesktop.Models.Common.Enum
{
    public enum CultureEnum
    {
        
        
        [Description("简体中文")]
        zh_Hans = 0,
        [Description("繁体中文")]
        zh_HK = 1,
        [Description("英语")]
        en_US = 2,
        [Description("日语")]
        ja_JP = 3,
        [Description("法语")]
        fr_FR = 4,
        [Description("俄语")]
        ru_RU = 5,
    }
}
