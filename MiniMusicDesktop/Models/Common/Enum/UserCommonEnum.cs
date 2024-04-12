using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMusicDesktop.Models.Common.Enum
{
    public class UserCommonEnum
    {
    }

    public enum UserStateEnum
    {
        [Description("禁用")]
        InValid = 0,

        [Description("正常")]
        Valid = 1,
    }
}
