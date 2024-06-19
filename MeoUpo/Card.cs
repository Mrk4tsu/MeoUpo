using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeoUpo
{
    internal class Card
    {
        public string Color { get; set; }
        public int Value { get; set; }
        public string Type { get; set; }
        public Card() { }
        public Card(string color, int value, string type)
        {
            Color = color;
            Value = value;
            Type = type;
        }

    }
}
