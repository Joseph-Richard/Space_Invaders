using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    abstract class ObsLink
    {
        public ObsLink oNext;
        public ObsLink oPrev;
        protected ObsLink()
        {
            this.Initialize();
        }
        protected void Initialize()
        {
            this.oNext = null;
            this.oPrev = null;
        }
    }
}
