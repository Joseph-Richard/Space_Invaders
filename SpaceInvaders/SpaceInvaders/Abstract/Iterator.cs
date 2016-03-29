using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    abstract class Iterator
    {
        public abstract PCSNode First();
        public abstract PCSNode Next();
        public abstract Boolean isDone();
        public abstract PCSNode CurrentItem();
    }
}
