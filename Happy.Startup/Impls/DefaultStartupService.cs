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
        private readonly List<IAssemblyLoader> _loaders = new List<IAssemblyLoader>();
        private readonly List<IStartupPlugin> _plugins = new List<IStartupPlugin>();
        private readonly List<ITypeProcessor> _processors = new List<ITypeProcessor>();

        public IStartupService Include(Predicate<Assembly> filter)
        {
            Check.MustNotNull(filter, "filter");
            this.MustNotStarted();

            _filters.Add(filter);

            return this;
        }

        public IStartupService RegisterLoader(IAssemblyLoader loader)
        {
            Check.MustNotNull(loader, "loader");
            _loaders.Add(loader);

            return this;
        }

        public IStartupService RegisterPlugin(IStartupPlugin plugin)
        {
            Check.MustNotNull(plugin, "plugin");
            this.MustNotStarted();

            _plugins.Add(plugin);

            return this;
        }

        public IStartupService RegisterProcessor(ITypeProcessor processor)
        {
            Check.MustNotNull(processor, "processor");
            this.MustNotStarted();

            _processors.Add(processor);

            return this;
        }

        public void Start()
        {
            this.MustNotStarted();

            _loaders.ForEach(x => x.Load());

            var assemblies = this.GetParticipateInStartupAssemblies();

            var context = new StartupContext(assemblies);
            foreach (var plug in _plugins)
            {
                plug.OnStarting(context);
            }

            foreach (var type in assemblies.SelectMany(x => x.GetTypes()))
            {
                foreach (var processor in _processors)
                {
                    processor.Process(type);
                }
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
