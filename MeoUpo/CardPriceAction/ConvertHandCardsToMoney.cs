using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeoUpo.CardPriceAction
{
    internal class ConvertHandCardsToMoney : ICommand
    {
        private Player player;
        private Deck deck;

        public ConvertHandCardsToMoney(Player player, Deck deck)
        {
            this.player = player;
            this.deck = deck;
        }
        public void perform()
        {
            throw new NotImplementedException();
        }
    }
}
