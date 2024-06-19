using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MeoUpo
{
    internal class CardAction : Card
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Points { get; set; }
        public string ActionDescription { get; set; }
        public CardAction() { }
        public CardAction(string color, int value, string type, string name, int price, int points, string actionDescription) : base(color, value, type)
        {
            Name = name;
            Price = price;
            Points = points;
            ActionDescription = actionDescription;
        }
        public override string ToString()
        {
            return $"Hành Động: {Name} - Giá: {Price} - Điểm: {Points} - Mô tả: {ActionDescription}";
        }
    }
}
