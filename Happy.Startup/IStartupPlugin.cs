using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

namespace Happy.Startup
{
    /// <summary>
    /// 启动插件。
    /// </summary>
    public interface IStartupPlugin
    {
        /// <summary>
        /// 当启动时，插件的处理逻辑。
        /// </summary>
        void OnStarting(StartupContext context);
    }
}
