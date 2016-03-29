using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    abstract class Command
    {

        /**
         * Abstract Methods
         * */
        public Sprite spriteTest;
       
        public abstract void Execute(float executeTime);
    }
}
