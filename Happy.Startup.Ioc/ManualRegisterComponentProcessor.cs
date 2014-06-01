using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Happy.Utils.Reflection;
using Happy.Ioc;

namespace Happy.Startup.Ioc
{
    /// <summary>
    /// 手工将组件注册到Ioc容器中。
    /// </summary>
    public sealed class ManualRegisterComponentProcessor : ITypeProcessor
    {
        private readonly IComponentRegistry _componentRegistry;

        /// <summary>
        /// 构造方法。
        /// </summary>
        public ManualRegisterComponentProcessor(IComponentRegistry componentRegistry)
        {
            Check.MustNotNull(componentRegistry, "componentRegistry");

            _componentRegistry = componentRegistry;
        }

        // <inheritdoc />
        public void Process(Type type)
        {
            if (!(typeof(IComponentManualRegister)).IsAssignableFrom(type))
            {
                return;
            }

            if (!type.IsConcreteType())
            {
                return;
            }

            type.CreateInstance<IComponentManualRegister>().Register(_componentRegistry);
        }
    }
}
