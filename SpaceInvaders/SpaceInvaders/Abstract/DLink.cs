using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    abstract class DLink
    {

        /**
         * Fields
         * */
        public DLink pNext;
        public DLink pPrev;
        public DLink.Status status;
        public enum Status
        {
            Uninitialized,
            Active,
            Reserve
        }

        /**
         * DLink Constructor
         * */
        public DLink()
        {
            this.pPrev = null;
            this.pNext = null;
            this.status = Status.Uninitialized;
        }

        /**
         * DLink Clear Method
         * */
        public void clear()
        {
            this.pNext = null;
            this.pPrev = null;
            this.status = Status.Uninitialized;  
        }
    }
}
