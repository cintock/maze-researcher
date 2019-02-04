using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.UI
{
    internal class ComboboxValues<EnumType>
        where EnumType : struct
    {
        private List<EnumType> values = new List<EnumType>();
        private Dictionary<EnumType, string> elements = new Dictionary<EnumType, string>();

        public ComboboxValues()
        {
        }

        public void AddElement(EnumType value, string name)
        {
            values.Add(value);
            elements.Add(value, name);
        }

        public string[] Names()
        {
            return elements.Values.ToArray();
        }

        public EnumType ValueByIndex(int index)
        {
            return values[index];
        }

        public int IndexByValue(EnumType value)
        {
            return values.IndexOf(value);
        }
    }
}
