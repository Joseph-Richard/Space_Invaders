using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class AnimationBomb:Command
    {
        private Column column;

        public AnimationBomb(Column c)
        {
            this.column = c;
            
        }

        public override void Execute(float executeTime)
        {
            Random rnd = new Random();
            Column column = null;
            while (column == null)
            {
                column = (Column)GameObjectManager.Find(GameObject.Name.Column, rnd.Next(11));
            }

            column.dropBomb();
            TimerManager.Add(TimerEvent.Name.BombDrop, executeTime, this);
            


        }

        
    }
}
