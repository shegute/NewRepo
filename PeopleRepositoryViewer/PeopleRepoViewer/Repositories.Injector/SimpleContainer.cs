using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Repositories.Injector
{
    public class SimpleContainer
    {
        public static T GetRepoFromConfig<T>() where T : class
        {
            string type = ConfigurationManager.AppSettings[typeof(T).ToString()];
            if (string.IsNullOrEmpty(type))
                return null;

            Type repoType = Type.GetType(type);
            object repoInstance = Activator.CreateInstance(repoType);
            T repo = repoInstance as T;
            return repo;
        }


        public static Dictionary<Type, object> catalog = new Dictionary<Type, object>();

        public static void MapInstance<T>(object concreteType)
        {
            Type instanceType = typeof(T);
            if (catalog.ContainsKey(instanceType))
                catalog.Remove(instanceType);
            catalog.Add(instanceType, concreteType);
        }

        public static T Get<T>() where T : class
        {
            T instance = GetInstanceFromCatalog<T>();
            if (instance == null)
            {
                //or we can do this in an initializer. ie. , 
                //mapping each interface to a concrete class before they are used.
                instance = GetRepoFromConfig<T>();
                MapInstance<T>(instance);
            }
            return instance;
        }

        private static T GetInstanceFromCatalog<T>() where T : class
        {
            object instance;
            catalog.TryGetValue(typeof(T), out instance);
            return instance as T;             
        }
    }
}
