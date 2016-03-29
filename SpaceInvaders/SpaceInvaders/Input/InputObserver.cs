using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    abstract class InputObserver:InLink
    {
        public InKey key;
        abstract public void Notify();
        virtual public void Execute()
        {

        }
    }
}
