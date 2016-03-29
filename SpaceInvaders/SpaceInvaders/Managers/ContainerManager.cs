using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class ContainerManager:Manager
    {
        //DATA--------------------------------------
        private static ContainerManager pInstance;

        //constructor, add, remove, create, compare, createnode, find, getInstance
        
        /**
         * ContainerManager Constructor
         * */
        private ContainerManager(int reserveNum, int growthRate): base(reserveNum,growthRate)
        {

        }

        /**
         * TODO: ContainerManager Add Function
         * */
        
        /**
         * TODO: ContainerManager Remove Function
         * */


        /**
         * TODO: ContainerManager Compare Function 
         * */
        override protected Boolean Compare(DLink pNodeA, DLink pNodeB)
        {
            Debug.Assert(pNodeA != null && pNodeB != null);
            SpriteBox pSBoxA = (SpriteBox)pNodeA;
            SpriteBox pSBoxB = (SpriteBox)pNodeB;
            if (pSBoxA == pSBoxB) return true;
            if (pSBoxA == pSBoxB) return true;
            return false;
        }
        /**
         * TODO: ContainerManager CreateNode Function
         * */
        protected override DLink CreateNode()
        {
            throw new NotImplementedException();
        }
        /**
         * TODO: ContainerManager Find Function
         * */
        

        /**
         * ContainerManager Create Function
        * */
        public static void Create(int reserveNum, int growthRate)
        {
            Debug.Assert(reserveNum > 0 && growthRate > 0);
            Debug.Assert(pInstance == null);
            if (pInstance == null)
            {
                pInstance = new ContainerManager(reserveNum, growthRate);
            }
        }

        public static ContainerManager getInstance(){
            return pInstance;
        }

        protected override bool Sort(DLink pLinkA, DLink pLinkB)
        {
            return false;
        }
    }
}
