using System;
using System.Collections.Generic;
using System.Reflection;

namespace PocketLib.Plugins
{
    public class PluginManager<T> where T : class
    {
        public T[] Plugins { get; private set; }

        public T GetFirst(Func<T, bool> predicate)
        {
            for (int i = 0; i < Plugins.Length; i++)
                if (predicate(Plugins[i]))
                    return Plugins[i];

            return null;
        }

        public IEnumerable<T> GetAll(Func<T, bool> predicate)
        {
            List<T> temp = new List<T>(0);

            for (int i = 0; i < Plugins.Length; i++)
                if (predicate(Plugins[i]))
                    temp.Add(Plugins[i]);

            return temp;
        }

        public IEnumerator<T> Get(Func<T, bool> predicate)
        {
            for (int i = 0; i < Plugins.Length; i++)
                if (predicate(Plugins[i]))
                    yield return Plugins[i];
        }

        public void Load(string path)
        {
            List<T> plugins = new List<T>();

            Type[] types = Assembly.LoadFile(path).GetExportedTypes();

            for (int i = 0; i < types.Length; i++)
            {
                Type type = types[i];
                if (typeof(T).IsAssignableFrom(type) && type.IsClass)
                    plugins.Add((T)Activator.CreateInstance(type));
            }

            Plugins = plugins.ToArray();
        }
    }
}
