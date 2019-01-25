using System.Collections.Generic;
using System.Linq;

namespace Maze.UI
{
    internal abstract class ObjectsDescription<Index, T> where Index: struct
    {
        private Dictionary<Index, NamedObject<T>> indexedNamedObjects =
            new Dictionary<Index, NamedObject<T>>();

        public ObjectsDescription()
        {
        }

        protected void RegisterObject(Index index, 
            T obj, string userFriendlyName)
        {
            NamedObject<T> namedObject = new NamedObject<T>(obj, userFriendlyName);
            indexedNamedObjects.Add(index, namedObject);
        }

        public T GetObject(Index index)
        {            
            return indexedNamedObjects[index].ObjectValue;
        }

        public T GetObject(int index)
        {
            return indexedNamedObjects.ElementAt(index).Value.ObjectValue;
        }

        public List<string> GetNamesList()
        {
            List<string> names = new List<string>();
            foreach (NamedObject<T> obj in indexedNamedObjects.Values)
            {
                names.Add(obj.Name);
            }

            return names;
        }

        public List<NamedObject<T>> GetNamedObjectsList()
        {
            List<NamedObject<T>> namedObjects = new List<NamedObject<T>>();
            foreach (NamedObject<T> obj in indexedNamedObjects.Values)
            {
                namedObjects.Add(obj);
            }

            return namedObjects;
        }
    }
}
