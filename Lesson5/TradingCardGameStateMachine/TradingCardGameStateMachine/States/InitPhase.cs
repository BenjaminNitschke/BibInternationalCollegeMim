using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingCardGameStateMachine.States
{
    public class InitPhase : State
    {
        private Player player;

        public InitPhase(Player player)
        {
            this.player = player;
        }

        public void EnterState()
        {
            
        }

        public void ExitState()
        {
            player = null;
        }

        public void UpdateState()
        {
            
        }
    }
}
