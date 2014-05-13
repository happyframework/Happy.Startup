using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Happy.Startup
{
    /// <summary>
    /// 启动服务接口，负责程序的启动。
    /// </summary>
    public interface IStartupService
    {
        /// <summary>
        /// 添加程序集过滤器，符合过滤器规则的程序集才会被<see cref="IStartupPlugin"/>处理。
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        IStartupService Include(Predicate<Assembly> filter);

        /// <summary>
        /// 添加<see cref="IStartupPlugin"/>，可以使用多个<see cref="IStartupPlugin"/>，必须
        /// 在启动前调用此方法。
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        IStartupService RegisterPlugin(IStartupPlugin plugin);

        /// <summary>
        /// 启动。
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        void Start();
    }
}
