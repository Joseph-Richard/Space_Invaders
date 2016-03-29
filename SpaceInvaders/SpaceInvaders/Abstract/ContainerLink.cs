using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    abstract class ContainerLink
    {
        /**
         * Fields
         * */
        public ContainerLink pCNext;
        public ContainerLink pCPrev;
        public ContainerLink.Status status;
        public enum Status
        {
            Uninitialized,
            Active,
            Reserve
        }

        /**
         * ContainerLink Constructor
         * */
        public ContainerLink()
        {
            this.pCNext = null;
            this.pCPrev = null;
            this.status = Status.Uninitialized;
        }

        /**
         * ContainerLink Clear Method
         * */
        public void clear()
        {
            this.pCNext = null;
            this.pCPrev = null;
            this.status = Status.Uninitialized;
        }
    }
}
