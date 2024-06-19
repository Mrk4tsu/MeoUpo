using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeoUpo.CardActs
{
    internal class MarryActionCommand : IActionCommand
    {
        private readonly Player _player;
        private readonly AI _ai;
        public MarryActionCommand(Player player, AI ai)
        {
            _player = player;
            _ai = ai;
        }
        public void perform()
        {
            _player.Points += 10;
            _player.Money -= 5;
        }
    }
}
