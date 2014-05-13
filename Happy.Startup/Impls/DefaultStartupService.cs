using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using Happy.Utils.Reflection;

namespace Happy.Startup.Impls
{
    internal sealed class DefaultStartupService : IStartupService
    {
        private bool _isStarted = false;
        private readonly List<Predicate<Assembly>> _filters = new List<Predicate<Assembly>>();
        private readonly List<IStartupPlugin> _plugins = new List<IStartupPlugin>();

        public IStartupService Include(Predicate<Assembly> filter)
        {
            Check.MustNotNull(filter, "filter");
            this.MustNotStarted();

            _filters.Add(filter);

            return this;
        }

        public IStartupService RegisterPlugin(IStartupPlugin plugin)
        {
            Check.MustNotNull(plugin, "plugin");
            this.MustNotStarted();

            _plugins.Add(plugin);

            return this;
        }

        public void Start()
        {
            this.MustNotStarted();

            var assemblies = this.GetParticipateInStartupAssemblies();

            foreach (var assembly in assemblies)
            {
                this.ExecutePlugs(assembly);
            }

            foreach (var assembly in assemblies)
            {
                this.ExecuteListeners(assembly);
            }
        }

        private List<Assembly> GetParticipateInStartupAssemblies()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                            .Where(this.CanParticipateInStartup).ToList();
        }

        private bool CanParticipateInStartup(Assembly assembly)
        {
            return assembly.IsDefined(typeof(ParticipateInStartupAttribute), false)
                   || _filters.Any(f => f(assembly));
        }

        private void ExecutePlugs(Assembly assembly)
        {
            foreach (var plug in _plugins)
            {
                plug.OnStarting(assembly);
            }
        }

        private void ExecuteListeners(Assembly assembly)
        {
            var listeners = assembly.CreateConcreteDescendentInstances<IStartupListener>();

            foreach (var listener in listeners)
            {
                listener.OnStarted();
            }
        }

        private void MustNotStarted()
        {
            if (!_isStarted)
            {
                return;
            }

            throw new InvalidOperationException(
                                Resource.Messages.Error_StartupServiceMustNotStarted);
        }
    }
}
