using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class updateEnterCommand:Command
    {
        public updateEnterCommand()
        {

        }

        public override void Execute(float executeTime)
        {

            InputManager.ResetHandled();
            TimerManager.Pause();
        }
    }
}
