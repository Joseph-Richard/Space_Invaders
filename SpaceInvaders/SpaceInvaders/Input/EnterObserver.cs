using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class EnterObserver:InputObserver
    {
        
        private int pressCount;
        private Boolean handled; 
        public EnterObserver()
        {
            this.pressCount = 0;
            this.handled = false;
        }

        public EnterObserver(EnterObserver e)
        {
            this.handled = e.handled;
        }
        public override void Notify()
        {
            pressCount += 1;

                Player currentPlayer = PlayerManager.getCurrentPlayer();
                if (currentPlayer.gameState == Player.GameState.Select)
                {
                    PlayerManager.SelectToGame();
                    TimerManager.Play();
                }
                else if (currentPlayer.gameState == Player.GameState.GameOver )
                {
                   // InputManager.HandleEnter();
                    //this.handled = true;
                    PlayerManager.EndToSelect();
                  //  DelayedManager.attachObserver(new EnterObserver(this));
                    
                    
                }
        }

        public override void Execute()
        {
            Command updateEnter = new updateEnterCommand();
            TimerManager.Add(TimerEvent.Name.UpdateEnter, 1.0f, updateEnter);
            TimerManager.Play();
            
        }
        
    }
}
