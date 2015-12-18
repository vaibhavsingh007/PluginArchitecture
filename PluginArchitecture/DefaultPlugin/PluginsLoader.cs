using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Greeting;
using Greeting.Interface;

namespace PluginArchitecture.DefaultPlugin
{
    internal static class PluginsLoader
    {
        public static List<Assembly> LoadPluginAssemblies()
        {
            List<Assembly> pluginAssemblies = new List<Assembly>();
            DirectoryInfo dirInfo = new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, "Plugins"));
            var files = dirInfo.GetFiles("*.dll");

            if (files.Length > 0)
            {
                pluginAssemblies.AddRange(files.Select(file => Assembly.LoadFile(file.FullName)));
            }

            return pluginAssemblies;
        }

        public static List<IGreeting> GetPlugins(List<Assembly> assemblies)
        {
            List<Type> availableTypes = new List<Type>();

            // Extract all Types from assemblies
            foreach (var assembly in assemblies)
            {
                availableTypes.AddRange(assembly.GetTypes());
            }

            // Extract interfaces and custom attributes from Types
            var greetingsList = availableTypes.FindAll(t =>
            {
                var interfaces = t.GetInterfaces();
                var attribs = t.GetCustomAttributes<GreetingsPluginAttribute>();

                // Filter
                return !(attribs == null || !attribs.Any()) && interfaces.Contains(typeof (IGreeting));
            });

            // Activate/Instantiate
            return greetingsList.ConvertAll(t => Activator.CreateInstance(t) as IGreeting);
        }
    }
}
