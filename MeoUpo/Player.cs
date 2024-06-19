using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeoUpo
{
    internal class Player
    {
        public List<Card> Hand { get; set; } = new List<Card>();
        public int Money { get; set; }
        public int Points { get; set; }
        public Player()
        {
            Hand = new List<Card>();
            Money = 0;
            Points = 0;
        }

    }
}
