using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class CollisionPairManager:Manager
    {
        private static CollisionPairManager pInstance;
        private CollisionPair refPair;
        private CollisionPair currentPair;
        /**
         * Collision Pair Manager Constructor
         * */
        private CollisionPairManager(int reserveNum, int growthRate):base(reserveNum, growthRate)
        {
            this.refPair = new CollisionPair();
        }


        /**
         * Collision Pair Manager Create Method
         * */
        public static void Create(int reserveNum, int growthRate)
        {
            Debug.Assert(pInstance == null);
            if (pInstance == null)
            {
                pInstance = new CollisionPairManager(reserveNum, growthRate);
            }

        }

        /**
         * Collision Pair Add Method
         * */
        public static CollisionPair Add(CollisionPair.Name colName, GameObject treeA, GameObject treeB)
        {
            Debug.Assert(treeA != null);
            Debug.Assert(treeB != null);

            CollisionPairManager cpm = CollisionPairManager.getInstance();
            CollisionPair cpTemp = (CollisionPair)cpm.baseAdd();

            Debug.Assert(cpTemp != null);

            cpTemp.set(colName, treeA, treeB);
            return cpTemp;
        }

        /**
         * CollisionPairManager Compare Method
         * */
        protected override bool Compare(DLink pLinkA, DLink pLinkB)
        {
            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            Boolean status = false;
            CollisionPair cpA = (CollisionPair)pLinkA;
            CollisionPair cpB = (CollisionPair)pLinkB;
            if (cpA.getName() == cpB.getName())
            {
                status = true;
            }
            return status;
        }

        public static void Process()
        {
            CollisionPairManager cpm = CollisionPairManager.getInstance();
            CollisionPair cp = (CollisionPair)cpm.pActive;

            while (cp != null)
            {
                cpm.currentPair = cp;
                cp.process();

                cp = (CollisionPair)cp.pNext;
            }
        }

        public static CollisionPair getCurrentCollisionPair(){
            CollisionPairManager cpm = CollisionPairManager.getInstance();
            return cpm.currentPair;
        }

        /**
         * CollisionPairManager CreateNode Method
         * */
        protected override DLink CreateNode()
        {
            CollisionPair cp = new CollisionPair();
            return (DLink)cp;
        }

        /**
         * Collision Pair Manager getInstance Method
         * */
        public static CollisionPairManager getInstance()
        {
            return pInstance;
        }
    }
}
