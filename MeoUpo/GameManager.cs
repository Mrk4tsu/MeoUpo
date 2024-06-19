using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

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
            DisplayStartingCard(); // Hiển thị lá bắt đầu
            DisplayCards(player, "Người chơi");
            DisplayCards(ai, "AI");
            DisplaySelectedActionCards(); // Hiển thị các thẻ hành động được lấy ra
            
        }
        // Phương thức cho phép người chơi bốc bài
        public void PlayerDrawCard()
        {
            if (deck.Cards.Count > 0) // Kiểm tra xem bộ bài còn thẻ không
            {
                Card drawnCard = deck.DrawCard(); // Bốc một thẻ từ bộ bài
                if (drawnCard != null)
                {
                    player.Hand.Add(drawnCard); // Thêm thẻ vào tay người chơi
                                                // Hiển thị thông tin thẻ
                    Console.WriteLine($"Người chơi đã bốc được thẻ: Loại - {drawnCard.Type}, Màu - {drawnCard.Color}, Giá trị - {drawnCard.Value}");
                }
            }
            else
            {
                Console.WriteLine("Bộ bài đã hết thẻ.");
            }
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
        public void PlayerPlayCard()
        {
            // Giả sử người chơi chọn thẻ thông qua một giao diện người dùng hoặc đầu vào từ bàn phím
            Console.WriteLine("Chọn thẻ để đánh (nhập chỉ số thẻ):");
            for (int i = 0; i < player.Hand.Count; i++)
            {
                Card card = player.Hand[i];
                Console.WriteLine($"{i}: Loại - {card.Type}, Màu - {card.Color}, Giá trị - {card.Value}");
            }

            int cardIndex;
            if (int.TryParse(Console.ReadLine(), out cardIndex) && cardIndex >= 0 && cardIndex < player.Hand.Count)
            {
                Card selectedCard = player.Hand[cardIndex];
                // Sử dụng phương thức CanPlayCard để kiểm tra xem thẻ có thể đánh không
                if (player.CanPlayCard(selectedCard, player, ai, deck, deck.StartingCard)) // Sử dụng đối tượng AI như là đối thủ
                {
                    // Cập nhật StartingCard trong deck với thẻ mới được chơi
                    deck.UpdateStartingCard(selectedCard);
                    player.PlayCard(selectedCard, ai, deck); // Đánh thẻ với AI như là đối thủ
                    Console.WriteLine($"Đã đánh thẻ: Loại - {selectedCard.Type}, Màu - {selectedCard.Color}, Giá trị - {selectedCard.Value}");
                }
                else
                {
                    Console.WriteLine("Không thể đánh thẻ này.");
                }
            }
            else
            {
                Console.WriteLine("Lựa chọn không hợp lệ.");
            }
        }
    
    private void DisplayCards(Player player, string playerName)
        {
            Console.WriteLine($"{playerName} có các thẻ sau:");
            foreach (var card in player.Hand)
            {
                string colorName = Enum.GetName(typeof(ColorCard), card.Color);
                Console.WriteLine($"Loại: {card.Type} - Màu: {colorName} - Giá trị: {card.Value}");
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
        private void DisplayStartingCard()
        {
            Console.WriteLine("Lá bắt đầu:");
            if (deck.StartingCard != null)
            {
                string colorName = Enum.GetName(typeof(ColorCard), deck.StartingCard.Color);
                Console.WriteLine($"Loại: {deck.StartingCard.Type} - Màu: {colorName} - Giá trị: {deck.StartingCard.Value}");
            }
            else
            {
                Console.WriteLine("Không có lá bắt đầu.");
            }
            Console.WriteLine(); // Thêm dòng trống cho dễ đọc
        }
    }
}
