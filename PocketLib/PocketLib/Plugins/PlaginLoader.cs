using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PocketLib.Plugins
{
    public class PlaginLoader<T>
    {
        public IEnumerable<T> LoadPlugins(string path)
        {
            List<T> plugins = new List<T>();

            Type[] types = Assembly.LoadFile(path).GetExportedTypes();

            for (int i = 0; i < types.Length; i++)
            {
                Type type = types[i];
                if (typeof(T).IsAssignableFrom(type) && type.IsClass)
                    plugins.Add((T)Activator.CreateInstance(type));
            }

            return plugins;
        }

        public IEnumerable<Type> FindPlugins(string path)
        {
            List<Type> plugins = new List<Type>();

            Type[] types = Assembly.LoadFile(path).GetExportedTypes();

            for (int i = 0; i < types.Length; i++)
            {
                Type type = types[i];
                if (typeof(T).IsAssignableFrom(type) && type.IsClass)
                    plugins.Add(type);
            }

            return plugins;
        }

        public IEnumerable<T> LoadPlugins(Assembly assembly)
        {
            List<T> plugins = new List<T>();

            Type[] types = assembly.GetExportedTypes();

            for (int i = 0; i < types.Length; i++)
            {
                Type type = types[i];
                if (typeof(T).IsAssignableFrom(type) && type.IsClass)
                    plugins.Add((T)Activator.CreateInstance(type));
            }

            return plugins;
        }

        public IEnumerable<Type> FindPlugins(Assembly assembly)
        {
            List<Type> plugins = new List<Type>();

            Type[] types = assembly.GetExportedTypes();

            for (int i = 0; i < types.Length; i++)
            {
                Type type = types[i];
                if (typeof(T).IsAssignableFrom(type) && type.IsClass)
                    plugins.Add(type);
            }

            return plugins;
        }

        public IEnumerable<T> LoadPlugins(IEnumerable<Type> types)
        {
            List<T> plugins = new List<T>();

            Type[] temp = types.ToArray();

            for (int i = 0; i < temp.Length; i++)
            {
                Type type = temp[i];
                if (typeof(T).IsAssignableFrom(type) && type.IsClass)
                    plugins.Add((T)Activator.CreateInstance(type));
            }

            return plugins;
        }

        public IEnumerable<Type> FindPlugins(IEnumerable<Type> types)
        {
            List<Type> plugins = new List<Type>();

            Type[] temp = types.ToArray();

            for (int i = 0; i < temp.Length; i++)
            {
                Type type = temp[i];
                if (typeof(T).IsAssignableFrom(type) && type.IsClass)
                    plugins.Add(type);
            }

            return plugins;
        }

        public IEnumerable<T> LoadPlugins(string path, Func<Type, bool> predicate)
        {
            List<T> plugins = new List<T>();

            Type[] types = Assembly.LoadFile(path).GetExportedTypes();

            for (int i = 0; i < types.Length; i++)
            {
                Type type = types[i];
                if (typeof(T).IsAssignableFrom(type) && type.IsClass && predicate(type))
                    plugins.Add((T)Activator.CreateInstance(type));
            }

            return plugins;
        }

        public IEnumerable<Type> FindPlugins(string path, Func<Type, bool> predicate)
        {
            List<Type> plugins = new List<Type>();

            Type[] types = Assembly.LoadFile(path).GetExportedTypes();

            for (int i = 0; i < types.Length; i++)
            {
                Type type = types[i];
                if (typeof(T).IsAssignableFrom(type) && type.IsClass && predicate(type))
                    plugins.Add(type);
            }

            return plugins;
        }

        public IEnumerable<T> LoadPlugins(Assembly assembly, Func<Type, bool> predicate)
        {
            List<T> plugins = new List<T>();

            Type[] types = assembly.GetExportedTypes();

            for (int i = 0; i < types.Length; i++)
            {
                Type type = types[i];
                if (typeof(T).IsAssignableFrom(type) && type.IsClass && predicate(type))
                    plugins.Add((T)Activator.CreateInstance(type));
            }

            return plugins;
        }

        public IEnumerable<Type> FindPlugins(Assembly assembly, Func<Type, bool> predicate)
        {
            List<Type> plugins = new List<Type>();

            Type[] types = assembly.GetExportedTypes();

            for (int i = 0; i < types.Length; i++)
            {
                Type type = types[i];
                if (typeof(T).IsAssignableFrom(type) && type.IsClass && predicate(type))
                    plugins.Add(type);
            }

            return plugins;
        }

        public IEnumerable<T> LoadPlugins(IEnumerable<Type> types, Func<Type, bool> predicate)
        {
            List<T> plugins = new List<T>();

            Type[] temp = types.ToArray();

            for (int i = 0; i < temp.Length; i++)
            {
                Type type = temp[i];
                if (typeof(T).IsAssignableFrom(type) && type.IsClass && predicate(type))
                    plugins.Add((T)Activator.CreateInstance(type));
            }

            return plugins;
        }

        public IEnumerable<Type> FindPlugins(IEnumerable<Type> types, Func<Type, bool> predicate)
        {
            List<Type> plugins = new List<Type>();

            Type[] temp = types.ToArray();

            for (int i = 0; i < temp.Length; i++)
            {
                Type type = temp[i];
                if (typeof(T).IsAssignableFrom(type) && type.IsClass && predicate(type))
                    plugins.Add(type);
            }

            return plugins;
        }
    }
}