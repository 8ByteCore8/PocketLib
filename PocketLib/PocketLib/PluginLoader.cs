//C#
//© Кушнір Б.T. , 2018
using System;
using System.Collections.Generic;
using System.Reflection;

namespace PocketLib
{
    public static class PluginLoader
    {
        public static TPligin[] Load<TPligin>(Assembly assembly)
        {
            List<TPligin> plugins = new List<TPligin>();
            foreach (Type type in assembly.GetTypes())
                if (type.IsClass && typeof(TPligin).IsAssignableFrom(type))
                    plugins.Add((TPligin)Activator.CreateInstance(type));

            return plugins.ToArray();
        }

        public static TPligin[] Load<TPligin>(string path) => Load<TPligin>(Assembly.LoadFile(path));

        public static TPligin[] Load<TPligin>(byte[] bytes) => Load<TPligin>(Assembly.Load(bytes));

        public static TPligin[] Load<TPligin>(Type type) => Load<TPligin>(type.Assembly);

        public static TPligin[] Load<TPligin, TSource>() => Load<TPligin>(typeof(TSource).Assembly);
    }
}