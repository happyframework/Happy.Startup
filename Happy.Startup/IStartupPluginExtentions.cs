using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Startup
{
    /// <summary>
    /// 扩展<see cref="IStartupPlugin"/>。
    /// </summary>
    public static class IStartupPluginExtentions
    {
        /// <summary>
        /// 配置完成，返回<see cref="IStartupService"/>实例。
        /// </summary>
        public static IStartupService Done(this IStartupPlugin that)
        {
            Check.MustNotNull(that, "that");

            return StartupService.Current;
        }
    }
}
