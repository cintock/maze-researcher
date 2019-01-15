﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maze.Implementation;

namespace Maze.UI
{
    internal abstract class ObjectsDescription<Index, T> where Index: struct
    {
        private Dictionary<Index, NamedObject<T>> indexedNamedObjects =
            new Dictionary<Index, NamedObject<T>>();

        public ObjectsDescription()
        {
            RegisterObjects();
        }

        protected abstract void RegisterObjects();

        protected void RegisterObject(Index index, 
            T drawer, String userFriendlyName)
        {
            NamedObject<T> obj = new NamedObject<T>(drawer, userFriendlyName);
            indexedNamedObjects.Add(index, obj);
        }

        public T GetObject(Index index)
        {            
            return indexedNamedObjects[index].ObjectValue;
        }

        public T GetObject(Int32 index)
        {
            return indexedNamedObjects.ElementAt(index).Value.ObjectValue;
        }

        public List<String> GetNamesList()
        {
            List<String> names = new List<String>();
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