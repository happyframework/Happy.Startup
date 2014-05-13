using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Startup
{
    /// <summary>
    /// 标记程序集参与到启动过程中。
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
    public sealed class ParticipateInStartupAttribute : Attribute
    {
    }
}
