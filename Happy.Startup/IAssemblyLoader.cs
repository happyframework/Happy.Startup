using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Startup
{
    /// <summary>
    /// 程序集加载器。
    /// </summary>
    public interface IAssemblyLoader
    {
        /// <summary>
        /// 执行插件前调用此方法加载程序集。
        /// </summary>
        void Load();
    }
}
