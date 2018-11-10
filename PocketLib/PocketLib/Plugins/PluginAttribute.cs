using System;
using System.Text.RegularExpressions;

namespace PocketLib.Plugins
{
    public class PluginAttribute:Attribute
    {
        public PluginAttribute(string name, string version, string module, string displayName, bool visible)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Version = version ?? throw new ArgumentNullException(nameof(version));
            if (!new Regex(@"^\d+\.\d+\.\d+\.\d+$").IsMatch(version))
                throw new Exceptions.FormatException("Invalid Version format (0.0.0.0 or 12.423.34.0)");
            Module = module ?? throw new ArgumentNullException(nameof(module));
            DisplayName = displayName ?? throw new ArgumentNullException(nameof(displayName));
            Visible = visible;
        }

        public string Name { get; }
        public string Version { get; }
        public string Module { get; }
        public string DisplayName { get; }
        public bool Visible { get; }
    }
}
