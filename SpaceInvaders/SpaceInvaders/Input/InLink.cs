using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    abstract class InLink
    {
        public InLink iNext;
        public InLink iPrev;
        protected InLink()
        {
            this.Initialize();
        }
        protected void Initialize()
        {
            this.iNext = null;
            this.iPrev = null;
        }

    }
}
