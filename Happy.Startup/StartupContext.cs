using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

namespace Happy.Startup
{
    /// <summary>
    /// 启动上下文。
    /// </summary>
    public sealed class StartupContext
    {
        internal StartupContext(IEnumerable<Assembly> assemblies)
        {
            Check.MustNotNull(assemblies, "assemblies");

            this.Assemblies = assemblies;
        }

        /// <summary>
        /// 参与启动的所有程序集。
        /// </summary>
        public IEnumerable<Assembly> Assemblies { get; private set; }
    }
}
