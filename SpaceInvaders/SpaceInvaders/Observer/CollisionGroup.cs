using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class CollisionGroup
    {
        private Observer root;
        private GameObject ObjA;
        private GameObject ObjB;

        public CollisionGroup()
        {
            this.root = null;
            this.ObjA = null;
            this.ObjB = null;
        }

        public void AttachObserver(Observer o)
        {
            Debug.Assert(o != null);
            o.setGroup(this);

            if (root == null)
            {
                root = o;
                root.oNext = null;
                root.oPrev = null;
            }
            else
            {
                root.oPrev = o;
                o.oNext = root;
                root = o;
            }
        }

        public GameObject getObjA()
        {
            return this.ObjA;
        }

        public GameObject getObjB()
        {
            return this.ObjB;
        }

        public Observer getRootObserver()
        {
            return this.root;
        }

        public void setObjA(GameObject a)
        {
            Debug.Assert(a != null);
            this.ObjA = a; 
        }

        public void setObjB(GameObject b)
        {
            Debug.Assert(b != null);
            this.ObjB = b;
        }


        public void NotifyAll()
        {
            Observer o = this.root;

            while (o != null)
            {
                o.Notify();
                o = (Observer)o.oNext;
            }

        }


    }
}
