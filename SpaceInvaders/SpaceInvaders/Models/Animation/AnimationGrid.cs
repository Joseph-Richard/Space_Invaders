using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class AnimationGrid:Command
    {
        private Grid grid;


        public AnimationGrid(Alien.Name name):base()
        {
         //   Debug.WriteLine("AnimationGrid Constructor Method was called.");
            this.grid = (Grid)GameObjectManager.Find(name);
            Debug.Assert(this.grid != null);
            this.spriteTest = this.grid.proxySprite.pSprite;
        }


        /**
         * AnimationSprite Attach Method
         * */
        public void Attach(Alien.Name name)
        {
          //  Debug.WriteLine("AnimationGrid Attach Method was called.");
            this.grid = (Grid)GameObjectManager.Find(name);
            Debug.Assert(this.grid != null);
        }


        /**
         * AnimationSprite Execute Function
         * */
        public override void Execute(float deltaTime)
        {
            if (this.grid.child != null)
            {
                Debug.WriteLine("AnimationGrid Execute Method was called.");
                Debug.Assert(deltaTime > 0);
                Debug.Assert(this.grid != null);
                //   Console.WriteLine("Grid being executed at "+(deltaTime));
                //deltaTime = deltaTime - (deltaTime / this.grid.totalAliens);
                float newDelta;
                if (this.grid.totalAliens > 5)
                {
                    newDelta = (float)(((this.grid.totalAliens) / 100)-(0.01*this.grid.currentLevel));
                }
                else
                {
                    newDelta = .07f;
                }
                this.grid.MoveGrid();
                GameObjectManager.Update();
                TimerManager.Add(TimerEvent.Name.GridAnimation, newDelta, this);
            }
        }
    }
}
