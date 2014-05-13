using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Startup
{
    /// <summary>
    /// 启动监听者，当启动服务执行完所有插件以后，就会执行所有的启动监听者。
    /// </summary>
    public interface IStartupListener
    {
        /// <summary>
        /// 插件执行完后执行的逻辑。
        /// </summary>
        void OnStarted();
    }
}
