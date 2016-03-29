using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class InKey
    {
        public InputObserver head;

        /**
         * InKey AttachObserver Method
         * */
        public void attachObserver(InputObserver obs)
        {
            Debug.Assert(obs != null);

            obs.key = this;

            if (head == null)
            {
                head = obs;
                obs.iNext = null;
                obs.iPrev = null;

            }
            else
            {
                obs.iNext = head;
                obs.iPrev = null;
                head.iPrev = obs;
                head = obs;

            }
        }


        /**
         * InKey Notify Method
         * */
        public void Notify()
        {
            InputObserver node = this.head;

            while (node != null)
            {
                node.Notify();
                node = (InputObserver)node.iNext;
            }
        }




    }
}
