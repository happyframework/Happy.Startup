using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Happy.Startup.Impls;

namespace Happy.Startup
{
    /// <summary>
    /// 启动服务的单一入口。
    /// </summary>
    public static class StartupService
    {
        private static readonly IStartupService _Current = new DefaultStartupService();

        /// <summary>
        /// 启动服务。
        /// </summary>
        public static IStartupService Current
        {
            get { return _Current; }
        }
    }
}
