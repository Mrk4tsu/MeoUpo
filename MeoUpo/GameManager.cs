using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeoUpo
{
    internal class GameManager
    {
        private Deck deck;
        private Player player;
        private AI ai;
        private List<CardAction> selectedActionCards = new List<CardAction>(); // Lưu trữ các thẻ hành động được chọn

        public GameManager()
        {
            deck = new Deck();
            player = new Player();
            ai = new AI();
            DistributeCards();
            DisplayCards(player, "Người chơi");
            DisplayCards(ai, "AI");
            DisplaySelectedActionCards(); // Hiển thị các thẻ hành động được lấy ra
        }
        private void DistributeCards()
        {
            // Phân phối 5 thẻ giá và 3 thẻ nợ cho mỗi người
            player.Hand.AddRange(deck.Cards.Where(c => c.Type == "Tài chính").Take(5));
            player.Hand.AddRange(deck.Cards.Where(c => c.Type == "Nợ").Take(3));
            deck.Cards.RemoveAll(c => player.Hand.Contains(c)); // Loại bỏ thẻ đã chia

            ai.Hand.AddRange(deck.Cards.Where(c => c.Type == "Tài chính").Take(5));
            ai.Hand.AddRange(deck.Cards.Where(c => c.Type == "Nợ").Take(3));
            deck.Cards.RemoveAll(c => ai.Hand.Contains(c));

            // Lấy ngẫu nhiên thẻ hành động
            selectedActionCards = deck.CardActions
                .Where(c => c.Price == 5).Take(6)
                .Concat(deck.CardActions.Where(c => c.Price == 7).Take(6))
                .Concat(deck.CardActions.Where(c => c.Price == 10).Take(2))
                .ToList();

            // Thêm 2 thẻ 'Tự do' vào danh sách thẻ hành động đã chọn
            selectedActionCards.AddRange(deck.CardActions.Where(c => c.Name.Contains("Tự do")));
        }
        private void DisplayCards(Player player, string playerName)
        {
            Console.WriteLine($"{playerName} có các thẻ sau:");
            foreach (var card in player.Hand)
            {
                Console.WriteLine($"Loại: {card.Type} - Màu: {card.Color} - Giá trị: {card.Value}");
            }
            Console.WriteLine(); // Thêm dòng trống cho dễ đọc
        }
        private void DisplaySelectedActionCards()
        {
            Console.WriteLine("Các thẻ hành động được lấy ra:");
            foreach (var actionCard in selectedActionCards)
            {
                Console.WriteLine(actionCard.ToString());
            }
            Console.WriteLine(); // Thêm dòng trống cho dễ đọc
        }
    }
}
