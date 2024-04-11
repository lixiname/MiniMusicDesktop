using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMusicDesktop.Models.Common
{
    public enum LoginStateEnum
    {
        [Description("登录")]
        Login = 1,

        [Description("离线")]
        Remove = 0,
    }
    public enum InfoTypeEnum
    {
        [Description("用户")]
        User = 0,

        [Description("管理员")]
        ManagmentUser = 1,

        [Description("空")]
        NullUser = 2,
    }
}
