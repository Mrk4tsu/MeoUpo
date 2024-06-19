using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeoUpo.CardPriceAction
{
    internal class DrawCardCommand : ICommand
    {
        private Player player;
        private Deck deck;

        public DrawCardCommand(Player player, Deck deck)
        {
            this.player = player;
            this.deck = deck;
        }
        public void perform()
        {
            try
            {
                Card drawnCard = deck.DrawCard();
                player.Hand.Add(drawnCard);
                Console.WriteLine($"Rút được thẻ: {drawnCard.Type} - {drawnCard.Color} - {drawnCard.Value}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
