using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Startup
{
    /// <summary>
    /// 类型处理器。
    /// </summary>
    public interface ITypeProcessor
    {
        /// <summary>
        /// 启动后，会对每个类型执行此方法。
        /// </summary>
        void Process(Type type);
    }
}
