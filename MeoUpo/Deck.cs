using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeoUpo
{
    internal class Deck
    {
        public List<Card> Cards { get; set; } = new List<Card>();
        public List<CardAction> CardActions { get; set; } = new List<CardAction>();
        public Deck()
        {
            InitPriceCard();
            InitActionCard();
            InitDebtCard();
            Shuffle();
        }
        private void InitPriceCard()
        {
            string[] colors = { "xanh", "tím", "vàng", "lam" };
            foreach (var c in colors)
            {
                for (int i = 1; i <= 5; i++)
                {
                    // Mỗi giá trị có 4 thẻ
                    for (int j = 0; j < 4; j++)
                    {
                        Cards.Add(new Card(c, i, "Tài chính"));
                    }
                }
            }
        }
        private void InitDebtCard()
        {
            for (int value = 1; value <= 5; value++)
            {
                for (int i = 0; i < 3; i++) // Mỗi giá trị có 3 thẻ nợ
                {
                    Cards.Add(new Card("đỏ", value, "Nợ"));
                }
            }
        }
        private void InitActionCard()
        {
            List<CardAction> tempActions = new List<CardAction>
            {
                new CardAction(null, 0, "Hành Động", name: "Kết hôn", price: 5, points: 10, "Sau khi mua lá này, nhận tiền bằng số tiền bạn đang sở hữu"),
                new CardAction(null, 0, "Hành Động", name: "Em bé", price: 5, points: 12, "Ở cuối mỗi trò chơi, mỗi lá Nợ của bạn sẽ trừ 5 điểm thay vì 3"),
                new CardAction(null, 0, "Hành Động", name: "Heo đất", price: 5, points: 7, "Mỗi khi trả nợ, bạn tốn ít hơn 1 tiền"),
                new CardAction(null, 0, "Hành Động", name: "Bảo hiểm", price: 5, points: 7, "Mỗi khi đánh lá xanh dương bạn được rút thêm 3 lá từ chồng bài"),
                new CardAction(null, 0, "Hành Động", name: "Công ty", price: 7, points: 10, "Mỗi khi bạn đánh lá vàng, bạn được nhận thêm 2 tiền"),
                new CardAction(null, 0, "Hành Động", name: "Nổi tiếng", price: 7, points: 10, "Một lần duy nhất, giảm 3 tiền khi mua lá hành động"),
                new CardAction(null, 0, "Hành Động", name: "Khách sạn", price: 7, points: 10, "Mỗi lần đánh trùng số, bạn nhận thêm 1 điểm"),
                new CardAction(null, 0, "Hành Động", name: "Máy bay", price: 7, points: 5, "Mỗi lượt bạn có thể đánh 2 lá liên tiếp"),
                new CardAction(null, 0, "Hành Động", name: "Từ thiện", price: 7, points: 10, "Sau khi mua lá bài này, lập tức bỏ 1 lá bài nợ bất kì trên tay"),
                new CardAction(null, 0, "Hành Động", name: "Nhà", price: 7, points: 10, "Mỗi khi đánh lá xanh dương bạn được hạ thêm 3 lá từ chồng bài trên tay"),
                new CardAction(null, 0, "Hành Động", name: "Hạnh phúc", price: 10, points: 15, "Ở cuối mỗi trò chơi, mỗi lá hành động khác sẽ được cộng thêm 3 điểm"),
                new CardAction(null, 0, "Hành Động", name: "Nghỉ dưỡng", price: 10, points: 15, "Ở cuối trò chơi, mỗi lá tài chính trên tay sẽ không bị trừ điểm"),
            };

            // Xáo trộn danh sách tempActions
            Shuffle(tempActions);

            // Xử lý cho thẻ giá 5 tiền
            var selectedActions5 = tempActions.Where(a => a.Price == 5).Take(3).ToList();
            foreach (var action in selectedActions5)
            {
                CardActions.Add(action);
                CardActions.Add(new CardAction(action.Color, action.Value, action.Type, action.Name, action.Price, action.Points, action.ActionDescription));
            }

            // Xử lý cho thẻ giá 7 tiền
            var selectedActions7 = tempActions.Where(a => a.Price == 7).Take(3).ToList();
            foreach (var action in selectedActions7)
            {
                CardActions.Add(action);
                CardActions.Add(new CardAction(action.Color, action.Value, action.Type, action.Name, action.Price, action.Points, action.ActionDescription));
            }

            // Xử lý cho thẻ giá 10 tiền
            var selectedAction10 = tempActions.Where(a => a.Price == 10).Take(1).ToList();
            foreach (var ac in selectedAction10)
            {
                CardActions.Add(ac);
                CardActions.Add(new CardAction(ac.Color, ac.Value, ac.Type, ac.Name, ac.Price, ac.Points, ac.ActionDescription));
            }

            CardActions.Add(new CardAction(null, 0, "Hành Động", name: "Tự do 1", price: 99, points: 10, "Người đầu tiên trả nợ xong sẽ lập tức nhận thẻ này"));
            CardActions.Add(new CardAction(null, 0, "Hành Động", name: "Tự do 2", price: 99, points: 5, "Người thứ 2 trả nợ xong sẽ lập tức nhận thẻ này"));

            CardActions.Sort((action1, action2) => action1.Name.CompareTo(action2.Name));
        }

        public void Shuffle()
        {
            Random rng = new Random();
            Cards = Cards.OrderBy(a => rng.Next()).ToList();// Xáo trộn thẻ tài chính
            CardActions = CardActions.OrderBy(a => rng.Next()).ToList(); // Xáo trộn thẻ hành động
        }
        private void Shuffle<T>(IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
