using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeoUpo
{
    internal class Run
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Khởi tạo trò chơi MeoUpo...");
            GameManager gameManager = new GameManager();
            Console.WriteLine("Trò chơi đã được khởi tạo. Các thẻ đã được phân phối và hiển thị.");
            bool gameRunning = true;
            while (gameRunning)
            {
                Console.WriteLine("Chọn hành động:");
                Console.WriteLine("1. Bốc bài");
                Console.WriteLine("2. Đánh bài");
                Console.WriteLine("Nhập số khác để thoát.");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        gameManager.PlayerDrawCard();
                        break;
                    case "2":
                        // Đánh bài
                        gameManager.PlayerPlayCard();
                        break;
                    default:
                        gameRunning = false;
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}
