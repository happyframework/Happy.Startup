using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Happy.Ioc;

namespace Happy.Startup.Ioc
{
    /// <summary>
    /// 自动将组件注册到Ioc容器中。
    /// </summary>
    public sealed class AutoRegisterComponentPlugin : IStartupPlugin
    {
        private readonly IComponentRegistry _componentRegistry;

        public AutoRegisterComponentPlugin(IComponentRegistry componentRegistry)
        {
            Check.MustNotNull(componentRegistry, "componentRegistry");

            _componentRegistry = componentRegistry;
        }

        // <inheritdoc />
        public void OnStarting(StartupContext context)
        {
            _componentRegistry.AutoRegister(context.Assemblies);
        }
    }
}
