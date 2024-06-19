using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeoUpo
{
    internal class Card
    {
        public ColorCard Color { get; set; }
        public int Value { get; set; }
        public string Type { get; set; }
        public Card() { }
        public Card(ColorCard color, int value, string type)
        {
            Color = color;
            Value = value;
            Type = type;
        }

    }
}
