using System.Collections.Generic;
using PluginArchitecture.DefaultPlugin;

namespace PluginArchitecture
{
    internal class PluginHostProvider
    {
        private static List<PluginHost> _greetings;

        public static List<PluginHost> Greetings
        {
            get
            {
                if (_greetings == null)
                {
                    Reload();
                }

                return _greetings;
            }
        }

        private static void Reload()
        {
            if (_greetings == null)
            {
                _greetings = new List<PluginHost>();
            }
            else
            {
                _greetings.Clear();
            }

            // Load default plugin
            _greetings.Add(new PluginHost());

            // Get all plugins
            var assemblies = PluginsLoader.LoadPluginAssemblies();
            var plugins = PluginsLoader.GetPlugins(assemblies);

            foreach (var plugin in plugins)
            {
                _greetings.Add(new PluginHost(plugin));
            }
        }

    }
}
