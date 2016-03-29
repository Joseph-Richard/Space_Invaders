using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class DestructionManager
    {
        private static DestructionManager instance;
        private Observer root;
        private DestructionManager()
        {
            this.root = null;
        }

        public static void Create()
        {
            Debug.Assert(instance == null);

            if (instance == null)
            {
                instance = new DestructionManager();
            }
        }

        public static void attachObserver(Observer o)
        {
            Debug.Assert(o != null);

            DestructionManager dm = DestructionManager.getInstance();
            if (dm.root == null)
            {
                dm.root = o;
                dm.root.oNext = null;
                dm.root.oPrev = null;

            }
            else
            {
                dm.root.oPrev = o;
                o.oNext = dm.root;
                o.oPrev = null;
                dm.root = o;
            }

        }


        public static void Process()
        {
            DestructionManager dm = DestructionManager.getInstance();
            Observer node = dm.root;

            while (node != null)
            {
                node.Execute();
                node = (Observer)node.oNext;
            }


            node = dm.root;
            Observer tmp = null;

            while (node != null)
            {
                tmp = node;
                node = (Observer)node.oNext;

                dm.Remove(ref dm.root, tmp);
            }
        }



        private void Remove(ref Observer root, Observer o)
        {
            if (o.oPrev != null)
            {
                o.oPrev.oNext = o.oNext;
            }
            else
            {
                root = (Observer)o.oNext;
            }
            if (o.oNext != null)
            {
                o.oNext.oPrev = o.oPrev;
            }

        }
        public static DestructionManager getInstance()
        {
            if (instance == null)
            {
                instance = new DestructionManager();
            }
            return instance;
        }
    }
}
