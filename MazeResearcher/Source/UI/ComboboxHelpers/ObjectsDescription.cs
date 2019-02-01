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

        public T GetObject(Index enumIndex)
        {            
            return indexedNamedObjects[enumIndex].ObjectValue;
        }

        public T GetObject(int numIndex)
        {
            return indexedNamedObjects.ElementAt(numIndex).Value.ObjectValue;
        }

        public int GetNumIndexByEnumIndex(Index enumIndex)
        {
            bool found = false;
            int count = 0;
            foreach (Index currIndex in indexedNamedObjects.Keys)
            {
                if (enumIndex.Equals(currIndex))
                {
                    found = true;
                    break;
                }
                count++;
            }
            return found ? count : -1;
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
