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
            Console.ReadKey();
        }
    }
}
