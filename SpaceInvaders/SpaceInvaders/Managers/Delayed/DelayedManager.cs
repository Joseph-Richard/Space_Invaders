using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class DelayedManager
    {

         private static DelayedManager instance;
        private Observer root;
        private InputObserver inputRoot;
        private DelayedManager()
        {
            this.root = null;
            this.inputRoot = null;
        }

        public static void Create()
        {
            Debug.Assert(instance == null);

            if (instance == null)
            {
                instance = new DelayedManager();
            }
        }

        public static void attachObserver(Observer o)
        {
            Debug.Assert(o != null);

            DelayedManager dm = DelayedManager.getInstance();
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

        public static void attachObserver(InputObserver o)
        {
            Debug.Assert(o != null);

            DelayedManager dm = DelayedManager.getInstance();
            if (dm.inputRoot == null)
            {
                dm.inputRoot = o;
                dm.inputRoot.iNext = null;
                dm.inputRoot.iPrev = null;

            }
            else
            {
                dm.inputRoot.iPrev = o;
                o.iNext = dm.inputRoot;
                o.iPrev = null;
                dm.inputRoot = o;
            }

        }

        public static void Process()
        {
            DelayedManager dm = DelayedManager.getInstance();
            Observer node = dm.root;
            InputObserver inputNode = dm.inputRoot;
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


            while (inputNode != null)
            {
                inputNode.Execute();
                inputNode = (InputObserver)inputNode.iNext;
            }

            inputNode = dm.inputRoot;
            InputObserver imp = null;

            while (inputNode != null)
            {
                imp = inputNode;
                inputNode = (InputObserver)inputNode.iNext;

                dm.Remove(ref dm.inputRoot, imp);
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

        private void Remove(ref InputObserver root, InputObserver o)
        {
            if (o.iPrev != null)
            {
                o.iPrev.iNext = o.iNext;
            }
            else
            {
                root = (InputObserver)o.iNext;
            }
            if (o.iNext != null)
            {
                o.iNext.iPrev = o.iPrev;
            }
        }

        public static DelayedManager getInstance()
        {
            if (instance == null)
            {
                instance = new DelayedManager();
            }
            return instance;
        }
    }
}

