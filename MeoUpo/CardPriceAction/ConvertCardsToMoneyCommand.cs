using System;

namespace MeoUpo.CardPriceAction
{
    internal class ConvertCardsToMoneyCommand : ICommand
    {
        private Player player;
        private Deck deck;

        public ConvertCardsToMoneyCommand(Player player, Deck deck)
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
