using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Startup
{
    /// <summary>
    /// 系统初始化器。
    /// </summary>
    public interface ISystemIniter
    {
        /// <summary>
        /// 在<see cref="IStartupPlugin"/>和<see cref="ITypeProcessor"/>之后执行此方法。
        /// </summary>
        void Init();
    }
}
