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
        public bool CanPlayCard(Card card, Player player, Player opponent, Deck deck, Card lastPlayedCard)
        {
            // Ví dụ: Kiểm tra xem thẻ có trong tay không
            if (!Hand.Contains(card))
            {
                Console.WriteLine("Thẻ không có trong tay.");
                return false;
            }
            if (card.Color == lastPlayedCard.Color || card.Value == lastPlayedCard.Value)
            {
                // Nếu cùng màu và khác số
                if (card.Color == lastPlayedCard.Color && card.Value != lastPlayedCard.Value)
                {
                    int valueDifference = Math.Abs(card.Value - lastPlayedCard.Value);
                    Console.WriteLine($"Sự khác biệt về số là {valueDifference}. Thực hiện hành động tương ứng.");
                    //switch (card.Color)
                    //{
                    //    case ColorCard.XANH:
                    //        // Ví dụ: chỉ có thể đánh thẻ màu xanh nếu đối phương có ít nhất 1 Money
                    //        if (opponent.Money < 1)
                    //        {
                    //            Console.WriteLine("Không thể đánh thẻ màu xanh vì đối phương không có đủ tiền.");
                    //            return false;
                    //        }
                    //        break;
                    //    case ColorCard.DO:
                    //        if (player.Money < card.Value)
                    //        {
                    //            Console.WriteLine("Không thể đánh thẻ này vì không có đủ tiền.");
                    //            return false;
                    //        }

                    //        break;
                    //}

                    // Nếu tất cả các điều kiện kiểm tra đều được thỏa mãn
                    return true;

                }
                return true;
            }
            else if (card.Color != lastPlayedCard.Color && card.Value == lastPlayedCard.Value)
            {
                // Nếu khác màu và cùng số
                return true;
            }
            else
            {
                Console.WriteLine("Thẻ không hợp lệ.");
                return false;
            }
            
        }
        public void PlayCard(Card card, Player opponent, Deck deck)
        {
            // Loại bỏ thẻ khỏi tay
            Hand.Remove(card);

            switch (card.Color)
            {
                case ColorCard.XANH:
                    // Lấy tiền của đối phương
                    int moneyToTake = Math.Min(card.Value, opponent.Money);
                    opponent.Money -= moneyToTake;
                    Money += moneyToTake;
                    break;
                case ColorCard.TIM:
                    // Rút số lá bài trên tay xuống, biến thành tiền
                    int cardsToConvert = Math.Min(card.Value, Hand.Count);
                    if (Hand.Count <= card.Value)
                    {
                        // Nếu số lượng bài trên tay nhỏ hơn hoặc bằng Value của card
                        // Loại bỏ tất cả các thẻ trừ thẻ DO
                        Hand = Hand.Where(c => c.Color == ColorCard.DO).ToList();
                    }
                    else
                    {
                        // Nếu số lượng bài trên tay lớn hơn Value của card
                        // Chuyển đổi số lượng thẻ tương ứng thành tiền
                        ConvertCardsToMoney(cardsToConvert);
                        // Loại bỏ số lượng thẻ tương ứng từ đầu danh sách
                        Hand.RemoveRange(0, cardsToConvert);
                    }
                    break;
                case ColorCard.VANG:
                    // Rút số lá bài từ deck về thành tiền bản thân theo số trên card
                    for (int i = 0; i < card.Value && deck.Cards.Count > 0; i++)
                    {
                        // Giả sử mỗi lần rút là 1 Money
                        deck.DrawCard(); 
                        Money++;
                    }
                    break;
                case ColorCard.LAM:
                    // Rút số lá bài từ deck về tay theo số trên card
                    for (int i = 0; i < card.Value && deck.Cards.Count > 0; i++)
                    {
                        Hand.Add(deck.DrawCard());
                    }
                    break;
                case ColorCard.DO:
                    break;
                case ColorCard.NONE:
                    break;
                default:
                    break;
            }
        }
        public void ConvertCardsToMoney(int amount)
        {
            // Giả sử mỗi thẻ có giá trị tương ứng với 'Value' của nó trong tiền tệ trò chơi
            // và 'amount' là số lượng thẻ mà người chơi muốn chuyển đổi.
            int totalMoney = 0;
            for (int i = 0; i < amount && Hand.Count > 0; i++)
            {
                Card card = Hand.First(); // Lấy thẻ đầu tiên trong tay
                totalMoney += card.Value; // Cộng giá trị thẻ vào tổng tiền
                Hand.Remove(card); // Xóa thẻ khỏi tay người chơi
            }

            Money += totalMoney; // Cập nhật số tiền của người chơi
        }
    }
}
