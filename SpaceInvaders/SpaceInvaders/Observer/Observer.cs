using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    abstract class Observer:ObsLink
    {
        private CollisionGroup cGroup;
        public abstract void Notify();


        public virtual void Execute()
        {
        }

        public void setGroup(CollisionGroup cg)
        {
            Debug.Assert(cg != null);
            this.cGroup = cg;
        }

        public CollisionGroup getGroup()
        {
            return this.cGroup;
        }
    }
}
