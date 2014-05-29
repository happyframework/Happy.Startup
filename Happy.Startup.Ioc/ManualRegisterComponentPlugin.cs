using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Happy.Ioc;

namespace Happy.Startup.Ioc
{
    /// <summary>
    /// 手工将组件注册到Ioc容器中。
    /// </summary>
    public sealed class ManualRegisterComponentPlugin : IStartupPlugin
    {
        private readonly IComponentRegistry _componentRegistry;

        /// <summary>
        /// 构造方法。
        /// </summary>
        public ManualRegisterComponentPlugin(IComponentRegistry componentRegistry)
        {
            Check.MustNotNull(componentRegistry, "componentRegistry");

            _componentRegistry = componentRegistry;
        }

        // <inheritdoc />
        public void OnStarting(StartupContext context)
        {
            _componentRegistry.ManualRegister(context.Assemblies);
        }
    }
}
